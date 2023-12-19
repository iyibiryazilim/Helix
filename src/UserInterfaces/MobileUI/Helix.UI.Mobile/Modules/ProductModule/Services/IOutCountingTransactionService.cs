using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IOutCountingTransactionService
{
	Task<DataResult<IEnumerable<OutCountingTransaction>>> GetObjects(HttpClient httpClient);
	Task<DataResult<OutCountingTransaction>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<OutCountingTransaction>> GetObjectByCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<OutCountingTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<OutCountingTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
	// insert eklenecek
}
