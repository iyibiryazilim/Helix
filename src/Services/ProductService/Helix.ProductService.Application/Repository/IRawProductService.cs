
using Helix.ProductService.Domain.Models;

namespace Helix.ProductService.Application.Repository
{
    public interface IRawProductService
    {
        public Task<DataResult<IEnumerable<RawProduct>>> GetProductList();
        public Task<DataResult<RawProduct>> GetProductById(int id);
        public Task<DataResult<RawProduct>> GetProductByCode(string code);
    }

}
