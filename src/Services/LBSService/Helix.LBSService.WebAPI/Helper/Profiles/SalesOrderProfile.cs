using AutoMapper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class SalesOrderProfile : Profile
	{
        public SalesOrderProfile()
        {

			CreateMap<SalesOrderDto, LG_SalesOrder>()
			  .ForMember(d => d.DATE, o => o.MapFrom(s => s.OrderDate))
			  .ForMember(d => d.NUMBER, o => o.MapFrom(s => s.Code))
			  .ForMember(d => d.SOURCE_WH, o => o.MapFrom(s => s.WarehouseNumber))
			  .ForMember(d => d.SOURCE_COST_GRP, o => o.MapFrom(s => s.WarehouseNumber))
 			  .ForMember(d => d.DATE_CREATED, o => o.MapFrom(s => s.OrderDate.Date))
			  .ForMember(d => d.HOUR_CREATED, o => o.MapFrom(s => s.OrderDate.Hour))
			  .ForMember(d => d.MIN_CREATED, o => o.MapFrom(s => s.OrderDate.Minute))
			  .ForMember(d => d.SEC_CREATED, o => o.MapFrom(s => s.OrderDate.Second))
			  .ForMember(d => d.ARP_CODE, o => o.MapFrom(s => s.CustomerCode));

		}
    }
}
