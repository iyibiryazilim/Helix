﻿using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;


namespace Helix.UI.Mobile.Modules.BaseModule.DataStores
{
	public class CustomQueryDataStore : ICustomQueryService
	{
		private string postUrl = "/gateway/customQuery/CustomQuery";
		public async Task<DataResult<dynamic>> GetObjectAsync(HttpClient httpClient, string query)
		{
			var content = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");
			//var content = new StringContent($"\"{query}\"", null, "application/json");

			HttpResponseMessage responseMessage = await httpClient.PostAsync(postUrl, content);
			DataResult<dynamic> dataResult = new();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonConvert.DeserializeObject<DataResult<IEnumerable<Dictionary<string, object>>>>(data);

						dataResult.Data = result?.Data.FirstOrDefault();
						dataResult.IsSuccess = true;
						dataResult.Message = "success";
						return dataResult;

					}
					else
					{
						var result = JsonConvert.DeserializeObject<DataResult<IEnumerable<Dictionary<string, object>>>>(data);

						dataResult.Data = result?.Data.FirstOrDefault();
						dataResult.IsSuccess = true;
						dataResult.Message = "empty";
						return dataResult;
					}

				}
				else
				{
					var result = JsonConvert.DeserializeObject<DataResult<IEnumerable<Dictionary<string, object>>>>(data);

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

		public async Task<DataResult<IEnumerable<dynamic>>> GetObjectsAsync(HttpClient httpClient, string query)
		{
			var content = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");
			//var content = new StringContent($"\"{query}\"", null, "application/json");

			HttpResponseMessage responseMessage = await httpClient.PostAsync(postUrl, content);
			DataResult<IEnumerable<dynamic>> dataResult = new DataResult<IEnumerable<dynamic>>();
			if (responseMessage.IsSuccessStatusCode)
			{
				var data = await responseMessage.Content.ReadAsStringAsync();
				if (data != null)
				{
					if (!string.IsNullOrEmpty(data))
					{
						var result = JsonConvert.DeserializeObject<DataResult<IEnumerable<Dictionary<string, object>>>>(data);

						dataResult.Data = result?.Data;
						dataResult.IsSuccess = true;
						dataResult.Message = "success";
						return dataResult;

					}
					else
					{
						var result = JsonConvert.DeserializeObject<DataResult<IEnumerable<Dictionary<string, object>>>>(data);

						dataResult.Data = result?.Data;
						dataResult.IsSuccess = true;
						dataResult.Message = "empty";
						return dataResult;
					}

				}
				else
				{
					var result = JsonConvert.DeserializeObject<DataResult<IEnumerable<Dictionary<string, object>>>>(data);

					dataResult.Data = Enumerable.Empty<dynamic>();
					dataResult.IsSuccess = false;
					dataResult.Message = await responseMessage.Content.ReadAsStringAsync();

					return dataResult;
				}


			}
			else
			{
				dataResult.Data = Enumerable.Empty<dynamic>();
				dataResult.IsSuccess = false;
				dataResult.Message = await responseMessage.Content.ReadAsStringAsync();
				return dataResult;
			}
		}
	}
}
