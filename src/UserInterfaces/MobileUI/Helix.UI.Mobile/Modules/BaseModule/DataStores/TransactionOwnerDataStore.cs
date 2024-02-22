using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Helix.UI.Mobile.Modules.BaseModule.DataStores
{
    public class TransactionOwnerDataStore : ITransactionOwnerService
    {
        private string PostUrl = $"/gateway/identity/odata/{nameof(TransactionOwner)}";
        public async Task<DataResult<TransactionOwner>> GetObject(HttpClient httpClient, Guid Oid, string query = null!)
        {
            DataResult<TransactionOwner> result = new DataResult<TransactionOwner>();

            var response = await httpClient.GetAsync($"{PostUrl}({Oid}){query}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var data = JsonNode.Parse(json).Deserialize<TransactionOwner>();
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

        public async Task<DataResult<IEnumerable<TransactionOwner>>> GetObjects(HttpClient httpClient, string query = "")
        {
            DataResult<IEnumerable<TransactionOwner>> result = new DataResult<IEnumerable<TransactionOwner>>();

            var response = await httpClient.GetAsync($"{PostUrl}{query}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var data = JsonNode.Parse(json)["value"].Deserialize<IEnumerable<TransactionOwner>>();
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

        public async Task<DataResult<TransactionOwner>> InsertObject(HttpClient httpClient, object item)
        {
            DataResult<TransactionOwner> result = new DataResult<TransactionOwner>();

            var response = await httpClient.PostAsync(PostUrl, new StringContent(JsonSerializer.Serialize(item), encoding: Encoding.UTF8, mediaType: "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var data = JsonNode.Parse(json).Deserialize<TransactionOwner>();
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
        public async Task<DataResult<TransactionOwner>> PutObject(HttpClient httpClient, TransactionOwner item, Guid oid)
        {
            DataResult<TransactionOwner> result = new DataResult<TransactionOwner>();

            var response = await httpClient.PutAsync(requestUri: $"{PostUrl}/{oid.ToString()}", content: new StringContent(JsonSerializer.Serialize(item), encoding: Encoding.UTF8, mediaType: "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(json))
                {
                    var data = JsonNode.Parse(json)["value"].Deserialize<TransactionOwner>();
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
        public async Task<DataResult<TransactionOwner>> PatchObject(HttpClient httpClient, object item, Guid oid)
        {
            DataResult<TransactionOwner> result = new DataResult<TransactionOwner>();

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
