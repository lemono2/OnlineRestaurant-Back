using OnlineShop.Entities;

namespace OnlineShop.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAll();
	}
}
