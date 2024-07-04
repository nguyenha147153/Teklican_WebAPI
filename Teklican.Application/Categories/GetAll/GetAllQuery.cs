using MediatR;
using Teklican.Application.Categories.Common;

namespace Teklican.Application.Categories.GetAll
{
    public record GetAllQuery() : IRequest<GetAllResult>;
}
