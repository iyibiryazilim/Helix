using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services;

public interface ICustomerService
{
	Task<DataResult<IEnumerable<Customer>>> GetObjects(HttpClient httpClient, string search, CustomerOrderBy orderBy, int page, int pageSize);
	Task<DataResult<Customer>> GetObjectById(HttpClient httpClient, int ReferenceId);
	Task<DataResult<Customer>> GetObjectByCode(HttpClient httpClient, string Code);
}
