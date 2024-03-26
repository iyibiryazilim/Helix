namespace Helix.DemandService.Domain.Dtos
{
	public class DemandDto
	{
		public DemandDto()
		{
			Lines = new List<DemandLineDto>();
		}

		public int ReferenceId { get; set; } = default;
		public DateTime Date { get; set; } = DateTime.Now;
		public string DocumentNumber { get; set; } = string.Empty;
		public string SpeCode { get; set; } = string.Empty;
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public string ProjectCode { get; set; } = string.Empty;
		public IList<DemandLineDto> Lines { get; set; }
	}
}