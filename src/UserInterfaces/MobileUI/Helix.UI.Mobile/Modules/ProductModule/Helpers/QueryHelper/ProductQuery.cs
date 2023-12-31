﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Helpers.QueryHelper;

public class ProductQuery : IDisposable
{
	static string CompanyNumber = "003";
	static string CompanyPeriod = "01";

	public string DetailValues(int ReferenceId)
	{
		string query = $@"SELECT
               [InputQuantity] = (SELECT ISNULL(SUM(AMOUNT), 0) FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE WHERE IOCODE IN(1, 2) AND STOCKREF = {ReferenceId}),
               [OutputQuantity] = (SELECT ISNULL(SUM(AMOUNT), 0) FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE WHERE IOCODE IN(3, 4) AND STOCKREF = {ReferenceId}),
               [StockQuantity] = (SELECT ISNULL(SUM(ONHAND), 0) FROM LV_{CompanyNumber}_{CompanyPeriod}_STINVTOT AS STINVTOT LEFT JOIN L_CAPIWHOUSE AS WAREHOUSE ON STINVTOT.INVENNO = WAREHOUSE.NR AND WAREHOUSE.FIRMNR = {Int32.Parse(CompanyNumber)}
               WHERE STINVTOT.STOCKREF = {ReferenceId} AND WAREHOUSE.NR = STINVTOT.INVENNO),
               [LastTransactionDate] = (SELECT TOP 1 LASTTRDATE FROM LV_{CompanyNumber}_{CompanyPeriod}_STINVTOT WHERE STOCKREF = {ReferenceId} ORDER BY DATE_ DESC)";

		return query;
	}

	public string GetTopProducts()
	{
		var query = @$"WITH DerivedTable AS (
    SELECT
        STLINE.STOCKREF AS ReferenceId,
        ITEMS.CODE AS Code,
        ITEMS.NAME AS Name,
        UNITSET.CODE AS SubUnitsetCode,
        UNITSET.LOGICALREF AS SubUnitsetReferenceId,
        BASEUNITSET.CODE AS UnitsetCode,
        BASEUNITSET.LOGICALREF AS UnitsetReferenceId,
        MAX(STLINE.DATE_) AS MaxDate
    FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE
    LEFT JOIN LG_{CompanyNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
    LEFT JOIN LG_{CompanyNumber}_UNITSETF AS BASEUNITSET ON ITEMS.UNITSETREF = BASEUNITSET.LOGICALREF
    LEFT JOIN LG_{CompanyNumber}_UNITSETL AS UNITSET ON UNITSET.UNITSETREF = BASEUNITSET.LOGICALREF AND MAINUNIT = 1
    GROUP BY STLINE.STOCKREF, ITEMS.CODE, ITEMS.NAME, BASEUNITSET.CODE, BASEUNITSET.LOGICALREF, UNITSET.CODE, UNITSET.LOGICALREF
)
SELECT TOP 5
    ReferenceId,
    Code,
    Name,
    SubUnitsetCode,
    SubUnitsetReferenceId,
    UnitsetCode,
    UnitsetReferenceId,
	FIRMDOC.LDATA as Image
FROM DerivedTable
LEFT JOIN LG_{CompanyNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = ReferenceId AND FIRMDOC.INFOTYP = 20
ORDER BY MaxDate DESC";

		return query;
	}
	public string LastTransactionList()
	{
		var query = @$"SELECT TOP 5
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
        [BaseTransactionCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitset] = UNITSET.CODE,
        [SubUnitsetReferenceId] = UNITSET.LOGICALREF,
        [UnitsetCode] = BASEUNITSET.CODE,
        [UnitsetReferenceId] = BASEUNITSET.LOGICALREF,
        [Quantity] = STLINE.AMOUNT,
        [Description] = STLINE.LINEEXP,
        [IOType] = STLINE.IOCODE,
        [WarehouseNumber] = CAPIWHOUSE.NR,
        [WarehouseName] = CAPIWHOUSE.NAME
        
        FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE
        LEFT JOIN LG_{CompanyNumber}_{CompanyPeriod}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_{CompanyNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
        LEFT JOIN LG_{CompanyNumber}_UNITSETL AS UNITSET ON STLINE.UOMREF = UNITSET.LOGICALREF
        LEFT JOIN LG_{CompanyNumber}_UNITSETF AS BASEUNITSET ON STLINE.USREF = BASEUNITSET.LOGICALREF 
        LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {Int32.Parse(CompanyNumber)}
        ORDER BY STLINE.DATE_ DESC";

		return query;
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}
}
