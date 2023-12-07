
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class EndProductDataStore : BaseDataStore, IEndProductService
	{
		public EndProductDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<EndProduct>> GetProductByCode(string code)
		{
			var result = new SqlQueryHelper<EndProduct>().GetObjectAsync(new EndProductQuery(_configuraiton).GetEndProductByCode(code));
			return result;
		}

		public Task<DataResult<EndProduct>> GetProductById(int id)
		{
			var result = new SqlQueryHelper<EndProduct>().GetObjectAsync(new EndProductQuery(_configuraiton).GetEndProductById(id));
			return result;
		}

		public Task<DataResult<IEnumerable<EndProduct>>> GetProductList()
		{
			var result = new SqlQueryHelper<EndProduct>().GetObjectsAsync(new EndProductQuery(_configuraiton).GetEndProductList());
			return result;
		}
	}
}
