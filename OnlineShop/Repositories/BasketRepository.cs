using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OnlineShop.Repositories
{
	public class BasketRepository : IBasketRepository
	{
		private readonly OnlineRestaurantContext _context;

		public BasketRepository(OnlineRestaurantContext context)
		{
			_context = context;
		}

		public async Task<Product> GetProductById(int id)
		{
			return await _context.Products.FirstOrDefaultAsync(b => b.ProductId == id);
		}

		//ADD to basket
		public async Task<Basket> AddToBasket(Basket basket)
		{
			_context.Baskets.Add(basket);
			await _context.SaveChangesAsync();
			return basket;
		}

		//GETALL 
		public async Task<IEnumerable<Basket>> GetAll()
		{
			return await _context.Baskets.Include(b => b.Product).ToListAsync();
		}

		public async Task<Basket> GetBasketById(int id)
		{
			return await _context.Baskets.FirstOrDefaultAsync(b => b.ProductId == id);
			//var basket = await _context.Baskets.FirstOrDefaultAsync(b => b.ProductId == id);
			//return basket ?? new Basket();
		}



		//DELETE PPRODUCT from basket 
		public async Task<Basket> RemoveFromBasket(Basket basket)
		{
			_context.Baskets.Remove(basket);
			await _context.SaveChangesAsync();
			return basket;
		}

		//UPDATE basket
		public async Task<Basket> UpdateBasket(Basket basket)
		{
			_context.Baskets.Update(basket);
			await _context.SaveChangesAsync();
			return basket;
		}
	}
}
