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
	public class PurchaseOrderLineDataStore : BaseDataStore, IPurchaseOrderLineService
	{
		private readonly ILogger<PurchaseOrderLineDataStore> _logger;
		public PurchaseOrderLineDataStore(IConfiguration configuration, ILogger<PurchaseOrderLineDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLine(string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLine(search,orderBy,page,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByCurrentCode(search, orderBy,code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByCurrentId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByFicheCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByFicheCode(search, orderBy, code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByFicheId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByFicheId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByProductCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByProductCode(search, orderBy, code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByProductId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByProductId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLine(string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLine(search, orderBy, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByCurrentCode(search, orderBy,code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByCurrentId(search, orderBy,id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByProductCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByProductCode(search, orderBy, code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByProductId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByProductId(search, orderBy, id, page, pageSize));
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
