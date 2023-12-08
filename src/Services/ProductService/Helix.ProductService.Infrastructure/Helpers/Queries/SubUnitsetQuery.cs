using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Infrastructure.Helpers.Queries
{
    public class SubUnitsetQuery: BaseQuery
    {
        public SubUnitsetQuery(IConfiguration configuration) : base(configuration)
        {
        }
        public string GetSubUnitsetById(int id) => "";

        public string GetSubUnitsetsFromProductId(int id) => "";

        public string GetSubUnitsetByUnitsetId(int id) => "";

        public string GetSubUnitsetList() => "";



    }
}
