using Helix.CustomQueryService.WebAPI.Models;
using Helix.CustomQueryService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Helix.CustomQueryService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomQueryController : ControllerBase
	{
		ICustomQueryService _service;
         public CustomQueryController(ICustomQueryService service)
        {
			_service = service;

		}
        [HttpPost]
		public async Task<DataResult<List<dynamic>>> GetAsync([FromBody] string query)
		{
			DataResult<List<dynamic>> dataResult = new();
			dataResult.Data = new List<dynamic>();

			try
			{
				var result = _service.GetAsync(query);

				await foreach (var item in result)
				{
					dataResult.Data.Add(item);
				}

				dataResult.IsSuccess = true;
				dataResult.Message = "succes";
			}
			catch (Exception ex)
			{
				dataResult.IsSuccess = false;
				dataResult.Message = ex.Message;
			}

			return dataResult;
		}

		private void HandleException(DataResult<dynamic> dataResult, Exception ex)
		{
			dataResult.IsSuccess = false;
			dataResult.Message = ex.Message;
			// You might want to log the exception here for better debugging
		}
	}
}
