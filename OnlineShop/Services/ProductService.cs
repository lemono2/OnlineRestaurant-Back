using OnlineShop.Entities;
using OnlineShop.Repositories;
using OnlineShop.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnlineShop.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		public ProductService(IProductRepository productRepository) 
		{
			_productRepository = productRepository;
		}

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await _productRepository.GetAll();
		}

		public async Task<IEnumerable<ProductDto>> GetAllDto()
		{
			var products = await _productRepository.GetAll();
			var productDtos = products.Select(p => new ProductDto
			{
				ProductId = p.ProductId,
				ProductName = p.ProductName,
				ProductPrice = p.ProductPrice,
				HasNuts = p.HasNuts,
				ProductImage = p.ProductImage,
				IsVegetarian = p.IsVegetarian,
				Spiciness = p.Spiciness,
				CategoryId = p.CategoryId
			}).ToList();

			return productDtos;
		}

		public async Task<IEnumerable<Product>> GetFiltered(bool? isVegetarian, bool? hasNuts, int? spiciness, int? categoryId)
		{

			var filter = await _productRepository.GetAll();
			if (isVegetarian != null)
			{
				filter = filter.Where(p => p.IsVegetarian == isVegetarian.Value);
			}
			if (hasNuts != null)
			{
				filter = filter.Where(p => p.HasNuts == hasNuts.Value);
			}
			if (spiciness != null)
			{
				filter = filter.Where(p => p.Spiciness == spiciness.Value);
			}
			if (categoryId != null)
			{
				filter = filter.Where(p => p.CategoryId == categoryId.Value);
			}
			return filter;
		}

		public async Task<IEnumerable<ProductDto>> GetFilteredDto(bool? isVegetarian, bool? hasNuts, int? spiciness, int? categoryId)
		{
			var products = await GetFiltered(isVegetarian, hasNuts, spiciness, categoryId);
			var productDtos = products.Select(p => new ProductDto
			{
				ProductId = p.ProductId,
				ProductName = p.ProductName,
				ProductPrice = p.ProductPrice,
				HasNuts = p.HasNuts,
				ProductImage = p.ProductImage,
				IsVegetarian = p.IsVegetarian,
				Spiciness = p.Spiciness,
				CategoryId = p.CategoryId
			}).ToList();

			return productDtos;

		}


	}
}
