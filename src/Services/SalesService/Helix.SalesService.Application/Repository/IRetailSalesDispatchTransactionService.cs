﻿using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;

namespace Helix.SalesService.Application.Repository;

public interface IRetailSalesDispatchTransactionService
{
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsAsync();
	public Task<DataResult<RetailSalesDispatchTransaction>> GetRetailSalesDispatchTransactionByIdAsync(int id);
	public Task<DataResult<RetailSalesDispatchTransaction>> GetRetailSalesDispatchTransactionByCode(string code);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsByCurrentIdAsync(int id);
	public Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsByCurrentCodeAsync(string code);
}
