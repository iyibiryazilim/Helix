using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Helpers.QueryHelper
{
    public class ProductPanelQuery 
    {
        static string CompanyNumber = "003";
        static string CompanyPeriod = "01";

        public string GetTodayInputCountValues()
        {
            string query = $@"SELECT COUNT(STLINE.STOCKREF) AS InputCount FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE WHERE IOCODE IN(1,2) AND STLINE.DATE_ = CONVERT(DATE,GETDATE())";

            return query;
        }

        public string GetTodayOutputCountValues()
        {
            string query = $@"SELECT COUNT(STLINE.STOCKREF) AS OutputCount FROM LG_{CompanyNumber}_{CompanyPeriod}_STLINE AS STLINE WHERE IOCODE IN(3,4) AND STLINE.DATE_ = CONVERT(DATE,GETDATE())";

            return query;
        }


    }

   
}
