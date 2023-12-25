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
	public async Task<DataResult<IEnumerable<Basket>>> GetBasket(string key)
	{
		var result = await _basketService.GetBasketAsync(key);
		return result;
	}

	[HttpPost]
	public Task AddBasket(string key, Basket basket)
	{
		var result = _basketService.AddBasket(key, basket);
		return result;
	}

	[HttpDelete]
	public async Task RemoveBasketAsync([FromBody] string key)
	{
		await _basketService.RemoveBasket(key);
	}

	[HttpDelete("All")]
	public async Task ClearBasketAsync()
	{
		await _basketService.ClearBasket();
	}
}
