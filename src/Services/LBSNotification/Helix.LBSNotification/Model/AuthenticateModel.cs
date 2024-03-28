namespace Helix.LBSNotification.Model
{
    public class AuthenticateModel
    {
        public bool Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
