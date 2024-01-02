using Helix.PurchaseService.Application.Services;
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

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(search,orderBy,code,page,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
			
 		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(search,orderBy,id,page,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByFicheCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(search,orderBy,code,page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByFicheId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(search,orderBy,id,page,pageSize));
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

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByProductCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(search,orderBy,code,page,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineByProductId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(search,orderBy,id,page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransactionLine>>> GetPurchaseDispatchTransactionLineList(string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransactionLine>().GetObjectsAsync(new PurchaseDispatchTransactionLineQuery(_configuraiton).GetTransactionList(search,orderBy,page,pageSize));
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
