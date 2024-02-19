using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Helix.UI.Sys.Module.ViewObjects
{
    [DefaultClassOptions]
    [NavigationItem("Sales Management")]
    [ImageName("BO_Employee")]
    [Persistent("View_Customer_003")]
    public class VW_Customer : XPLiteObject
    {
        public VW_Customer(Session session) : base(session)
        {
        }
        [Browsable(false)]
        [Key]
        public int ReferenceId { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string Code { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string Title { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string Telephone { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string OtherTelephone { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string TaxOffice { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string Email { get; set; }
        [ModelDefault("AllowEdit", "false")]
        public string TaxNumber { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string Address { get; set; }
    }
}
