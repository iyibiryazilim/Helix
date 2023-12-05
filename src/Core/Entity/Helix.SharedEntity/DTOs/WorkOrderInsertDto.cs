using Helix.SharedEntity.DTOs.Base;

namespace Helix.SharedEntity.DTOs
{
	public class WorkOrderInsertDto : BaseDto
	{
        public WorkOrderInsertDto()
        {
            WorkOrders = new List<WorkOrderDto>();
        }
        public IList<WorkOrderDto> WorkOrders { get; set; }
    }
}
