using Microsoft.Extensions.Configuration;



namespace Helix.ProductService.Infrastructure.Helpers.Queries
{
	public class ProductQuery : BaseQuery
    {
        public ProductQuery(IConfiguration configuration) : base(configuration)
        {
        }
        public string GetProductList(string search = "", string groupCode = "", string orderBy = ProductOrderBy.ItemNameAsc, int page = 0, int pageSize = 20)
        {
			int currentIndex = pageSize * page;

			string query = @$"SELECT
        [ReferenceId] = ITEMS.LOGICALREF,
        [CardType] =ITEMS.CARDTYPE,
        [Code] = ITEMS.CODE,
        [GroupName] = ITEMS.STGRPCODE,
        [Name] = ITEMS.NAME,
		[TrackingType] = ITEMS.TRACKTYPE,
		LockTrackingType = ITEMS.LOCTRACKING,
		[SpeCode] = ITEMS.SPECODE,
        [BrandName] = MARK.DESCR,
        [BrandReferenceId] = MARK.LOGICALREF,
        [BrandCode] = MARK.CODE,
        [SubUnitsetCode] = SUBUNITSET.CODE,
        [SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
        [Image] = FIRMDOC.LDATA,
        [UnitsetCode] = UNITSET.CODE,
        [UnitsetReferenceId] = UNITSET.LOGICALREF,
        [StockQuantity] = (SELECT ISNULL(SUM(ONHAND),0) FROM LV_00{FirmNumber}_0{PeriodNumber}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF AND INVENNO = -1),
        [LastTransactionDate] = (SELECT TOP 1 LASTTRDATE FROM LV_00{FirmNumber}_0{PeriodNumber}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_00{FirmNumber}_ITEMS AS ITEMS
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ITEMS.UNITSETREF = UNITSET.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON SUBUNITSET.UNITSETREF = UNITSET.LOGICALREF AND SUBUNITSET.MAINUNIT = 1
		LEFT JOIN LG_00{FirmNumber}_MARK AS MARK ON ITEMS.MARKREF = MARK.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = ITEMS.LOGICALREF AND FIRMDOC.INFOTYP = 20
        WHERE ITEMS.CODE <> 'ÿ' AND (ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%') AND ITEMS.STGRPCODE LIKE '%{groupCode}%'
        {orderBy}
        OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY
        "; ;
            return query;
		}
        public string GetProductByCode(string code) =>
            @$"SELECT
        [ReferenceId] = ITEMS.LOGICALREF,
        [CardType] =ITEMS.CARDTYPE,
        [Code] = ITEMS.CODE,
        [Name] = ITEMS.NAME,
        [GroupName] = ITEMS.STGRPCODE,
		[TrackingType] = ITEMS.TRACKTYPE,
		LockTrackingType = ITEMS.LOCTRACKING,
		[SpeCode] = ITEMS.SPECODE,
        [BrandName] = MARK.DESCR,
        [BrandReferenceId] = MARK.LOGICALREF,
        [BrandCode] = MARK.CODE,
        [SubUnitsetCode] = SUBUNITSET.CODE,
        [SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
        [Image] = FIRMDOC.LDATA,
        [UnitsetCode] = UNITSET.CODE,
        [UnitsetReferenceId] = UNITSET.LOGICALREF,
        [StockQuantity] = (SELECT ISNULL(SUM(ONHAND),0) FROM LV_00{FirmNumber}_0{PeriodNumber}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF AND INVENNO = -1),
        [LastTransactionDate] = (SELECT TOP 1 LASTTRDATE FROM LV_00{FirmNumber}_0{PeriodNumber}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_00{FirmNumber}_ITEMS AS ITEMS
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ITEMS.UNITSETREF = UNITSET.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON SUBUNITSET.UNITSETREF = UNITSET.LOGICALREF AND SUBUNITSET.MAINUNIT = 1
		LEFT JOIN LG_00{FirmNumber}_MARK AS MARK ON ITEMS.MARKREF = MARK.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = ITEMS.LOGICALREF AND FIRMDOC.INFOTYP = 20
        WHERE ITEMS.CODE <> 'ÿ' AND  ITEMS.CODE = '{code}'";
        public string GetProductById(int id) =>
            @$"SELECT
        [ReferenceId] = ITEMS.LOGICALREF,
        [CardType] =ITEMS.CARDTYPE,
        [Code] = ITEMS.CODE,
        [GroupName] = ITEMS.STGRPCODE,
        [Name] = ITEMS.NAME,
		[TrackingType] = ITEMS.TRACKTYPE,
		LockTrackingType = ITEMS.LOCTRACKING,
		[SpeCode] = ITEMS.SPECODE,
        [BrandName] = MARK.DESCR,
        [BrandReferenceId] = MARK.LOGICALREF,
        [BrandCode] = MARK.CODE,
        [SubUnitsetCode] = SUBUNITSET.CODE,
        [SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
        [Image] = FIRMDOC.LDATA,
        [UnitsetCode] = UNITSET.CODE,
        [UnitsetReferenceId] = UNITSET.LOGICALREF,
        [StockQuantity] = (SELECT ISNULL(SUM(ONHAND),0) FROM LV_00{FirmNumber}_0{PeriodNumber}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF AND INVENNO = -1),
        [LastTransactionDate] = (SELECT TOP 1 LASTTRDATE FROM LV_00{FirmNumber}_0{PeriodNumber}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_00{FirmNumber}_ITEMS AS ITEMS
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ITEMS.UNITSETREF = UNITSET.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON SUBUNITSET.UNITSETREF = UNITSET.LOGICALREF AND SUBUNITSET.MAINUNIT = 1
		LEFT JOIN LG_00{FirmNumber}_MARK AS MARK ON ITEMS.MARKREF = MARK.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = ITEMS.LOGICALREF AND FIRMDOC.INFOTYP = 20
        WHERE ITEMS.CODE <> 'ÿ' AND  ITEMS.LOGICALREF = {id}";
        public string GetProductsGroups()
        {
            string query = @$"SELECT
                [GroupDefinition] = specode.DEFINITION_,
                [GroupCode] = specode.SPECODE
                from LG_00{FirmNumber}_SPECODES as specode
                WHERE CODETYPE = 4 AND SPECODETYPE = 0";
            return query;
        }
    }
    public class ProductOrderBy
    {
		public const string ItemCodeAsc = "ORDER BY ITEMS.CODE ASC";
		public const string ItemCodeDesc = "ORDER BY ITEMS.CODE DESC";
		public const string ItemNameAsc = "ORDER BY ITEMS.NAME ASC";
		public const string ItemNameDesc = "ORDER BY ITEMS.NAME DESC";
	}

}