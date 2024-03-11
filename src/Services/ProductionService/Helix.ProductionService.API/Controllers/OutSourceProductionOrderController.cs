using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutSourceProductionOrderController : ControllerBase
    {
        IOutsourceProductionOrderService _outsourceProductionOrderService;

        public OutSourceProductionOrderController(IOutsourceProductionOrderService outsourceProductionOrderService)
        {
            _outsourceProductionOrderService = outsourceProductionOrderService;
        }

        [HttpGet]
        public async Task<DataResult<IEnumerable<OutsourceProductionOrder>>> GetAll()
        {
            var result = await _outsourceProductionOrderService.GetProductionOrderList();
            return result;
        }

        [HttpGet("Id/{id:int}")]
        public async Task<DataResult<OutsourceProductionOrder>> GetById(int id)
        {
            var result = await _outsourceProductionOrderService.GetProductionOrderById(id);
            return result;
        }

        [HttpGet("Code/{code}")]
        public async Task<DataResult<OutsourceProductionOrder>> GetByCode(string code)
        {
            var result = await _outsourceProductionOrderService.GetProductionOrderByCode(code);
            return result;
        }
    }
}
