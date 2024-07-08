using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Products;

namespace Teklican.Application.Products.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, Response<IEnumerable<Product>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Response<IEnumerable<Product>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var query = await _productRepository.GetAllAsync();

            return new Response<IEnumerable<Product>> (query, "Lấy dữ liệu thành công");
        }
    }
}
