using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineShop.Entities;
using OnlineShop.Repositories;
using OnlineShop.Services;


namespace OnlineShop
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<OnlineRestaurantContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<IProductService, ProductService>();

			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();

			builder.Services.AddScoped<IBasketRepository, BasketRepository>();
			builder.Services.AddScoped<IBasketService, BasketService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

				app.UseSwagger();
				app.UseSwaggerUI();
			

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
