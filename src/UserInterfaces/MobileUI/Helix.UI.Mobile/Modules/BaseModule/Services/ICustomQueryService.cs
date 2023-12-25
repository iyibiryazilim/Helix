using Helix.UI.Mobile.Modules.BaseModule.Dtos;

namespace Helix.UI.Mobile.Modules.BaseModule.Services
{
	public interface ICustomQueryService
	{
		public Task<DataResult<IEnumerable<dynamic>>> GetObjectsAsync(HttpClient httpClient,string query);
		public Task<DataResult<dynamic>> GetObjectAsync(HttpClient httpClient,string query);

	}
}
