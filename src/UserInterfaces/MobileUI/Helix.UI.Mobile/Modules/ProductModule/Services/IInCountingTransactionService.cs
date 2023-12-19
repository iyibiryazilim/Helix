using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IInCountingTransactionService
{
	Task<DataResult<IEnumerable<InCountingTransaction>>> GetObjects(HttpClient httpClient);
	Task<DataResult<InCountingTransaction>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<InCountingTransaction>> GetObjectByCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<InCountingTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<InCountingTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
	// insert eklenecek
}
