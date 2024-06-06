using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;
using OnlineShop.Entities;
using OnlineShop.Dtos;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet("GetAll")]
		public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
		{
			var categories = await _categoryService.GetAllDto();
			return Ok(categories);
		}

		[HttpGet("GetCategory/{id}")]
		public async Task<ActionResult<CategoryDto>> GetCategory(int id)
		{
			var ctg = await _categoryService.GetCategoryDto(id);
			if (ctg == null)
			{
				return BadRequest("Category not found");
			}
			return Ok(ctg);
		}

	}
}
