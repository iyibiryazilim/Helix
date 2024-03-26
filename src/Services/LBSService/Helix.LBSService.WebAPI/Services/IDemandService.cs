using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IDemandService
	{
		public Task<DataResult<DemandDto>> Insert(DemandDto dto);
	}
}