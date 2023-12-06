using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class TransferTransactionLineDataStore : BaseDataStore,ITransferTransactionLineService
{
	public TransferTransactionLineDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<TransferTransactionLine>> GetTransferTransactionLineByIdAsync(int id)
	{
		var result = new SqlQueryHelper<TransferTransactionLine>().GetObjectAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesAsync()
	{
		var result = new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByFicheCodeAsync(string code)
	{
		var result = new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByFicheIdAsync(int id)
	{
		var result = new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByProductCodeAsync(string code)
	{
		var result = new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<TransferTransactionLine>>> GetTransferTransactionLinesByProductIdAsync(int id)
	{
		var result = new SqlQueryHelper<TransferTransactionLine>().GetObjectsAsync(new TransferTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
		return result;
	}
}
