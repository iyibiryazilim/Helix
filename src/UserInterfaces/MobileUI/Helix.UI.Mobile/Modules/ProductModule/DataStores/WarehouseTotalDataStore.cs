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
	public class WarehouseTotalDataStore : IWarehouseTotalService
	{
		string postUrl = $"/gateway/product/" + nameof(WarehouseTotal);

       

        public async Task<DataResult<IEnumerable<WarehouseTotal>>> GetWarehouseTotals(HttpClient httpClient, int number, string cardType, string search, WarehouseTotalOrderBy orderBy, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/Warehouse/Number/{number}&{cardType}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<WarehouseTotal>> dataResult = new DataResult<IEnumerable<WarehouseTotal>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WarehouseTotal>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WarehouseTotal>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WarehouseTotal>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<WarehouseTotal>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<WarehouseTotal>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

        public async Task<DataResult<IEnumerable<WarehouseTotal>>> GetWarehouseTotalByProductId(HttpClient httpClient,int id, string search, WarehouseTotalOrderBy orderBy, int page, int pageSize)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/Warehouse/Id/{id}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
            DataResult<IEnumerable<WarehouseTotal>> dataResult = new DataResult<IEnumerable<WarehouseTotal>>();
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                if (data != null)
                {
                    if (!string.IsNullOrEmpty(data))
                    {
                        var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WarehouseTotal>>>(data, new JsonSerializerOptions
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
                        var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WarehouseTotal>>>(data, new JsonSerializerOptions
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
                    var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WarehouseTotal>>>(data, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    dataResult.Data = Enumerable.Empty<WarehouseTotal>();
                    dataResult.IsSuccess = false;
                    dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

                    return dataResult;
                }


            }
            else
            {
                dataResult.Data = Enumerable.Empty<WarehouseTotal>();
                dataResult.IsSuccess = false;
                dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
                return dataResult;
            }




        }

    }
	public enum WarehouseTotalOrderBy
	{
		nameasc,
		namedesc,
		codeasc,
		codedesc,
		quantityasc,
		quantitydesc
	}
}
