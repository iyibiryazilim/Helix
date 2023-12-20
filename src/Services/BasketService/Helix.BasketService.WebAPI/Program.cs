using Helix.BasketService.Application.Services;
using Helix.BasketService.Infrastructure.Repository;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;

namespace Helix.BasketService.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			// Redis configuration
			builder.Services.AddMemoryCache();
			IConfiguration configuration = builder.Configuration;
			var redis = ConnectionMultiplexer.Connect("redis-19047.c250.eu-central-1-1.ec2.cloud.redislabs.com:19047,password=BX46QsxiatvvorbAhsffv1SJ2zDqPyzD");
			using IHost host = builder.Build();
			IMemoryCache distributedCache = host.Services.GetRequiredService<IMemoryCache>();
			// Add services to the container.
			builder.Services.AddSingleton<IBasketService, BasketDataStore>();
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
