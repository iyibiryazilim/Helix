using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.SalesService.Infrastructure.Repository
{
    public class ShipInfoDataStore :BaseDataStore,IShipInfoService
    {
        ILogger<ShipInfoDataStore> _logger;

        public ShipInfoDataStore(IConfiguration configuration, ILogger<ShipInfoDataStore> logger) : base(configuration)
        {
            _logger = logger;
        }

        public async Task<DataResult<IEnumerable<ShipInfo>>> GetShipInfoListAsync(int currentReferenceId)
        {
            try
            {
                var result = await new SqlQueryHelper<ShipInfo>(_configuraiton).GetObjectsAsync(new ShipInfoQuery(_configuraiton).GetShipInfoListAsync(currentReferenceId));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

                throw;
            }
        }
    }
}
