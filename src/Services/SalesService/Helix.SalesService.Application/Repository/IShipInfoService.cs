using Helix.SalesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.SalesService.Application.Repository
{
    public interface IShipInfoService
    {
        public Task<DataResult<IEnumerable<ShipInfo>>> GetShipInfoListAsync(int currentReferenceId);
    }
}
