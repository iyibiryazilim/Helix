using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
    public interface IWorkOrderService
	{
		public Task<DataResult<WorkOrderDto>> Inserts(WorkOrdersDto dto);
        public Task<DataResult<WorkOrderDto>> Insert(WorkOrderDto dto); 
        public Task<DataResult<WorkOrderDto>> InsertStopTransaction(StopTransactionForWorkOrderDto dto);
		public Task<DataResult<WorkOrderDto>> InsertWorkOrderStatus(WorkOrderChangeStatusDto dto);
	}
}