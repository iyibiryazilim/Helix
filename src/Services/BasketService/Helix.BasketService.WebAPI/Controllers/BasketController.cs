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

	[HttpDelete]
	public async Task<IActionResult> ClearBasket()
	{
		await _basketService.ClearBasket();
		return Ok();
	}

	[HttpPost]
	public async Task<IActionResult> AddBasket(Basket basket)
	{
		await _basketService.AddBasket(basket);
		return Ok();
	}


}
