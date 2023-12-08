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
	public class PurchaseDispatchTransactionDataStore : BaseDataStore, IPurchaseDispatchTransactionService
	{
		private readonly ILogger<PurchaseDispatchTransactionDataStore> _logger;
		public PurchaseDispatchTransactionDataStore(IConfiguration configuration,ILogger<PurchaseDispatchTransactionDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<PurchaseDispatchTransaction>> GetPurchaseDispatchTransactionByCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransaction>().GetObjectAsync(new PurchaseDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
				_logger.LogInformation(code, result);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message);
				throw;
			}
			
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionByCurrentCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransaction>().GetObjectsAsync(new PurchaseDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionByCurrentId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransaction>().GetObjectsAsync(new PurchaseDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
 		}

		public async Task<DataResult<PurchaseDispatchTransaction>> GetPurchaseDispatchTransactionById(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransaction>().GetObjectAsync(new PurchaseDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
			
		}

		public async Task<DataResult<IEnumerable<PurchaseDispatchTransaction>>> GetPurchaseDispatchTransactionList()
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseDispatchTransaction>().GetObjectsAsync(new PurchaseDispatchTransactionQuery(_configuraiton).GetTransactionList());
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
