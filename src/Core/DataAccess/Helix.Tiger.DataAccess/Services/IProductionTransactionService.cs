using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IProductionTransactionService
{
	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsAsync();
	public Task<DataResult<ProductionTransaction>> GetProductionTransactionByIdAsync(int id);
	public Task<DataResult<ProductionTransaction>> GetProductionTransactionByCode(string code);
	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentCodeAsync(string code);
}
