﻿using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class WholeSalesReturnReturnDispatchTransactionLineDataStore : BaseDataStore,IWholeSalesReturnReturnDispatchTransactionLineService
{
	public WholeSalesReturnReturnDispatchTransactionLineDataStore(IConfiguration configuration) : base(configuration)
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
