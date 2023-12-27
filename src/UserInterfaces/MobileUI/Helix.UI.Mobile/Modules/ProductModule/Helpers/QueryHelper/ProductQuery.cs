using System;
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

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}
}
