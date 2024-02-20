namespace Helix.UI.Mobile.Modules.LoginModule.Models
{
    public class DataResult<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }
    }
}
