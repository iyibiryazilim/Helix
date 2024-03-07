using Helix.ProductionService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductionService.Application.Services
{
    public interface IOutsourceWorkOrder
    {
        public Task<DataResult<IEnumerable<OutSourceWorkOrder>>> GetOutSourceWorkOrderList();
        public Task<DataResult<IEnumerable<OutSourceWorkOrder>>> GetOutSourceWorkOrderByStatus(int[] status);
        public Task<DataResult<OutSourceWorkOrder>> GetOutSourceWorkOrderById(int id);
        public Task<DataResult<IEnumerable<OutSourceWorkOrder>>> GetOutSourceWorkOrderByWorkstationId(int id);
        public Task<DataResult<IEnumerable<OutSourceWorkOrder>>> GetOutSourceWorkOrderByWorkstationCode(string code);
        public Task<DataResult<IEnumerable<OutSourceWorkOrder>>> GetOutSourceWorkOrderByProductionOrderId(int id);
        public Task<DataResult<IEnumerable<OutSourceWorkOrder>>> GetOutSourceWorkOrderByProductionOrderCode(string code);

        public Task<DataResult<IEnumerable<OutSourceWorkOrder>>> GetOutSourceWorkOrderByProductId(int id);

        public Task<DataResult<IEnumerable<OutSourceWorkOrder>>> GetOutSourceWorkOrderBySupplierId(int id);
    }
}
