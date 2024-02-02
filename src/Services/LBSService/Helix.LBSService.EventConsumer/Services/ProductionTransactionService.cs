﻿using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class ProductionTransactionService : IService<ProductionTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/ProductionTransaction/Insert"; // Replace with your actual API endpoint
		}
	}
}
