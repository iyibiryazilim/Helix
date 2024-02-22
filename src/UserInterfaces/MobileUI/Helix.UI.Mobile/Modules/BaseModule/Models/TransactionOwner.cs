using Helix.UI.Mobile.Modules.LoginModule.Models;

namespace Helix.UI.Mobile.Modules.BaseModule.Models
{
    public class TransactionOwner
    {
        public Guid Oid { get; set; }
        public bool IsRead { get; set; }
        public int FicheReferenceId { get; set; }
        public Employee Employee { get; set; }
    }
}
