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
    public class CarrierDataStore: BaseDataStore,ICarrierService
    {
        ILogger<CarrierDataStore> _logger;
        public CarrierDataStore(IConfiguration configuration, ILogger<CarrierDataStore> logger) : base(configuration)
        {
            _logger = logger;
        }
        public async Task<DataResult<IEnumerable<Carrier>>> GetCarriersListAsync()
        {
            try
            {
                var result = await new SqlQueryHelper<Carrier>(_configuraiton).GetObjectsAsync(new CarrierQuery(_configuraiton).GetCarriersListAsync());
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
