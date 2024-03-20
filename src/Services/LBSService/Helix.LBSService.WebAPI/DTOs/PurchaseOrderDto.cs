namespace Helix.LBSService.WebAPI.DTOs
{
	public class PurchaseOrderDto : OrderDto
	{
		public IList<PurchaseOrderLineDto> Lines { get; set; }

		public PurchaseOrderDto()
		{
			Lines = new List<PurchaseOrderLineDto>();
		}
	}

	public class PurchaseOrderLineDto : OrderLineDto
	{
		public PurchaseOrderLineDto()
		{

		}
	}
}
