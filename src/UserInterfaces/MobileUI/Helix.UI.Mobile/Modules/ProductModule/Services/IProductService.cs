using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IProductService: IBaseProductService<Product>
{
    public  Task<DataResult<IEnumerable<ProductGroup>>> GetGroupCode(HttpClient httpClient);
    public Task<DataResult<IEnumerable<Product>>> GetAlternativeProducts(HttpClient httpClient,int id, string search, ProductOrderBy orderBy, int page, int pageSize);
    public Task<DataResult<IEnumerable<ProductCustomerAndSupplier>>> GetCustomerAndSupplier(HttpClient httpClient, int id,string search,ProductCustomerAndSupplierOrderBy orderBy, int page, int pageSize);

}
