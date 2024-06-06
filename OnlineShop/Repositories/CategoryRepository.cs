using OnlineShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;

namespace OnlineShop.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly OnlineRestaurantContext _context;

		public CategoryRepository(OnlineRestaurantContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Category>> GetAll()
		{
			//var categories = await _context.Categories.Include(c => c.Products).ToListAsync();
			//return categories;
			return await _context.Categories.ToListAsync();

		}

		public async Task<Category> GetCategory(int id)
		{
			var ctg = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
			//if (ctg == null)
			//{
			//	return BadRequest("User not found");
			//}
			return ctg;
		}
	}
}
