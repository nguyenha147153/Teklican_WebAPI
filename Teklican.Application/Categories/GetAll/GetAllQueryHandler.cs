using MediatR;
using Teklican.Application.Categories.Common;
using Teklican.Application.Common.Interfaces.Persistence;

namespace Teklican.Application.Categories.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, GetAllResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<GetAllResult> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAllAsync();

            return new GetAllResult(result);
        }
    }
}
