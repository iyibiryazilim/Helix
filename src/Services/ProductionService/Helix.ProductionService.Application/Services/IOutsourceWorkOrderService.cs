using Helix.ProductionService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductionService.Application.Services
{
    public interface IOutsourceWorkOrderService
    {
        public Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderList();
        public Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByStatus(int[] status);
        public Task<DataResult<OutsourceWorkOrder>> GetOutSourceWorkOrderById(int id);
        public Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByWorkstationId(int id);
        public Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByWorkstationCode(string code);
        public Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByProductionOrderId(int id);
        public Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByProductionOrderCode(string code);

        public Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderByProductId(int id);

        public Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetOutSourceWorkOrderBySupplierId(int id);
    }
}
