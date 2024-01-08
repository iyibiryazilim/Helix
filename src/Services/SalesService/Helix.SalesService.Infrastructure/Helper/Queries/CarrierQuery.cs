using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.SalesService.Infrastructure.Helper.Queries
{
    public class CarrierQuery :BaseQuery
    {
        public CarrierQuery(IConfiguration configuration) : base(configuration)
        {
            
        }
        public string GetCarriersListAsync()
        {

            string query = @$"SELECT LOGICALREF AS [ReferenceId],CODE AS [Code], TITLE AS [Name] FROM L_SHPAGENT";

            return query;
        }
    }
}
