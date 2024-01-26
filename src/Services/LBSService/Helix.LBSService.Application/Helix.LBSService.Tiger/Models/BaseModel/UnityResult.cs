namespace Helix.LBSService.Tiger.Models.BaseModel
{
	public class UnityResult
	{
		public bool IsSuccess { get; set; } = false;
		public object? Data { get; set; }
		public string Message { get; set; } = string.Empty;
	}
}
