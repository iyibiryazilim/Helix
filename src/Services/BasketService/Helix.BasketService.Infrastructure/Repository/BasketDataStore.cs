using Helix.BasketService.Application.Services;
using Helix.BasketService.Domain.Models;
using Helix.BasketService.Infrastructure.BaseRepository;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Diagnostics;
using System.Text.Json;

namespace Helix.BasketService.Infrastructure.Repository;

public class BasketDataStore : BaseDataStore, IBasketService
{
	IConnectionMultiplexer _connectionMultiplexer;
	IDatabase _db;
	const string basketKey = "basket";

	public BasketDataStore(IConfiguration configuration,IConnectionMultiplexer connectionMultiplexer) : base(configuration)
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

	public async Task<DataResult<IEnumerable<Basket>>> GetBasketAsync(string key)
	{
		if(!_db.KeyExists(key))
			return null;
		var basket = await _db.StringGetAsync(key);
		var result = JsonSerializer.Deserialize<DataResult<IEnumerable<Basket>>>(basket);
		return result;
	}
}
