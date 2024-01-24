using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.SalesModule.DataStores
{
	public class CustomerTransactionDataStore : ICustomerTransactionService
	{
		string postUrl = $"/gateway/sales/" + typeof(CustomerTransaction).Name;

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentCodeAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, string code, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/Current/Code/{code}/Input?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransaction>> dataResult = new DataResult<IEnumerable<CustomerTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentIdAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, int id, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/Current/Id/{id}/Input?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransaction>> dataResult = new DataResult<IEnumerable<CustomerTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentCodeAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, string code, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/Current/Code/{code}/Output?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransaction>> dataResult = new DataResult<IEnumerable<CustomerTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentIdAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, int id, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/Current/Id/{id}/Output?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransaction>> dataResult = new DataResult<IEnumerable<CustomerTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByCurrentCodeAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, string code, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/Current/Code/{code}/All?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransaction>> dataResult = new DataResult<IEnumerable<CustomerTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByCurrentIdAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, int id, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/Current/Id/{id}/All?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransaction>> dataResult = new DataResult<IEnumerable<CustomerTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, string currentCode, string TransactionType, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/Current/Code/{currentCode}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransaction>> dataResult = new DataResult<IEnumerable<CustomerTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, int currentId, string TransactionType, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/Current/Id/{currentId}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransaction>> dataResult = new DataResult<IEnumerable<CustomerTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}
		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAndWarehouseAsync(HttpClient httpClient, string search, CustomerTransactionOrderBy orderBy, int currentId,int warehouseNumber, string TransactionType, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl + $"/CurrentAndWarehouse/Id/{currentId}&{TransactionType}&{warehouseNumber}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransaction>> dataResult = new DataResult<IEnumerable<CustomerTransaction>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransaction>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransaction>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransaction>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}


    }
    public enum CustomerTransactionOrderBy
	{ 
		codedesc,
		codeasc,
		dateasc,
		datedesc,
	}
}
