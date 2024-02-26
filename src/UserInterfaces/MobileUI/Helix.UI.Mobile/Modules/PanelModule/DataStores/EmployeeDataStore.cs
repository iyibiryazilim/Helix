using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.LoginModule.Models;
using Helix.UI.Mobile.Modules.PanelModule.Services;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Helix.UI.Mobile.Modules.PanelModule.DataStores
{
	public class EmployeeDataStore : IEmployeeService
	{
		private string PostUrl = $"gateway/identity/odata/{nameof(Employee)}"; 
		public async Task<DataResult<Employee>> GetObject(HttpClient httpClient, Guid Oid, string query = null)
		{
			DataResult<Employee> result = new DataResult<Employee>();

			var response = await httpClient.GetAsync($"{PostUrl}({Oid}){query}");
			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				if (!string.IsNullOrEmpty(json))
				{
					var data = JsonNode.Parse(json).Deserialize<Employee>();
					result.IsSuccess = true;
					result.Message = "Success";
					result.Data = data;
				}
				else
				{
					result.IsSuccess = false;
					result.Data = null;
					result.Message = "Empty Data";
				}
			}
			else
			{
				result.IsSuccess = false;
				result.Data = null;
				result.Message = await response.Content.ReadAsStringAsync();
			}


			return await Task.FromResult(result);
		}

		public async Task<DataResult<IEnumerable<Employee>>> GetObjects(HttpClient httpClient, string query = null)
		{
			DataResult<IEnumerable<Employee>> result = new DataResult<IEnumerable<Employee>>();

			var response = await httpClient.GetAsync($"{PostUrl}{query}");
			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				if (!string.IsNullOrEmpty(json))
				{
					var data = JsonNode.Parse(json)["value"].Deserialize<IEnumerable<Employee>>();
					result.IsSuccess = true;
					result.Message = "Success";
					result.Data = data;
				}
				else
				{
					result.IsSuccess = false;
					result.Data = null;
					result.Message = "Empty Data";
				}
			}
			else
			{
				result.IsSuccess = false;
				result.Data = null;
				result.Message = await response.Content.ReadAsStringAsync();
			}


			return await Task.FromResult(result);
		}
	}
}
