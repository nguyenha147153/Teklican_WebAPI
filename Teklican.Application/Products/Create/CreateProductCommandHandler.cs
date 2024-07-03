using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Products.Common;
using Teklican.Domain.Products;

namespace Teklican.Application.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResult>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var product = Product.Create(
                    request.Name,
                    request.Description,
                    request.Amount,
                    request.Sku,
                    request.Status,
                    request.CategoryId,
                    "",0);

            _productRepository.Create(product);

            return new ProductResult(product);
        }
    }
}
