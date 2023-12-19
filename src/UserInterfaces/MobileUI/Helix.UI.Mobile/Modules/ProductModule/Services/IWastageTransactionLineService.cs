using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IWastageTransactionLineService
{
	Task<DataResult<IEnumerable<WastageTransactionLine>>> GetObjects(HttpClient httpClient);
	Task<DataResult<WastageTransactionLine>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<WastageTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<WastageTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<WastageTransactionLine>>> GetObjectsByProductId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<WastageTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<WastageTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<WastageTransactionLine>>> GetObjectsByFicheCode(HttpClient httpClient, string code);
}
