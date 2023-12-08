using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductionService.Infrastructure.Repository;

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

	public Task<DataResult<IEnumerable<Workstation>>> GetWorkstationList()
	{
		var result = new SqlQueryHelper<Workstation>().GetObjectsAsync(new WorkstationQuery(_configuraiton).GetWorkstationList());
		return result;
	}
}