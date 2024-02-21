using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.LoginModule.Models;
using Helix.UI.Mobile.Modules.LoginModule.Services;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Helix.UI.Mobile.Modules.LoginModule.DataStores
{
    public class ApplicationUserDataStore : IApplicationUserService
    {
        private string PostUrl = $"gateway/identity/odata/{nameof(ApplicationUser)}";
        public async Task<DataResult<ApplicationUser>> GetObject(HttpClient httpClient, Guid Oid, string query = null!)
        {
            DataResult<ApplicationUser> result = new DataResult<ApplicationUser>();

            var response = await httpClient.GetAsync($"{PostUrl}({Oid}){query}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var data = JsonNode.Parse(json).Deserialize<ApplicationUser>();
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

        public async Task<DataResult<IEnumerable<ApplicationUser>>> GetObjects(HttpClient httpClient, string query = "")
        {
            DataResult<IEnumerable<ApplicationUser>> result = new DataResult<IEnumerable<ApplicationUser>>();

            var response = await httpClient.GetAsync($"{PostUrl}{query}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var data = JsonNode.Parse(json)["value"].Deserialize<IEnumerable<ApplicationUser>>();
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
