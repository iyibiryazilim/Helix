namespace Helix.LBSService.WebAPI.DTOs
{
	public class OrderLineDto
	{
		public string ProductCode { get; set; }
		public int Quantity { get; set; }
        public double VatRate { get; set; }
        public double Price { get; set; }
		public double EdtCurr { get; set; } 
		public double EdtPrice{ get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string UnitsetCode { get; set; } = string.Empty;
		public short WarehouseNumber { get; set; } = default;
    }
}
