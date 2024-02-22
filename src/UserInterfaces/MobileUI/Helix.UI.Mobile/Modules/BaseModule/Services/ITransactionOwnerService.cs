using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.BaseModule.Models;

namespace Helix.UI.Mobile.Modules.BaseModule.Services
{
    public interface ITransactionOwnerService
    {
        Task<DataResult<TransactionOwner>> GetObject(HttpClient httpClient, Guid Oid, string query = null!);
        Task<DataResult<IEnumerable<TransactionOwner>>> GetObjects(HttpClient httpClient, string query = null!);
        Task<DataResult<TransactionOwner>> PutObject(HttpClient httpClient, TransactionOwner item, Guid oid);
        Task<DataResult<TransactionOwner>> PatchObject(HttpClient httpClient, object item, Guid oid);
    }
}
