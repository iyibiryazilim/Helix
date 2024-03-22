namespace Helix.LBSService.WebAPI.Helper
{
	public static class Global
	{
		public static UnityObjects.UnityApplication UnityApp = new UnityObjects.UnityApplication();
		public static bool IsTiger { get; private set; }

		public static void Initialize(IConfiguration configuration)
		{
			IsTiger = configuration.GetValue<bool>("YourConfigKey");
		}
	}
}