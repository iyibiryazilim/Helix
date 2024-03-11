using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.Repository
{
	public class CustomerTransactionLineDataStore : BaseDataStore, ICustomerTransactionLineService
	{
		ILogger<CustomerTransactionLineDataStore> _logger;

		public CustomerTransactionLineDataStore(IConfiguration configuration, ILogger<CustomerTransactionLineDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransactionLine>(_configuraiton).GetObjectsAsync(new CustomerTransactionLineQuery(_configuraiton).GetInputTransactionLineByCurrentCode(search,orderBy,code,page,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransactionLine>(_configuraiton).GetObjectsAsync(new CustomerTransactionLineQuery(_configuraiton).GetInputTransactionLineByCurrentId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransactionLine>(_configuraiton).GetObjectsAsync(new CustomerTransactionLineQuery(_configuraiton).GetOutputTransactionLineByCurrentCode(search, orderBy, code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransactionLine>(_configuraiton).GetObjectsAsync(new CustomerTransactionLineQuery(_configuraiton).GetOutputTransactionLineByCurrentId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransactionLine>(_configuraiton).GetObjectsAsync(new CustomerTransactionLineQuery(_configuraiton).GetTransactionLineByCurrentCode(search, orderBy, code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransactionLine>(_configuraiton).GetObjectsAsync(new CustomerTransactionLineQuery(_configuraiton).GetTransactionLineByCurrentId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransactionLine>(_configuraiton).GetObjectsAsync(new CustomerTransactionLineQuery(_configuraiton).GetTransactionLineByFicheCode(search, orderBy, code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransactionLine>(_configuraiton).GetObjectsAsync(new CustomerTransactionLineQuery(_configuraiton).GetTransactionLineByFicheId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string search, string orderBy, string currentCode, string TransactionType, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransactionLine>(_configuraiton).GetObjectsAsync(new CustomerTransactionLineQuery(_configuraiton).GetTransactionLineByTransactionTypeAsync(search, orderBy, currentCode,TransactionType, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string search, string orderBy, int currentId, string TransactionType, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransactionLine>(_configuraiton).GetObjectsAsync(new CustomerTransactionLineQuery(_configuraiton).GetTransactionLineByTransactionTypeAsync(search, orderBy, currentId, TransactionType, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}
		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAndWarehouseNumberAsync(string search, string orderBy, int currentId, int warehouseNumber,string TransactionType, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransactionLine>(_configuraiton).GetObjectsAsync(new CustomerTransactionLineQuery(_configuraiton).GetTransactionLineByTransactionTypeAndWarehouseAsync(search, orderBy, currentId,warehouseNumber, TransactionType, page, pageSize));
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
