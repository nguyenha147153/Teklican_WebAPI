using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teklican.Application.Products.Common;
using Teklican.Application.Products.Create;
using Teklican.Application.Products.Delete;
using Teklican.Application.Products.GetAll;
using Teklican.Application.Products.GetById;
using Teklican.Application.Products.Update;
using Teklican.Application.Wrapper;
using Teklican.Contracts.Products;

namespace Teklican.API.Controllers
{
    [Route("controller")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public ProductsController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllQuery();

            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdQuery(id);

            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var command = _mapper.Map<CreateProductCommand>(request);

            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
        {
            var command = _mapper.Map<UpdateProductCommand>(request);

            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var command = new DeleteProductCommand(id);

            return Ok(await _mediator.Send(command));
        }

    }
}
