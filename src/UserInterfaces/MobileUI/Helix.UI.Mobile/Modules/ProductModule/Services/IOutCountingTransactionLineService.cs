using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IOutCountingTransactionLineService
{
	Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetObjects(HttpClient httpClient);
	Task<DataResult<OutCountingTransactionLine>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetObjectsByProductId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetObjectsByFicheCode(HttpClient httpClient, string code);
}
