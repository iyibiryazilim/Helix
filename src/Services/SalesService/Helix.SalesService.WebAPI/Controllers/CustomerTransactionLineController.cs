using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Helix.SalesService.Infrastructure.Helper.Queries.CustomerTransactionLineQuery;

namespace Helix.SalesService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class CustomerTransactionLineController : ControllerBase
	{
		ICustomerTransactionLineService _customerTransactionLineService;
		public CustomerTransactionLineController(ICustomerTransactionLineService customerTransactionLineService)
		{
			_customerTransactionLineService = customerTransactionLineService;
		}

		[HttpGet("Current/Code/{currentCode}")]
		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAndCodeAsync([FromQuery] string search = "", string orderBy = CustomerTransactionLineOrderBy.DateAsc, string currentCode = "", string TransactionType = "1", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransactionLine>>();
			switch (orderBy)
			{
				case "namedesc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.ProductNameDesc, currentCode, TransactionType, page, pageSize);
					return result;
				case "nameasc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.ProductNameAsc, currentCode, TransactionType, page, pageSize);
					return result;
				case "codedesc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.ProductCodeDesc, currentCode, TransactionType, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.ProductCodeAsc, currentCode, TransactionType, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.DateAsc, currentCode, TransactionType, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.DateDesc, currentCode, TransactionType, page, pageSize);
					return result;
				default:
					return result;
			}

		}
		[HttpGet("Current/Id/{currentId:int}")]
		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAndIdAsync([FromQuery] string search = "", string orderBy = CustomerTransactionLineOrderBy.DateAsc, int currentId = 0, string TransactionType = "1", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransactionLine>>();
			switch (orderBy)
			{
				case "namedesc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.ProductNameDesc, currentId, TransactionType, page, pageSize);
					return result;
				case "nameasc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.ProductNameAsc, currentId, TransactionType, page, pageSize);
					return result;
				case "codedesc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.ProductCodeDesc, currentId, TransactionType, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.ProductCodeAsc, currentId, TransactionType, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.DateAsc, currentId, TransactionType, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, CustomerTransactionLineOrderBy.DateDesc, currentId, TransactionType, page, pageSize);
					return result;
				default:
					return result;
			}

		}

        [HttpGet("CurrentAndWarehouse/Id/{currentId:int}&{TransactionType}&{warehouseNumber:int}")]
        public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByTransactionTypeAndIdAndWarehouseAsync(int currentId, int warehouseNumber, string TransactionType, [FromQuery] string search = "", string orderBy = CustomerTransactionLineOrderBy.DateAsc, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<CustomerTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseNumberAsync(search, CustomerTransactionLineOrderBy.ProductNameDesc, currentId,warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseNumberAsync(search, CustomerTransactionLineOrderBy.ProductNameAsc, currentId, warehouseNumber,TransactionType, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseNumberAsync(search, CustomerTransactionLineOrderBy.ProductCodeDesc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseNumberAsync(search, CustomerTransactionLineOrderBy.ProductCodeAsc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseNumberAsync(search, CustomerTransactionLineOrderBy.DateAsc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseNumberAsync(search, CustomerTransactionLineOrderBy.DateDesc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                default:
                    result = await _customerTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseNumberAsync(search, CustomerTransactionLineOrderBy.ProductNameDesc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
            }

        }

        [HttpGet("Current/Code/{currentCode}/All")]
		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByCurrentCodeAsync([FromQuery] string search = "", string orderBy = CustomerTransactionLineOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransactionLine>>();
			switch (orderBy)
			{
				case "namedesc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductNameDesc, currentCode, page, pageSize);
					return result;
				case "nameasc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductNameAsc, currentCode, page, pageSize);
					return result;
				case "codedesc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductCodeDesc, currentCode, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductCodeAsc, currentCode, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.DateAsc, currentCode, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.DateDesc, currentCode, page, pageSize);
					return result;
				default:
					return result;
			}

		}
		[HttpGet("Current/Id/{currentId:int}/All")]
		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByCurrentIdAsync([FromQuery] string search = "", string orderBy = CustomerTransactionLineOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransactionLine>>();
			switch (orderBy)
			{
				case "namedesc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductNameDesc, currentId, page, pageSize);
					return result;
				case "nameasc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductNameAsc, currentId, page, pageSize);
					return result;
				case "codedesc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductCodeDesc, currentId, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductCodeAsc, currentId, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.DateAsc, currentId, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionLineService.GetTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.DateDesc, currentId, page, pageSize);
					return result;
				default:
					return result;
			}
			
		}
		[HttpGet("Current/Code/{currentCode}/Input")]
		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentCode([FromQuery] string search = "", string orderBy = CustomerTransactionLineOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransactionLine>>();
			switch (orderBy)
			{
				case "namedesc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductNameDesc, currentCode, page, pageSize);
					return result;
				case "nameasc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductNameAsc, currentCode, page, pageSize);
					return result;
				case "codedesc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductCodeDesc, currentCode, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductCodeAsc, currentCode, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.DateAsc, currentCode, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.DateDesc, currentCode, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
		[HttpGet("Current/Id/{currentId:int}/Input")]
		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetInputTransactionLineByCurrentId([FromQuery] string search = "", string orderBy = CustomerTransactionLineOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransactionLine>>();
			switch (orderBy)
			{
				case "namedesc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductNameDesc, currentId, page, pageSize);
					return result;
				case "nameasc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductNameAsc, currentId, page, pageSize);
					return result;
				case "codedesc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductCodeDesc, currentId, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductCodeAsc, currentId, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.DateAsc, currentId, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionLineService.GetInputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.DateDesc, currentId, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
		[HttpGet("Current/Code/{currentCode}/Output")]
		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentCode([FromQuery] string search = "", string orderBy = CustomerTransactionLineOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransactionLine>>();
			switch (orderBy)
			{
				case "namedesc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductNameDesc, currentCode, page, pageSize);
					return result;
				case "nameasc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductNameAsc, currentCode, page, pageSize);
					return result;
				case "codedesc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductCodeDesc, currentCode, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.ProductCodeAsc, currentCode, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.DateAsc, currentCode, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentCode(search, CustomerTransactionLineOrderBy.DateDesc, currentCode, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
		[HttpGet("Current/Id/{currentId:int}/Output")]
		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetOutputTransactionLineByCurrentId([FromQuery] string search = "", string orderBy = CustomerTransactionLineOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransactionLine>>();
			switch (orderBy)
			{
				case "namedesc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductNameDesc, currentId, page, pageSize);
					return result;
				case "nameasc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductNameAsc, currentId, page, pageSize);
					return result;
				case "codedesc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductCodeDesc, currentId, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.ProductCodeAsc, currentId, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.DateAsc, currentId, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionLineService.GetOutputTransactionLineByCurrentId(search, CustomerTransactionLineOrderBy.DateDesc, currentId, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
		[HttpGet("Fiche/Code/{ficheCode}")]
		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheCode([FromQuery] string search = "", string orderBy = CustomerTransactionLineOrderBy.DateAsc, string ficheCode = "", int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransactionLine>>();
			switch (orderBy)
			{
				case "namedesc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheCode(search, CustomerTransactionLineOrderBy.ProductNameDesc, ficheCode, page, pageSize);
					return result;
				case "nameasc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheCode(search, CustomerTransactionLineOrderBy.ProductNameAsc, ficheCode, page, pageSize);
					return result;
				case "codedesc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheCode(search, CustomerTransactionLineOrderBy.ProductCodeDesc, ficheCode, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheCode(search, CustomerTransactionLineOrderBy.ProductCodeAsc, ficheCode, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheCode(search, CustomerTransactionLineOrderBy.DateAsc, ficheCode, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheCode(search, CustomerTransactionLineOrderBy.DateDesc, ficheCode, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
		[HttpGet("Fiche/Id/{ficheId:int}")]
		public async Task<DataResult<IEnumerable<CustomerTransactionLine>>> GetTransactionLineByFicheId([FromQuery] string search = "", string orderBy = CustomerTransactionLineOrderBy.DateAsc, int ficheId = 0, int page = 0, int pageSize = 20)
		{
			var result = new DataResult<IEnumerable<CustomerTransactionLine>>();
			switch (orderBy)
			{
				case "namedesc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheId(search, CustomerTransactionLineOrderBy.ProductNameDesc, ficheId, page, pageSize);
					return result;
				case "nameasc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheId(search, CustomerTransactionLineOrderBy.ProductNameAsc, ficheId, page, pageSize);
					return result;
				case "codedesc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheId(search, CustomerTransactionLineOrderBy.ProductCodeDesc, ficheId, page, pageSize);
					return result;
				case "codeasc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheId(search, CustomerTransactionLineOrderBy.ProductCodeAsc, ficheId, page, pageSize);
					return result;
				case "dateasc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheId(search, CustomerTransactionLineOrderBy.DateAsc, ficheId, page, pageSize);
					return result;
				case "datedesc":
					result = await _customerTransactionLineService.GetTransactionLineByFicheId(search, CustomerTransactionLineOrderBy.DateDesc, ficheId, page, pageSize);
					return result;
				default:
					return result;
			} 
		}
	}
}
