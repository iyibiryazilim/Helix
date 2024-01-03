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

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(search, orderBy, code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}

		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByFicheCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(search, orderBy, code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByFicheId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<PurchaseReturnDispatchTransactionLine>> GetTransactionLineById(int id)
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

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByProductCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(search, orderBy, code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineByProductId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
				throw;
			}
		}

		public async Task<DataResult<IEnumerable<PurchaseReturnDispatchTransactionLine>>> GetTransactionLineList(string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<PurchaseReturnDispatchTransactionLine>().GetObjectsAsync(new PurchaseReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionList(search, orderBy, page, pageSize));
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
