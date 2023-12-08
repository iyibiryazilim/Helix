using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository;

public class InCountingTransactionDataStore : BaseDataStore, IInCountingTransactionService
{
    public InCountingTransactionDataStore(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<DataResult<InCountingTransaction>> GetInCountingTransactionByCode(string code)
    {
        var result = new SqlQueryHelper<InCountingTransaction>().GetObjectAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionByCode(code));
        return result;
    }

    public Task<DataResult<InCountingTransaction>> GetInCountingTransactionByIdAsync(int id)
    {
        var result = new SqlQueryHelper<InCountingTransaction>().GetObjectAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionById(id));
        return result;
    }

    public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsAsync()
    {
        var result = new SqlQueryHelper<InCountingTransaction>().GetObjectsAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionList());
        return result;
    }

    public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsByCurrentCodeAsync(string code)
    {
        var result = new SqlQueryHelper<InCountingTransaction>().GetObjectsAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<InCountingTransaction>>> GetInCountingTransactionsByCurrentIdAsync(int id)
    {
        var result = new SqlQueryHelper<InCountingTransaction>().GetObjectsAsync(new InCountingTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
        return result;
    }
}
