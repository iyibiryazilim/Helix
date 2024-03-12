using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.SalesService.Infrastructure.Helper.Queries
{
    public class ShipInfoQuery :BaseQuery
    {
        public ShipInfoQuery(IConfiguration configuration) : base(configuration)
        {
            
        }

        public string GetShipInfoListAsync(int currentReferenceId)
        {
            string query= @$"SELECT 
        [ReferenceId] = LOGICALREF,
        [Code] = CODE,
        [Name] = NAME
        FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_SHIPINFO WHERE CLIENTREF = {currentReferenceId} ORDER BY NAME";
            return query;
        }
    }
}
