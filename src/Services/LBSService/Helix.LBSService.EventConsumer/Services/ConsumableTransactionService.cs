﻿using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class ConsumableTransactionService : IService<ConsumableTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/ConsumableTransaction/Insert"; // Replace with your actual API endpoint
		}
	}
}
