using OnlineShop.Repositories;
using OnlineShop.Entities;
using OnlineShop.Dtos;

namespace OnlineShop.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<IEnumerable<Category>> GetAll()
		{
			return await _categoryRepository.GetAll();
		}

		public async Task<IEnumerable<CategoryDto>> GetAllDto()
		{
			var categories = await _categoryRepository.GetAll();
			var categoryDtos = categories.Select(p => new CategoryDto
			{
				CategoryId = p.CategoryId,
				CategoryName = p.CategoryName
			}).ToList();

			return categoryDtos;
		}

		public async Task<Category> GetCategory(int id)
		{
			return await _categoryRepository.GetCategory(id);
		}

		public async Task<CategoryDto> GetCategoryDto(int _id)
		{
			var category = await _categoryRepository.GetCategory(_id);
			var categoryDto = new CategoryDto();
			categoryDto.CategoryId = category.CategoryId;
			categoryDto.CategoryName = category.CategoryName;

			return categoryDto;
		}

	}
}
