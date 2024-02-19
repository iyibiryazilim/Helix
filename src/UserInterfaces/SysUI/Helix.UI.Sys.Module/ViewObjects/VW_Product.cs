using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Helix.UI.Sys.Module.ViewObjects
{
    [Persistent("View_Product_003")]
    [DefaultClassOptions]
    [ImageName("BO_Product")]
    [NavigationItem("Product Management")]
    [DefaultProperty("Name")]
    public class VW_Product : XPLiteObject
    {
        public VW_Product(Session session) : base(session)
        {
        }

        [Browsable(false)]
        [Key]
        public int ReferenceId { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string Name { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string Code { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string SpeCode { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string SubUnitset { get; set; }

        [Browsable(false)]
        public int SubUnitsetReferenceId { get; set; }

        [Browsable(false)]
        public int UnitsetReferenceId { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string Unitset { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public double StockQuantity { get; set; }

        [ModelDefault("AllowEdit", "False")]
        [Browsable(false)]
        public short CardType { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public string CardTypeName
        {
            get
            {
                switch (CardType)
                {
                    case 1:
                        return "Ticari Ürün";
                    case 10:
                        return "Hammadde";
                    case 11:
                        return "Yarı Mamul";
                    case 12:
                        return "Mamul";
                    default:
                        return "Diğer";
                }
            }
        }

    }
}
