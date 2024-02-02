﻿using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class PurchaseDispatchTransactionService : IService<PurchaseDispatchTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/PurchaseDispatchTransaction/Insert"; // Replace with your actual API endpoint
		}
	}
}
