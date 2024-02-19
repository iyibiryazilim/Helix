using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Helix.UI.Sys.Module.ViewObjects
{
    [Persistent("View_Supplier_003")]
    [DefaultClassOptions]
    [ImageName("BO_Employee")]
    [NavigationItem("Purchase Management")]
    public class VW_Supplier : XPLiteObject
    {
        public VW_Supplier(Session session) : base(session)
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
