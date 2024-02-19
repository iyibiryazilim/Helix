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
 
    public class Employee : BaseObject
    {
        private int _referenceId;
        private string _code;
        private string _name;
        private string _registerCode;
        
        public Employee(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }
        public int ReferenceId { get => _referenceId; set => SetPropertyValue(nameof(ReferenceId), ref _referenceId, value); }

        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }

        public string FirstName { get => _name; set=>SetPropertyValue(nameof(FirstName), ref _name, value); }
        
        

        public string RegisterCode { get => _registerCode; set =>SetPropertyValue(nameof(RegisterCode), ref _registerCode, value); }

      

       




    }
}