using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface ITransferTransactionLineService
{
	Task<DataResult<IEnumerable<TransferTransactionLine>>> GetObjects(HttpClient httpClient);
	Task<DataResult<TransferTransactionLine>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<TransferTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<TransferTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<TransferTransactionLine>>> GetObjectsByProductId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<TransferTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<TransferTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<TransferTransactionLine>>> GetObjectsByFicheCode(HttpClient httpClient, string code);
}
