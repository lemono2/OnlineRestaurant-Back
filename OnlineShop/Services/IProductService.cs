using OnlineShop.Entities;
using OnlineShop.Dtos;

namespace OnlineShop.Services
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetAll();

		Task<IEnumerable<Product>> GetFiltered(bool? isVegetarian, bool? hasNuts, int? spiciness, int? categoryId);

		Task<IEnumerable<ProductDto>> GetAllDto();
		Task<IEnumerable<ProductDto>> GetFilteredDto(bool? isVegetarian, bool? hasNuts, int? spiciness, int? categoryId);
	}
}
