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
    
    public class ConnectionParameter : BaseObject
    {

        private string _dataSource;
        private string _initialCatalog;
        private string _userId;
        private string _password;
        private int _defaultFirmNumber;
        private int _defaultPeriodNumber;
        private bool _isActive;

        public ConnectionParameter(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        public string DataSource { get => _dataSource; set => SetPropertyValue(nameof(DataSource), ref _dataSource, value); }
        public string InitialCatalog { get => _initialCatalog; set => SetPropertyValue(nameof(InitialCatalog), ref _initialCatalog, value); }
        public string UserId { get => _userId; set => SetPropertyValue(nameof(UserId), ref _userId, value); }
        public string Password { get => _password; set => SetPropertyValue(nameof(Password), ref _password, value); }
        public int DefaultFirmNumber { get => _defaultFirmNumber; set => SetPropertyValue(nameof(DefaultFirmNumber), ref _defaultFirmNumber, value); }
        public int DefaultPeriodNumber { get => _defaultPeriodNumber; set => SetPropertyValue(nameof(DefaultPeriodNumber), ref _defaultPeriodNumber, value); }
        public bool IsActive { get => _isActive; set => SetPropertyValue(nameof(IsActive), ref _isActive, value); }
        public string ConnectionString => $"Data Source={DataSource};Initial Catalog={InitialCatalog};User ID={UserId};Password={Password};";

    }
}