using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using Helix.ProductService.Domain.Models;
using Microsoft.Extensions.Configuration;


namespace Helix.ProductService.Infrastructure.Helpers;

public class SqlQueryHelper<T> where T : class
{
    IConfiguration _configuration;
    public SqlQueryHelper(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<DataResult<IEnumerable<T>>> GetObjectsAsync(string query)
    {
        DataResult<IEnumerable<T>> dataResult = new();
        try
        {
            DataTable datatable = new();
            await using (SqlConnection connection = new(_configuration.GetConnectionString("LBSConnectionString")))
            {
                await connection.OpenAsync();
                using (SqlDataAdapter adapter = new(query, connection))
                {
                    await Task.Run(() => adapter.Fill(datatable));
                }
            }
            var json = JsonConvert.SerializeObject(datatable);
            var obj = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            if (obj != null)
            {
                dataResult = new DataResult<IEnumerable<T>>()
                {
                    Data = obj,
                    IsSuccess = true,
                    Message = "Success",
                    TotalRecord = obj.Count()
                };
            }
            else
            {
                dataResult = new DataResult<IEnumerable<T>>()
                {
                    Data = obj,
                    IsSuccess = false,
                    Message = "Object is null",
                    TotalRecord = 0
                };
            }
        }
        catch (Exception ex)
        {
            dataResult = new DataResult<IEnumerable<T>>()
            {
                Data = null,
                IsSuccess = false,
                Message = ex.Message,
                TotalRecord = 0
            };
        }
        return dataResult;

    }

    public async Task<DataResult<T>> GetObjectAsync(string query)
    {
        DataResult<T> dataResult = new();
        try
        {
            DataTable datatable = new();
            await using (SqlConnection connection = new(_configuration.GetConnectionString("LBSConnectionString")))
            {
                await connection.OpenAsync();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    await Task.Run(() => adapter.Fill(datatable));
                }
            }
            var json = JsonConvert.SerializeObject(datatable);
            var obj = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            if (obj != null)
            {
                dataResult = new DataResult<T>()
                {
                    Data = obj.FirstOrDefault(),
                    IsSuccess = true,
                    Message = "Success",
                    TotalRecord = obj.Count()
                };
            }
            else
            {
                dataResult = new DataResult<T>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Object is null",
                    TotalRecord = 0
                };
            }
        }
        catch (Exception ex)
        {
            dataResult = new DataResult<T>()
            {
                Data = null,
                IsSuccess = false,
                Message = ex.Message,
                TotalRecord = 0
            };
        }
        return dataResult;

    }
}
