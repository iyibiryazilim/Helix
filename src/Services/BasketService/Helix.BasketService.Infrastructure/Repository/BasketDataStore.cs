using Helix.BasketService.Application.Services;
using Helix.BasketService.Domain.Dtos;
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
	public async Task<bool> AddBasketAsync(string key, Basket basket)
	{
		if(_db.KeyExists(key))
		{
			return false;
		}
		var jsonData = JsonSerializer.Serialize(basket);
		var result = await _db.StringSetAsync(key, jsonData);

		return result;
	}

	public void ClearBasket()
	{
		var server = _connectionMultiplexer.GetServer(_connectionMultiplexer.GetEndPoints()[0]);
		if(server is null)
			return;
		server.Keys(pattern: "*").ToList().ForEach(async key =>await  _db.KeyDeleteAsync(key));
	}

	public async Task<bool> RemoveBasketAsync(string key)
	{
		if (!_db.KeyExists(key))
			return false; 
		var result = await _db.KeyDeleteAsync(key);
		return result;
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
