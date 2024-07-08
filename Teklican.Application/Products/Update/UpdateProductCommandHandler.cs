using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Categories;
using Teklican.Domain.Products;
using Teklican.Domain.Products.ValueObjects;

namespace Teklican.Application.Products.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<Product>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateProductCommandHandler(
            IProductRepository productRepository, 
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<Response<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(new ProductId(request.Id));
            
            if(product is null) 
            {
                return new Response<Product>("Id sản phẩm không tồn tại: " + request.Id);
            }

            var category = await _categoryRepository.GetByIdAsync(new CategoryId(request.CategoryId));
            if (category is null)
            {
                return new Response<Product>("Id loại không tồn tại: " + request.CategoryId);
            }

            try
            {
                product.Update(
                   request.Name,
                   request.Description,
                   new Money(request.Current, request.Amount),
                   Sku.Create(request.Sku)!,
                   request.Status,
                   new CategoryId(request.CategoryId));

                _productRepository.Update(product);
                await _productRepository.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {

            }

            return new Response<Product>(product, "Cập nhật thành công");
        }
    }
}
