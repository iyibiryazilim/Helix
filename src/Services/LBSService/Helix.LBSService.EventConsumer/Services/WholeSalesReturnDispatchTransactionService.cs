﻿using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.EventConsumer.Dtos;

namespace Helix.LBSService.EventConsumer.Services
{
	public class WholeSalesReturnDispatchTransactionService : IService<WholeSalesReturnTransactionDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/WholeSalesReturnDispatchTransaction/Insert"; // Replace with your actual API endpoint
		}
	}
}
