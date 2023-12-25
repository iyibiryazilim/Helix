using Helix.ProductService.Domain.AggregateModels.BaseModels;
using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository
{
	public interface IProductTransactionLineService
	{
		/// <summary>
		/// Where column_name IN (TransactionType)
		/// </summary>
		/// <param name="TransactionType"></param>
		/// <returns></returns>
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string ProductCode, string TransactionType);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByTransactionTypeAsync(int ProductId, string TransactionType);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetInputTransactionLineByProductCode(string code);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetInputTransactionLineByProductId(int id);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetOutputTransactionLineByProductCode(string code);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetOutputTransactionLineByProductId(int id);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByFicheId(int id);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByFicheCode(string code);
	}
}
