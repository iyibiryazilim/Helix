namespace Helix.LBSService.Base.Models
{
	public static class LBSParameter
	{
		public static string Username { get; set; } = string.Empty;
		public static string Password { get; set; } = string.Empty;
		public static int FirmNumber { get; set; }
		public static int Period { get; set; }
		public static string DB_DataSource { get; set; } = string.Empty;
		public static string DB_UserId { get; set; } = string.Empty;
		public static string DB_Password { get; set; } = string.Empty;
		public static string DB_InitialCatalog { get; set; } = string.Empty;
		public static bool IsTiger { get; set; } = false;

		public static string Connection
		{
			get => $"Data Source={DB_DataSource};User ID={DB_UserId};Password={DB_Password};Initial Catalog={DB_InitialCatalog};";
			set { } // Empty set to avoid compiler warning
		}
	}
}
