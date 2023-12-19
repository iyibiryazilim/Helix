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

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>().GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetInputTransactionByCurrentCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetInputTransactionByCurrentId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>().GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetInputTransactionByCurrentId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentCode(string code)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>().GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetOutputTransactionByCurrentCode(code));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetOutputTransactionByCurrentId(int id)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>().GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetOutputTransactionByCurrentId(id));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(string currentCode, string TransactionType)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>().GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetTransactionByTransactionTypeAsync(currentCode,TransactionType));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;

			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<CustomerTransaction>>> GetTransactionByTransactionTypeAsync(int currentId, string TransactionType)
		{
			try
			{
				var result = await new SqlQueryHelper<CustomerTransaction>().GetObjectsAsync(new CustomerTransactionQuery(_configuraiton).GetTransactionByTransactionTypeAsync(currentId,TransactionType));
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
