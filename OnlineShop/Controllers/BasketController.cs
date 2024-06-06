using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Dtos;
using OnlineShop.Entities;
using OnlineShop.Services;

namespace OnlineShop.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketController : ControllerBase
	{
		private readonly IBasketService _basketService;

		public BasketController(IBasketService basketService)
		{
			_basketService = basketService;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IEnumerable<Basket>>> GetAll()
		{
			return Ok(await _basketService.GetAll());
		}

		

		[HttpPost("AddToBasket")]
		public async Task<ActionResult<Basket>> AddToBasket(BasketDto basket)
		{
			var _basket = new Basket();
			_basket.ProductId = basket.ProductId;
			_basket.Quantity = basket.Quantity;
			_basket.Product = await _basketService.GetProductById(_basket.ProductId);
			_basket.Price = _basket.Product.ProductPrice * _basket.Quantity;

			return Ok(await _basketService.AddToBasket(_basket));
		}

		[HttpPut("UpdateBasket")]
		public async Task<ActionResult<Basket>> UpdateBasket(BasketDto basket)
		{
			var _basket = new Basket();
			_basket.ProductId = basket.ProductId;
			_basket.Quantity = basket.Quantity;
			_basket.Product = await _basketService.GetProductById(_basket.ProductId);
			_basket.Price = _basket.Product.ProductPrice * _basket.Quantity;
			return Ok(await _basketService.UpdateBasket(_basket));
		}


		[HttpDelete("DeleteProduct/{id}")]
		public async Task<ActionResult<Basket>> RemoveFromBasket(int id)
		{
			var delete = await _basketService.RemoveFromBasket(id);
			if (delete == null) {
				return BadRequest();
			}
			return Ok(delete);
		}

	}
}
