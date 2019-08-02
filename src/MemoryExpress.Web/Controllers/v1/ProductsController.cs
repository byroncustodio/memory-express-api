using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoryExpress.Core.Entities;
using MemoryExpress.Core.Interfaces;

namespace MemoryExpress.Web.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = nameof(GetAllProducts))]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200 )]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            return Ok(products);
        }
    }
}