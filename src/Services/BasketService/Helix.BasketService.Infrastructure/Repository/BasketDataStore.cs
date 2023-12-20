using Helix.BasketService.Application.Services;
using Helix.BasketService.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System.Diagnostics;
using System.Text.Json;

namespace Helix.BasketService.Infrastructure.Repository;

public class BasketDataStore : IBasketService
{
	private readonly MemoryCache _memoryCache;
	private readonly IConnectionMultiplexer _connectionMultiplexer;
	private readonly IDatabase _db;
	const string basketKey = "basket";

	public BasketDataStore(MemoryCache memoryCache, IConnectionMultiplexer connectionMultiplexer)
	{
		_memoryCache = memoryCache;
		_connectionMultiplexer = connectionMultiplexer;
		_db = _connectionMultiplexer.GetDatabase();
	}
	public Task AddBasket(Basket basket)
	{
		_memoryCache.Set(basketKey, JsonSerializer.Serialize(basket));
		return Task.CompletedTask; // kaldırılacak
	}

	public Task ClearBasket()
	{
		_memoryCache.Clear();
		return Task.CompletedTask; // kaldırılacak
	}

	public Task RemoveBasket(string key)
	{
		_memoryCache.Remove(key);
		return Task.CompletedTask; // kaldırılacak
	}
}
