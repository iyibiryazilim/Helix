﻿using Microsoft.Extensions.Configuration;

namespace Helix.FinanceService.Infrastructure.Queries;

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
