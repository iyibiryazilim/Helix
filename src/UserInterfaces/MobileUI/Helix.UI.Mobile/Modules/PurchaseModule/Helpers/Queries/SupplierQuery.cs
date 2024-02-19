namespace Helix.UI.Mobile.Modules.PurchaseModule.Helpers.Queries
{
	public class SupplierQuery
	{
		readonly string CompanyNumber = "008";
		readonly string CompanyPeriod = "02";
		readonly string FirmNumber = "8";

		public string GetTopSuppliers()
		{
			var query = @$"WITH DerivedTable AS (
                           SELECT
                               CLCARD.LOGICALREF AS [ReferenceId],
                               CLCARD.CODE AS [Code],
                               CLCARD.DEFINITION_ AS [Name],
                               SUM(STLINE.LINENET) AS TOTAL
                           FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE
                           LEFT JOIN LG_{CompanyNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
                           LEFT JOIN LG_{CompanyNumber}_{CompanyPeriod}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
                           WHERE STFICHE.GRPCODE = 1 AND CLCARD.CODE LIKE '32%'
                           GROUP BY CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
                            )
                            SELECT TOP 5
                                [ReferenceId],
                                [Code],
                                [Name],
                                TOTAL,
                            	FIRMDOC.LDATA as Image
                            
                            FROM DerivedTable
                            LEFT JOIN LG_{CompanyNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = ReferenceId AND FIRMDOC.INFOTYP = 21
                            ORDER BY TOTAL DESC;
                                ";

			return query;
		}

		public string GetLastPurchaseLines()
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
        [SubUnitsetCode] = UNITSET.CODE,
        [SubUnitsetReferenceId] = UNITSET.LOGICALREF,
        [BaseUnitsetCode] = BASEUNITSET.CODE,
        [BaseUnitsetReferenceId] = BASEUNITSET.LOGICALREF,
        [Quantity] = STLINE.AMOUNT,
        [Description] = STLINE.LINEEXP,
        [IOType] = STLINE.IOCODE,
        [WarehouseNumber] = CAPIWHOUSE.NR,
        [WarehouseName] = CAPIWHOUSE.NAME,
        [CurrentName] = CLCARD.DEFINITION_,
        [CurrentCode] = CLCARD.CODE
        FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE
        LEFT JOIN LG_{CompanyNumber}_{CompanyPeriod}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
		LEFT JOIN LG_{CompanyNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_{CompanyNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
        LEFT JOIN LG_{CompanyNumber}_UNITSETL AS UNITSET ON STLINE.UOMREF = UNITSET.LOGICALREF
        LEFT JOIN LG_{CompanyNumber}_UNITSETF AS BASEUNITSET ON STLINE.USREF = BASEUNITSET.LOGICALREF 
        LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE CLCARD.DEFINITION_ IS NOT NULL AND STFICHE.GRPCODE = 1 AND CLCARD.CODE LIKE '32%'
        ORDER BY STLINE.DATE_ DESC";

			return query;
		}
        public string GetTopPurchaseProducts(int CurrentReferenceId)
        {
            string query = $@"WITH BaseQuery AS (
    SELECT
        ITEMS.CODE AS Code,
        ITEMS.NAME AS Name,
        SUM(STLINE.LINENET) AS [Total],
        ITEMS.LOGICALREF AS ReferenceId,
		[TrackingType] = ITEMS.TRACKTYPE,
		LockTrackingType = ITEMS.LOCTRACKING,
		[SpeCode] = ITEMS.SPECODE,
		[SubUnitsetCode] = SUBUNITSET.CODE,
		[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
		[UnitsetCode] = UNITSET.CODE,
		[UnitsetReferenceId] = UNITSET.LOGICALREF
		FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE
		LEFT JOIN LG_{CompanyNumber}_{CompanyPeriod}_STFICHE AS STFICHE ON STFICHE.LOGICALREF = STLINE.STFICHEREF
		LEFT JOIN LG_{CompanyNumber}_ITEMS AS ITEMS ON ITEMS.LOGICALREF = STLINE.STOCKREF
		LEFT JOIN LG_{CompanyNumber}_CLCARD AS CLCARD ON CLCARD.LOGICALREF = STLINE.CLIENTREF
		LEFT JOIN LG_{CompanyNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN LG_{CompanyNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF
		WHERE CLCARD.LOGICALREF = {CurrentReferenceId} AND STFICHE.GRPCODE = 1
		GROUP BY STLINE.STOCKREF, ITEMS.CODE, ITEMS.NAME,ITEMS.LOGICALREF,ITEMS.TRACKTYPE,ITEMS.LOCTRACKING,ITEMS.SPECODE,SUBUNITSET.CODE,SUBUNITSET.LOGICALREF,UNITSET.CODE,UNITSET.LOGICALREF
)
SELECT TOP 5
    BQ.Code,
    BQ.[Total],
	BQ.Name,
	BQ.ReferenceId,
	BQ.TrackingType,
	BQ.LockTrackingType,
	BQ.[SpeCode],
	BQ.[SubUnitsetCode],
	BQ.[SubUnitsetReferenceId],
	BQ.[UnitsetCode],
	BQ.[UnitsetReferenceId],
    (SELECT FIRMDOC.LDATA FROM LG_{CompanyNumber}_FIRMDOC AS FIRMDOC WHERE FIRMDOC.INFOREF = BQ.ReferenceId AND FIRMDOC.INFOTYP = 20) AS [Image]

FROM BaseQuery AS BQ
ORDER BY BQ.[Total] DESC;";

            return query;
        }

    }
}
