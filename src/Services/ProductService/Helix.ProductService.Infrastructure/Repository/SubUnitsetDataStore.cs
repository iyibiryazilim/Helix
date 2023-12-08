using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository
{
    public class SubUnitsetDataStore : BaseDataStore ,ISubUnitsetService
    {
        private readonly ILogger<SubUnitsetDataStore> _logger;
        public SubUnitsetDataStore(IConfiguration configuration, ILogger<SubUnitsetDataStore> logger) : base(configuration)
        {
            _logger = logger;

        }

        public async Task<DataResult<IEnumerable<SubUnitset>>> GetSubUnitsetById(int id)
        {
            try
            {
                var result = await new SqlQueryHelper<SubUnitset>().GetObjectsAsync(new SubUnitsetQuery(_configuraiton).GetSubUnitsetById(id));
                return result;
            }
            catch (Exception ex) {
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SubUnitset>>> GetSubUnitsetByUnitsetId(int id)
        {
            try
            {
                var result = await new SqlQueryHelper<SubUnitset>().GetObjectsAsync(new SubUnitsetQuery(_configuraiton).GetSubUnitsetByUnitsetId(id));
                return result;

            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;

            }
        }

        public async Task<DataResult<IEnumerable<SubUnitset>>> GetSubUnitsetsFromProductId(int id)
        {
            try
            {
                var result = await new SqlQueryHelper<SubUnitset>().GetObjectsAsync(new SubUnitsetQuery(_configuraiton).GetSubUnitsetsFromProductId(id));
                return result;
            }
            catch(Exception ex
            )
            {
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }

        public async Task<DataResult<IEnumerable<SubUnitset>>> GetSubUnitsetList()
        {
            try
            {
                var result = await new SqlQueryHelper<SubUnitset>().GetObjectsAsync(new SubUnitsetQuery(_configuraiton).GetSubUnitsetList());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;

            }
        }
    }
}
