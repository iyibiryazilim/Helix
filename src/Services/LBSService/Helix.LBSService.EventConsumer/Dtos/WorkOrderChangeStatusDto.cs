﻿namespace Helix.LBSService.EventConsumer.Dtos
{
	public class WorkOrderChangeStatusDto
	{
		public string FicheNo { get; set; } = string.Empty;
		public int Status { get; set; } = 0;
		public short DeleteFiche { get; set; } = 2;
	}
}
