using Microsoft.Extensions.Configuration;

namespace Helix.Queries
{
	public class EmployeeQuery : BaseQuery
	{
		public EmployeeQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetEmployeeList() =>
			@$"SELECT 
			[ReferenceId]=Employee.LOGICALREF,
			[Code]= Employee.CODE,
			[Name]=Employee.Name
			FROM LG_00{FirmNumber}_EMPLOYEE AS Employee";

		public string GetEmployeeByCode(string code) =>
			@$"SELECT 
			[ReferenceId]=Employee.LOGICALREF,
			[Code]= Employee.CODE,
			[Name]=Employee.Name
			FROM LG_00{FirmNumber}_EMPLOYEE AS Employee
			WHERE Code = '{code}'";

		public string GetEmployeeById( int id) =>
			@$"SELECT 
			[ReferenceId]=Employee.LOGICALREF,
			[Code]= Employee.CODE,
			[Name]= Employee.Name
			FROM LG_00{FirmNumber}_EMPLOYEE AS Employee
			WHERE Employee.LOGICALREF = {id}";

	}
}
