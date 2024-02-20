using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace Helix.UI.Sys.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Transaction Audit")]
    public class TransactionOwner : BaseObject
    { 
        private Employee _employee;
        private int _ficheReferenceId;
       

        public TransactionOwner(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }
        
        public Employee Employee { get => _employee; set => SetPropertyValue(nameof(Employee), ref _employee, value); }

        public int FicheReferenceId { get => _ficheReferenceId; set=>SetPropertyValue(nameof(FicheReferenceId),ref _ficheReferenceId, value); }
  

    }
}