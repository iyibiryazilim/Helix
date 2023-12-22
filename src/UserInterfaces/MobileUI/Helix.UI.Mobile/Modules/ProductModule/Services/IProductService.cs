using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IProductService: IBaseProductService<Product>
{
    public  Task<DataResult<IEnumerable<ProductGroup>>> GetGroupCode(HttpClient httpClient);
}
