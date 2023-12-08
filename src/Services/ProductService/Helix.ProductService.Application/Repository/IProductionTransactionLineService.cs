using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository;
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
