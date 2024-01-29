namespace Helix.LBSService.WebAPI.Models
{
	public class LBSParameterModel
	{
		public  string Username { get; set; } = string.Empty;
		public  string Password { get; set; } = string.Empty;
		public  int FirmNumber { get; set; }
		public  bool IsTiger { get; set; } = false;

	}
}
