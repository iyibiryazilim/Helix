using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IInCountingTransactionLineService
{
	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesAsync();
	public Task<DataResult<InCountingTransactionLine>> GetInCountingTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByCurrentCodeAsync(string code);
	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByProductIdAsync(int id);
	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByProductCodeAsync(string code);
	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByFicheIdAsync(int id);
	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByFicheCodeAsync(string code);
}
