using Helix.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Shared.Entity.Models;

namespace Helix.Tiger.DataAccess.DataStores;

public class WorkstationDataStore : BaseDataStore, IWorkstationService
{
	public WorkstationDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<BankAccount>> GetWorkstationByCode(string code)
	{
		throw new NotImplementedException();
	}

	public Task<DataResult<Workstation>> GetWorkstationById(int id)
	{
		throw new NotImplementedException();
	}

	public Task<DataResult<IEnumerable<Workstation>>> GetWorkstations()
	{
		throw new NotImplementedException();
	}
}
