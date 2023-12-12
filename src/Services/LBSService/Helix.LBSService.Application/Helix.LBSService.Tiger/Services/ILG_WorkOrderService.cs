using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_WorkOrderService
	{
		Task<DataResult<WorkOrderDto>> Insert(WorkOrdersDto dto);
		Task<DataResult<WorkOrderDto>> InsertStopTransaction(StopTransactionForWorkOrderDto dto);
		Task<DataResult<WorkOrderDto>> InsertWorkOrderStatus(WorkOrderChangeStatusDto dto);
	}
}
