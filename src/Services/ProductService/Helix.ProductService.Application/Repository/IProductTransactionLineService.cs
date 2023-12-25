using Helix.ProductService.Domain.AggregateModels.BaseModels;
using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository
{
	public interface IProductTransactionLineService
	{
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLinesByProductCodeAsync(string ProductCode, string search,
			string orderBy, int page, int pageSize);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLinesByProductIdAsync(int ProductId, string search,
			string orderBy, int page, int pageSize);
		/// <summary>
		/// Where column_name IN (TransactionType)
		/// </summary>
		/// <param name="TransactionType"></param>
		/// <returns></returns>
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByTransactionTypeAsync(string ProductCode, string TransactionType ,string search,
			string orderBy, int page, int pageSize);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByTransactionTypeAsync(int ProductId, string TransactionType, string search,
			string orderBy, int page, int pageSize);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetInputTransactionLineByProductCode(string code, string search,
			string orderBy, int page, int pageSize);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetInputTransactionLineByProductId(int id, string search,
			string orderBy, int page, int pageSize);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetOutputTransactionLineByProductCode(string code, string search,
			string orderBy, int page, int pageSize);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetOutputTransactionLineByProductId(int id, string search,
			string orderBy, int page, int pageSize);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByFicheId(int id, string search,
			string orderBy, int page, int pageSize);
		public Task<DataResult<IEnumerable<ProductTransactionLine>>> GetTransactionLineByFicheCode(string code, string search,
			string orderBy, int page, int pageSize);
	}
}
