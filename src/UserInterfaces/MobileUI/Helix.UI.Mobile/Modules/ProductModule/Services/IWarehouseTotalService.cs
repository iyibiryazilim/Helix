using Helix.UI.Mobile.Modules.BaseModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Services
{
	public interface IWarehouseTotalService
	{
		Task<DataResult<IEnumerable<WarehouseTotal>>> GetWarehouseTotals(HttpClient httpClient, int number, string cardType, string search, WarehouseTotalOrderBy orderBy, int page, int pageSize);

        Task<DataResult<IEnumerable<WarehouseTotal>>> GetWarehouseTotalByProductId(HttpClient httpClient, int number, string search, WarehouseTotalOrderBy orderBy, int page, int pageSize);
    }
}
