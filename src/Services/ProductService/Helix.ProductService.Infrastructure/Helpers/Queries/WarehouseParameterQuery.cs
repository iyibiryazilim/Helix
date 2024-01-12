using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Infrastructure.Helpers.Queries
{
    public class WarehouseParameterQuery : BaseQuery
    {
        public WarehouseParameterQuery(IConfiguration configuration) : base(configuration)
        {
           

        }
        public string GetWarehouseTotalByProductId(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
        {
            int currentIndex = pageSize * currentPage;

            string query = @$"SELECT 
        WAREHOUSE.NR AS [WarehouseNumber],
        WAREHOUSE.NAME AS [WarehouseName],
        INVDEF.MINLEVEL AS [MinLevel],
        INVDEF.MAXLEVEL AS [MaxLevel],
        INVDEF.SAFELEVEL AS [SafeLevel],
        [StockQuantity] = ISNULL((SELECT SUM(DISTINCT ONHAND) FROM LV_00{FirmNumber}_0{PeriodNumber}_STINVTOT AS STINVTOT WHERE STINVTOT.STOCKREF = {id} AND STINVTOT.INVENNO = WAREHOUSE.NR),0)
        FROM LG_00{FirmNumber}_INVDEF AS INVDEF
        LEFT JOIN L_CAPIWHOUSE AS WAREHOUSE ON INVDEF.INVENNO = WAREHOUSE.NR AND WAREHOUSE.FIRMNR = {FirmNumber}
        {orderBy}
	    OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY;";
            return query;
        }
    }
    public class WarehouseParameterOrderBy
    {
        public const string QuantityAsc = "ORDER BY [StockQuantity] ASC";
        public const string QuantityDesc = "ORDER BY [StockQuantity]] DESC";
        public const string WarehouseNameAsc = "ORDER BY WAREHOUSE.NAME ASC";
        public const string WarehouseNameDesc = "ORDER BY WAREHOUSE.NAME DESC";
        public const string WarehouseNumberAsc = "ORDER BY WAREHOUSE.NR ASC";
        public const string WarehouseNumberDesc = "ORDER BY WAREHOUSE.NR DESC";
    }
}
