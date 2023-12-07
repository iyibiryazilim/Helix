using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class WholeSalesReturnDispatchTransactionLineDataStore : BaseDataStore,IWholeSalesReturnDispatchTransactionLineService
{
	public WholeSalesReturnDispatchTransactionLineDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<WholeSalesReturnDispatchTransactionLine>> GetWholeSalesReturnDispatchTransactionLineByIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesAsync()
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(string code)
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
		return result;
	}

	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(int id)
	{
		var result = new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
		return result;
	}
}
