﻿using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class RetailSalesDispatchTransactionService : IService<RetailSalesDispatchTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/RetailSalesDispatchTransaction/Insert"; // Replace with your actual API endpoint
		}
	}
}
