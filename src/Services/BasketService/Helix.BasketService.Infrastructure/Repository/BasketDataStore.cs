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
		if(_db.KeyExists(key))
		{
			return Task.CompletedTask; // kaldırılacak
		}
		var jsonData = JsonSerializer.Serialize(basket);
		_db.StringSet(key, jsonData);
		return Task.CompletedTask; // kaldırılacak
	}

	public Task ClearBasket()
	{
		// remove all the keys in db
		var server = _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints()[0]);
		server.Keys(pattern: "*").ToList().ForEach(key => _db.KeyDelete(key));
		return Task.CompletedTask; // kaldırılacak
	}

	public Task RemoveBasket(string key)
	{
		if(!_db.KeyExists(key))
			return Task.CompletedTask; // kaldırılacak
		_db.KeyDelete(key);
		return Task.CompletedTask; // kaldırılacak
	}

	public Task<Basket> GetBasket(string key)
	{
		if(!_db.KeyExists(key))
			return Task.FromResult<Basket>(null);
		var basket = _db.StringGet(key);
		return Task.FromResult(JsonSerializer.Deserialize<Basket>(basket));
	}
}
