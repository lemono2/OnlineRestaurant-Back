using OnlineShop.Dtos;
using OnlineShop.Entities;

namespace OnlineShop.Services
{
	public interface ICategoryService
	{
		Task<IEnumerable<Category>> GetAll();
		Task<IEnumerable<CategoryDto>> GetAllDto();

		Task<Category> GetCategory(int id);
		Task<CategoryDto> GetCategoryDto(int id);
	}
}
