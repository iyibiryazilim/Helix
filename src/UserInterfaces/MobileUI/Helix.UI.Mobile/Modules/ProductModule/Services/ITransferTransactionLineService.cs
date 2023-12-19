using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface ITransferTransactionLineService
{
	Task<DataResult<IEnumerable<TransferTransaction>>> GetObjects(HttpClient httpClient);
	Task<DataResult<TransferTransaction>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<TransferTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<TransferTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<TransferTransaction>>> GetObjectsByProductId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<TransferTransaction>>> GetObjectsByProductCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<TransferTransaction>>> GetObjectsByFicheId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<TransferTransaction>>> GetObjectsByFicheCode(HttpClient httpClient, string code);
}
