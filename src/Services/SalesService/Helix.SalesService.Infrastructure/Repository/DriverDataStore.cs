using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.Repository
{
    public class DriverDataStore : BaseDataStore,IDriverService
    {
        ILogger<DriverDataStore> _logger;
        public DriverDataStore(IConfiguration configuration, ILogger<DriverDataStore> logger) : base(configuration)
        {
            _logger = logger;
        }
        
        public async Task<DataResult<IEnumerable<Driver>>> GetDriversListAsync()
        {
            try
            {
                var result = await new SqlQueryHelper<Driver>().GetObjectsAsync(new DriverQuery(_configuraiton).GetDriversListAsync());
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
