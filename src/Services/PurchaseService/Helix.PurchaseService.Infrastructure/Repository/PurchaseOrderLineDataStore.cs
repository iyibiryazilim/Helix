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

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLine()
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLine());
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCurrentCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByCurrentCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByCurrentId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByCurrentId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<PurchaseOrderLine>> GetPurchaseOrderLineById(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineById(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByProductCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByProductCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
			 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetPurchaseOrderLineByProductId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetPurchaseOrderLineByProductId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLine()
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLine());
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByCurrentCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByCurrentCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByCurrentId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByCurrentId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByProductCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByProductCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseOrderLine>>> GetWaitingPurchaseOrderLineByProductId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseOrderLine>().GetObjectsAsync(new PurchaseOrderLineQuery(_configuraiton).GetWaitingPurchaseOrderLineByProductId(id));
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
