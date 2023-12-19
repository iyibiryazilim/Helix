using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IConsumableTransactionService
{
	Task<DataResult<IEnumerable<ConsumableTransaction>>> GetObjects(HttpClient httpClient);
	Task<DataResult<ConsumableTransaction>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<ConsumableTransaction>> GetObjectByCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<ConsumableTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<ConsumableTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
	// insert eklenecek

}
