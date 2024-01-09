using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.SalesService.Infrastructure.Helper.Queries
{
    public class DriverQuery : BaseQuery
    {
        public DriverQuery(IConfiguration configuration) : base(configuration)
        {
        }

        public string GetDriversListAsync()
        {

            string query = @$"SELECT LOGICALREF AS[ReferenceId],
            NAME AS [Name],
            SURNAME AS [Surname],
            TCNO AS [IdentityNumber],
            PLATENUM AS [PlateNumber]
            FROM L_DRIVERS";

            return query;
        }
    }
}
