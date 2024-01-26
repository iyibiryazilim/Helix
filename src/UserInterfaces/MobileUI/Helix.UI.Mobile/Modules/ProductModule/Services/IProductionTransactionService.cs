using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IProductionTransactionService
{
	Task<DataResult<IEnumerable<ProductionTransaction>>> GetObjects(HttpClient httpClient);
	Task<DataResult<ProductionTransaction>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<ProductionTransaction>> GetObjectByCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<ProductionTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<ProductionTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
    Task<DataResult<ProductionTransactionDto>> InsertObject(HttpClient httpClient, ProductionTransactionDto productionTransactionDto);

}
