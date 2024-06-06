using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Entities;
using OnlineShop.Services;
using OnlineShop.Dtos;

namespace OnlineShop.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
		{
			var products = await _productService.GetAllDto();
			//products = (IEnumerable<Product>)_productService.productToDto();
			return Ok(products);
		}

		[HttpGet("GetFiltered")]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetFiltered(bool? isVegetarian, bool? hasNuts, int? spiciness, int? categoryId)
		{
			var products = await _productService.GetFilteredDto(isVegetarian, hasNuts, spiciness, categoryId);
			if (spiciness > 4 || spiciness < 0)
			{
				return BadRequest();
			}
			
			return Ok(products);
		}
	}
}
