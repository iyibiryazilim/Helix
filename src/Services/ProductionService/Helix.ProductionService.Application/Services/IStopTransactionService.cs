using Helix.ProductionService.Domain.Models;

namespace Helix.ProductionService.Application.Services;

public interface IStopTransactionService
{
	public Task<DataResult<IEnumerable<StopTransaction>>> GetStopTransactionList();
}
