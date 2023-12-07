using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LBS.Gateway.Controllers.Tiger;

[Route("api/[controller]")]
[ApiController]
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
	public async Task<DataResult<IEnumerable<Supplier>>> GetAll()
	{
		var result = await _supplierService.GetSupplierList();
		return result;
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
