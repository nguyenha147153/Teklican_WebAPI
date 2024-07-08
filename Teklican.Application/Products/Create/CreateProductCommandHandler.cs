using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Products.Common;
using Teklican.Application.Wrapper;
using Teklican.Domain.Categories;
using Teklican.Domain.Products;
using Teklican.Domain.Products.ValueObjects;

namespace Teklican.Application.Products.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<Product>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Response<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(new CategoryId(request.CategoryId));
            if (category is null)
            {
                return new Response<Product>("Id loại không tồn tại: " + request.CategoryId);
            }

            var product = Product.Create(
                    request.Name,
                    request.Description,
                    new Money(request.Current,request.Amount),
                    Sku.Create(request.Sku)!,
                    request.Status,
                    new CategoryId(request.CategoryId));

            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync(cancellationToken);

            return new Response<Product>(product,"Thêm thành công");
        }
    }
}
