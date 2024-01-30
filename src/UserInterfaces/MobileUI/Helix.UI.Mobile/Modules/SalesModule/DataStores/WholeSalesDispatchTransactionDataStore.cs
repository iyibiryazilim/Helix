using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using System.Text;
using System.Text.Json;


namespace Helix.UI.Mobile.Modules.SalesModule.DataStores
{
	public class WholeSalesDispatchTransactionDataStore : IWholeSalesDispatchTransactionService
	{
		string postUrl = $"/gateway/sales/" + nameof(WholeSalesDispatchTransaction);
		public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetObjects(HttpClient httpClient)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl);
			DataResult<IEnumerable<WholeSalesDispatchTransaction>> dataResult = new DataResult<IEnumerable<WholeSalesDispatchTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WholeSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WholeSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WholeSalesDispatchTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<WholeSalesDispatchTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<WholeSalesDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}
		public async Task<DataResult<WholeSalesDispatchTransaction>> GetObjectById(HttpClient httpClient, int ReferenceId)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Id/{ReferenceId}");
			DataResult<WholeSalesDispatchTransaction> dataResult = new DataResult<WholeSalesDispatchTransaction>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<WholeSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<WholeSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<WholeSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
		public async Task<DataResult<WholeSalesDispatchTransaction>> GetObjectByCode(HttpClient httpClient, string Code)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Code/{Code}");
			DataResult<WholeSalesDispatchTransaction> dataResult = new DataResult<WholeSalesDispatchTransaction>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<WholeSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<WholeSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<WholeSalesDispatchTransaction>>(data, new JsonSerializerOptions
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
		public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Code/{Code}");
			DataResult<IEnumerable<WholeSalesDispatchTransaction>> dataResult = new DataResult<IEnumerable<WholeSalesDispatchTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WholeSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WholeSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WholeSalesDispatchTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<WholeSalesDispatchTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<WholeSalesDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}
		public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Id/{ReferenceId}");
			DataResult<IEnumerable<WholeSalesDispatchTransaction>> dataResult = new DataResult<IEnumerable<WholeSalesDispatchTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WholeSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WholeSalesDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<WholeSalesDispatchTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<WholeSalesDispatchTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<WholeSalesDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}
        public async Task<DataResult<WholeSalesDispatchTransactionDto>> InsertObject(HttpClient httpClient, WholeSalesDispatchTransactionDto wholeSalesDispatchTransactionDto)
        {
            HttpResponseMessage responseMessage = await httpClient.PostAsync(postUrl, new StringContent(JsonSerializer.Serialize(wholeSalesDispatchTransactionDto), Encoding.UTF8, "application/json"));

            DataResult<WholeSalesDispatchTransactionDto> dataResult = new DataResult<WholeSalesDispatchTransactionDto>();
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
                    var result = JsonSerializer.Deserialize<DataResult<WholeSalesDispatchTransactionDto>>(data, new JsonSerializerOptions
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
}
