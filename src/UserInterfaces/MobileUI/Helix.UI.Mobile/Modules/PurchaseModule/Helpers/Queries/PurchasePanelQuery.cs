using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Helpers.Queries
{
    public class PurchasePanelQuery
    {
        readonly string CompanyNumber = "008";
        readonly string CompanyPeriod = "02";

        public string GetSalesReturnCount()
        {
            var query = @$"SELECT COUNT(STLINE.LOGICALREF) AS PurchaseDispatchCount  FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS 
STLINE WHERE STLINE.TRCODE IN(1)";
            return query;
        }

        public string GetPurchaseReturnCount()
        {
            var query = $@"SELECT COUNT(STLINE.LOGICALREF) AS SalesReturnCount  FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS 
STLINE WHERE STLINE.TRCODE IN(2,3)";
            return query;
        }

    }
}
