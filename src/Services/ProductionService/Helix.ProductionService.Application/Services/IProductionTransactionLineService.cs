using Helix.ProductionService.Domain.AggregateModels;
using Helix.ProductionService.Domain.Models.BaseModels;

namespace Helix.ProductionService.Application.Services;

public interface IProductionTransactionLineService
{
	public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesAsync();
	public Task<DataResult<ProductionTransactionLine>> GetProductionTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByCurrentCodeAsync(string code);
	public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByProductIdAsync(int id);
	public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByProductCodeAsync(string code);
	public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByFicheIdAsync(int id);
	public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByFicheCodeAsync(string code);
}
