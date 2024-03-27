using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Events;
using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        private readonly IWorkOrderService _workOrderService;
        private readonly IEventBus _eventBus;

        public WorkOrderController(IWorkOrderService workOrderService, IEventBus eventBus)
        {
            _workOrderService = workOrderService;
            _eventBus = eventBus;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<WorkOrderDto>> Insert([FromBody] WorkOrderDto dto)
        {
            try
            {
                var result = await _workOrderService.Insert(dto);

                return new DataResult<WorkOrderDto>()
                {
                    Data = null,
                    Message = result.Message,
                    IsSuccess = result.IsSuccess,
                };
            }
            catch (Exception ex)
            {
                _eventBus.Publish(new SYSMessageIntegrationEvent(0, false, ex.Message, null, dto));
                _eventBus.Publish(new LOGOFailureIntegrationEvent(0, ex.Message, null, dto));
                return new DataResult<WorkOrderDto>()
                {
                    Data = null,
                    Message = ex.Message + "----" + ex.StackTrace,
                    IsSuccess = false,
                };
            }
        }

        [HttpPost("Inserts")]
        public async Task<DataResult<WorkOrderDto>> Inserts([FromBody] WorkOrdersDto dto)
        {
            try
            {
                var result = await _workOrderService.Inserts(dto);

                return new DataResult<WorkOrderDto>()
                {
                    Data = null,
                    Message = result.Message,
                    IsSuccess = result.IsSuccess,
                };
            }
            catch (Exception ex)
            {
                _eventBus.Publish(new SYSMessageIntegrationEvent(0, false, ex.Message, null, dto));
                _eventBus.Publish(new LOGOFailureIntegrationEvent(0, ex.Message, null, dto));
                return new DataResult<WorkOrderDto>()
                {
                    Data = null,
                    Message = ex.Message + "----" + ex.StackTrace,
                    IsSuccess = false,
                };
            }
        }

        [HttpPost("StopTransaction")]
        public async Task<DataResult<WorkOrderDto>> InsertStopTransaction([FromBody] StopTransactionForWorkOrderDto dto)
        {
            try
            {
                var result = await _workOrderService.InsertStopTransaction(dto);

                return new DataResult<WorkOrderDto>()
                {
                    Data = null,
                    Message = result.Message,
                    IsSuccess = result.IsSuccess,
                };
            }
            catch (Exception ex)
            {
                _eventBus.Publish(new SYSMessageIntegrationEvent(0, false, ex.Message, null, dto));
                _eventBus.Publish(new LOGOFailureIntegrationEvent(0, ex.Message, null, dto));
                return new DataResult<WorkOrderDto>()
                {
                    Data = null,
                    Message = ex.Message + "----" + ex.StackTrace,
                    IsSuccess = false,
                };
            }
        }

        [HttpPost("Status")]
        public async Task<DataResult<WorkOrderDto>> InsertChangeStatus([FromBody] WorkOrderChangeStatusDto dto)
        {
            try
            {
                var result = await _workOrderService.InsertWorkOrderStatus(dto);

                return new DataResult<WorkOrderDto>()
                {
                    Data = null,
                    Message = result.Message,
                    IsSuccess = result.IsSuccess,
                };
            }
            catch (Exception ex)
            {
                _eventBus.Publish(new SYSMessageIntegrationEvent(0, false, ex.Message, null, dto));
                _eventBus.Publish(new LOGOFailureIntegrationEvent(0, ex.Message, null, dto));
                return new DataResult<WorkOrderDto>()
                {
                    Data = null,
                    Message = ex.Message + "----" + ex.StackTrace,
                    IsSuccess = false,
                };
            }
        }
    }
}