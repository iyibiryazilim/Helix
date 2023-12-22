namespace Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

public interface IBaseProductService<T> where T : class
{
    public Task<DataResult<IEnumerable<T>>> GetObjects(HttpClient httpClient, string search, string groupCode, ProductOrderBy orderBy, int page, int pageSize);

    public Task<DataResult<T>> GetObjectById(HttpClient httpClient, int ReferenceId);

    public Task<DataResult<T>> GetObjectByCode(HttpClient httpClient, string Code);





}
