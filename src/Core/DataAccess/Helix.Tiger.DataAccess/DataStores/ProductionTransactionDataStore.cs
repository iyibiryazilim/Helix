using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class ProductionTransactionDataStore : BaseDataStore,IProductionTransactionService
{
	public ProductionTransactionDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<ProductionTransaction>> GetProductionTransactionByCode(string code)
	{
		var result = new SqlQueryHelper<ProductionTransaction>().GetObjectAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCode(code));
		return result;
	}

	public Task<DataResult<ProductionTransaction>> GetProductionTransactionByIdAsync(int id)
	{
		var result = new SqlQueryHelper<ProductionTransaction>().GetObjectAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsAsync()
	{
		var result = new SqlQueryHelper<ProductionTransaction>().GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<ProductionTransaction>().GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<ProductionTransaction>().GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}
}
