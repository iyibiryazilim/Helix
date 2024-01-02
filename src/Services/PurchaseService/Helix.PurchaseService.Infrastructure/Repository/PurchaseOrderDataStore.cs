using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.AggregateModelss;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.BaseRepository;
using Helix.PurchaseService.Infrastructure.Helper;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Helix.Tiger.DataAccess.DataStores
{
	public class PurchaseOrderDataStore : BaseDataStore, IPurchaseOrderService
	{
		private readonly ILogger<PurchaseOrderDataStore> _logger;
		public PurchaseOrderDataStore(IConfiguration configuration, ILogger<PurchaseOrderDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderList(string search, string orderBy, int currentPage, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrder>().GetObjectsAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrder(search,orderBy,currentPage,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<PurchaseOrder>> GetPurchaseOrderByCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrder>().GetObjectAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderByCode(code)); _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderByCurrentCode(string search, string orderBy, string code, int currentPage, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrder>().GetObjectsAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderByCurrentCode(search,orderBy,code,currentPage,pageSize));
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderByCurrentId(string search, string orderBy, int id, int currentPage, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrder>().GetObjectsAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderByCurrentId(search, orderBy, id, currentPage, pageSize));
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<PurchaseOrder>> GetPurchaseOrderById(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrder>().GetObjectAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderById(id));
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
