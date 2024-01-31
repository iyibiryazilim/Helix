using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Helix.PurchaseService.Infrastructure.Helper.Queries.SupplierQuery;

namespace LBS.Gateway.Controllers.Tiger;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SupplierController : ControllerBase
{
	ISupplierService _supplierService;
	IConfiguration _configuration;
	public SupplierController(ISupplierService supplierService, IConfiguration configuration)
	{
		_supplierService = supplierService;
		_configuration = configuration;
	}
	[HttpGet]
	public async Task<DataResult<IEnumerable<Supplier>>> GetAll([FromQuery] string search = "", string orderBy = SupplierOrderBy.SupplierNameAsc, int page = 0, int pageSize = 20)
	{
		DataResult<IEnumerable<Supplier>> result = new();
		switch (orderBy)
		{
			case "namedesc":
				result = await _supplierService.GetSupplierList(search, SupplierOrderBy.SupplierNameDesc, page, pageSize);
				return result;
			case "nameasc":
				result = await _supplierService.GetSupplierList(search, SupplierOrderBy.SupplierNameAsc, page, pageSize);
				return result;
			case "codedesc":
				result = await _supplierService.GetSupplierList(search, SupplierOrderBy.SupplierCodeDesc, page, pageSize);
				return result;
			case "codeasc":
				result = await _supplierService.GetSupplierList(search, SupplierOrderBy.SupplierCodeAsc, page, pageSize);
				return result;
			default:
				result = await _supplierService.GetSupplierList(search, orderBy, page, pageSize);
				return result;
		}
		 
	}
	[HttpGet("Code/{code}")]
	public async Task<DataResult<Supplier>> GetByCode(string code)
	{
		var result = await _supplierService.GetSupplierByCode(code);
		return result;
	}
	[HttpGet("Id/{id:int}")]
	public async Task<DataResult<Supplier>> GetById(int id)
	{
		var result = await _supplierService.GetSupplierById(id);
		return result;
	}
}
