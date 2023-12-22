namespace Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;

public interface IBaseProductService< T> where T : class
{
    Task<DataResult<IEnumerable<T>>> GetObjects(HttpClient httpClient,string search, string groupCode, ProductOrderBy orderBy, int page, int pageSize);

    Task<DataResult<T>> GetObjectById(HttpClient httpClient,int ReferenceId);

    Task<DataResult<T>> GetObjectByCode(HttpClient httpClient,string Code);


}
