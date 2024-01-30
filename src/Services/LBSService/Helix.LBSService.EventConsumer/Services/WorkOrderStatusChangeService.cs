﻿using Helix.LBSService.EventConsumer.Helper;
using Helix.LBSService.Tiger.DTOs;

namespace Helix.LBSService.EventConsumer.Services
{
	public class WorkOrderStatusChangeService : IService<WorkOrderChangeStatusDto>
	{
		public string GetApiEndpoint()
		{
			return "/api/WorkOrder/Status"; // Replace with your actual API endpoint
		}
	}
}