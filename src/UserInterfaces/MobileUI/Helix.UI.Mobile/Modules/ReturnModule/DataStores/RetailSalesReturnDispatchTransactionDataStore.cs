using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Services;
using System.Text;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.ReturnModule.DataStores;

public class RetailSalesReturnDispatchTransactionDataStore : IRetailSalesReturnDispatchTransactionService
{
	string postUrl = $"/gateway/sales/{nameof(RetailSalesReturnDispatchTransaction)}";

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetObjects(HttpClient httpClient)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl);
		DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>> dataResult = new DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransaction>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}
	public async Task<DataResult<RetailSalesReturnDispatchTransaction>> GetObjectByCode(HttpClient httpClient, string code)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Code/{code}");
		DataResult<RetailSalesReturnDispatchTransaction> dataResult = new DataResult<RetailSalesReturnDispatchTransaction>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();

			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<RetailSalesReturnDispatchTransaction>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<RetailSalesReturnDispatchTransaction>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<RetailSalesReturnDispatchTransaction>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = null;
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}
		else
		{
			dataResult.Data = null;
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
			return dataResult;
		}
	}

	public async Task<DataResult<RetailSalesReturnDispatchTransaction>> GetObjectById(HttpClient httpClient, int id)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Id/{id}");
		DataResult<RetailSalesReturnDispatchTransaction> dataResult = new DataResult<RetailSalesReturnDispatchTransaction>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();

			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<RetailSalesReturnDispatchTransaction>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<RetailSalesReturnDispatchTransaction>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<RetailSalesReturnDispatchTransaction>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = null;
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}
		else
		{
			dataResult.Data = null;
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
			return dataResult;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string code)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Code/{code}");
		DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>> dataResult = new DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransaction>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int id)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Id/{id}");
		DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>> dataResult = new DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransaction>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}

    public async Task<DataResult<RetailSalesReturnDispatchTransactionInsertDto>> InsertObject(HttpClient httpClient, RetailSalesReturnDispatchTransactionInsertDto retailSalesReturnDispatchTransactionInsertDto)
    {
        HttpResponseMessage responseMessage = await httpClient.PostAsync(postUrl, new StringContent(JsonSerializer.Serialize(retailSalesReturnDispatchTransactionInsertDto), Encoding.UTF8, "application/json"));


        DataResult<RetailSalesReturnDispatchTransactionInsertDto> dataResult = new DataResult<RetailSalesReturnDispatchTransactionInsertDto>();
        dataResult.IsSuccess = responseMessage.IsSuccessStatusCode;

        if (dataResult.IsSuccess)
        {
            var data = await responseMessage.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(data))
            {
                dataResult.Data = null;
                dataResult.Message = "empty";
            }
            else
            {
                var result = JsonSerializer.Deserialize<DataResult<RetailSalesReturnDispatchTransactionInsertDto>>(data, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                dataResult.Data = result?.Data;
                dataResult.Message = "success";
            }
        }
        else
        {
            dataResult.Data = null;
            dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
        }

        return dataResult;
    }

}
