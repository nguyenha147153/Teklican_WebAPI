using MediatR;
using System.Net.WebSockets;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Categories;

namespace Teklican.Application.Categories.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Response<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Response<Category>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(new CategoryId(request.Id));
            if (category is null) 
            {
                return new Response<Category>("Id không tồn tại: " + request.Id);
            }

            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();
            return new Response<Category>(category, "Xóa thành công");
        }
    }
}
