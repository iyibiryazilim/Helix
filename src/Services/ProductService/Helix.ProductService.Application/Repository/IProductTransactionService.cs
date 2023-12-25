using Helix.ProductService.Domain.AggregateModels.BaseModels;
using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository
{
	public interface IProductTransactionService
	{
		/// <summary>
		/// Where column_name IN (TransactionType)
		/// </summary>
		/// <param name="TransactionType"></param>
		/// <returns></returns>
		public Task<DataResult<IEnumerable<ProductTransaction>>> GetTransactionByTransactionTypeAsync(string ProductCode, string TransactionType);
		public Task<DataResult<IEnumerable<ProductTransaction>>> GetTransactionByTransactionTypeAsync(int ProductId, string TransactionType);
		public Task<DataResult<IEnumerable<ProductTransaction>>> GetInputTransactionByProductCode(string code);
		public Task<DataResult<IEnumerable<ProductTransaction>>> GetInputTransactionByProductId(int id);
		public Task<DataResult<IEnumerable<ProductTransaction>>> GetOutputTransactionByProductCode(string code);
		public Task<DataResult<IEnumerable<ProductTransaction>>> GetOutputTransactionByProductId(int id);
	}
}
