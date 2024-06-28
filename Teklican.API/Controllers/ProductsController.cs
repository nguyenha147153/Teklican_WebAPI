using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teklican.Contracts.Products;

namespace Teklican.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public IActionResult CreateProduct(CreateProductRequest request)
        {
            return Ok(request);
        }
    }
}
