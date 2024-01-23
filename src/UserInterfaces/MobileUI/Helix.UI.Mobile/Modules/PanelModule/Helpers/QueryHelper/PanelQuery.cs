using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.PanelModule.Helpers.QueryHelper;

public class PanelQuery : IDisposable
{
	static string CompanyNumber = "003";
	static string CompanyPeriod = "01";

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
		WHERE STLINE.DATE_ = CONVERT(DATE,DATEADD(day, -1, GETDATE()))
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


	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}
}
