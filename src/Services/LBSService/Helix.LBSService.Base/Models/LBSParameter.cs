namespace Helix.LBSService.Base.Models
{
	public static class LBSParameter
	{
		public static string Username { get; set; } = string.Empty;
		public static string Password { get; set; } = string.Empty;
		public static int FirmNumber { get; set; }
		public static int Period { get; set; } 
		public static bool IsTiger { get; set; } = false; 
		public static string Connection { get; set; } = string.Empty;
	}
}
