using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class RetailSalesReturnDispatchTransactionLineDataStore : BaseDataStore,IRetailSalesReturnDispatchTransactionLineService
{
	public RetailSalesReturnDispatchTransactionLineDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<RetailSalesReturnDispatchTransactionLine>> GetRetailSalesReturnDispatchTransactionLineByIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesAsync()
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(string code)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(string code)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(int id)
	{
		var result = new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
		return result;
	}
}
