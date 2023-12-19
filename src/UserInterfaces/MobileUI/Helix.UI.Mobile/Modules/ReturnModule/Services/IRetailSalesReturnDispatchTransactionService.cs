using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ReturnModule.Services;

public interface IRetailSalesReturnDispatchTransactionService
{
	Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetObjects(HttpClient httpClient);
	Task<DataResult<RetailSalesReturnDispatchTransaction>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<RetailSalesReturnDispatchTransaction>> GetObjectByCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);

	//Task<DataResult<RetailSalesReturnDispatchTransaction>> InsertAsync(HttpClient httpClient, RetailSalesReturnDispatchTransactionInsertDto dto);
}
