using AutoMapper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class CurrentProfile : Profile
	{
        public CurrentProfile()
        {
            CreateMap<CurrentDto, LG_Current>()
                .ForMember(d => d.TITLE, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.ADDRESS1, o => o.MapFrom(s => s.Address))
                .ForMember(d => d.ADDRESS2, o => o.MapFrom(s => s.OtherAddress))
                .ForMember(d => d.DISTRICT_CODE, o => o.MapFrom(s => s.DistrictCode))
                 .ForMember(d => d.TOWN_CODE, o => o.MapFrom(s => s.TownCode))
                 .ForMember(d => d.CITY_CODE, o => o.MapFrom(s => s.CityCode))
                 .ForMember(d => d.COUNTRY_CODE, o => o.MapFrom(s => s.CountryCode))
                 .ForMember(d => d.TELEPHONE1, o => o.MapFrom(s => s.Telephone))
                .ForMember(d => d.TAX_ID, o => o.MapFrom(s => s.TaxNumber))
                .ForMember(d => d.TAX_OFFICE, o => o.MapFrom(s => s.TaxOffice))
                .ForMember(d => d.PAYMENT_CODE, o => o.MapFrom(s => s.PaymentCode))
                .ForMember(d => d.E_MAIL, o => o.MapFrom(s => s.EMail));
                
        }
    }
}
