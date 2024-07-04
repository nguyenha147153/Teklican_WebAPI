using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Categories;

namespace Teklican.Application.Categories.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Response<Category>>
    {
        private readonly ICategoryRepository _categoryRepository = null!;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public CreateCategoryCommandHandler()
        {
            
        }
        public async Task<Response<Category>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = Category.Create(request.Name);
                _categoryRepository.Add(category);
                await _categoryRepository.SaveChangesAsync();

                return new Response<Category>("Thêm thành công");
            }
            catch
            {
                return new Response<Category>("Thêm thất bại");
            }
        }
    }
}
