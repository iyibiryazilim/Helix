using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.PurchaseModule.DataStores
{
	public class PurchaseOrderLineDataStore : IPurchaseOrderLineService
	{
		public string postUrl = $"gateway/purchase/" + nameof(PurchaseOrderLine);

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrderByCode(HttpClient httpClient,string search, PurchaseOrderLineOrderBy orderBy, string Code,int page,int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Code/{Code}?search={search}&includeWaiting=true&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<PurchaseOrderLine>> dataResult = new DataResult<IEnumerable<PurchaseOrderLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrderById(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, int ReferenceId, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Id/{ReferenceId}?search={search}&includeWaiting=true&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<PurchaseOrderLine>> dataResult = new DataResult<IEnumerable<PurchaseOrderLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrders(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy , int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}?search={search}&includeWaiting=true&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<PurchaseOrderLine>> dataResult = new DataResult<IEnumerable<PurchaseOrderLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<PurchaseOrderLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<PurchaseOrderLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByCurrentCode(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, string Code, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Code/{Code}?search={search}&includeWaiting=true&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<PurchaseOrderLine>> dataResult = new DataResult<IEnumerable<PurchaseOrderLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<PurchaseOrderLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<PurchaseOrderLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByCurrentId(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, int ReferenceId, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Id/{ReferenceId}?search={search}&includeWaiting=true&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<PurchaseOrderLine>> dataResult = new DataResult<IEnumerable<PurchaseOrderLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<PurchaseOrderLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<PurchaseOrderLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByProductCode(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, string Code, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Product/Code/{Code}?search={search}&includeWaiting=true&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<PurchaseOrderLine>> dataResult = new DataResult<IEnumerable<PurchaseOrderLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<PurchaseOrderLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<PurchaseOrderLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingOrdersByProductId(HttpClient httpClient, string search, PurchaseOrderLineOrderBy orderBy, int ReferenceId, int page, int pageSize)
		{
			HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Product/Id/{ReferenceId}?search={search}&includeWaiting=true&orderBy={orderBy}&page={page}&pageSize={pageSize}");
			DataResult<IEnumerable<PurchaseOrderLine>> dataResult = new DataResult<IEnumerable<PurchaseOrderLine>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
						var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<PurchaseOrderLine>>>(data, new JsonSerializerOptions
					{
						PropertyNamingPolicy = JsonNamingPolicy.CamelCase
					});

					dataResult.Data = Enumerable.Empty<PurchaseOrderLine>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<PurchaseOrderLine>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}

	}
	public enum PurchaseOrderLineOrderBy
	{
		productcodedesc,
		productcodeasc,
		productnamedesc,
		productnameasc,
		currentcodedesc,
		currentcodeasc,
		currentnamedesc,
		currentnameasc,
		dateasc,
		datedesc
	}
}
