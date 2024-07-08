using MediatR;
using System.Net.WebSockets;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Products;

namespace Teklican.Application.Products.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Response<Product>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(new ProductId(request.Id));

            if(product is null)
            {
                return new Response<Product>("Id không tồn tại: " + request.Id);
            }

            return new Response<Product>(product,"Lấy dữ liệu thành công");
        }
    }
}
