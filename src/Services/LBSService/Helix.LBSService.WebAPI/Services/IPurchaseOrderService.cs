using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IPurchaseOrderService
	{
		public Task<DataResult<PurchaseOrderDto>> Insert(PurchaseOrderDto dto);
	}
}