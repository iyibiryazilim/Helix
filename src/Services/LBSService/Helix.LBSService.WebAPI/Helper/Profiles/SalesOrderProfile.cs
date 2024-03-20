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
			  .ForMember(d => d.SALESMAN_CODE, o => o.MapFrom(s => s.SalesmanCode))
			  .ForMember(d => d.DATE_CREATED, o => o.MapFrom(s => s.OrderDate.Date))
			  .ForMember(d => d.HOUR_CREATED, o => o.MapFrom(s => s.OrderDate.Hour))
			  .ForMember(d => d.MIN_CREATED, o => o.MapFrom(s => s.OrderDate.Minute))
			  .ForMember(d => d.SALESMAN, o => o.MapFrom(s => s.SalesmanCode))
			  .ForMember(d => d.SEC_CREATED, o => o.MapFrom(s => s.OrderDate.Second))
			  .ForMember(d => d.ARP_CODE_SHPM, o => o.MapFrom(s => s.ShipmentAccountCode))
			  .ForMember(d => d.PROJECT_CODE, o => o.MapFrom(s => s.ProjectCode))
			  .ForMember(d => d.TOTAL_GROSS, o => o.MapFrom(s => s.Total))
			  .ForMember(d => d.TOTAL_VAT, o => o.MapFrom(s => s.TotalVat))
			  .ForMember(d => d.TOTAL_NET, o => o.MapFrom(s => s.NetTotal))
			  .ForMember(d => d.TOTAL_DISCOUNTED, o => o.MapFrom(s => s.DiscountTotal))
			  .ForMember(d => d.ARP_CODE, o => o.MapFrom(s => s.CurrentCode));
		}
	}
}