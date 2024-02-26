using Helix.UI.Mobile.Modules.LoginModule.Models;

namespace Helix.UI.Mobile.Modules.BaseModule.Models
{
    public class FailureTransactionOwner
    {
        public Guid Oid { get; set; }
        public Employee Employee{ get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
        public bool IsRead { get; set; }

    }
}
