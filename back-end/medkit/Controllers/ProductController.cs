using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace medkit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await productService.GetProductByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("code")]
        public async Task<IActionResult> GetProductByCode(string code)
        {
            var result = await productService.GetProductByCodeAsync(code);
            if (result == null)
                return BadRequest();
            if (result.User.Count < 5)
                return Ok("true");
            else
                return Ok("false");
        }
    }
}
