
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Domain.Models.BaseModels;

namespace Helix.ProductionService.Application.Services;

public interface IWorkstationService
{
	public Task<DataResult<IEnumerable<Workstation>>> GetWorkstations();
	public Task<DataResult<Workstation>> GetWorkstationById(int id);
	public Task<DataResult<Workstation>> GetWorkstationByCode(string code);
}
