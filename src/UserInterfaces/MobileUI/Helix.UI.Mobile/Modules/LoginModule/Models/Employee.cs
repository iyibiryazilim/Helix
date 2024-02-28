using Helix.UI.Mobile.Modules.BaseModule.Models;

namespace Helix.UI.Mobile.Modules.LoginModule.Models
{
	public class Employee
    {
        public Guid Oid { get; set; }
        public int ReferenceId { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ImageDto Image { get; set; }
    }
}
