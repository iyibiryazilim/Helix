using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.SalesModule.DataStores
{
	public class CustomerTransactionLineDataStore : ICustomerTransactionLineService
	{
		string postUrl = $"/gateway/sales/" + typeof(CustomerTransactionLine).Name;

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentCodeAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, string code, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpclient.GetAsync(postUrl + $"/Current/Code/{code}/Input?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransactionLine>> dataResult = new DataResult<IEnumerable<CustomerTransactionLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentIdAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, int id, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpclient.GetAsync(postUrl + $"/Current/Id/{id}/Input?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransactionLine>> dataResult = new DataResult<IEnumerable<CustomerTransactionLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentCodeAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, string code, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpclient.GetAsync(postUrl + $"/Current/Code/{code}/Output?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransactionLine>> dataResult = new DataResult<IEnumerable<CustomerTransactionLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentIdAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, int id, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpclient.GetAsync(postUrl + $"/Current/Id/{id}/Output?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransactionLine>> dataResult = new DataResult<IEnumerable<CustomerTransactionLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByCurrentCodeAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, string code, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpclient.GetAsync(postUrl + $"/Current/Code/{code}/All?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransactionLine>> dataResult = new DataResult<IEnumerable<CustomerTransactionLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByCurrentIdAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, int id, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpclient.GetAsync(postUrl + $"/Current/Id/{id}/All?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransactionLine>> dataResult = new DataResult<IEnumerable<CustomerTransactionLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheCodeAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, string code, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpclient.GetAsync(postUrl + $"/Fiche/Code/{code}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransactionLine>> dataResult = new DataResult<IEnumerable<CustomerTransactionLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheIdAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, int id, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpclient.GetAsync(postUrl + $"/Fiche/Id/{id}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransactionLine>> dataResult = new DataResult<IEnumerable<CustomerTransactionLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, string currentCode, string TransactionType, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpclient.GetAsync(postUrl + $"/Current/Code/{currentCode}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransactionLine>> dataResult = new DataResult<IEnumerable<CustomerTransactionLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAsync(HttpClient httpclient, string search, CustomerTransactionLineOrderBy orderBy, int currentId, string TransactionType, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpclient.GetAsync(postUrl + $"/Current/Id/{currentId}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<CustomerTransactionLine>> dataResult = new DataResult<IEnumerable<CustomerTransactionLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<CustomerTransactionLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<CustomerTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}
	}

	public enum CustomerTransactionLineOrderBy
	{
		namedesc,
		nameasc,
		codedesc,
		codeasc,
		dateasc,
		datedesc,
	}
}
