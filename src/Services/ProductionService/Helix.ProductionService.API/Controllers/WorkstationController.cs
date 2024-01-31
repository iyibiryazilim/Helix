using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class WorkstationController : ControllerBase
	{
		IWorkstationService _workstationService;

		public WorkstationController(IWorkstationService workstationService)
		{
			_workstationService = workstationService;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<Workstation>>> GetAll()
		{
			var result = await _workstationService.GetWorkstationList();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<Workstation>> GetById(int id)
		{
			var result = await _workstationService.GetWorkstationById(id);
			return result;
		}

		[HttpGet("Code/{code}")]
		public async Task<DataResult<Workstation>> GetByCode(string code)
		{
			var result = await _workstationService.GetWorkstationByCode(code);
			return result;
		}
	}
}
