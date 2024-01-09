using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.SalesModule.DataStores;

public class SpeCodeDataStore :ISpeCodeService
{
    string postUrl = $"gateway/sales" + typeof(SpeCodeModel).Name;

    public async Task<DataResult<IEnumerable<SpeCodeModel>>> GetObjects(HttpClient httpClient)
    {
        HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl);
        DataResult<IEnumerable<SpeCodeModel>> dataResult = new DataResult<IEnumerable<SpeCodeModel>>();
        if (responseMessage.IsSuccessStatusCode)
        {
            var data = await responseMessage.Content.ReadAsStringAsync();
            if (data != null)
            {
                if (!string.IsNullOrEmpty(data))
                {
                    var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SpeCodeModel>>>(data, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    dataResult.Data = result?.Data;
                    dataResult.IsSuccess = true;
                    dataResult.Message = "success";
                    return dataResult;

                }
                else
                {
                    var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SpeCodeModel>>>(data, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    dataResult.Data = result?.Data;
                    dataResult.IsSuccess = true;
                    dataResult.Message = "empty";
                    return dataResult;
                }

            }
            else
            {
                var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SpeCodeModel>>>(data, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                dataResult.Data = Enumerable.Empty<SpeCodeModel>();
                dataResult.IsSuccess = false;
                dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

                return dataResult;
            }


        }
        else
        {
            dataResult.Data = Enumerable.Empty<SpeCodeModel>();
            dataResult.IsSuccess = false;
            dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
            return dataResult;
        }
    }
}
