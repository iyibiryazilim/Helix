using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace Helix.UI.Sys.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Transaction Audit")]

    public class FailureTransactionOwner : BaseObject
    {
        private Employee _employee;
        private string _message;
        private string _data;
        private bool _IsRead;
        public FailureTransactionOwner(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        public Employee Employee { get => _employee; set=>SetPropertyValue(nameof(Employee),ref _employee, value); }

        [Size(-1)]
        public string Message { get => _message; set => SetPropertyValue(nameof(Message), ref _message, value); }

        [Size(-1)]
        public string Data { get => _data; set=> SetPropertyValue(nameof(Data),ref _data, value); }

        public bool IsRead { get => _IsRead; set => SetPropertyValue(nameof(IsRead), ref _IsRead, value); }
        
    }
}