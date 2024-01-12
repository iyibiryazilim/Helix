using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.DataStores
{
    public class WarehouseParameterDataStore : IWarehouseParameterService
    {
        string postUrl = $"/gateway/product/" + nameof(WarehouseParameter);
       

         async Task<DataResult<IEnumerable<WarehouseParameter>>> IWarehouseParameterService.GetWarehouseParameterByProductId(HttpClient httpClient, int id, string search, WarehouseParameterOrderBy orderBy, int page, int pageSize)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/Warehouse/Id/{id}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
            DataResult<IEnumerable<WarehouseParameter>> dataResult = new DataResult<IEnumerable<WarehouseParameter>>();
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                if (data != null)
                {
                    if (!string.IsNullOrEmpty(data))
                    {
                        var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WarehouseParameter>>>(data, new JsonSerializerOptions
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
                        var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WarehouseParameter>>>(data, new JsonSerializerOptions
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
                    var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WarehouseParameter>>>(data, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    dataResult.Data = Enumerable.Empty<WarehouseParameter>();
                    dataResult.IsSuccess = false;
                    dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

                    return dataResult;
                }


            }
            else
            {
                dataResult.Data = Enumerable.Empty<WarehouseParameter>();
                dataResult.IsSuccess = false;
                dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
                return dataResult;
            }
        }
    }
   
}
