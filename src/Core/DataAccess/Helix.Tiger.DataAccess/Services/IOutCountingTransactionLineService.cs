using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IOutCountingTransactionLineService
{
	public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesAsync();
	public Task<DataResult<OutCountingTransactionLine>> GetOutCountingTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByCurrentCodeAsync(string code);
	public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByProductIdAsync(int id);
	public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByProductCodeAsync(string code);
	public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByFicheIdAsync(int id);
	public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByFicheCodeAsync(string code);
}
