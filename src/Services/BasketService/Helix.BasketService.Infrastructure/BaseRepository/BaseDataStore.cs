using Microsoft.Extensions.Configuration;

namespace Helix.BasketService.Infrastructure.BaseRepository;

public class BaseDataStore
{
	public readonly IConfiguration _configuraiton;

	public BaseDataStore(IConfiguration configuration)
	{
		_configuraiton = configuration;
	}
}
