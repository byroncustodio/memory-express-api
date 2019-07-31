using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MemoryExpress.Core.Interfaces;
using MemoryExpress.Core.Services;

namespace MemoryExpress.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllProducts();

            return Ok(products);
        }
    }
}