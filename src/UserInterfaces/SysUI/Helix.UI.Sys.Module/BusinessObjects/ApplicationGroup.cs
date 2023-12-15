using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Helix.UI.Sys.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class ApplicationGroup : BaseObject
    {
        private int _referenceId;
        private string _name;
        private string _code;

        public ApplicationGroup(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        [ModelDefault("AllowEdit","False")]
        public int ReferenceId { get =>_referenceId; set=>SetPropertyValue(nameof(ReferenceId),ref _referenceId,value); }
        
        [RuleRequiredField]
        public string Name { get => _name; set => SetPropertyValue(nameof(Name), ref _name, value); }

        [RuleRequiredField]
        [RuleUniqueValue]
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }

        [Association("UserAssignGroup")]
        public XPCollection<ApplicationUser> Users => GetCollection<ApplicationUser>(nameof(Users));


    }
}