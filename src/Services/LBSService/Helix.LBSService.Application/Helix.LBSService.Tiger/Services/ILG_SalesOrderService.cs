using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_SalesOrderService
	{
		Task<DataResult<LG_SalesOrder>> Insert(LG_SalesOrder dto); 
	}
}
