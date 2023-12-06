using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class InCountingTransactionLineDataStore : BaseDataStore,IInCountingTransactionLineService
{
	public InCountingTransactionLineDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<InCountingTransactionLine>> GetInCountingTransactionLineByIdAsync(int id)
	{
		var result = new SqlQueryHelper<InCountingTransactionLine>().GetObjectAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesAsync()
	{
		var result = new SqlQueryHelper<InCountingTransactionLine>().GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<InCountingTransactionLine>().GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<InCountingTransactionLine>().GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByFicheCodeAsync(string code)
	{
		var result = new SqlQueryHelper<InCountingTransactionLine>().GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByFicheIdAsync(int id)
	{
		var result = new SqlQueryHelper<InCountingTransactionLine>().GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByProductCodeAsync(string code)
	{
		var result = new SqlQueryHelper<InCountingTransactionLine>().GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<InCountingTransactionLine>>> GetInCountingTransactionLinesByProductIdAsync(int id)
	{
		var result = new SqlQueryHelper<InCountingTransactionLine>().GetObjectsAsync(new InCountingTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
		return result;
	}
}
