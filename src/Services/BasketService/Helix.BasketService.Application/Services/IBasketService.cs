using Helix.BasketService.Domain.Models;

namespace Helix.BasketService.Application.Services;

public interface IBasketService
{
	public Task<DataResult<IEnumerable<Basket>>> GetBasketAsync(string key);
	public Task AddBasket(string key, Basket basket);
	public Task RemoveBasket(string key);
	public Task ClearBasket();
}
