using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teklican.Application.Products.Common;
using Teklican.Application.Products.Create;
using Teklican.Application.Wrapper;
using Teklican.Contracts.Products;

namespace Teklican.API.Controllers
{
    [Route("api/[controller]")]
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
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
            var command = _mapper.Map<CreateProductCommand>(request);
            ProductResult result = await _mediator.Send(command);
            var response = _mapper.Map<ProductResponse>(result);
            return Ok(new ResponseException<ProductResponse>(response,"Thêm thành công"));
        }
    }
}
