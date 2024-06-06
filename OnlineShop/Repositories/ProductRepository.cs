using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;

namespace OnlineShop.Repositories
{
	public class ProductRepository : IProductRepository
	{
		readonly OnlineRestaurantContext _context;
		public ProductRepository(OnlineRestaurantContext context) 
		{
			_context = context;	
		}

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await _context.Products.ToListAsync();
		}
	}
}
