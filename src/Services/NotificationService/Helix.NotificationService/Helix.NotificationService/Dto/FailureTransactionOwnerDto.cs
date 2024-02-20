namespace Helix.NotificationService.Dto
{
	public class FailureTransactionOwnerDto
	{
        public string? Message { get; set; }
        public Guid? Employee { get; set; }
        public string? Data { get; set; } = string.Empty;
    }
}
