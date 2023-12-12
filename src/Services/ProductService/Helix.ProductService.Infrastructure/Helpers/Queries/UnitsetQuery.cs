using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Infrastructure.Helpers.Queries
{
    public class UnitsetQuery : BaseQuery
    {
        public UnitsetQuery(IConfiguration configuration) :base(configuration) 
        {
            
        }
        public string GetUnitsetById(int id) => "";
        public string GetUnitsetFromProductId(int id) => "";

        public string GetUnitsetList() => "";
    }
}
