using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IRetailSalesDispatchTransactionLineService
{
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesAsync();
	public Task<DataResult<RetailSalesDispatchTransactionLine>> GetRetailSalesDispatchTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(string code);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByProductIdAsync(int id);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByProductCodeAsync(string code);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByFicheIdAsync(int id);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(string code);
}
