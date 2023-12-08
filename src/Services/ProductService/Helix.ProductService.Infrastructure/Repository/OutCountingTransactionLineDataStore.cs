using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository;

public class OutCountingTransactionLineDataStore : BaseDataStore, IOutCountingTransactionLineService
{
    public OutCountingTransactionLineDataStore(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<DataResult<OutCountingTransactionLine>> GetOutCountingTransactionLineByIdAsync(int id)
    {
        var result = new SqlQueryHelper<OutCountingTransactionLine>().GetObjectAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionById(id));
        return result;
    }

    public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesAsync()
    {
        var result = new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionList());
        return result;
    }

    public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByCurrentCodeAsync(string code)
    {
        var result = new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByCurrentIdAsync(int id)
    {
        var result = new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
        return result;
    }

    public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByFicheCodeAsync(string code)
    {
        var result = new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByFicheIdAsync(int id)
    {
        var result = new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
        return result;
    }

    public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByProductCodeAsync(string code)
    {
        var result = new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
        return result;
    }

    public Task<DataResult<IEnumerable<OutCountingTransactionLine>>> GetOutCountingTransactionLinesByProductIdAsync(int id)
    {
        var result = new SqlQueryHelper<OutCountingTransactionLine>().GetObjectsAsync(new OutCountingTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
        return result;
    }
}
