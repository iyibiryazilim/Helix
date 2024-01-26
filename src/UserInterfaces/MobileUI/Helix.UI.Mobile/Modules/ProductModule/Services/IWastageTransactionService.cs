using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IWastageTransactionService
{
	Task<DataResult<IEnumerable<WastageTransaction>>> GetObjects(HttpClient httpClient);
	Task<DataResult<WastageTransaction>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<WastageTransaction>> GetObjectByCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<WastageTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<WastageTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
	Task<DataResult<WastageTransactionDto>> InsertObject(HttpClient httpClient,WastageTransactionDto wastageTransactionDto);
}
