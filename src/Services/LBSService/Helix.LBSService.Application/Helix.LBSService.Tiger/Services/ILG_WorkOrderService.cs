using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_WorkOrderService
	{
		Task<DataResult<WorkOrderDto>> Inserts(WorkOrdersDto dto);
        Task<DataResult<WorkOrderDto>> Insert(WorkOrderDto dto); 
        Task<DataResult<WorkOrderDto>> InsertStopTransaction(StopTransactionForWorkOrderDto dto); 
		Task<DataResult<WorkOrderDto>> InsertWorkOrderStatus(WorkOrderChangeStatusDto dto);
	}
}