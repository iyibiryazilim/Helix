using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.LoginModule.Models;

namespace Helix.UI.Mobile.Modules.LoginModule.Services
{
    public interface IApplicationUserService
    {
        Task<DataResult<ApplicationUser>> GetObject(HttpClient httpClient, Guid Oid, string query = null!);
        Task<DataResult<IEnumerable<ApplicationUser>>> GetObjects(HttpClient httpClient, string query = null!);
    }
}
