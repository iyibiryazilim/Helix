namespace Helix.UI.Mobile.Modules.ReturnModule.Helpers.Queries;

public class ReturnPanelQuery : IDisposable
{
	static string CompanyNumber = "008";
	static string CompanyPeriod = "01";

	public string LastReturnProductQuery()
	{
		string query = $@"WITH DerivedTable AS (
    SELECT
        ITEMS.LOGICALREF AS [ReferenceId],
        ITEMS.CODE AS [Code],
        ITEMS.NAME AS [Name],
MAX(STLINE.DATE_) AS [Date]
    FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE
    LEFT JOIN LG_{CompanyNumber}_{CompanyPeriod}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
    LEFT JOIN LG_{CompanyNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
    WHERE STFICHE.TRCODE IN (2, 3, 6)
    GROUP BY ITEMS.LOGICALREF, ITEMS.CODE, ITEMS.NAME 
)
SELECT TOP 5
    [ReferenceId],
    [Code],
    [Name],
[Date],
		FIRMDOC.LDATA as Image
FROM DerivedTable
LEFT JOIN LG_{CompanyNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = ReferenceId AND FIRMDOC.INFOTYP = 20
ORDER BY Date

";

		return query;
	}

	public string LastReturnCustomerQuery()
	{
		string query = $@"WITH DerivedTable AS (
    SELECT
        CLCARD.LOGICALREF AS [ReferenceId],
        CLCARD.CODE AS [Code],
        CLCARD.DEFINITION_ AS [Name],
MAX(STLINE.DATE_) AS Date
    FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE
    LEFT JOIN LG_{CompanyNumber}_{CompanyPeriod}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
    LEFT JOIN LG_{CompanyNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
    WHERE STFICHE.TRCODE IN (2, 3, 6)
    GROUP BY CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_ 
)
SELECT TOP 5
    [ReferenceId],
    [Code],
    [Name],
[Date],
	FIRMDOC.LDATA as Image
FROM DerivedTable
LEFT JOIN LG_{CompanyNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = ReferenceId AND FIRMDOC.INFOTYP = 21
ORDER BY Date

";

		return query;
	}

	public string TopReturnTransactionListQuery()
	{
		string query = $@"SELECT TOP 5
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
        [FicheCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [UnitsetCode] = UNITSET.CODE,
        [UnitsetReferenceId] = UNITSET.LOGICALREF,
        [SubUnitsetCode] = BASEUNITSET.CODE,
        [SubUnitsetReferenceId] = BASEUNITSET.LOGICALREF,
        [Quantity] = STLINE.AMOUNT,
        [Description] = STLINE.LINEEXP,
        [IOType] = STLINE.IOCODE,
        [WarehouseNumber] = CAPIWHOUSE.NR,
        [WarehouseName] = CAPIWHOUSE.NAME,
        [CurrentName] = CLCARD.DEFINITION_
        FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE
        LEFT JOIN LG_{CompanyNumber}_{CompanyPeriod}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
		LEFT JOIN LG_{CompanyNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_{CompanyNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
        LEFT JOIN LG_{CompanyNumber}_UNITSETL AS UNITSET ON STLINE.UOMREF = UNITSET.LOGICALREF
        LEFT JOIN LG_{CompanyNumber}_UNITSETF AS BASEUNITSET ON STLINE.USREF = BASEUNITSET.LOGICALREF 
        LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {Int32.Parse(CompanyNumber)}
		WHERE CLCARD.DEFINITION_ IS NOT NULL AND STFICHE.TRCODE IN(2,3,6)
        ORDER BY STLINE.DATE_ DESC";

		return query;
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}
}