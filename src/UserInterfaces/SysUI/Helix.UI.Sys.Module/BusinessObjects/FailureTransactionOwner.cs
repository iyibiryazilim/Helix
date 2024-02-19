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
    public class FailureTransactionOwner : BaseObject
    {
        private ApplicationUser _applicationUser;
        private string _message;
        private string _data;
        public FailureTransactionOwner(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }
        public ApplicationUser ApplicationUser { get => _applicationUser; set=>SetPropertyValue(nameof(ApplicationUser),ref _applicationUser, value); }

        [Size(-1)]
        public string Message { get => _message; set => SetPropertyValue(nameof(Message), ref _message, value); }

        public string Data { get => _data; set=> SetPropertyValue(nameof(Data),ref _data, value); }
        
    }
}