using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.Helpers.QueryHelper
{
    public class SalesPanelQuery
    {
        readonly string CompanyNumber = "003";
        readonly string CompanyPeriod = "01";
       


        public string GetSalesCountAsync()
        {
            var query = $@"SELECT COUNT(STLINE.LOGICALREF) AS SalesDispatchCount  FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS 
STLINE WHERE STLINE.TRCODE IN(7,8)
";
            return query;

        }

        public string GetPurchaseCountAsync()
        {
            var query = $@"SELECT COUNT(STLINE.LOGICALREF) AS PurchaseReturnCount  FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS 
STLINE WHERE STLINE.TRCODE IN(6)";
            return query;
        }


    }
}
