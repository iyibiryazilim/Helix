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
using static DevExpress.DataProcessing.InMemoryDataProcessor.AddSurrogateOperationAlgorithm;

namespace Helix.UI.Sys.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // 
    public class TransactionOwner : BaseObject
    { 
        private Employee _employee;
        private int _ficheReferanceId;
       

        public TransactionOwner(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }
        
        public Employee Employee { get => _employee; set => SetPropertyValue(nameof(Employee), ref _employee, value); }

        public int FicheReferanceId { get => _ficheReferanceId; set=>SetPropertyValue(nameof(FicheReferanceId),ref _ficheReferanceId, value); }
  

    }
}