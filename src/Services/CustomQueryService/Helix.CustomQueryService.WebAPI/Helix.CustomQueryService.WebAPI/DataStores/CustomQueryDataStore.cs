using Helix.CustomQueryService.WebAPI.Models;
using Helix.CustomQueryService.WebAPI.Services;
using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Reflection.Metadata;

namespace Helix.CustomQueryService.WebAPI.DataStores
{
	public class CustomQueryDataStore : ICustomQueryService
	{
		private LBSParameter? _parameter;
		public CustomQueryDataStore(LBSParameter? parameter)
		{
			_parameter = parameter;

		}
		public async IAsyncEnumerable<dynamic> GetAsync(string query)
		{
			await using (SqlConnection connection = new SqlConnection(_parameter.ToString()))
			{
				await connection.OpenAsync();
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (var reader = await command.ExecuteReaderAsync())
					{
						var names = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
						foreach (IDataRecord record in reader as IEnumerable)
						{
							var expando = new ExpandoObject() as IDictionary<string, object>;
							foreach (var name in names)
								expando[name] = record[name];

							yield return expando;
						}
					}
				}
			}
		}
	}
}
