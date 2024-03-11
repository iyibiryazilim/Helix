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
    public class WarehouseParameterDataStore : BaseDataStore, IWarehouseParameterService
    {
        ILogger<WarehouseParameterDataStore> _logger;
        public WarehouseParameterDataStore(IConfiguration configuration, ILogger<WarehouseParameterDataStore> logger) : base(configuration)
        {
            _logger = logger;
        }

        public async Task<DataResult<IEnumerable<WarehouseParameter>>> GetWarehouseParameterByProductId(int id, string search, string orderBy, int page, int pageSize)
        {
            try
            {
                var result = await new SqlQueryHelper<WarehouseParameter>(_configuraiton).GetObjectsAsync(new WarehouseParameterQuery(_configuraiton).GetWarehouseTotalByProductId(id, search, orderBy, page, pageSize));
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
