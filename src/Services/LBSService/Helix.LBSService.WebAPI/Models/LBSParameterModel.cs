namespace Helix.LBSService.WebAPI.Models
{
	public class LBSParameterModel
	{
		public string Username { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public int FirmNumber { get; set; }
		public int Period { get; set; }
		public string DB_DataSource { get; set; } = string.Empty;
		public string DB_UserId { get; set; } = string.Empty;
		public string DB_Password { get; set; } = string.Empty;
		public string DB_InitialCatalog { get; set; } = string.Empty;
		public bool IsTiger { get; set; } = false;
		public string Connection { get; set; } = string.Empty;
	}
}