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
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        
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

        public string FirstName { get => _firstName; set=>SetPropertyValue(nameof(FirstName), ref _firstName, value); }
        
        public string LastName { get => _lastName; set =>SetPropertyValue(nameof(LastName), ref _lastName, value); }

        public string Email { get => _email; set =>SetPropertyValue(nameof(Email), ref _email, value); }

        public string Phone { get => _phone; set => SetPropertyValue(nameof(Phone), ref _phone, value); }

       




    }
}