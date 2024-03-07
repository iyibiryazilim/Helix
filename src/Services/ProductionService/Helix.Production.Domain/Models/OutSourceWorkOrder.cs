using Helix.ProductionService.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductionService.Domain.Models
{
    public class OutSourceWorkOrder :BaseWorkOrder
    {
        public int SupplierReferenceId { get; set; }

        public string SupplierCode { get; set; }

        public string SupplierName { get; set; } = string.Empty;
    }
}
