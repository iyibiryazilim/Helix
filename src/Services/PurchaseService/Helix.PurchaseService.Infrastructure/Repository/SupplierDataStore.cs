using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.BaseRepository;
using Helix.PurchaseService.Infrastructure.Helper;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.PurchaseService.Infrastructure.Repository
{
	public class SupplierDataStore : BaseDataStore, ISupplierService
	{
		private readonly ILogger<SupplierDataStore> _logger;
		public SupplierDataStore(IConfiguration configuration, ILogger<SupplierDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<Supplier>> GetSupplierByCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<Supplier>().GetObjectAsync(new SupplierQuery(_configuraiton).GetSupplierByCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<Supplier>> GetSupplierById(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<Supplier>().GetObjectAsync(new SupplierQuery(_configuraiton).GetSupplierById(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<Supplier>>> GetSupplierList(string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<Supplier>().GetObjectsAsync(new SupplierQuery(_configuraiton).GetSupplierList(search,orderBy,page,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}
	}
}
