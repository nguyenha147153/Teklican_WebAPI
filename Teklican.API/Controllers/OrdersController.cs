using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teklican.Application.Orders.Create;
using Teklican.Application.Orders.GetAll;
using Teklican.Application.Orders.GetOrderById;

namespace Teklican.API.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public OrdersController(ISender mediator, IMapper mapper)
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

            return Ok(response);
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetOrderByIdQuery(id);
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CreateOrderCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
