using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository;

public class TransferTransactionDataStore : BaseDataStore, ITransferTransactionService
{
    public TransferTransactionDataStore(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<DataResult<TransferTransaction>> GetTransferTransactionByCode(string code)
    {
        var result = new SqlQueryHelper<TransferTransaction>().GetObjectAsync(new TransferTransactionQuery(_configuraiton).GetTransactionByCode(code));
        return result;
    }

    public Task<DataResult<TransferTransaction>> GetTransferTransactionByIdAsync(int id)
    {
        var result = new SqlQueryHelper<TransferTransaction>().GetObjectAsync(new TransferTransactionQuery(_configuraiton).GetTransactionById(id));
        return result;
    }

    public Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsAsync()
    {
        var result = new SqlQueryHelper<TransferTransaction>().GetObjectsAsync(new TransferTransactionQuery(_configuraiton).GetTransactionList());
        return result;
    }

    public Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsByCurrentCodeAsync(string code)
    {
        var result = new SqlQueryHelper<TransferTransaction>().GetObjectsAsync(new TransferTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<TransferTransaction>>> GetTransferTransactionsByCurrentIdAsync(int id)
    {
        var result = new SqlQueryHelper<TransferTransaction>().GetObjectsAsync(new TransferTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
        return result;
    }
}
