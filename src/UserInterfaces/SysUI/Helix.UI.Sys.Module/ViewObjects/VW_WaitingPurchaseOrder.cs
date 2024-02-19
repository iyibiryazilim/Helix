using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Helix.UI.Sys.Module.ViewObjects
{
    [NavigationItem("Purchase Management")]
    [Persistent("View_WaitingPurchaseOrder_003_01")]
    [ImageName("BO_Order")]
    [DefaultClassOptions]
    
    
    public class VW_WaitingPurchaseOrder : XPLiteObject
    {
        public VW_WaitingPurchaseOrder(Session session) : base(session)
        {
            
        }
        [Key]
        [Browsable(false)]
        public int? ReferenceId { get; set; }

        [Browsable(false)]
        public short? TransactionType { get; set; }

        [Browsable(false)]
        public int? ProductReferenceId { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string ProductCode { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string ProductName { get; set; }

        [Browsable(false)]
        public int? UnitsetReferenceId { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string UnitsetCode { get; set; }

        [Browsable(false)]
        public int? SubUnitsetReferenceId { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string SubUnitsetCode { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public double? Quantity { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public double? ShippedQuantity { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public double WaitingQuantity { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public double? UnitPrice { get; set; }


        [ModelDefault("AllowEdit", "False")]
        [Browsable(false)]
        public short? DivisionNumber { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string DivisionName { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string WarehouseName { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public short? WarehouseNumber { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public DateTime? DueDate { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public double? NetTotal { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string Description { get; set; }


        [ModelDefault("AllowEdit", "False")]
        public DateTime? OrderDate { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string OrderCode { get; set; }

        [Browsable(false)]
        public int? CurrentReferenceId { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string CurrentCode { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string CurrentName { get; set; }
    }
}
