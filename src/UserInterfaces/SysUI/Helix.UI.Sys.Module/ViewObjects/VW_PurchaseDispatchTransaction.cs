using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Helix.UI.Sys.Module.ViewObjects
{
    [NavigationItem("Purchase Management")]
    [Persistent("View_PurchaseDispatchTransaction_003_01")]
    [DefaultClassOptions]
    public class VW_PurchaseDispatchTransaction : XPLiteObject
    {
        public VW_PurchaseDispatchTransaction(Session session) : base(session)
        {
        }

        [Key]
        [Browsable(false)]
        public int ReferenceId { get; set; }

        [Browsable(false)]
        public short TransactionType { get; set; }


        [ModelDefault("AllowEdit", "False")]
        public string TransactionTypeName
        {
            get
            {
                switch (TransactionType)
                {
                    case 1:
                        return "Satınalma İrsaliyesi";
                    case 7:
                        return "Perakende Satış İrsaliyesi";
                    case 8:
                        return "Toptan Satış İrsaliyesi";
                    default:
                        return "Diğer";
                }
            }
        }
        [ModelDefault("AllowEdit", "False")]
        public DateTime DispatchDate { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string FicheNumber { get; set; }

        [Browsable(false)]
        public int ProductReferenceId { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string ProductName { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string ProductCode { get; set; }

        [Browsable(false)]
        public int SubUnitsetReferenceId { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string SubUnitsetCode { get; set; }

        [Browsable(false)]
        public int UnitsetReferenceId { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string UnitsetCode { get; set; }

        [Browsable(false)]
        public int CurrentReferenceId { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string CurrentCode { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string CurrentName { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public double Quantity { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public short WarehouseNumber { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string WarehouseName { get; set; }

        [Browsable(false)]
        public short DivisionNumber { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string DivisionName { get; set; }
    }
}
