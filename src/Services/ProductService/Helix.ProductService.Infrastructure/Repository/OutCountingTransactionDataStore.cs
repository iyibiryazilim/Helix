using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository;

public class OutCountingTransactionDataStore : BaseDataStore, IOutCountingTransactionService
{
    public OutCountingTransactionDataStore(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<DataResult<OutCountingTransaction>> GetOutCountingTransactionByCode(string code)
    {
        var result = new SqlQueryHelper<OutCountingTransaction>().GetObjectAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionByCode(code));
        return result;
    }

    public Task<DataResult<OutCountingTransaction>> GetOutCountingTransactionByIdAsync(int id)
    {
        var result = new SqlQueryHelper<OutCountingTransaction>().GetObjectAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionById(id));
        return result;
    }

    public Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsAsync()
    {
        var result = new SqlQueryHelper<OutCountingTransaction>().GetObjectsAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionList());
        return result;
    }

    public Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsByCurrentCodeAsync(string code)
    {
        var result = new SqlQueryHelper<OutCountingTransaction>().GetObjectsAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<OutCountingTransaction>>> GetOutCountingTransactionsByCurrentIdAsync(int id)
    {
        var result = new SqlQueryHelper<OutCountingTransaction>().GetObjectsAsync(new OutCountingTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
        return result;
    }
}
