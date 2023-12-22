using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Helpers.Queries
{
	public class WarehouseQuery : BaseQuery
	{
		public WarehouseQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetWarehouseList(string search = "", string orderBy = WarehouseOrderBy.ItemNumberAsc, int page = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT 
			[ReferenceId] = LGMAIN.LOGICALREF,
			[Number] = LGMAIN.NR,
			[Name] = LGMAIN.NAME
			FROM L_CAPIWHOUSE AS LGMAIN WITH (NOLOCK) WHERE LGMAIN.FIRMNR = {FirmNumber} AND (LGMAIN.NAME LIKE '%{search}%' OR LGMAIN.NR LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
			
	}
	public class WarehouseOrderBy
	{
		public const string ItemNumberAsc = "ORDER BY LGMAIN.NR ASC";
		public const string ItemNumberDesc = "ORDER BY LGMAIN.NR DESC";
		public const string ItemNameAsc = "ORDER BY LGMAIN.NAME ASC";
		public const string ItemNameDesc = "ORDER BY LGMAIN.NAME DESC";
	}
}
