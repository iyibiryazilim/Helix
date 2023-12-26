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
	public async Task<DataResult<IEnumerable<Basket>>> GetBasketAsync(string key)
	{
		var result = await _basketService.GetBasketAsync(key);
		return result;
	}

	[HttpPost]
	public async Task<bool> AddBasketAsync(string key, [FromBody] Basket basket)
	{
		var result = await _basketService.AddBasketAsync(key, basket);
		return result;
	}

	[HttpDelete]
	public async Task<bool> RemoveBasketAsync([FromBody] string key)
	{
		var result = await _basketService.RemoveBasketAsync(key);
		return result;
	}

	[HttpDelete("Clear")]
	public void ClearBasket()
	{
		_basketService.ClearBasket();
	}
}
