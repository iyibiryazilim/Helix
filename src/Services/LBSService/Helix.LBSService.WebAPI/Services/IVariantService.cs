using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IVariantService
	{
		public Task<DataResult<VariantDto>> Insert(VariantDto dto);
	}
}