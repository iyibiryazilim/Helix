using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository;

public class WastageTransactionDataStore : BaseDataStore, IWastageTransactionService
{
    public WastageTransactionDataStore(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<DataResult<WastageTransaction>> GetWastageTransactionByCode(string code)
    {
        var result = new SqlQueryHelper<WastageTransaction>().GetObjectAsync(new WastageTransactionQuery(_configuraiton).GetTransactionByCode(code));
        return result;
    }

    public Task<DataResult<WastageTransaction>> GetWastageTransactionByIdAsync(int id)
    {
        var result = new SqlQueryHelper<WastageTransaction>().GetObjectAsync(new WastageTransactionQuery(_configuraiton).GetTransactionById(id));
        return result;
    }

    public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsAsync()
    {
        var result = new SqlQueryHelper<WastageTransaction>().GetObjectsAsync(new WastageTransactionQuery(_configuraiton).GetTransactionList());
        return result;
    }

    public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsByCurrentCodeAsync(string code)
    {
        var result = new SqlQueryHelper<WastageTransaction>().GetObjectsAsync(new WastageTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<WastageTransaction>>> GetWastageTransactionsByCurrentIdAsync(int id)
    {
        var result = new SqlQueryHelper<WastageTransaction>().GetObjectsAsync(new WastageTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
        return result;
    }
}
