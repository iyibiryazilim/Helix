using Microsoft.Extensions.Configuration;

namespace Helix.Queries;

public class EndProductQuery : BaseQuery
{
	public EndProductQuery(IConfiguration configuration) : base(configuration)
	{
	}

	public string GetEndProductList() =>
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
        [StockQuantity] = (SELECT ISNULL(SUM(ONHAND),0) FROM LV_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF AND INVENNO = -1),
        [LastTransactionDate] = (SELECT TOP 1 LASTTRDATE FROM LV_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS
        LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ITEMS.UNITSETREF = UNITSET.LOGICALREF
        LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON SUBUNITSET.UNITSETREF = UNITSET.LOGICALREF AND SUBUNITSET.MAINUNIT = 1
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_MARK AS MARK ON ITEMS.MARKREF = MARK.LOGICALREF
        LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = ITEMS.LOGICALREF AND FIRMDOC.INFOTYP = 20
        WHERE ITEMS.CODE <> 'ÿ' AND ITEMS.CARDTYPE = 12";

	public string GetEndProductByCode(string code) =>
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
        [StockQuantity] = (SELECT ISNULL(SUM(ONHAND),0) FROM LV_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF AND INVENNO = -1),
        [LastTransactionDate] = (SELECT TOP 1 LASTTRDATE FROM LV_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS
        LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ITEMS.UNITSETREF = UNITSET.LOGICALREF
        LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON SUBUNITSET.UNITSETREF = UNITSET.LOGICALREF AND SUBUNITSET.MAINUNIT = 1
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_MARK AS MARK ON ITEMS.MARKREF = MARK.LOGICALREF
        LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = ITEMS.LOGICALREF AND FIRMDOC.INFOTYP = 20
        WHERE ITEMS.CODE <> 'ÿ' AND ITEMS.CARDTYPE = 12 AND ITEMS.CODE = '{code}'";

	public string GetEndProductById(int id) =>
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
        [StockQuantity] = (SELECT ISNULL(SUM(ONHAND),0) FROM LV_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF AND INVENNO = -1),
        [LastTransactionDate] = (SELECT TOP 1 LASTTRDATE FROM LV_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STINVTOT WHERE STOCKREF = ITEMS.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS
        LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ITEMS.UNITSETREF = UNITSET.LOGICALREF
        LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON SUBUNITSET.UNITSETREF = UNITSET.LOGICALREF AND SUBUNITSET.MAINUNIT = 1
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_MARK AS MARK ON ITEMS.MARKREF = MARK.LOGICALREF
        LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = ITEMS.LOGICALREF AND FIRMDOC.INFOTYP = 20
        WHERE ITEMS.CODE <> 'ÿ' AND ITEMS.CARDTYPE = 12 AND ITEMS.LOGICALREF = {id}";
}
