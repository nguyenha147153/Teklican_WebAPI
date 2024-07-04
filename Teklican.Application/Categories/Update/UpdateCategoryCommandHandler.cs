using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Categories;

namespace Teklican.Application.Categories.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Response<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Response<Category>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(new CategoryId(request.Id));

            if(category is null)
            {
                return new Response<Category>("Id không tồn tại: " + request.Id);
            }
            category.Update(request.Name);
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();

            return new Response<Category>(category,"Cập nhật thành công");
        }
    }
}
