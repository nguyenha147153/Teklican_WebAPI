using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teklican.Application.Carts.AddItem;
using Teklican.Application.Carts.GetAll;
using Teklican.Application.Carts.RemoveItem;

namespace Teklican.API.Controllers
{
    [Route("cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CartController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll(Guid accountId)
        {
            var query = new GetAllQuery(accountId);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        [Route("additem")]  
        public async Task<IActionResult> AddItem(AddItemCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        [Route("removeitem")]
        public async Task<IActionResult> RemoveItem(RemoveItemCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
