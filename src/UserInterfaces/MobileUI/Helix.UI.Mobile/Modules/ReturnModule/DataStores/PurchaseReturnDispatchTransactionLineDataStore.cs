using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ReturnModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Services;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.ReturnModule.DataStores;

public class PurchaseReturnDispatchTransactionLineDataStore : IPurchaseReturnDispatchTransactionLineService
{
	string postUrl = $"/gateway/purchase/{typeof(PurchaseReturnDispatchTransactionLine).Name}";

	public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjects(HttpClient httpClient)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl);
		DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>> dataResult = new DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<PurchaseReturnDispatchTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}

		}
		else
		{
			dataResult.Data = Enumerable.Empty<PurchaseReturnDispatchTransactionLine>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}

	public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetByFicheNo(HttpClient httpClient, string BaseTransactionCode)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Fiche/Code/{BaseTransactionCode}");
		DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>> dataResult = new DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<PurchaseReturnDispatchTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<PurchaseReturnDispatchTransactionLine>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}

	public async Task<DataResult<PurchaseReturnDispatchTransactionLine>> GetObjectById(HttpClient httpClient, int ReferenceId)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Id/{ReferenceId}");
		DataResult<PurchaseReturnDispatchTransactionLine> dataResult = new DataResult<PurchaseReturnDispatchTransactionLine>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();

			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<PurchaseReturnDispatchTransactionLine>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<PurchaseReturnDispatchTransactionLine>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<PurchaseReturnDispatchTransactionLine>>(data, new JsonSerializerOptions
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


	public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Code/{Code}");

		throw new NotImplementedException();
	}

	public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId)
	{
		throw new NotImplementedException();
	}

	public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjectsByFicheId(HttpClient httpClient, int ReferenceId)
	{
		throw new NotImplementedException();
	}

	public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjectsByProductCode(HttpClient httpClient, string Code)
	{
		throw new NotImplementedException();
	}

	public Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetObjectsByProductId(HttpClient httpClient, int ReferenceId)
	{
		throw new NotImplementedException();
	}
}
