﻿using Microsoft.AspNetCore.Mvc;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class PurchaseReturnDispatchTransactionController : ControllerBase
    {
        private readonly ILG_PurchaseReturnDispatchTransactionService _purchaseReturnDispatchTransactionService;
        private ILogger<PurchaseReturnDispatchTransactionController> _logger;
        public PurchaseReturnDispatchTransactionController(ILG_PurchaseReturnDispatchTransactionService purchaseReturnDispatchTransactionService, ILogger<PurchaseReturnDispatchTransactionController> logger)
        {
            _purchaseReturnDispatchTransactionService = purchaseReturnDispatchTransactionService;
            _logger = logger;
        }
        [HttpPost("Insert")]
        public async Task<DataResult<PurchaseReturnDispatchTransactionDto>> Insert([FromBody] PurchaseReturnDispatchTransactionDto dto)
        {
            var result = await _purchaseReturnDispatchTransactionService.Insert(dto);
            return result;
        }

    }
}
