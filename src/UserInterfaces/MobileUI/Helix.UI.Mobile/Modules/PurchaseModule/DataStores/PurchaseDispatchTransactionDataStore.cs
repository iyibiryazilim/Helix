using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using System.Text;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.PurchaseModule.DataStores
{
	public class PurchaseDispatchTransactionDataStore : IPurchaseDispatchTransactionService
	{
		public string postUrl = $"gateway/purchase/" + nameof(PurchaseDispatchTransaction);

		public async Task<DataResult<PurchaseDispatchTransaction>> GetObjectByCode(HttpClient httpClient, string Code)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Code/{Code}");
			DataResult<PurchaseDispatchTransaction> dataResult = new DataResult<PurchaseDispatchTransaction>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<PurchaseDispatchTransaction>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<PurchaseDispatchTransaction>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<PurchaseDispatchTransaction>>(data, new JsonSerializerOptions
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

		public async Task<DataResult<PurchaseDispatchTransaction>> GetObjectById(HttpClient httpClient, int ReferenceId)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Id/{ReferenceId}");
			DataResult<PurchaseDispatchTransaction> dataResult = new DataResult<PurchaseDispatchTransaction>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<PurchaseDispatchTransaction>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<PurchaseDispatchTransaction>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<PurchaseDispatchTransaction>>(data, new JsonSerializerOptions
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

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetObjects(HttpClient httpClient, string search, SupplierOrderBy orderBy, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<PurchaseDispatchTransaction>> dataResult = new DataResult<IEnumerable<PurchaseDispatchTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseDispatchTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseDispatchTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<PurchaseDispatchTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<PurchaseDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Code/{Code}");
			DataResult<IEnumerable<PurchaseDispatchTransaction>> dataResult = new DataResult<IEnumerable<PurchaseDispatchTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseDispatchTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseDispatchTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<PurchaseDispatchTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<PurchaseDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Id/{ReferenceId}");
			DataResult<IEnumerable<PurchaseDispatchTransaction>> dataResult = new DataResult<IEnumerable<PurchaseDispatchTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseDispatchTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseDispatchTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseDispatchTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<PurchaseDispatchTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<PurchaseDispatchTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}
        public async Task<DataResult<PurchaseDispatchTransactionDto>> InsertObject(HttpClient httpClient, PurchaseDispatchTransactionDto purchaseDispatchTransactionDto)
        {
            HttpResponseMessage responseMessage = await httpClient.PostAsync(postUrl, new StringContent(JsonSerializer.Serialize(purchaseDispatchTransactionDto), Encoding.UTF8, "application/json"));

            DataResult<PurchaseDispatchTransactionDto> dataResult = new DataResult<PurchaseDispatchTransactionDto>();
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
                    var result = JsonSerializer.Deserialize<DataResult<PurchaseDispatchTransactionDto>>(data, new JsonSerializerOptions
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
	public enum SupplierOrderBy
	{
		nameasc,
		namedesc,
		codeasc,
		codedesc
	}
}
