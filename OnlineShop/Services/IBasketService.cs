using OnlineShop.Dtos;
using OnlineShop.Entities;

namespace OnlineShop.Services
{
	public interface IBasketService
	{
		Task<IEnumerable<Basket>> GetAll();
		Task<Basket> UpdateBasket(Basket basket);
		Task<Basket> AddToBasket(Basket basket);
		Task<Basket> RemoveFromBasket(int id);
		Task<Basket> GetBasketById(int id);

		Task<Product> GetProductById(int id);
	}
}
