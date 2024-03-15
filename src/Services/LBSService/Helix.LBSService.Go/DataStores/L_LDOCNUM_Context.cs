using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Helix.LBSService.Go.DataStores
{
	public class L_LDOCNUM_Context : IL_LDOCNUM_Context
	{
		readonly IEventBus _eventBus;
		readonly int _defaultFirmNumber = LBSParameter.FirmNumber;
 		readonly string _connectionString = LBSParameter.Connection;
		readonly Logger<L_LDOCNUM_Context> _logger;

		public L_LDOCNUM_Context(IEventBus eventBus, Logger<L_LDOCNUM_Context> logger)
		{
			_eventBus = eventBus;
			_logger = logger;
		}
		public async Task<string> GetLastAsgn(string effsdate, string effedate, int TRCODE)
		{
			try
			{
				var lastNumber = string.Empty;
				string query = $"SELECT TOP 1 LASTASGND as lastNumber FROM L_LDOCNUM WHERE EFFSDATE<='{effsdate}' AND EFFEDATE>='{effedate}' AND FIRMID={_defaultFirmNumber} AND DOCIDEN = {TRCODE}";

				await using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					await connection.OpenAsync();
					await using (SqlCommand command = new SqlCommand(query, connection))
					{
						SqlDataReader dr = await command.ExecuteReaderAsync();
						await dr.ReadAsync(); // Veri okuma işlemine başla  
						if (dr.HasRows)
						{
							lastNumber = dr["lastNumber"].ToString();
						}
						else
						{
							throw new Exception("No data found");
						}
					}
					await connection.CloseAsync();
					if (string.IsNullOrEmpty(lastNumber))
					{
						throw new Exception("No data found");
					}
					return lastNumber; 
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while getting last L_LDOCNUM  object.");

				throw;
			}
		}

		public async Task<int> UpdateObject(string lastAsgnd, string effsdate, string effedate, int TRCODE)
		{
			try
			{
				string query = $@"UPDATE L_LDOCNUM SET LASTASGND = '{lastAsgnd}'
				 WHERE EFFSDATE<='{effsdate}' AND EFFEDATE>='{effedate}' AND FIRMID={_defaultFirmNumber} AND DOCIDEN ={TRCODE} ";
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					await connection.OpenAsync();
					await using (SqlCommand command = new SqlCommand(query, connection))
					{
						return await command.ExecuteNonQueryAsync();
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while updation L_LDOCNUM  object.");

				throw;
			}
		}
	}
}
