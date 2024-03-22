namespace Helix.LBSService.WebAPI.DTOs
{
	public class SalesOrderDto : OrderDto
	{
		public IList<SalesOrderLineDto> Lines { get; set; }

		public SalesOrderDto()
		{
			Lines = new List<SalesOrderLineDto>();
		}
	}

	public class SalesOrderLineDto : OrderLineDto
	{
		public SalesOrderLineDto()
		{
		}
	}
}