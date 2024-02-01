using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Helpers.QueryHelper
{
    public class WarehouseQuery
    {
        static string CompanyNumber = "008";
        static string CompanyPeriod = "02";

        public string WarehouseDetailCardTypeCount(int number)
        {
            string query = $@"SELECT ITEMS.CARDTYPE as [CardType] ,COUNT(DISTINCT STOCKREF) as [ReferenceCount] FROM LV_{CompanyNumber}_{CompanyPeriod}_STINVTOT AS STINVTOT
                    LEFT JOIN LG_{CompanyNumber}_ITEMS AS ITEMS ON STINVTOT.STOCKREF = ITEMS.LOGICALREF
                    WHERE INVENNO={number} AND ITEMS.CARDTYPE IS NOT NULL
                    GROUP BY ITEMS.CARDTYPE";

            return query;
        }
    }
}
