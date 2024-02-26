using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.LoginModule.Models;

namespace Helix.UI.Mobile.Modules.PanelModule.Services
{
	public interface IEmployeeService
	{
		Task<DataResult<Employee>> GetObject(HttpClient httpClient, Guid Oid, string query = null!);
		Task<DataResult<IEnumerable<Employee>>> GetObjects(HttpClient httpClient, string query = null!);
	}
}
