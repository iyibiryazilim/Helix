using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

 
namespace Helix.Tiger.DataAccess.Services;

public interface IWorkstationService
{
	public Task<DataResult<IEnumerable<Workstation>>> GetWorkstations();
	public Task<DataResult<Workstation>> GetWorkstationById(int id);
	public Task<DataResult<Workstation>> GetWorkstationByCode(string code);
}
