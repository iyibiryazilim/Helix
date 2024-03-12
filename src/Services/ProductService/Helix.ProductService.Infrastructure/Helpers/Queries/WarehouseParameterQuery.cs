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
SUBUNITSET.CODE AS [SubUnitsetCode],
		SUBUNITSET.LOGICALREF AS [SubUnitsetReferenceId],
        [StockQuantity] = ISNULL((SELECT SUM(DISTINCT ONHAND) FROM LV_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STINVTOT AS STINVTOT WHERE STINVTOT.STOCKREF = {id} AND STINVTOT.INVENNO = WAREHOUSE.NR),0)
        FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_INVDEF AS INVDEF
        LEFT JOIN L_CAPIWHOUSE AS WAREHOUSE ON INVDEF.INVENNO = WAREHOUSE.NR AND WAREHOUSE.FIRMNR = {FirmNumber}
        LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON INVDEF.ITEMREF = ITEMS.LOGICALREF
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ITEMS.UNITSETREF = UNITSET.LOGICALREF
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON SUBUNITSET.UNITSETREF = UNITSET.LOGICALREF AND SUBUNITSET.MAINUNIT = 1
        WHERE ITEMREF = {id} AND (WAREHOUSE.NAME LIKE '%{search}%')
        {orderBy}
	    OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
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
