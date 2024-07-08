using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Products;

namespace Teklican.Application.Products.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<Product>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Response<Product>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(new ProductId(request.Id));
            if(product is null) 
            {
                return new Response<Product>("Id sản phẩm không tồn tại: " + request.Id);
            }

            _productRepository.Delete(product);
            await _productRepository.SaveChangesAsync(cancellationToken);

            return new Response<Product>(product, "Xóa thành công");
        }
    }
}
