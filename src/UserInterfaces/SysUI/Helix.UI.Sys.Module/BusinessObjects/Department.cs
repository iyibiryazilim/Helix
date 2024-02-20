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
    [NavigationItem("System Settings")]
    public class Department : BaseObject
    {
        private string _code;
        private string _name;
        private string _description;
        private bool _isActive;


        public Department(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }
        public string Code { get => _code; set => SetPropertyValue(nameof(Code), ref _code, value); }
        public string Name { get => _name; set => SetPropertyValue(nameof(Name), ref _name, value); }
        public string Description { get => _description; set => SetPropertyValue(nameof(Description), ref _description, value); }
        public bool IsActive { get => _isActive; set => SetPropertyValue(nameof(IsActive), ref _isActive, value); }

        [Association("Department-Positions")]
        public XPCollection<Position>Positions =>GetCollection<Position>(nameof(Positions));
    }

}