using Helix.UI.Sys.Module.BusinessObjects;
using Helix.UI.Sys.Module.ViewObjects;
using System.Data;
using System.Data.SqlClient;

namespace Helix.UI.Sys.Module.DataStores
{
    public  class EmployeeDataStore
    {
        ConnectionParameter _connectionParameter;
        public EmployeeDataStore(ConnectionParameter connectionParameter)
        {
            _connectionParameter = connectionParameter;
        }

        public async Task<IEnumerable<ViewObjects.EmployeeList>> ConvertObjects(DataTable dataTable)
        {
            List<ViewObjects.EmployeeList> items = new List<ViewObjects.EmployeeList>();
            try
            {
                foreach (DataRow row in dataTable.Rows)
                {


                    ViewObjects.EmployeeList item = new ViewObjects.EmployeeList();
                    item.ReferenceId = string.IsNullOrEmpty(row["ReferenceId"].ToString()) ? 0 : Convert.ToInt32(row["ReferenceId"]); 
                    item.Code = string.IsNullOrEmpty(row["Code"].ToString()) ? string.Empty : row["Code"].ToString();
                    item.FirstName = string.IsNullOrEmpty(row["FirstName"].ToString()) ? string.Empty : row["FirstName"].ToString();
                    item.RegisterCode = string.IsNullOrEmpty(row["RegisterCode"].ToString()) ? string.Empty : row["RegisterCode"].ToString();

                    items.Add(item);


                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return await Task.FromResult(items);

        }
        public async Task<IEnumerable<ViewObjects.EmployeeList>> GetObjects()
        {
            try
            {
                return await Task.Run(async () =>
                {
                    DataTable dataTable = new DataTable();
                    string commandString = string.Empty;
                    string connectionString = $"{_connectionParameter.ConnectionString}TrustServerCertificate=True";
                    commandString = @$"
                      SELECT 
                   [ReferenceId]=EMP.LOGICALREF,
                   [Code]=EMP.CODE,
                   [FirstName]=EMP.NAME,
                   [RegisterCode]=EMP.REGISTERCODE
                    FROM LG_{_connectionParameter.DefaultFirmNumber.ToString().PadLeft(3, '0')}_EMPLOYEE AS EMP";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(commandString,connectionString))
                        adapter.Fill(dataTable);

                    return await ConvertObjects(dataTable);
                });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
