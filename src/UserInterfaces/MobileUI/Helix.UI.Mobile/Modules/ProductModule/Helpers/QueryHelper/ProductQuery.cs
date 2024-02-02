using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Helpers.QueryHelper;

public class ProductQuery : IDisposable
{
	static string CompanyNumber = "008";
	static string CompanyPeriod = "02";

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
        [SubUnitsetCode] = UNITSET.CODE,
        [SubUnitsetReferenceId] = UNITSET.LOGICALREF,
        [UnitsetCode] = BASEUNITSET.CODE,
        [UnitsetReferenceId] = BASEUNITSET.LOGICALREF,
        [Quantity] = STLINE.AMOUNT,
        [Description] = STLINE.LINEEXP,
        [IOType] = STLINE.IOCODE,
        [DocumentNumber] = STFICHE.DOCODE,
		[DocumentTrackingNumber] = STFICHE.DOCTRACKINGNR,
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

    public string WarehouseListByProductId(int id)
    {
        var query = @$"SELECT
    [WarehouseReferenceId] = CAPIWHOUSE.LOGICALREF,
    [WarehouseName] = CAPIWHOUSE.NAME,
    [WarehouseNumber] = CAPIWHOUSE.NR,
    [LastTransactionDate] = MAX(STINVTOT.LASTTRDATE),
    [OnHand] = ISNULL(SUM(STINVTOT.ONHAND), 0)
FROM
    LV_{CompanyNumber}_{CompanyPeriod}_STINVTOT AS STINVTOT
    LEFT JOIN LG_{CompanyNumber}_ITEMS AS ITEMS ON STINVTOT.STOCKREF = ITEMS.LOGICALREF
    LEFT JOIN LG_{CompanyNumber}_UNITSETF AS BASEUNITSET ON ITEMS.UNITSETREF = BASEUNITSET.LOGICALREF
    LEFT JOIN LG_{CompanyNumber}_UNITSETL AS UNITSET ON UNITSET.UNITSETREF = BASEUNITSET.LOGICALREF AND MAINUNIT = 1
    LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STINVTOT.INVENNO = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {Int32.Parse(CompanyNumber)}
WHERE

    ITEMS.CODE<> 'ÿ'
    AND STINVTOT.INVENNO<> - 1
    AND ITEMS.LOGICALREF = {id}
GROUP BY
    CAPIWHOUSE.LOGICALREF, CAPIWHOUSE.NAME, CAPIWHOUSE.NR
ORDER BY
    [WarehouseName];";

        return query;
    }

    public string BarcodeAndSubUnitsetsByProductId(int id)
    {
        var query = @$"SELECT 
        [Barcode] = (SELECT TOP 1 ISNULL(BARCODE,'') FROM LG_{CompanyNumber}_UNITBARCODE	WHERE ITEMREF = ITMUNITA.ITEMREF AND ITMUNITAREF = ITMUNITA.LOGICALREF AND UNITLINEREF = ITMUNITA.UNITLINEREF),
        ITMUNITA.WIDTH AS [Width],
        ITMUNITA.HEIGHT AS [Height],
        ITMUNITA.VOLUME_ AS [Volume],
        ITMUNITA.WEIGHT AS [Weight],
        UNITSETL.LOGICALREF AS [SubUnitsetReferenceId],
        UNITSETL.CODE AS [SubUnitsetCode],
        [IsMainUnitset] = ISNULL((UNITSETL.MAINUNIT),'')
        FROM LG_{CompanyNumber}_ITMUNITA AS ITMUNITA
        LEFT JOIN LG_{CompanyNumber}_UNITSETL AS UNITSETL ON ITMUNITA.UNITLINEREF = UNITSETL.LOGICALREF
        WHERE ITEMREF = {id}";

        return query;
    }
    public void Dispose()
	{
		GC.SuppressFinalize(this);
	}
}
