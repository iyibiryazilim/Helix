using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.SalesService.Infrastructure.Helper.Queries
{
    public class SpeCodeQuery :BaseQuery
    {
        public SpeCodeQuery(IConfiguration configuration) : base(configuration)
        {
            
        }
        public string GetSpeCodeListAsync()
        {

            string query = @$"SELECT LOGICALREF AS [ReferenceId],SPECODE AS [SpeCode], DEFINITION_ AS [Definition] FROM LG_00{FirmNumber}_SPECODES";

            return query;
        }
    }
}
