using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Infrastructure.Repository
{
    public class UnitsetDataStore :BaseDataStore,IUnitsetService
    {
        private readonly ILogger<UnitsetDataStore> _logger;
        public UnitsetDataStore(IConfiguration configuration, ILogger<UnitsetDataStore> logger) : base(configuration)
        {
            _logger = logger;
        }

        public async Task<DataResult<IEnumerable<Unitset>>> GetUnitsetById(int id)
        {
            try
            {
                var result = await new SqlQueryHelper<Unitset>().GetObjectsAsync(new UnitsetQuery(_configuraiton).GetUnitsetById(id));
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }

        public async Task<DataResult<IEnumerable<Unitset>>> GetUnitsetFromProductId(int id)
        {
            try
            {
                var result = await new SqlQueryHelper<Unitset>().GetObjectsAsync(new UnitsetQuery(_configuraiton).GetUnitsetFromProductId(id));
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }

        public async Task<DataResult<IEnumerable<Unitset>>> GetUnitsetList()
        {
            try
            {
                var result = await new SqlQueryHelper<Unitset>().GetObjectsAsync(new UnitsetQuery(_configuraiton).GetUnitsetList());
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
