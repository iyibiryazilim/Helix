using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.ProductTransactionLineDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IProductTransactionLineService
{
	Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLinesByProductId(HttpClient httpClient, int id, string search, ProductTransactionLineOrderBy orderBy, int page, int pageSize);
	Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLinesByProductCode(HttpClient httpClient, string code, string search, ProductTransactionLineOrderBy orderBy, int page, int pageSize);

	Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLinesByTransactionType(HttpClient httpClient, string productCode, string transactionType, string search, ProductTransactionLineOrderBy orderBy, int page, int pageSize);


}
