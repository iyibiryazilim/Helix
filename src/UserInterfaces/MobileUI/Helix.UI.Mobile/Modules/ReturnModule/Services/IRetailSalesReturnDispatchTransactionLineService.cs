using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ReturnModule.Services;

public interface IRetailSalesReturnDispatchTransactionLineService
{
	Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjects(HttpClient httpClient);
	Task<DataResult<RetailSalesReturnDispatchTransactionLine>> GetObjectById(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code);
	Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByProductId(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient, string Code);
	Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient, int ReferenceId);
	Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByFicheNo(HttpClient httpClient, string BaseTransactionCode);
}
