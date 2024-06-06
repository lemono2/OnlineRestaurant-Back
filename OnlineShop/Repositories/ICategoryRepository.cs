using OnlineShop.Entities;

namespace OnlineShop.Repositories
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAll();

		Task<Category> GetCategory(int id);
	}
}
