using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System.Collections;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.Services;

public interface IWarehouseService
{
    Task<DataResult<IEnumerable<Warehouse>>>GetObjects(HttpClient httpClient, string search,WarehouseOrderBy orderBy, int page, int pageSize);
    Task<DataResult<Warehouse>>GetObjectById(HttpClient httpClient,int ReferenceId);

    Task<DataResult<Warehouse>> GetObjectByCode(HttpClient httpClient,string Code);
}
