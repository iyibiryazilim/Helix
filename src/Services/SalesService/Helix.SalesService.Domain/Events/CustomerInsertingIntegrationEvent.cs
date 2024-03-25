using Helix.EventBus.Base.Events;

namespace Helix.SalesService.Domain.Events
{
	public class CustomerInsertingIntegrationEvent : IntegrationEvent
	{
		public string Code { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string OtherAddress { get; set; } = string.Empty;
		public string DistrictCode { get; set; } = string.Empty;
		public string CountyCode { get; set; } = string.Empty;
		public string CityCode { get; set; } = string.Empty;
		public string CountryCode { get; set; } = string.Empty;
		public string Telephone { get; set; } = string.Empty;
		public string TaxNumber { get; set; } = string.Empty;
		public string TaxOffice { get; set; } = string.Empty;
		public string PaymentCode { get; set; } = string.Empty;
		public string EMail { get; set; } = string.Empty;
		public string TCKN { get; set; } = string.Empty;

		public CustomerInsertingIntegrationEvent(string code, string title, string address, string otherAddress, string districtCode, string countyCode, string cityCode, string countryCode, string telephone, string taxNumber, string taxOffice, string paymentCode, string eMail, string tckn)
		{
			Code = code;
			Title = title;
			Address = address;
			OtherAddress = otherAddress;
			DistrictCode = districtCode;
			CountyCode = countyCode;
			CityCode = cityCode;
			CountryCode = countryCode;
			Telephone = telephone;
			TaxNumber = taxNumber;
			TaxOffice = taxOffice;
			PaymentCode = paymentCode;
			EMail = eMail;
			TCKN = tckn;
		}
	}
}