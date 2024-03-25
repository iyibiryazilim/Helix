namespace Helix.SalesService.Domain.Dtos
{
	public record CustomerDto(
	string code,
	string title,
	string address,
	string otherAddress,
	string districtCode,
 	string countyCode,
 	string cityCode,
 	string countryCode,
 	string telephone,
	string taxNumber,
	string taxOffice,
	string paymentCode,
	string eMail,
	string tckn
	)
	{
	}
}