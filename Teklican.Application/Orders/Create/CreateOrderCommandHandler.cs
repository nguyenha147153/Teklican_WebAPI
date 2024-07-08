using MediatR;
using Microsoft.Extensions.Hosting;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Accounts;
using Teklican.Domain.Orders;
using Teklican.Domain.Orders.Entities;
using Teklican.Domain.Products;
using Teklican.Domain.Products.ValueObjects;

namespace Teklican.Application.Orders.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<Order>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILineItemsRepository _lineItemsRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            ILineItemsRepository lineItemsRepository,
            IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _lineItemsRepository = lineItemsRepository;
            _productRepository = productRepository;
        }
        public async Task<Response<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var listItem = request.LineItems.ToList();
            List<Guid> invalidProductIds = new List<Guid>();

            foreach (var item in listItem)
            {
                var product = await _productRepository.GetByIdAsync(new ProductId(item.ProductId));
                if(product is null) 
                {
                    invalidProductIds.Add(item.ProductId);
                }
            }

            if(invalidProductIds.Count > 0)
            {
                var error = $"Mã sản phẩm không tồn tại: {string.Join(", ", invalidProductIds)}";
                return new Response<Order>()
                {
                    Errors = new List<string> { error }
                };
            }

            var order = Order.Create(new AccountId(request.AccountId));

            foreach (var item in listItem)
            {
                var product = await _productRepository.GetByIdAsync(new ProductId(item.ProductId));
                var lineItem = LineItem.Create(order.Id, product!.Id, new Money(item.Currency,item.Amount),item.Quantity,item.SubTotal);
                _lineItemsRepository.Insert(lineItem);
            }

            _orderRepository.Insert(order);
            await _orderRepository.SaveChangesAsync(cancellationToken);

            return new Response<Order>(order, "Thêm đơn hàng thành công");
        }
    }
}
