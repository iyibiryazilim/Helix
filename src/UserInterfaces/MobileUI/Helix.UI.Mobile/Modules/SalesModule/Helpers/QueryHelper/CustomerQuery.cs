namespace Helix.UI.Mobile.Modules.SalesModule.Helpers.QueryHelper
{
	public class CustomerQuery
	{
		readonly string CompanyNumber = "003";
		readonly string CompanyPeriod = "01";
		readonly string FirmNumber = "3";

		public string GetTopCustomers()
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
                           WHERE STFICHE.GRPCODE = 2 AND CLCARD.CODE LIKE '12%'
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

		public string GetLastSaleLines()
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
        [Unitset] = UNITSET.CODE,
        [UnitsetReferenceId] = UNITSET.LOGICALREF,
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
		WHERE CLCARD.DEFINITION_ IS NOT NULL AND STFICHE.GRPCODE = 2 AND CLCARD.CODE LIKE '12%'
        ORDER BY STLINE.DATE_ DESC";

			return query;
		}


	}
}

