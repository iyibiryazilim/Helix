using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using System.Text.Json;

namespace Helix.UI.Mobile.Modules.SalesModule.DataStores;

public class SalesOrderDataStore : ISalesOrderService
{
	string postUrl = $"/gateway/sales/" + nameof(SalesOrder);
	public async Task<DataResult<IEnumerable<SalesOrder>>> GetObjects(HttpClient httpClient,string search, SalesOrderOrderBy orderBy, int page, int pageSize)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync(postUrl+ $"?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
		DataResult<IEnumerable<SalesOrder>> dataResult = new DataResult<IEnumerable<SalesOrder>>();
		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});

				dataResult.Data = Enumerable.Empty<SalesOrder>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}


		}
		else
		{
			dataResult.Data = Enumerable.Empty<SalesOrder>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
			return dataResult;
		}
	}
	public async Task<DataResult<SalesOrder>> GetObjectById(HttpClient httpClient, int ReferenceId)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Id/{ReferenceId}");
		DataResult<SalesOrder> dataResult = new DataResult<SalesOrder>();
		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<SalesOrder>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<SalesOrder>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<SalesOrder>>(data, new JsonSerializerOptions
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
	public async Task<DataResult<SalesOrder>> GetObjectByCode(HttpClient httpClient, string Code)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Code/{Code}");
		DataResult<SalesOrder> dataResult = new DataResult<SalesOrder>();
		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<SalesOrder>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<SalesOrder>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<SalesOrder>>(data, new JsonSerializerOptions
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
	public async Task<DataResult<IEnumerable<SalesOrder>>> GetObjectsByCurrentCode(HttpClient httpClient, string Code, string search, SalesOrderOrderBy orderBy, int page, int pageSize)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Code/{Code}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
		DataResult<IEnumerable<SalesOrder>> dataResult = new DataResult<IEnumerable<SalesOrder>>();
		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});

				dataResult.Data = Enumerable.Empty<SalesOrder>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}


		}
		else
		{
			dataResult.Data = Enumerable.Empty<SalesOrder>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
			return dataResult;
		}
	}
	public async Task<DataResult<IEnumerable<SalesOrder>>> GetObjectsByCurrentId(HttpClient httpClient, int ReferenceId, string search, SalesOrderOrderBy orderBy, int page, int pageSize)
	{
		HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/Current/Id/{ReferenceId}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
		DataResult<IEnumerable<SalesOrder>> dataResult = new DataResult<IEnumerable<SalesOrder>>();
		if (responseMessage.IsSuccessStatusCode)
		{
			var data = await responseMessage.Content.ReadAsStringAsync();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data))
				{
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
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
					var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
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
				var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});

				dataResult.Data = Enumerable.Empty<SalesOrder>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

				return dataResult;
			}


		}
		else
		{
			dataResult.Data = Enumerable.Empty<SalesOrder>();
			dataResult.IsSuccess = false;
			dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
			return dataResult;
		}
	}
    public async Task<DataResult<IEnumerable<SalesOrder>>> GetObjectsByCurrentIdAndWarehouseNumber(HttpClient httpClient, int ReferenceId,int WarehouseNumber, string search, SalesOrderOrderBy orderBy, int page, int pageSize)
    {
        HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/CurrentAndWarehouse/Id/{ReferenceId}&{WarehouseNumber}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
        DataResult<IEnumerable<SalesOrder>> dataResult = new DataResult<IEnumerable<SalesOrder>>();
        if (responseMessage.IsSuccessStatusCode)
        {
            var data = await responseMessage.Content.ReadAsStringAsync();
            if (data != null)
            {
                if (!string.IsNullOrEmpty(data))
                {
                    var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
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
                    var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
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
                var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                dataResult.Data = Enumerable.Empty<SalesOrder>();
                dataResult.IsSuccess = false;
                dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

                return dataResult;
            }


        }
        else
        {
            dataResult.Data = Enumerable.Empty<SalesOrder>();
            dataResult.IsSuccess = false;
            dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
            return dataResult;
        }
    }
    public async Task<DataResult<IEnumerable<SalesOrder>>> GetObjectsByCurrentIdAndWarehouseNumberAndShipInfo(HttpClient httpClient, int ReferenceId, int WarehouseNumber,int ShipInfoReferenceId, string search, SalesOrderOrderBy orderBy, int page, int pageSize)
    {
        HttpResponseMessage responseMessage = await httpClient.GetAsync($"{postUrl}/CurrentAndWarehouseAndShipInfo/Id/{ReferenceId}&{WarehouseNumber}&{ShipInfoReferenceId}?search={search}&orderBy={orderBy}&page={page}&pageSize={pageSize}");
        DataResult<IEnumerable<SalesOrder>> dataResult = new DataResult<IEnumerable<SalesOrder>>();
        if (responseMessage.IsSuccessStatusCode)
        {
            var data = await responseMessage.Content.ReadAsStringAsync();
            if (data != null)
            {
                if (!string.IsNullOrEmpty(data))
                {
                    var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
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
                    var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
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
                var result = JsonSerializer.Deserialize<DataResult<IEnumerable<SalesOrder>>>(data, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                dataResult.Data = Enumerable.Empty<SalesOrder>();
                dataResult.IsSuccess = false;
                dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

                return dataResult;
            }


        }
        else
        {
            dataResult.Data = Enumerable.Empty<SalesOrder>();
            dataResult.IsSuccess = false;
            dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
            return dataResult;
        }
    }


    public enum SalesOrderOrderBy
	{
		customernamedesc,
		customernameasc,
		customercodedesc,
		customercodeasc,
		nettotalasc,
		nettotaldesc,
		dateasc,
		datedesc,
	}
}
