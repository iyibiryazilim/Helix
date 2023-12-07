namespace Helix.PurchaseService.Domain.Models
{
	public class Supplier
	{
        public int ReferenceId { get; set; }
		public string Code { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
        public string MyProperty { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string OtherTelephone { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string WebAddress { get; set; } = string.Empty;
		public string TaxOffice { get; set; } = string.Empty;
		public string TaxNumber { get; set; } = string.Empty;
		public short CardType { get; set; } = default;
		public string County { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public string Country { get; set; } = string.Empty;
		public int ReferenceCount { get; set; } = default;
		public double NetTotal { get; set; } = default;
        public DateTime? LastTransactionDate { get; set; }
        public TimeSpan? LastTransactionTime { get; set; }
		public string Image { get; set; } = string.Empty; 		 
	}
}
