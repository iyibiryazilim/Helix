using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IProductionTransactionLineService
{
	Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetObjects(HttpClient httpClient);
	Task<DataResult<ProductionTransactionLine>> GetObjectById(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetObjectsByProductId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient, string code);
	Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient, int id);
	Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetObjectsByFicheCode(HttpClient httpClient, string code);
}
