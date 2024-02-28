namespace Helix.UI.Mobile.Modules.BaseModule.Helpers.QueryHelper
{
    public class NotificationQuery : IDisposable
    {
        static string CompanyNumber = "003";
        static string CompanyPeriod = "01";

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string GetNotificationDetails(int referenceId)
        {
            string query = $@"SELECT [FicheNumber] = FICHENO,[TransactionType] = TRCODE FROM LG_{CompanyNumber}_{CompanyPeriod}_STFICHE WHERE LOGICALREF = {referenceId}";

            return query;
        }
    }
}
