using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Services;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.ReturnModule.DataStores;

public class RetailSalesReturnDispatchTransactionLineDataStore : IRetailSalesReturnDispatchTransactionLineService
{
	string postUrl = $"/gateway/sales/{typeof(RetailSalesReturnDispatchTransactionLine)}";

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjects(HttpClient httpClient)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl);
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> dataResult = new DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}
	public async Task<DataResult<RetailSalesReturnDispatchTransactionLine>> GetObjectById(HttpClient httpClient, int ReferenceId)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Id/{ReferenceId}");
		DataResult<RetailSalesReturnDispatchTransactionLine> dataResult = new DataResult<RetailSalesReturnDispatchTransactionLine>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();

			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<RetailSalesReturnDispatchTransactionLine>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<RetailSalesReturnDispatchTransactionLine>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<RetailSalesReturnDispatchTransactionLine>>(data, new JsonSerializerOptions
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

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Code/{Code}");
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> dataResult = new DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Id/{ReferenceId}");
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> dataResult = new DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient, int ReferenceId)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Fiche/Id/{ReferenceId}");
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> dataResult = new DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByFicheNo(HttpClient httpClient, string BaseTransactionCode)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Fiche/Code/{BaseTransactionCode}");
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> dataResult = new DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient, string Code)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Product/Code/{Code}");
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> dataResult = new DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetObjectsByProductId(HttpClient httpClient, int ReferenceId)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Product/Id/{ReferenceId}");
		DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>> dataResult = new DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<RetailSalesReturnDispatchTransactionLine>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}
}
