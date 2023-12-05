using Helix.Models;
using Helix.Queries;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Shared.Entity.Models;

namespace Helix.Tiger.DataAccess.DataStores;

public class WorkstationDataStore : BaseDataStore, IWorkstationService
{
	public WorkstationDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<Workstation>> GetWorkstationByCode(string code)
	{
		var result = new SqlQueryHelper<Workstation>().GetObjectAsync(new WorkstationQuery(_configuraiton).GetWorkstationByCode(code));
		return result;
	}

	public Task<DataResult<Workstation>> GetWorkstationById(int id)
	{
		var result = new SqlQueryHelper<Workstation>().GetObjectAsync(new WorkstationQuery(_configuraiton).GetWorkstationById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<Workstation>>> GetWorkstations()
	{
		var result = new SqlQueryHelper<Workstation>().GetObjectsAsync(new WorkstationQuery(_configuraiton).GetWorkstationList());
		return result;
	}
}
