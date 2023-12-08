using Helix.ProductionService.Domain.Models;

namespace Helix.ProductionService.Application.Services;

public interface IWorkstationService
{
	public Task<DataResult<IEnumerable<Workstation>>> GetWorkstationList();
	public Task<DataResult<Workstation>> GetWorkstationById(int id);
	public Task<DataResult<Workstation>> GetWorkstationByCode(string code);
}
