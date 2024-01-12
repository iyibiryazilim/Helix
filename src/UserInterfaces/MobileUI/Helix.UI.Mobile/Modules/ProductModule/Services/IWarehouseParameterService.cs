using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Services
{
    public interface IWarehouseParameterService
    {
        public Task<DataResult<IEnumerable<WarehouseParameter>>> GetWarehouseParameterByProductId(HttpClient httpClient ,int id, string search, WarehouseParameterOrderBy orderBy, int page, int pageSize);
    }
}
