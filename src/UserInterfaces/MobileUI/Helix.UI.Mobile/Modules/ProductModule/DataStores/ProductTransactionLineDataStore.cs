using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.ProductModule.DataStores;

public class ProductTransactionLineDataStore : IProductTransactionLineService
{
	string postUrl = $"gateway/product/{nameof(ProductTransactionLine)}";
	public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLinesByProductCode(HttpClient httpClient, string code, string search, ProductTransactionLineOrderBy orderBy, int page, int pageSize)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Product/Code/{code}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
		DataResult<IEnumerable<ProductTransactionLine>> dataResult = new DataResult<IEnumerable<ProductTransactionLine>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<ProductTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<ProductTransactionLine>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<ProductTransactionLine>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<ProductTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<ProductTransactionLine>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}

	public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLinesByProductId(HttpClient httpClient, int id, string search, ProductTransactionLineOrderBy orderBy, int page, int pageSize)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Product/Id/{id}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
		DataResult<IEnumerable<ProductTransactionLine>> dataResult = new DataResult<IEnumerable<ProductTransactionLine>>();

		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<ProductTransactionLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<ProductTransactionLine>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<ProductTransactionLine>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				dataResult.Data = Enumerable.Empty<ProductTransactionLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}
		}
		else
		{
			dataResult.Data = Enumerable.Empty<ProductTransactionLine>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

			return dataResult;
		}
	}

	public enum ProductTransactionLineOrderBy
	{
		datedesc,
		dateasc,
		quantitydesc,
		quantityasc
	}
}
