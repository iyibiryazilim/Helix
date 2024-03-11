using Helix.ProductionService.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductionService.Domain.Models
{
    public class OutsourceWorkOrder :BaseWorkOrder
    {
        public int? SupplierReferenceId { get; set; }

        public string SupplierCode { get; set; } = String.Empty;

        public string SupplierName { get; set; } = string.Empty;
    }
}
