using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class ConsumableTransactionLineDataStore : BaseDataStore,IConsumableTransactionLineService
{
	public ConsumableTransactionLineDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<ConsumableTransactionLine>> GetConsumableTransactionLineByIdAsync(int id)
	{
		var result = new SqlQueryHelper<ConsumableTransactionLine>().GetObjectAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesAsync()
	{
		var result = new SqlQueryHelper<ConsumableTransactionLine>().GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<ConsumableTransactionLine>().GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<ConsumableTransactionLine>().GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByFicheCodeAsync(string code)
	{
		var result = new SqlQueryHelper<ConsumableTransactionLine>().GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByFicheIdAsync(int id)
	{
		var result = new SqlQueryHelper<ConsumableTransactionLine>().GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByProductCodeAsync(string code)
	{
		var result = new SqlQueryHelper<ConsumableTransactionLine>().GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByProductIdAsync(int id)
	{
		var result = new SqlQueryHelper<ConsumableTransactionLine>().GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
		return result;
	}
}
