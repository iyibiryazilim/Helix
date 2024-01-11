using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
    public class BarcodeAndSubUnitset
    {
        public string Barcode { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
        public int SubUnitsetReferenceId { get; set; }
        public string SubUnitsetCode { get; set; }
        public short IsMainUnitset { get; set; }

    }
}
