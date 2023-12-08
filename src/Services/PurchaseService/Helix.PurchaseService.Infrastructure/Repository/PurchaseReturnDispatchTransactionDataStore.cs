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
	public class PurchaseReturnDispatchTransactionDataStore : BaseDataStore, IPurchaseReturnDispatchTransactionService
	{
		private readonly ILogger<PurchaseReturnDispatchTransactionDataStore> _logger;
		public PurchaseReturnDispatchTransactionDataStore(IConfiguration configuration, ILogger<PurchaseReturnDispatchTransactionDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<PurchaseReturnDispatchTransaction>> GetTransactionByCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransaction>().GetObjectAsync(new PurchaseReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionByCurrentCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransaction>().GetObjectsAsync(new PurchaseReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionByCurrentId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransaction>().GetObjectsAsync(new PurchaseReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
			 
		}

		public async Task<DataResult<PurchaseReturnDispatchTransaction>> GetTransactionById(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransaction>().GetObjectAsync(new PurchaseReturnDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			} 
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransaction>>> GetTransactionList()
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransaction>().GetObjectsAsync(new PurchaseReturnDispatchTransactionQuery(_configuraiton).GetTransactionList());
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
