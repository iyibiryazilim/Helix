using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace Helix.UI.Sys.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(false)]
    public class TransactionOwner : BaseObject
    { 
        private Employee _employee;
        private int _ficheReferenceId;
        private bool _isRead;
       

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

        public bool IsRead { get => _isRead; set => SetPropertyValue(nameof(IsRead), ref _isRead, value); }
  

    }
}