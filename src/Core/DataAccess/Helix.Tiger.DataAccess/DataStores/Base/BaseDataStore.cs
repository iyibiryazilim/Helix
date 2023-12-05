using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores.Base
{
	public class BaseDataStore
	{
        public readonly IConfiguration _configuraiton;
        public BaseDataStore(IConfiguration configuration)
        {
            _configuraiton = configuration;
        }
    }
}
