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
	public class PurchaseDispatchTransactionLineDataStore : BaseDataStore, IPurchaseDispatchTransactionLineService
	{
		private readonly ILogger<PurchaseDispatchTransactionLineDataStore> _logger;
		public PurchaseDispatchTransactionLineDataStore(IConfiguration configuration, ILogger<PurchaseDispatchTransactionLineDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByCurrentCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
			
 		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByCurrentId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByFicheCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByFicheId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<PurchaseDispatchTransactionLine>> GetPurchaseDispatchTransactionLineById(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByProductCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByProductId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineList()
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
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
