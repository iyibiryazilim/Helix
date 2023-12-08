using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository;

public class ProductionTransactionDataStore : BaseDataStore, IProductionTransactionService
{
    public ProductionTransactionDataStore(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<DataResult<ProductionTransaction>> GetProductionTransactionByCode(string code)
    {
        var result = new SqlQueryHelper<ProductionTransaction>().GetObjectAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCode(code));
        return result;
    }

    public Task<DataResult<ProductionTransaction>> GetProductionTransactionByIdAsync(int id)
    {
        var result = new SqlQueryHelper<ProductionTransaction>().GetObjectAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionById(id));
        return result;
    }

    public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsAsync()
    {
        var result = new SqlQueryHelper<ProductionTransaction>().GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionList());
        return result;
    }

    public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentCodeAsync(string code)
    {
        var result = new SqlQueryHelper<ProductionTransaction>().GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentIdAsync(int id)
    {
        var result = new SqlQueryHelper<ProductionTransaction>().GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
        return result;
    }
}
