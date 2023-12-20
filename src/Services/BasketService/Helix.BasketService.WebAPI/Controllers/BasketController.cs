using Helix.BasketService.Application.Services;
using Helix.BasketService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.BasketService.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
	IBasketService _basketService;

	public BasketController(IBasketService basketService)
	{
		_basketService = basketService;
	}

	[HttpGet]
	public Task<Basket> GetBasket(string key)
	{
		var result =  _basketService.GetBasket(key);
		return result;
	}

	[HttpPost]
	public Task AddBasket(string key, Basket basket)
	{
		var result = _basketService.AddBasket(key, basket);
		return result;
	}

	[HttpDelete("Delete/Item/Key/{key}")]
	public async Task RemoveBasketAsync([FromBody] string key)
	{
		await _basketService.RemoveBasket(key);
	}

	[HttpDelete("Delete/All")]
	public async Task ClearBasketAsync()
	{
		await _basketService.ClearBasket();
	}
}
