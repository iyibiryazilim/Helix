using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using System.Text;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.SalesModule.DataStores;

public class RetailSalesDispatchTransactionDataStore : IRetailSalesDispatchTransactionService
{
	string postUrl = $"/gateway/sales/" + nameof(RetailSalesDispatchTransaction);
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetObjects(HttpClient httpClient)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl);
		DataResult<IEnumerable<RetailSalesDispatchTransaction>> dataResult = new DataResult<IEnumerable<RetailSalesDispatchTransaction>>();
		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesDispatchTransaction>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});

				dataResult.Data = Enumerable.Empty<RetailSalesDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}


		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesDispatchTransaction>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
			return dataResult;
		}
	}
	public async Task<DataResult<RetailSalesDispatchTransaction>> GetObjectById(HttpClient httpClient, int ReferenceId)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Id/{ReferenceId}");
		DataResult<RetailSalesDispatchTransaction> dataResult = new DataResult<RetailSalesDispatchTransaction>();
		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<RetailSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<RetailSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<RetailSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
	public async Task<DataResult<RetailSalesDispatchTransaction>> GetObjectByCode(HttpClient httpClient, string Code)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Code/{Code}");
		DataResult<RetailSalesDispatchTransaction> dataResult = new DataResult<RetailSalesDispatchTransaction>();
		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<RetailSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<RetailSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<RetailSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Code/{Code}");
		DataResult<IEnumerable<RetailSalesDispatchTransaction>> dataResult = new DataResult<IEnumerable<RetailSalesDispatchTransaction>>();
		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesDispatchTransaction>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});

				dataResult.Data = Enumerable.Empty<RetailSalesDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}


		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesDispatchTransaction>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
			return dataResult;
		}
	}
	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Id/{ReferenceId}");
		DataResult<IEnumerable<RetailSalesDispatchTransaction>> dataResult = new DataResult<IEnumerable<RetailSalesDispatchTransaction>>();
		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesDispatchTransaction>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});

				dataResult.Data = Enumerable.Empty<RetailSalesDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}


		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesDispatchTransaction>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
			return dataResult;
		}
	}
    public async Task<DataResult<RetailSalesDispatchTransactionDto>> InsertObject(HttpClient httpClient, RetailSalesDispatchTransactionDto retailSalesDispatchTransactionDto)
    {
        HttpResponseMessage responseMessage = await httpClient.PostAsync(postUrl, new StringContent(JsonSerializer.Serialize(retailSalesDispatchTransactionDto), Encoding.UTF8, "application/json"));

        DataResult<RetailSalesDispatchTransactionDto> dataResult = new DataResult<RetailSalesDispatchTransactionDto>();
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
                var result = JsonSerializer.Deserialize<DataResult<RetailSalesDispatchTransactionDto>>(data, new JsonSerializerOptions
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
