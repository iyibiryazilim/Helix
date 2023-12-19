using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface ITransferTransactionService
{
	Task<DataResult<IEnumerable<TransferTransaction>>> GetObjects(HttpClient httpClient);
	Task<DataResult<TransferTransaction>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<TransferTransaction>> GetObjectByCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<TransferTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<TransferTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
	// insert eklenecek
}
