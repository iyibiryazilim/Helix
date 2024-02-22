using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Helix.UI.Sys.Module.ViewObjects
{
    [DefaultClassOptions]
    [Persistent("View_TransactionOwner")]
    [NavigationItem("Transaction Audit")]
    public class VW_TransactionOwner : XPLiteObject
    {
        public VW_TransactionOwner(Session session) : base(session)
        {
        }

        [Key]
        [Browsable(false)]
        public Guid Oid { get; set; }

        [Browsable(false)]
        public int FicheReferenceId { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string FicheNumber { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public DateTime FicheDate { get; set; }

        [Browsable(false)]
        public short FicheType { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string FicheTypeName
        {
            get
            {

                switch (FicheType)
                {
                    case 1:
                        return "Satınalma İrsaliyesi";
                    case 2:
                        return "Perakende Satış İade İrsaliyesi";
                    case 3:
                        return "Toptan Satış İade İrsaliyesi";
                    case 4:
                        return "Konsinye Çıkış İade İrsaliyesi";
                    case 5:
                        return "Konsinye Giriş İade İrsaliyesi";
                    case 6:
                        return "Alım İade İrsaliyesi";
                    case 7:
                        return "Perakende Satış İrsaliyesi";
                    case 8:
                        return "Toptan Satış İrsaliyesi";
                    case 9:
                        return "Konsinye Çıkış İrsaliyesi";
                    case 10:
                        return "Konsinye Giriş İade İrsaliyesi";
                    case 13:
                        return "Üretimden Giriş Fişi";
                    case 14:
                        return "Devir Fişi";
                    case 12:
                        return "Sarf Fişi";
                    case 11:
                        return "Fire Fişi";
                    case 25:
                        return "Ambar Fişi";
                    case 26:
                        return "Mustahsil İrsaliyesi";
                    case 50:
                        return "Sayım Fazlası Fişi";
                    case 51:
                        return "Sayım Eksiği Fişi";
                    default:
                        return "Diğer";
                }
            }
        }

        [ModelDefault("AllowEdit", "False")]    
        public string EmployeeName { get; set; }
    }
}
