using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ReturnModule.Services;

public interface IWholeSalesReturnDispatchTransactionLineService
{
	Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetObjects(HttpClient httpClient);
	Task<DataResult<WholeSalesReturnDispatchTransactionLine>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient,int id);
	Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient,string code);
	Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetObjectsByProductId(HttpClient httpClient,int id);
	Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient,string code);
	Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient,int id);
	Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetObjectsByFicheCode(HttpClient httpClient, string code);
}
