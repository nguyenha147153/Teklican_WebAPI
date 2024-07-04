using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Categories;

namespace Teklican.Application.Categories.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Response<Category>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetByIdAsync(new CategoryId(request.Id));

            if (result == null)
            {
                return new Response<Category>("Không có dữ liệu hợp lệ");
            }

            return new Response<Category>(result, "Lấy dữ liệu thành công");
        }
    }
}
