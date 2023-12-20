using Helix.BasketService.Domain.Models;

namespace Helix.BasketService.Application.Services;

public interface IBasketService
{
	Task<Basket> GetBasket(string key);
	Task AddBasket(string key, Basket basket);
	Task RemoveBasket(string key);
	Task ClearBasket();
}
