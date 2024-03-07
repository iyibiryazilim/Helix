using Helix.ProductionService.Domain.Models;

namespace Helix.ProductionService.Application.Services;

public interface IWorkOrderService
{
	public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderList();
	public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByStatus(int[] status);
	public Task<DataResult<WorkOrder>> GetWorkOrderById(int id);
	public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByWorkstationId(int id);
	public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByWorkstationCode(string code);
	public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByProductionOrderId(int id);
	public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByProductionOrderCode(string code);

	public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByProductId(int id);
}
