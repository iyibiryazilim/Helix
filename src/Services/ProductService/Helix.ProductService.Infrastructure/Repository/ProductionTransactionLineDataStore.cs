using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository;

public class ProductionTransactionLineDataStore : BaseDataStore, IProductionTransactionLineService
{
    public ProductionTransactionLineDataStore(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<DataResult<ProductionTransactionLine>> GetProductionTransactionLineByIdAsync(int id)
    {
        var result = new SqlQueryHelper<ProductionTransactionLine>().GetObjectAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionById(id));
        return result;
    }

    public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesAsync()
    {
        var result = new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionList());
        return result;
    }

    public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByCurrentCodeAsync(string code)
    {
        var result = new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByCurrentIdAsync(int id)
    {
        var result = new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
        return result;
    }

    public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByFicheCodeAsync(string code)
    {
        var result = new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByFicheIdAsync(int id)
    {
        var result = new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
        return result;
    }

    public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByProductCodeAsync(string code)
    {
        var result = new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByProductIdAsync(int id)
    {
        var result = new SqlQueryHelper<ProductionTransactionLine>().GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
        return result;
    }
}
