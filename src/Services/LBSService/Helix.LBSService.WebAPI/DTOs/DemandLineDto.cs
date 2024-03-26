﻿namespace Helix.LBSService.WebAPI.DTOs
{
	public class DemandLineDto
	{
		public double Quantity { get; set; } = default;
		public string CurrentCode { get; set; } = string.Empty;
		public string ProductCode { get; set; } = string.Empty;
		public string Unitset { get; set; } = string.Empty;
		public string VariantCode { get; set; } = string.Empty;
		public double Price { get; set; } = default;
	}
}