using Helix.CustomQueryService.WebAPI.Models;

namespace Helix.CustomQueryService.WebAPI.Services
{
	public interface ICustomQueryService
	{
		public IAsyncEnumerable<dynamic> GetAsync(string query);
	}
}
