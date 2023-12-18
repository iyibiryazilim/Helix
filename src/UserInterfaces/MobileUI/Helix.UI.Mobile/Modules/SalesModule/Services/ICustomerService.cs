using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Services;

public interface ICustomerService
{
	Task<DataResult<IEnumerable<Customer>>> GetObjects(HttpClient httpClient);
	Task<DataResult<Customer>> GetObjectById(HttpClient httpClient, int ReferenceId);
	Task<DataResult<Customer>> GetObjectByCode(HttpClient httpClient, string Code);
}
