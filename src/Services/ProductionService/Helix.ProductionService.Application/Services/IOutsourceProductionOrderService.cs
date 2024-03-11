using Helix.ProductionService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductionService.Application.Services
{
    public interface IOutsourceProductionOrderService
    {
        public Task<DataResult<IEnumerable<OutsourceProductionOrder>>> GetProductionOrderList();
        public Task<DataResult<OutsourceProductionOrder>> GetProductionOrderByCode(string code);
        public Task<DataResult<OutsourceProductionOrder>> GetProductionOrderById(int id);
    }
}
