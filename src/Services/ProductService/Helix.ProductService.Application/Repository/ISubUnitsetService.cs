using Helix.ProductService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Application.Repository
{
    public interface ISubUnitsetService
    {
        public Task<DataResult<IEnumerable<SubUnitset>>> GetSubUnitsetList();
        public Task<DataResult<IEnumerable<SubUnitset>>> GetSubUnitsetsFromProductId(int id);
        public Task<DataResult<IEnumerable<SubUnitset>>> GetSubUnitsetByUnitsetId(int id);

        public Task<DataResult<IEnumerable<SubUnitset>>> GetSubUnitsetById(int id);
    }
}
