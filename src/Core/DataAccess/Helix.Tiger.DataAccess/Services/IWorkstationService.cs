using Helix.Models;
using Shared.Entity.Models;

namespace Helix.Tiger.DataAccess.Services;

public interface IWorkstationService
{
	public Task<DataResult<IEnumerable<Workstation>>> GetWorkstations();
	public Task<DataResult<Workstation>> GetWorkstationById(int id);
	public Task<DataResult<BankAccount>> GetWorkstationByCode(string code);
}
