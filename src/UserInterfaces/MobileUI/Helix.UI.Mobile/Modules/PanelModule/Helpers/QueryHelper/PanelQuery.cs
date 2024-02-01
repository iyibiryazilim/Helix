using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.PanelModule.Helpers.QueryHelper;

public class PanelQuery : IDisposable
{
	static string CompanyNumber = "008";
	static string CompanyPeriod = "02";

	public string GetTodayTransactionedProducts()
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
		WHERE STLINE.DATE_ = CONVERT(DATE, GETDATE())
		GROUP BY STLINE.STOCKREF, ITEMS.CODE, ITEMS.NAME,ITEMS.LOGICALREF,ITEMS.TRACKTYPE,ITEMS.LOCTRACKING,ITEMS.SPECODE,SUBUNITSET.CODE,SUBUNITSET.LOGICALREF,UNITSET.CODE,UNITSET.LOGICALREF
)
SELECT
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

FROM BaseQuery AS BQ;";

		return query;
	}

	public string GetTodayInputCountValues()
	{
		string query = $@"SELECT COUNT(STLINE.LOGICALREF) AS InputCount FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE WHERE IOCODE IN(1,2) AND STLINE.DATE_ = CONVERT(DATE,GETDATE())";

		return query;
	}

	public string GetTodayOutputCountValues()
	{
		string query = $@"SELECT COUNT(STLINE.LOGICALREF) AS OutputCount FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE WHERE IOCODE IN(3,4) AND STLINE.DATE_ = CONVERT(DATE,GETDATE())";

		return query;
	}

	public string GetWaitingSalesOrderCountValues()
	{
		string query = $@"SELECT COUNT(DISTINCT ORFLINE.STOCKREF) AS WaitingSalesOrderCount  FROM LG_{CompanyNumber}_{CompanyPeriod}_ORFLINE AS ORFLINE WHERE (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0  AND ORFLINE.TRCODE = 1";

		return query;
	}

	public string GetWaitingPurchaseOrderCountValues()
	{
		string query = $@"SELECT COUNT(DISTINCT ORFLINE.STOCKREF) AS WaitingPurchaseOrderCount FROM LG_{CompanyNumber}_{CompanyPeriod}_ORFLINE AS ORFLINE WHERE (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0  AND ORFLINE.TRCODE = 2";

		return query;
	}




	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}
}
