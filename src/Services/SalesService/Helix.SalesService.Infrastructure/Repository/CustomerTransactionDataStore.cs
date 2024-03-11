using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.Repository
{
	public class CustomerTransactionDataStore : BaseDataStore, ICustomerTransactionService
	{
		ILogger<CustomerTransactionDataStore> _logger;

        public CustomerTransactionDataStore(IConfiguration configuration, ILogger<CustomerTransactionDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>(_configuraiton).GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetInputTransactionByCurrentCode(search,orderBy,code,page,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>(_configuraiton).GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetInputTransactionByCurrentId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>(_configuraiton).GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetOutputTransactionByCurrentCode(search, orderBy, code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>(_configuraiton).GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetOutputTransactionByCurrentId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>(_configuraiton).GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetTransactionByCurrentCode(search, orderBy, code, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>(_configuraiton).GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetTransactionByCurrentId(search, orderBy, id, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(string search, string orderBy, string currentCode, string TransactionType, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>(_configuraiton).GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetTransactionByTransactionTypeAsync(search,orderBy, currentCode,TransactionType,page,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}
		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(string search, string orderBy, int currentId, string TransactionType, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>(_configuraiton).GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetTransactionByTransactionTypeAsync(search, orderBy, currentId, TransactionType, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}
	
		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAndWarehouseNumberAsync(string search, string orderBy, int currentId,int warehouseNumber, string TransactionType, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>(_configuraiton).GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetTransactionByTransactionTypeAndWarehouseAsync(search, orderBy, currentId,warehouseNumber ,TransactionType, page, pageSize));
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
