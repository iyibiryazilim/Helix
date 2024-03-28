using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Events;
using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WastageTransactionController : ControllerBase
	{
		private readonly IWastageTransactionService _service;
		private readonly ILogger<WastageTransactionController> _logger;
		private readonly IEventBus _eventBus;

		public WastageTransactionController(ILogger<WastageTransactionController> logger, IWastageTransactionService service, IEventBus eventBus)
		{
			_logger = logger;
			_service = service;
			_eventBus = eventBus;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<WastageTransactionDto>> Insert([FromBody] WastageTransactionDto dto)
		{
			try
			{
				var result = await _service.Insert(dto);
				if (result.IsSuccess)
				{
					//_eventBus.Publish(new SYSMessageIntegrationEvent(dto.ReferenceId, result.IsSuccess, result.Message, string.IsNullOrEmpty(dto.EmployeeOid) ? null : new Guid(dto.EmployeeOid), dto));
					//_eventBus.Publish(new LOGOSuccessIntegrationEvent(dto.ReferenceId, result.Message, string.IsNullOrEmpty(dto.EmployeeOid) ? null : new Guid(dto.EmployeeOid), dto));
				}
				else
				{
					//_eventBus.Publish(new SYSMessageIntegrationEvent(dto.ReferenceId, result.IsSuccess, result.Message, string.IsNullOrEmpty(dto.EmployeeOid) ? null : new Guid(dto.EmployeeOid), dto));
					//_eventBus.Publish(new LOGOFailureIntegrationEvent(dto.ReferenceId, result.Message, string.IsNullOrEmpty(dto.EmployeeOid) ? null : new Guid(dto.EmployeeOid), dto));
				}
				return result;
			}
			catch (Exception ex)
			{
				//_eventBus.Publish(new SYSMessageIntegrationEvent(dto.ReferenceId, false, ex.Message, string.IsNullOrEmpty(dto.EmployeeOid) ? null : new Guid(dto.EmployeeOid), dto));
				//_eventBus.Publish(new LOGOFailureIntegrationEvent(dto.ReferenceId, ex.Message, string.IsNullOrEmpty(dto.EmployeeOid) ? null : new Guid(dto.EmployeeOid), dto));
				_logger.LogError(ex, "WastageTransactionController.Insert");
				return new DataResult<WastageTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}
	}
}