﻿using Helix.EventBus.Base.Events;

namespace Helix.LBSService.PostConsumer.Events
{
	public class CustomerInsertingIntegrationEvent : IntegrationEvent
	{
		public string Title { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string OtherAddress { get; set; } = string.Empty;
		public string DistrictCode { get; set; } = string.Empty;
		public string TownCode { get; set; } = string.Empty;
		public string CityCode { get; set; } = string.Empty;
		public string CountryCode { get; set; } = string.Empty;
		public string Telephone { get; set; } = string.Empty;
		public string TaxNumber { get; set; } = string.Empty;
		public string TaxOffice { get; set; } = string.Empty;
		public string PaymentCode { get; set; } = string.Empty;
		public string EMail { get; set; } = string.Empty;
	}
}