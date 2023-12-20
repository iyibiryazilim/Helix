using Helix.BasketService.Application.Services;
using Helix.BasketService.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System.Diagnostics;
using System.Text.Json;

namespace Helix.BasketService.Infrastructure.Repository;

public class BasketDataStore : IBasketService
{
	IConnectionMultiplexer _connectionMultiplexer;
	IDatabase _db;
	const string basketKey = "basket";

	public BasketDataStore(IConnectionMultiplexer connectionMultiplexer)
	{
		_connectionMultiplexer = connectionMultiplexer;
		_db = _connectionMultiplexer.GetDatabase();
	}
	public Task AddBasket(string key,Basket basket)
	{
		var jsonData = JsonSerializer.Serialize(basket);
		_db.StringSet(key, jsonData);
		return Task.CompletedTask; // kaldırılacak
	}

	public Task ClearBasket()
	{
		
		return Task.CompletedTask; // kaldırılacak
	}

	public Task RemoveBasket(string key, Basket basket)
	{
		var jsonData = JsonSerializer.Serialize(basket);
		_db.SetRemove(key, jsonData);
		return Task.CompletedTask; // kaldırılacak
	}

	public Task<Basket> GetBasket(string key)
	{
		var basket = _db.StringGet(key);
		return Task.FromResult(JsonSerializer.Deserialize<Basket>(basket));
	}
}
