using Helix.PurchaseService.Application.Services;
using Helix.PurchaseService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Helix.PurchaseService.Infrastructure.Helper.Queries.SupplierTransactionLineQuery;

namespace Helix.PurchaseService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SupplierTransactionLineController : ControllerBase
    {
        ISupplierTransactionLineService _supplierTransactionLineService;
        public SupplierTransactionLineController(ISupplierTransactionLineService SupplierTransactionLineService)
        {
            _supplierTransactionLineService = SupplierTransactionLineService;
        }
        [HttpGet("Current/Code/{currentCode}")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAndCodeAsync([FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, string currentCode = "", string TransactionType = "1", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentCode, TransactionType, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.ProductNameAsc, currentCode, TransactionType, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.ProductCodeDesc, currentCode, TransactionType, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.ProductCodeAsc, currentCode, TransactionType, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.DateAsc, currentCode, TransactionType, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.DateDesc, currentCode, TransactionType, page, pageSize);
                    return result;
                default:
                    return result;
            }

        }
        [HttpGet("Current/Id/{currentId:int}")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAndIdAsync([FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, int currentId = 0, string TransactionType = "1", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentId, TransactionType, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.ProductNameAsc, currentId, TransactionType, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.ProductCodeDesc, currentId, TransactionType, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.ProductCodeAsc, currentId, TransactionType, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.DateAsc, currentId, TransactionType, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAsync(search, SupplierTransactionLineOrderBy.DateDesc, currentId, TransactionType, page, pageSize);
                    return result;
                default:
                    result.Message = "OrderBy wrong text";
                    return result;
            }

        }

        [HttpGet("CurrentAndWarehouse/Id/{currentId:int}&{TransactionType}&{warehouseNumber:int}")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAndIdAndWarehouseAsync(int currentId, int warehouseNumber, string TransactionType, [FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAsync(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAsync(search, SupplierTransactionLineOrderBy.ProductNameAsc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAsync(search, SupplierTransactionLineOrderBy.ProductCodeDesc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAsync(search, SupplierTransactionLineOrderBy.ProductCodeAsc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAsync(search, SupplierTransactionLineOrderBy.DateAsc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAsync(search, SupplierTransactionLineOrderBy.DateDesc, currentId,warehouseNumber, TransactionType, page, pageSize);
                    return result;
                default:
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAsync(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentId, warehouseNumber, TransactionType, page, pageSize);
                    return result;
            }

        }

        [HttpGet("CurrentAndWarehouseAndShipInfo/Id/{currentId:int}&{TransactionType}&{warehouseNumber:int}&{shipInfoReferenceId:int}")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByTransactionTypeAndIdAndWarehouseAndShipInfoAsync(int currentId, int warehouseNumber,int shipInfoReferenceId, string TransactionType, [FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentId, warehouseNumber, shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionLineOrderBy.ProductNameAsc, currentId, warehouseNumber, shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionLineOrderBy.ProductCodeDesc, currentId, warehouseNumber, shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionLineOrderBy.ProductCodeAsc, currentId, warehouseNumber, shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionLineOrderBy.DateAsc, currentId, warehouseNumber, shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionLineOrderBy.DateDesc, currentId, warehouseNumber,shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
                default:
                    result = await _supplierTransactionLineService.GetTransactionLineByTransactionTypeAndWarehouseAndShipInfoAsync(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentId, warehouseNumber, shipInfoReferenceId, TransactionType, page, pageSize);
                    return result;
            }

        }

        [HttpGet("Current/Code/{currentCode}/All")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByCurrentCodeAsync([FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentCode, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductNameAsc, currentCode, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductCodeDesc, currentCode, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductCodeAsc, currentCode, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.DateAsc, currentCode, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.DateDesc, currentCode, page, pageSize);
                    return result;
                default:
                    return result;
            }

        }
        [HttpGet("Current/Id/{currentId:int}/All")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByCurrentIdAsync([FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentId, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductNameAsc, currentId, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductCodeDesc, currentId, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductCodeAsc, currentId, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.DateAsc, currentId, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.DateDesc, currentId, page, pageSize);
                    return result;
                default:
                    return result;
            }

        }
        [HttpGet("Current/Code/{currentCode}/Input")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetInputTransactionLineByCurrentCode([FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentCode, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductNameAsc, currentCode, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductCodeDesc, currentCode, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductCodeAsc, currentCode, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.DateAsc, currentCode, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.DateDesc, currentCode, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
        [HttpGet("Current/Id/{currentId:int}/Input")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetInputTransactionLineByCurrentId([FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentId, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductNameAsc, currentId, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductCodeDesc, currentId, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductCodeAsc, currentId, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.DateAsc, currentId, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetInputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.DateDesc, currentId, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
        [HttpGet("Current/Code/{currentCode}/Output")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetOutputTransactionLineByCurrentCode([FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, string currentCode = "", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentCode, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductNameAsc, currentCode, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductCodeDesc, currentCode, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.ProductCodeAsc, currentCode, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.DateAsc, currentCode, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentCode(search, SupplierTransactionLineOrderBy.DateDesc, currentCode, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
        [HttpGet("Current/Id/{currentId:int}/Output")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetOutputTransactionLineByCurrentId([FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, int currentId = 0, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductNameDesc, currentId, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductNameAsc, currentId, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductCodeDesc, currentId, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.ProductCodeAsc, currentId, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.DateAsc, currentId, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetOutputTransactionLineByCurrentId(search, SupplierTransactionLineOrderBy.DateDesc, currentId, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
        [HttpGet("Fiche/Code/{ficheCode}")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByFicheCode([FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, string ficheCode = "", int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheCode(search, SupplierTransactionLineOrderBy.ProductNameDesc, ficheCode, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheCode(search, SupplierTransactionLineOrderBy.ProductNameAsc, ficheCode, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheCode(search, SupplierTransactionLineOrderBy.ProductCodeDesc, ficheCode, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheCode(search, SupplierTransactionLineOrderBy.ProductCodeAsc, ficheCode, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheCode(search, SupplierTransactionLineOrderBy.DateAsc, ficheCode, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheCode(search, SupplierTransactionLineOrderBy.DateDesc, ficheCode, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
        [HttpGet("Fiche/Id/{ficheId:int}")]
        public async Task<DataResult<IEnumerable<SupplierTransactionLine>>> GetTransactionLineByFicheId([FromQuery] string search = "", string orderBy = SupplierTransactionLineOrderBy.DateAsc, int ficheId = 0, int page = 0, int pageSize = 20)
        {
            var result = new DataResult<IEnumerable<SupplierTransactionLine>>();
            switch (orderBy)
            {
                case "namedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheId(search, SupplierTransactionLineOrderBy.ProductNameDesc, ficheId, page, pageSize);
                    return result;
                case "nameasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheId(search, SupplierTransactionLineOrderBy.ProductNameAsc, ficheId, page, pageSize);
                    return result;
                case "codedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheId(search, SupplierTransactionLineOrderBy.ProductCodeDesc, ficheId, page, pageSize);
                    return result;
                case "codeasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheId(search, SupplierTransactionLineOrderBy.ProductCodeAsc, ficheId, page, pageSize);
                    return result;
                case "dateasc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheId(search, SupplierTransactionLineOrderBy.DateAsc, ficheId, page, pageSize);
                    return result;
                case "datedesc":
                    result = await _supplierTransactionLineService.GetTransactionLineByFicheId(search, SupplierTransactionLineOrderBy.DateDesc, ficheId, page, pageSize);
                    return result;
                default:
                    return result;
            }
        }
    }
}
