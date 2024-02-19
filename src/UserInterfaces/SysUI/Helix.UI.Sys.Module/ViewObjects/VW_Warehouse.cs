using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Helix.UI.Sys.Module.ViewObjects
{
    [DefaultClassOptions]
    [Persistent("View_Warehouse_003")]
    [NavigationItem("System Settings")]
    [ImageName("BO_Address")]
    [DefaultProperty("Name")]

    public class VW_Warehouse : XPLiteObject
    {
        public VW_Warehouse(Session session) : base(session)
        {
        }

        [Key]
        [ModelDefault("AllowEdit", "false")]
        [Browsable(false)]
        public int ReferenceId { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string Name { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public int Number { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string DivisionName { get; set; }

        [ModelDefault("AllowEdit", "false")]
        [Browsable(false)]
        public int DivisionNumber { get; set; }
    }
}
