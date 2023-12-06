﻿using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IWholeSalesReturnReturnDispatchTransactionLineService 
{
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesAsync();
	public Task<DataResult<WholeSalesReturnDispatchTransactionLine>> GetWholeSalesReturnDispatchTransactionLineByIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(string code);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(string code);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(int id);
	public Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(string code);
}
