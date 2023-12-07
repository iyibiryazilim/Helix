using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository.Base
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
