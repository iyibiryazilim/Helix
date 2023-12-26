using Helix.BasketService.Domain.Models;

namespace Helix.BasketService.Application.Services;

public interface IBasketService
{
	public Task<DataResult<IEnumerable<Basket>>> GetBasketAsync(string key);
	public Task<bool> AddBasketAsync(string key, Basket basket);
	public Task<bool> RemoveBasketAsync(string key);
	public void ClearBasket();
}
