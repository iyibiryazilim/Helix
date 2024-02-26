using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.BaseModule.Models;

namespace Helix.UI.Mobile.Modules.BaseModule.Services
{
    public interface IFailureTransactionService
    {
        Task<DataResult<FailureTransactionOwner>> GetObject(HttpClient httpClient, Guid Oid, string query = null!);
        Task<DataResult<IEnumerable<FailureTransactionOwner>>> GetObjects(HttpClient httpClient, string query = null!);
        Task<DataResult<FailureTransactionOwner>> PutObject(HttpClient httpClient, FailureTransactionOwner item, Guid oid);
        Task<DataResult<FailureTransactionOwner>> PatchObject(HttpClient httpClient, object item, Guid oid);
    }
}
