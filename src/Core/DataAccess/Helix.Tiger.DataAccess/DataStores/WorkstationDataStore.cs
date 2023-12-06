using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class WorkstationDataStore : BaseDataStore, IWorkstationService
{
	public WorkstationDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<Workstation>> GetWorkstationByCode(string code)
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
