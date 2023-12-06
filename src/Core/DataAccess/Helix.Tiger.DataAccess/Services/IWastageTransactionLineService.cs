using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IWastageTransactionLineService 
{
	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesAsync();
	public Task<DataResult<WastageTransactionLine>> GetWastageTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByCurrentCodeAsync(string code);
	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByProductIdAsync(int id);
	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByProductCodeAsync(string code);
	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByFicheIdAsync(int id);
	public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByFicheCodeAsync(string code);
}
