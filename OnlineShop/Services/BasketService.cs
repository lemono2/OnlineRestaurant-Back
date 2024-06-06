using Microsoft.EntityFrameworkCore;
using OnlineShop.Dtos;
using OnlineShop.Entities;
using OnlineShop.Repositories;

namespace OnlineShop.Services
{
	public class BasketService : IBasketService
	{
		private readonly IBasketRepository _basketRepository;

		public BasketService(IBasketRepository basketRepository)
		{
			_basketRepository = basketRepository;
		}

		//GETALL 
		public async Task<IEnumerable<Basket>> GetAll()
		{
			return await _basketRepository.GetAll();
		}

		//ADD to basket
		public async Task<Basket> AddToBasket(Basket basket)
		{
			return await _basketRepository.AddToBasket(basket);
		}

		//UPDATE basket
		public async Task<Basket> UpdateBasket(Basket  basket)
		{
			return await _basketRepository.UpdateBasket(basket);
		}


		//DELETE PPRODUCT from basket 
		public async Task<Basket> RemoveFromBasket(int id)
		{
			var basketToDelete = await _basketRepository.GetBasketById(id);
			return await _basketRepository.RemoveFromBasket(basketToDelete);
		}

		public async Task<Basket> GetBasketById(int id)
		{
			return await _basketRepository.GetBasketById(id);
		}

		public async Task<Product> GetProductById(int id)
		{
			return await _basketRepository.GetProductById(id);
		}
	}
}
