using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository;
public class WastageTransactionLineDataStore : BaseDataStore, IWastageTransactionLineService
{
    public WastageTransactionLineDataStore(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<DataResult<WastageTransactionLine>> GetWastageTransactionLineByIdAsync(int id)
    {
        var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionById(id));
        return result;
    }

    public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesAsync()
    {
        var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionList());
        return result;
    }

    public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByCurrentCodeAsync(string code)
    {
        var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByCurrentIdAsync(int id)
    {
        var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
        return result;
    }

    public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByFicheCodeAsync(string code)
    {
        var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByFicheIdAsync(int id)
    {
        var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
        return result;
    }

    public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByProductCodeAsync(string code)
    {
        var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<WastageTransactionLine>>> GetWastageTransactionLinesByProductIdAsync(int id)
    {
        var result = new SqlQueryHelper<WastageTransactionLine>().GetObjectsAsync(new WastageTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
        return result;
    }
}
