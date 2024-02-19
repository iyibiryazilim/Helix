using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Helix.UI.Sys.Module.ViewObjects
{
    [Persistent("View_WaitingSalesOrder_003_01")]
    [NavigationItem("Sales Management")]
    [ImageName("BO_Order")]
    [DefaultClassOptions]
    public class VW_WaitingSalesOrder : XPLiteObject
    {
        public VW_WaitingSalesOrder(Session session) : base(session)
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
