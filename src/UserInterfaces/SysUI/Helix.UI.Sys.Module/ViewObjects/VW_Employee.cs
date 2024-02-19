using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Helix.UI.Sys.Module.ViewObjects
{
    [DefaultClassOptions]
    [DomainComponent]
    public class VW_Employee 
    {
        public VW_Employee()
        {
        }

        
        [Browsable(false)]
        [Key]
        public int ReferenceId { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string Code { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string FirstName { get; set; }

        [ModelDefault("AllowEdit", "false")]
        public string RegisterCode { get; set; }
        


    }
}
