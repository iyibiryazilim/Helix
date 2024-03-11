using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutSourceWorkOrderController : ControllerBase
    {
        IOutsourceWorkOrderService _outsourceWorkOrderService;

        public OutSourceWorkOrderController(IOutsourceWorkOrderService outsourceWorkOrderService)
        {
			_outsourceWorkOrderService = outsourceWorkOrderService;

        }

        [HttpGet]
        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetAll()
        {
            var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderList();
            return result;
        }

        [HttpGet("Id/{id:int}")]
        public async Task<DataResult<OutsourceWorkOrder>> GetById(int id)
        {
            var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderById(id);
            return result;
        }

        [HttpGet("Status")]
        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByStatus([FromQuery(Name = "status")] int[] status)
        {
            var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByStatus(status);
            return result;
        }

        [HttpGet("Workstation/Id/{id:int}")]
        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByWorkstationId(int id)
        {
            var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByWorkstationId(id);
            return result;
        }

        [HttpGet("Workstation/Code/{code}")]
        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByWorkstationCode(string code)
        {
            var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByWorkstationCode(code);
            return result;
        }

        [HttpGet("ProductionOrder/Id/{id:int}")]
        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByProductionOrderId(int id)
        {
            var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByProductionOrderId(id);
            return result;
        }

        [HttpGet("ProductionOrder/Code/{code}")]
        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByProductionOrderCode(string code)
        {
            var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByProductionOrderCode(code);
            return result;
        }

        [HttpGet("Product/Id/{id:int}")]
        public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByProductId(int id)
        {
            var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByProductId(id);
            return result;
        }

    }
}
