using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductionService.Infrastructure.Repository
{
    public class OutsourceProductionOrderDataStore :BaseDataStore ,IOutsourceProductionOrderService
    {
        ILogger<OutsourceProductionOrderDataStore> _logger;
        public OutsourceProductionOrderDataStore(IConfiguration configuration, ILogger<OutsourceProductionOrderDataStore> logger) : base(configuration)
        {
            _logger = logger;
        }

        public async Task<DataResult<OutsourceProductionOrder>> GetProductionOrderByCode(string code)
        {
            try
            {
                var result = await new SqlQueryHelper<OutsourceProductionOrder>(_configuraiton).GetObjectAsync(new OutsourceProductionOrderQuery(_configuraiton).GetOutsourceOrderByCode(code));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
                throw;
            }
        }

        public async Task<DataResult<OutsourceProductionOrder>> GetProductionOrderById(int id)
        {
            try
            {
                var result = await new SqlQueryHelper<OutsourceProductionOrder>(_configuraiton).GetObjectAsync(new OutsourceProductionOrderQuery(_configuraiton).GetOutsourceProductionOrderById(id));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
                throw;
            }
        }

        public async Task<DataResult<IEnumerable<OutsourceProductionOrder>>> GetProductionOrderList()
        {
            try
            {
                var result = await new SqlQueryHelper<OutsourceProductionOrder>(_configuraiton).GetObjectsAsync(new OutsourceProductionOrderQuery(_configuraiton).GetOutsourceProductionOrderList());
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
