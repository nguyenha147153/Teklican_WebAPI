using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Products.Common;
using Teklican.Domain.Categories;
using Teklican.Domain.Products;
using Teklican.Domain.Products.ValueObjects;

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
            var product = Product.Create(
                    request.Name,
                    request.Description,
                    new Money(request.Current,request.Amount),
                    Sku.Create(request.Sku)!,
                    request.Status,
                    new CategoryId(request.CategoryId));

            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();

            return new ProductResult(product);
        }
    }
}
