using OnlineShop.Entities;
using OnlineShop.Dtos;
using System.Data.SqlTypes;

namespace OnlineShop.Repositories
{
	public interface IBasketRepository
	{
		Task<IEnumerable<Basket>> GetAll();
		Task<Basket> UpdateBasket(Basket basket);
		Task<Basket> AddToBasket(Basket basket);
		Task<Basket> RemoveFromBasket(Basket basket);
		Task<Basket> GetBasketById(int id);

		Task<Product> GetProductById(int id);
	}
}
