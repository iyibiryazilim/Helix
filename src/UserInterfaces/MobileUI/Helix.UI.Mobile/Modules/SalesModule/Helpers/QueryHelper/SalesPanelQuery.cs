using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.Helpers.QueryHelper
{
    public class SalesPanelQuery
    {
        readonly string CompanyNumber = "008";
        readonly string CompanyPeriod = "02";
       


        public string GetSalesCountAsync()
        {
            var query = $@"SELECT COUNT(STLINE.LOGICALREF) AS SalesCount  FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS 
STLINE WHERE STLINE.TRCODE IN(7,8)";
            return query;

        }

        public string GetSalesPurchaseCountAsync()
        {
            var query = $@"SELECT COUNT(STLINE.LOGICALREF) AS SalesPurchaseCount  FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS 
STLINE WHERE STLINE.TRCODE IN(6)";
            return query;
        }


    }
}
