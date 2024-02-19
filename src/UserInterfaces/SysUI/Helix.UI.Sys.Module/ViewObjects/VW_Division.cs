using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Helix.UI.Sys.Module.ViewObjects
{
    [Persistent("View_Division_003")]
    [DefaultProperty("Name")]
    [ImageName("BO_Address")]
    [NavigationItem("System Settings")]
    [DefaultClassOptions]
    public class VW_Division : XPLiteObject
    {
        private int _referenceId;
        private int _number;
        private string _name;
        public VW_Division(Session session) : base(session)
        {
        }

        [Key]
        [Browsable(false)]
        public int ReferenceId { get;set; }

        [ModelDefault("AllowEdit", "False")]
        public int Number { get;set; }

        [ModelDefault("AllowEdit", "False")]
        public string Name { get; set; }

    }

}
