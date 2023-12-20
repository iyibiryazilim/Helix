using Helix.BasketService.Domain.Models;

namespace Helix.BasketService.Application.Services;

public interface IBasketService
{
	public Task AddBasket(Basket basket);
	public Task RemoveBasket(string key);
	public Task ClearBasket();
}
