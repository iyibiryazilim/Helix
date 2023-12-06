using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface ITransferTransactionLineService
{
	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesAsync();
	public Task<DataResult<TransferTransactionLine>> GetTransferTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByCurrentCodeAsync(string code);
	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByProductIdAsync(int id);
	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByProductCodeAsync(string code);
	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByFicheIdAsync(int id);
	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByFicheCodeAsync(string code);
}
