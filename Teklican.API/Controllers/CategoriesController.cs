using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teklican.Application.Categories.Common;
using Teklican.Application.Categories.Create;
using Teklican.Application.Categories.Delete;
using Teklican.Application.Categories.GetAll;
using Teklican.Application.Categories.GetById;
using Teklican.Application.Categories.Update;
using Teklican.Application.Wrapper;

namespace Teklican.API.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CategoriesController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllQuery();
            var response = await _mediator.Send(query);

            return Ok(new Response<GetAllResult>(response, "Lấy dữ liệu thành công"));
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdQuery(id);

            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(string name)
        {
            var command = new CreateCategoryCommand(name);

            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(int id,string name)
        {
            var command = new UpdateCategoryCommand(id,name);

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand(id);

            return Ok(await _mediator.Send(command));
        }
    }
}
