using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.Models;
using Helix.PurchaseService.Infrastructure.Helper.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.PurchaseService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class SupplierTransactionController : ControllerBase
    {
        ISupplierTransactionService _supplierTransactionService;
        public SupplierTransactionController(ISupplierTransactionService supplierTransactionService)
        {
                _supplierTransactionService = supplierTransactionService;
        }
        [HttpGet("Current/Code/{currentCode}")]
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAndCodeAsync([FromQuery] string search = "", string orderBy = SupplierTransactionOrderBy.DateAsc, string currentCode = "", string TransactionType = "1", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransaction>>();
            switch (orderBy)
            {

                case "codedesc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAsync(search, SupplierTransactionOrderBy.CodeDesc, currentCode, TransactionType, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAsync(search, SupplierTransactionOrderBy.CodeAsc, currentCode, TransactionType, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAsync(search, SupplierTransactionOrderBy.DateAsc, currentCode, TransactionType, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAsync(search, SupplierTransactionOrderBy.DateDesc, currentCode, TransactionType, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
        [HttpGet("Current/Id/{currentId:int}")]
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAndIdAsync([FromQuery] string search = "", string orderBy = SupplierTransactionOrderBy.DateAsc, int currentId = 0, string TransactionType = "1", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransaction>>();
            switch (orderBy)
            {

                case "codedesc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAsync(search, SupplierTransactionOrderBy.CodeDesc, currentId, TransactionType, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAsync(search, SupplierTransactionOrderBy.CodeAsc, currentId, TransactionType, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAsync(search, SupplierTransactionOrderBy.DateAsc, currentId, TransactionType, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAsync(search, SupplierTransactionOrderBy.DateDesc, currentId, TransactionType, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }

        [HttpGet("CurrentAndWarehouse/Id/{currentId:int}&{warehouseNumber:int}&{TransactionType}")]
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAndIdAndWarehouseAsync(int currentId, int warehouseNumber, string TransactionType,[FromQuery] string search = "", string orderBy = SupplierTransactionOrderBy.DateAsc, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransaction>>();
            switch (orderBy)
            {

                case "codedesc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAsync(search, SupplierTransactionOrderBy.CodeDesc, currentId,warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAsync(search, SupplierTransactionOrderBy.CodeAsc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAsync(search, SupplierTransactionOrderBy.DateAsc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAsync(search, SupplierTransactionOrderBy.DateDesc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                default:
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAsync(search, SupplierTransactionOrderBy.DateDesc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
            }
        }
        
        [HttpGet("CurrentAndWarehouseAndShipInfo/Id/{currentId:int}&{warehouseNumber:int}&{TransactionType}&{shipInfoReferenceId:int}")]
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByTransactionTypeAndIdAndWarehouseAndShipInfoAsync(int currentId, int warehouseNumber, string TransactionType, int shipInfoReferenceId,[FromQuery] string search = "", string orderBy = SupplierTransactionOrderBy.DateAsc, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransaction>>();
            switch (orderBy)
            {

                case "codedesc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionOrderBy.CodeDesc, currentId, warehouseNumber,shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionOrderBy.CodeAsc, currentId, warehouseNumber, shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionOrderBy.DateAsc, currentId, warehouseNumber, shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionOrderBy.DateDesc, currentId, warehouseNumber, shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
                default:
                    result = await _supplierTransactionService.GetTransactionByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionOrderBy.CodeDesc, currentId, warehouseNumber, shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
            }
        }

        [HttpGet("Current/Code/{currentCode}/All")]
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByCurrentCodeAsync([FromQuery] string search = "", string orderBy = SupplierTransactionOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransaction>>();
            switch (orderBy)
            {

                case "codedesc":
                    result = await _supplierTransactionService.GetTransactionByCurrentCode(search, SupplierTransactionOrderBy.CodeDesc, currentCode, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionService.GetTransactionByCurrentCode(search, SupplierTransactionOrderBy.CodeAsc, currentCode, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionService.GetTransactionByCurrentCode(search, SupplierTransactionOrderBy.DateAsc, currentCode, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionService.GetTransactionByCurrentCode(search, SupplierTransactionOrderBy.DateDesc, currentCode, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
        [HttpGet("Current/Id/{currentId:int}/All")]
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetTransactionByCurrentIdAsync([FromQuery] string search = "", string orderBy = SupplierTransactionOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransaction>>();
            switch (orderBy)
            {

                case "codedesc":
                    result = await _supplierTransactionService.GetTransactionByCurrentId(search, SupplierTransactionOrderBy.CodeDesc, currentId, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionService.GetTransactionByCurrentId(search, SupplierTransactionOrderBy.CodeAsc, currentId, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionService.GetTransactionByCurrentId(search, SupplierTransactionOrderBy.DateAsc, currentId, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionService.GetTransactionByCurrentId(search, SupplierTransactionOrderBy.DateDesc, currentId, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
        [HttpGet("Current/Code/{currentCode}/Input")]
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetInputTransactionByCurrentCode([FromQuery] string search = "", string orderBy = SupplierTransactionOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransaction>>();
            switch (orderBy)
            {

                case "codedesc":
                    result = await _supplierTransactionService.GetInputTransactionByCurrentCode(search, SupplierTransactionOrderBy.CodeDesc, currentCode, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionService.GetInputTransactionByCurrentCode(search, SupplierTransactionOrderBy.CodeAsc, currentCode, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionService.GetInputTransactionByCurrentCode(search, SupplierTransactionOrderBy.DateAsc, currentCode, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionService.GetInputTransactionByCurrentCode(search, SupplierTransactionOrderBy.DateDesc, currentCode, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
        [HttpGet("Current/Id/{currentId:int}/Input")]
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetInputTransactionByCurrentId([FromQuery] string search = "", string orderBy = SupplierTransactionOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransaction>>();
            switch (orderBy)
            {

                case "codedesc":
                    result = await _supplierTransactionService.GetInputTransactionByCurrentId(search, SupplierTransactionOrderBy.CodeDesc, currentId, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionService.GetInputTransactionByCurrentId(search, SupplierTransactionOrderBy.CodeAsc, currentId, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionService.GetInputTransactionByCurrentId(search, SupplierTransactionOrderBy.DateAsc, currentId, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionService.GetInputTransactionByCurrentId(search, SupplierTransactionOrderBy.DateDesc, currentId, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
        [HttpGet("Current/Code/{currentCode}/Output")]
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetOutputTransactionByCurrentCode([FromQuery] string search = "", string orderBy = SupplierTransactionOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransaction>>();
            switch (orderBy)
            {

                case "codedesc":
                    result = await _supplierTransactionService.GetOutputTransactionByCurrentCode(search, SupplierTransactionOrderBy.CodeDesc, currentCode, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionService.GetOutputTransactionByCurrentCode(search, SupplierTransactionOrderBy.CodeAsc, currentCode, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionService.GetOutputTransactionByCurrentCode(search, SupplierTransactionOrderBy.DateAsc, currentCode, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionService.GetOutputTransactionByCurrentCode(search, SupplierTransactionOrderBy.DateDesc, currentCode, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
        [HttpGet("Current/Id/{currentId:int}/Output")]
        public async Task<DataResult<IEnumerable<SupplierTransaction>>> GetOutputTransactionByCurrentId([FromQuery] string search = "", string orderBy = SupplierTransactionOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransaction>>();
            switch (orderBy)
            {

                case "codedesc":
                    result = await _supplierTransactionService.GetOutputTransactionByCurrentId(search, SupplierTransactionOrderBy.CodeDesc, currentId, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionService.GetOutputTransactionByCurrentId(search, SupplierTransactionOrderBy.CodeAsc, currentId, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionService.GetOutputTransactionByCurrentId(search, SupplierTransactionOrderBy.DateAsc, currentId, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionService.GetOutputTransactionByCurrentId(search, SupplierTransactionOrderBy.DateDesc, currentId, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
    }
}
