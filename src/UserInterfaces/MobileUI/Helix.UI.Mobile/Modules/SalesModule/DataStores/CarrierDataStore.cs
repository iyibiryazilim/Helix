using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.DataStores
{
    public class CarrierDataStore :ICarrierService
    {
        string postUrl = $"gateway/sales/" + typeof(Carrier).Name;

        public async Task <DataResult<IEnumerable<Carrier>>>GetObjects(HttpClient httpClient)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl);
            DataResult<IEnumerable<Carrier>> dataResult = new DataResult<IEnumerable<Carrier>>();
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                if (data != null)
                {
                    if (!string.IsNullOrEmpty(data))
                    {
                        var result = JsonSerializer.Deserialize<DataResult<IEnumerable<Carrier>>>(data, new JsonSerializerOptions
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
                        var result = JsonSerializer.Deserialize<DataResult<IEnumerable<Carrier>>>(data, new JsonSerializerOptions
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
                    var result = JsonSerializer.Deserialize<DataResult<IEnumerable<Carrier>>>(data, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    dataResult.Data = Enumerable.Empty<Carrier>();
                    dataResult.IsSuccess = false;
                    dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

                    return dataResult;
                }


            }
            else
            {
                dataResult.Data = Enumerable.Empty<Carrier>();
                dataResult.IsSuccess = false;
                dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
                return dataResult;
            }
        }

    }
}
