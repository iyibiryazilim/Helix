using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface ISalesOrderService
	{
		public Task<DataResult<SalesOrderDto>> Insert(SalesOrderDto dto);
	}
}