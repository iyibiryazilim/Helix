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
	public class PurchaseReturnDispatchTransactionLineDataStore : BaseDataStore, IPurchaseReturnDispatchTransactionLineService
	{
		private readonly ILogger<PurchaseReturnDispatchTransactionLineDataStore> _logger;
		public PurchaseReturnDispatchTransactionLineDataStore(IConfiguration configuration, ILogger<PurchaseReturnDispatchTransactionLineDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByCurrentCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByCurrentId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByFicheCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByFicheId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
			
 		}

		public async Task<DataResult<PurchaseReturnDispatchTransactionLine>> GetTransactionById(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByProductCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionByProductId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionList()
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
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
