using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services;

public interface ICustomerService<T> where T : class
{
	Task<DataResult<IEnumerable<T>>> GetObjects(HttpClient httpClient);
	Task<DataResult<T>> GetObjectById(HttpClient httpClient, int ReferenceId);
	Task<DataResult<T>> GetObjectByCode(HttpClient httpClient, string Code);
}
