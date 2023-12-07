using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Infrastructure.Helpers.Queries
{
    public abstract class BaseQuery
    {
        public readonly int FirmNumber;
        public readonly int PeriodNumber;

        IConfiguration _configuration;
        public BaseQuery(IConfiguration configuration)
        {
            _configuration = configuration;
            FirmNumber = Convert.ToInt32(_configuration["LBSParameterDto:DefaultFirmNumber"]);
            PeriodNumber = Convert.ToInt32(_configuration["LBSParameterDto:DefaultPeriodNumber"]);

        }
    }
}

