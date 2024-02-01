using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Helix.ProductService.Infrastructure.Helpers.Queries
{
    public class WarehouseTotalQuery : BaseQuery
    {
        public WarehouseTotalQuery(IConfiguration configuration) : base(configuration)
        {
        }
        public string GetProductsByWarehouseNumber(int number, string CardType, string search, string orderBy, int currentPage = 0, int pageSize = 20)
        {
            int currentIndex = pageSize * currentPage;

            string query = @$"WITH BaseQuery AS (
    SELECT 
        STINVTOT.STOCKREF AS ProductReferenceId,
        ITEMS.CODE AS ProductCode,
        ITEMS.NAME AS ProductName,
        UNITSET.CODE AS SubUnitsetCode,
        UNITSET.LOGICALREF AS SubUnitsetReferenceId,
        BASEUNITSET.CODE AS UnitsetCode,
        BASEUNITSET.LOGICALREF AS UnitsetReferenceId,
        ISNULL(SUM(STINVTOT.ONHAND), 0) AS OnHand
    FROM 
        LV_00{FirmNumber}_0{PeriodNumber}_STINVTOT AS STINVTOT 
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STINVTOT.STOCKREF = ITEMS.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS BASEUNITSET ON ITEMS.UNITSETREF = BASEUNITSET.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS UNITSET ON UNITSET.UNITSETREF = BASEUNITSET.LOGICALREF AND MAINUNIT = 1
    WHERE  
        (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%') 
        AND ITEMS.CARDTYPE IN ({CardType})
    GROUP BY 
        STINVTOT.STOCKREF, STINVTOT.INVENNO, ITEMS.CODE, ITEMS.NAME, UNITSET.CODE, UNITSET.LOGICALREF, UNITSET.CODE,
        BASEUNITSET.CODE, BASEUNITSET.LOGICALREF
    HAVING 
        STINVTOT.INVENNO = {number} AND ITEMS.CODE <> 'ÿ'
        {orderBy}
            OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY
)
SELECT 
    BQ.ProductReferenceId,
    BQ.ProductCode,
    BQ.ProductName,
    BQ.SubUnitsetCode,
    BQ.SubUnitsetReferenceId,
    BQ.UnitsetCode,
    BQ.UnitsetReferenceId,
    BQ.OnHand,
    FIRMDOC.LDATA AS Image 
FROM 
    BaseQuery AS BQ
    LEFT JOIN LG_00{FirmNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = BQ.ProductReferenceId AND FIRMDOC.INFOTYP = 20 
           ";
            return query;
        }
        public string GetWarehouseTotalByProductId(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
        {

            string query = @$"WITH BaseQuery AS (
    SELECT 
        STINVTOT.STOCKREF AS ProductReferenceId,
        ITEMS.CODE AS ProductCode,
        ITEMS.NAME AS ProductName,
        UNITSET.CODE AS SubUnitsetCode,
        UNITSET.LOGICALREF AS SubUnitsetReferenceId,
        BASEUNITSET.CODE AS UnitsetCode,
        BASEUNITSET.LOGICALREF AS UnitsetReferenceId,
        CAPIWHOUSE.LOGICALREF AS WarehouseReferenceId,
        CAPIWHOUSE.NAME AS WarehouseName,
        CAPIWHOUSE.NR AS WarehouseNumber,
        ISNULL(SUM(STINVTOT.ONHAND), 0) AS OnHand
    FROM 
        LV_00{FirmNumber}_0{PeriodNumber}_STINVTOT AS STINVTOT 
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STINVTOT.STOCKREF = ITEMS.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS BASEUNITSET ON ITEMS.UNITSETREF = BASEUNITSET.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS UNITSET ON UNITSET.UNITSETREF = BASEUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON CAPIWHOUSE.NR = STINVTOT.INVENNO AND CAPIWHOUSE.FIRMNR = {FirmNumber}
    WHERE  
        (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR CAPIWHOUSE.NAME LIKE '%{search}%') 
        AND ITEMS.LOGICALREF = {id}
    GROUP BY 
        STINVTOT.STOCKREF, STINVTOT.INVENNO, ITEMS.CODE, ITEMS.NAME, UNITSET.CODE, UNITSET.LOGICALREF, UNITSET.CODE,
        CAPIWHOUSE.LOGICALREF, CAPIWHOUSE.NAME, CAPIWHOUSE.NR, BASEUNITSET.CODE, BASEUNITSET.LOGICALREF
    HAVING 
        STINVTOT.INVENNO <> -1
         AND ITEMS.CODE <> 'ÿ'
)
SELECT 
    BQ.ProductReferenceId,
    BQ.ProductCode,
    BQ.ProductName,
    BQ.SubUnitsetCode,
    BQ.SubUnitsetReferenceId,
    BQ.UnitsetCode,
    BQ.UnitsetReferenceId,
    BQ.WarehouseReferenceId,
    BQ.WarehouseName,
    BQ.WarehouseNumber,
    BQ.OnHand,
    FIRMDOC.LDATA AS Image
FROM 
    BaseQuery AS BQ
    LEFT JOIN LG_00{FirmNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = BQ.ProductReferenceId AND FIRMDOC.INFOTYP = 20 "; 
            return query;
        }


    }

    public class WarehouseTotalOrderBy
    {
        public const string QuantityAsc = "ORDER BY [OnHand] ASC";
        public const string QuantityDesc = "ORDER BY [OnHand] DESC";
        public const string CodeAsc = "ORDER BY ITEMS.CODE ASC";
        public const string CodeDesc = "ORDER BY ITEMS.CODE DESC";
        public const string NameAsc = "ORDER BY ITEMS.NAME ASC";
        public const string NameDesc = "ORDER BY ITEMS.NAME DESC";
        public const string WarehouseNameAsc = "ORDER BY CAPIWHOUSE.NAME ASC";
        public const string WarehouseNameDesc = "ORDER BY CAPIWHOUSE.NAME DESC";
        public const string WarehouseNumberAsc = "ORDER BY CAPIWHOUSE.NR ASC";
        public const string WarehouseNumberDesc = "ORDER BY CAPIWHOUSE.NR DESC";
    }
}




