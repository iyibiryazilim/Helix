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

		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderList()
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrder>().GetObjectsAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderQuery());
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
				var result = await new SqlQueryHelper<PurchaseOrder>().GetObjectAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderByCodeQuery(code)); _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderByCurrentCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrder>().GetObjectsAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderByCurrentCodeQuery(code));
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrder>>> GetPurchaseOrderByCurrentId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrder>().GetObjectsAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderByCurrentIdQuery(id));
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
				var result = await new SqlQueryHelper<PurchaseOrder>().GetObjectAsync(new PurchaseOrderQuery(_configuraiton).GetPurchaseOrderByIdQuery(id));
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
