using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services;

public interface IShipInfoService
{
    Task<DataResult<IEnumerable<ShipInfo>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId);
}
