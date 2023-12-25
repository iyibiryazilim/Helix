using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helix.FinanceService.Domain.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Helix.FinanceService.Infrastructure.Helpers;

public class SqlQueryHelper<T> where T : class
{
    public async Task<DataResult<IEnumerable<T>>> GetObjectsAsync(string query)
    {
        DataResult<IEnumerable<T>> dataResult = new();
        try
        {
            DataTable datatable = new();
            await using (SqlConnection connection = new("Data Source=172.25.86.103; User id= sa; Password = iyibir!*#16730000; Initial Catalog = TIGER3ENTERPRISE; TrustServerCertificate=True"))
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
            await using (SqlConnection connection = new("Data Source=172.25.86.103; User id= sa; Password = iyibir!*#16730000; Initial Catalog = TIGER3ENTERPRISE; TrustServerCertificate=True"))
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
