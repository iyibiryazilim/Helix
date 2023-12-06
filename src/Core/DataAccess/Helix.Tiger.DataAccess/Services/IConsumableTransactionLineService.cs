using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IConsumableTransactionLineService
{
	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesAsync();
	public Task<DataResult<ConsumableTransactionLine>> GetConsumableTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByCurrentCodeAsync(string code);
	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByProductIdAsync(int id);
	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByProductCodeAsync(string code);
	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByFicheIdAsync(int id);
	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByFicheCodeAsync(string code);
}
