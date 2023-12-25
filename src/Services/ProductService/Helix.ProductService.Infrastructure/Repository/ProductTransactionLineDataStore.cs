using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class ProductTransactionLineDataStore : BaseDataStore, IProductTransactionLineService
	{
		ILogger<ProductTransactionLineDataStore> _logger;
		public ProductTransactionLineDataStore(IConfiguration configuration, ILogger<ProductTransactionLineDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetInputTransactionLineByProductCode(string code,string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<ProductTransactionLine>().GetObjectsAsync(new ProductTransactionLineQuery(_configuraiton).GetInputTransactionLineByProductCode(code,search,orderBy,page,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetInputTransactionLineByProductId(int id, string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<ProductTransactionLine>().GetObjectsAsync(new ProductTransactionLineQuery(_configuraiton).GetInputTransactionLineByProductId(id, search, orderBy, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetOutputTransactionLineByProductCode(string code, string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<ProductTransactionLine>().GetObjectsAsync(new ProductTransactionLineQuery(_configuraiton).GetOutputTransactionLineByProductCode(code, search, orderBy, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetOutputTransactionLineByProductId(int id, string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<ProductTransactionLine>().GetObjectsAsync(new ProductTransactionLineQuery(_configuraiton).GetOutputTransactionLineByProductId(id, search, orderBy, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByFicheCode(string code, string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<ProductTransactionLine>().GetObjectsAsync(new ProductTransactionLineQuery(_configuraiton).GetTransactionLineByFicheCode(code, search, orderBy, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByFicheId(int id, string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<ProductTransactionLine>().GetObjectsAsync(new ProductTransactionLineQuery(_configuraiton).GetTransactionLineByFicheId(id, search, orderBy, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string ProductCode, string TransactionType, string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<ProductTransactionLine>().GetObjectsAsync(new ProductTransactionLineQuery(_configuraiton).GetTransactionLineByTransactionTypeAsync(ProductCode,TransactionType,search,orderBy,page,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByTransactionTypeAsync(int ProductId, string TransactionType, string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<ProductTransactionLine>().GetObjectsAsync(new ProductTransactionLineQuery(_configuraiton).GetTransactionLineByTransactionTypeAsync(ProductId,TransactionType, search, orderBy, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLinesByProductCodeAsync(string ProductCode, string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<ProductTransactionLine>().GetObjectsAsync(new ProductTransactionLineQuery(_configuraiton).GetTransactionLinesByProductCodeAsync(ProductCode, search, orderBy, page, pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}

		public async Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLinesByProductIdAsync(int ProductId, string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<ProductTransactionLine>().GetObjectsAsync(new ProductTransactionLineQuery(_configuraiton).GetTransactionLinesByProductIdAsync(ProductId, search, orderBy, page, pageSize));
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
