using Helix.ProductionService.Domain.Models;

namespace Helix.ProductionService.Application.Services;

public interface IStopCauseService
{
	public Task<DataResult<IEnumerable<StopCause>>> GetStopCauseList();
}
