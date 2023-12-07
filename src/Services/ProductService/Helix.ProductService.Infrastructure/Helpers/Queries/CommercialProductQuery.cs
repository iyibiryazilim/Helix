using Helix.ProductService.Infrastructure.Helpers.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Helpers.Queries { 
public class CommercialProductQuery : BaseQuery
{
	public CommercialProductQuery(IConfiguration configuration) : base(configuration)
	{
	}
	public string GetCommercialProductList() =>
		@$"SELECT
        [ReferenceId] = ITEMS.LOGICALREF,
        [CardType] =ITEMS.CARDTYPE,
        [Code] = ITEMS.CODE,
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
        WHERE ITEMS.CODE <> 'ÿ' AND ITEMS.CARDTYPE = 1";

	public string GetCommercialProductByCode(string code) =>
		@$"SELECT
        [ReferenceId] = ITEMS.LOGICALREF,
        [CardType] =ITEMS.CARDTYPE,
        [Code] = ITEMS.CODE,
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
        WHERE ITEMS.CODE <> 'ÿ' AND ITEMS.CARDTYPE = 1 AND ITEMS.CODE = '{code}'";

	public string GetCommercialProductById(int id) =>
		@$"SELECT
        [ReferenceId] = ITEMS.LOGICALREF,
        [CardType] =ITEMS.CARDTYPE,
        [Code] = ITEMS.CODE,
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
        WHERE ITEMS.CODE <> 'ÿ' AND ITEMS.CARDTYPE = 1 AND ITEMS.LOGICALREF = {id}";
}
}
