using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
{
	public class WorkOrderDataStore : BaseDataStore, IWorkOrderService
	{
		public WorkOrderDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<WorkOrder>> GetWorkOrderById(int id)
		{
			var result = new SqlQueryHelper<WorkOrder>().GetObjectAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByProductionOrderCode(string code)
		{
			var result = new SqlQueryHelper<WorkOrder>().GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByProductionOrderCode(code));
			return result;
		}

		public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByProductionOrderId(int id)
		{
			var result = new SqlQueryHelper<WorkOrder>().GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByProductionOrderId(id));
			return result;
		}

		public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByStatus(int[] status)
		{
			var result = new SqlQueryHelper<WorkOrder>().GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByStatus(status));
			return result;
		}

		public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByWorkstationCode(string code)
		{
			var result = new SqlQueryHelper<WorkOrder>().GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByWorkstationCode(code));
			return result;
		}

		public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByWorkstationId(int id)
		{
			var result = new SqlQueryHelper<WorkOrder>().GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByWorkstationId(id));
			return result;
		}

		public Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderList()
		{
			var result = new SqlQueryHelper<WorkOrder>().GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderList());
			return result;
		}
	}
}
