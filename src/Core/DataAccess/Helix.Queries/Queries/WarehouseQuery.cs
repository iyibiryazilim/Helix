using Microsoft.Extensions.Configuration;
using Helix.PurchaseService.Infrastructure.Helper.Queries;

namespace Helix.Queries
{
	public class WarehouseQuery : BaseQuery
	{
		public WarehouseQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetWarehouseList() => 
			@$"SELECT 
			[ReferenceId] = LGMAIN.LOGICALREF,
			[Number] = LGMAIN.NR,
			[Name] = LGMAIN.NAME
			FROM L_CAPIWHOUSE AS LGMAIN WITH (NOLOCK) WHERE LGMAIN.FIRMNR = {FirmNumber} ";
	}
}
