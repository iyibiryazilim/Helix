using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Helix.UI.Mobile.Modules.BaseModule.DataStores
{
    public class FailureTransactionOwnerDataStore : IFailureTransactionService
    {
        private string PostUrl = $"/gateway/identity/odata/{nameof(FailureTransactionOwner)}";
        public async Task<DataResult<FailureTransactionOwner>> GetObject(HttpClient httpClient, Guid Oid, string query = null!)
        {
            DataResult<FailureTransactionOwner> result = new DataResult<FailureTransactionOwner>();

            var response = await httpClient.GetAsync($"{PostUrl}({Oid}){query}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var data = JsonNode.Parse(json).Deserialize<FailureTransactionOwner>();
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

        public async Task<DataResult<IEnumerable<FailureTransactionOwner>>> GetObjects(HttpClient httpClient, string query = "")
        {
            DataResult<IEnumerable<FailureTransactionOwner>> result = new DataResult<IEnumerable<FailureTransactionOwner>>();

            var response = await httpClient.GetAsync($"{PostUrl}{query}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var data = JsonNode.Parse(json)["value"].Deserialize<IEnumerable<FailureTransactionOwner>>();
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

        public async Task<DataResult<FailureTransactionOwner>> InsertObject(HttpClient httpClient, object item)
        {
            DataResult<FailureTransactionOwner> result = new DataResult<FailureTransactionOwner>();

            var response = await httpClient.PostAsync(PostUrl, new StringContent(JsonSerializer.Serialize(item), encoding: Encoding.UTF8, mediaType: "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var data = JsonNode.Parse(json).Deserialize<FailureTransactionOwner>();
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

        /// <summary>
        /// Tüm alanların güncellenmesini sağlar
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="item"></param>
        /// <param name="oid"></param>
        /// <returns></returns>
        public async Task<DataResult<FailureTransactionOwner>> PutObject(HttpClient httpClient, FailureTransactionOwner item, Guid oid)
        {
            DataResult<FailureTransactionOwner> result = new DataResult<FailureTransactionOwner>();

            var response = await httpClient.PutAsync(requestUri: $"{PostUrl}/{oid.ToString()}", content: new StringContent(JsonSerializer.Serialize(item), encoding: Encoding.UTF8, mediaType: "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(json))
                {
                    var data = JsonNode.Parse(json)["value"].Deserialize<FailureTransactionOwner>();
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

        /// <summary>
        /// Sadece belirli alanların güncellenmesini sağlar
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="item"></param>
        /// <param name="oid"></param>
        /// <returns></returns>
        public async Task<DataResult<FailureTransactionOwner>> PatchObject(HttpClient httpClient, object item, Guid oid)
        {
            DataResult<FailureTransactionOwner> result = new DataResult<FailureTransactionOwner>();

            var response = await httpClient.PatchAsync(requestUri: $"{PostUrl}/{oid.ToString()}", content: new StringContent(JsonSerializer.Serialize(item), encoding: Encoding.UTF8, mediaType: "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(json))
                {
                    result.IsSuccess = true;
                    result.Message = "Success";
                    result.Data = null;
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
