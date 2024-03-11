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
    public class OutsourceWorkOrderDataStore : BaseDataStore, IOutsourceWorkOrderService
    {
        ILogger<OutsourceWorkOrderDataStore> _logger;
        public OutsourceWorkOrderDataStore(IConfiguration configuration,ILogger<OutsourceWorkOrderDataStore>logger) : base(configuration)
        {
            _logger = logger;
        }

        public async Task<DataResult<OutsourceWorkOrder>> GetOutSourceWorkOrderById(int id)
        {
            try
            {
                var result = await new SqlQueryHelper<OutsourceWorkOrder>(_configuraiton).GetObjectAsync(new OutsourceProductionOrderQuery(_configuraiton).GetOutsourceProductionOrderById(id));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
                throw;
            }
        }

        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByProductId(int id)
        {
            try
            {
                var result = await new SqlQueryHelper<OutsourceWorkOrder>(_configuraiton).GetObjectsAsync(new OutsourceWorkOrderQuery(_configuraiton).GetOutsourceProductionOrderById(id));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
                throw;
            }
        }

        public async  Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByProductionOrderCode(string code)
        {
            try
            {
                var result = await new SqlQueryHelper<OutsourceWorkOrder>(_configuraiton).GetObjectsAsync(new OutsourceWorkOrderQuery(_configuraiton).GetOutsourceByProductionOrderCode(code));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
                throw;
            }
        }

        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByProductionOrderId(int id)
        {
            try
            {
                var result = await new SqlQueryHelper<OutsourceWorkOrder>(_configuraiton).GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByProductionOrderId(id));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
                throw;
            }
        }

        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByStatus(int[] status)
        {
            try
            {
                var result = await new SqlQueryHelper<OutsourceWorkOrder>(_configuraiton).GetObjectsAsync(new OutsourceWorkOrderQuery(_configuraiton).GetOutsourceProductionOrderByStatus(status));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
                throw;
            }
        }

        public Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderBySupplierId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByWorkstationCode(string code)
        {
            try
            {
                var result = await new SqlQueryHelper<OutsourceWorkOrder>(_configuraiton).GetObjectsAsync(new OutsourceWorkOrderQuery(_configuraiton).GetOutsourceByWorkstationCode(code));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
                throw;
            }
        }

        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByWorkstationId(int id)
        {
            try
            {
                var result = await new SqlQueryHelper<OutsourceWorkOrder>(_configuraiton).GetObjectsAsync(new OutsourceWorkOrderQuery(_configuraiton).GetOutsourceByWorkstationId(id));
                _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
                throw;
            }
        }

        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderList()
        {
            try
            {
                var result = await new SqlQueryHelper<OutsourceWorkOrder>(_configuraiton).GetObjectsAsync(new OutsourceWorkOrderQuery(_configuraiton).GetOutsourceProductionOrderList());
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
