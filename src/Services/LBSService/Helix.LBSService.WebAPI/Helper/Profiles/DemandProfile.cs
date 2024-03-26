using AutoMapper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class DemandProfile : Profile
	{
		public DemandProfile()
		{
			CreateMap<LG_Demand, DemandDto>()
				 .ForMember(d => d.Date, o => o.MapFrom(s => s.DATE))
				 .ForMember(d => d.DateCreated, o => o.MapFrom(s => s.DATE_CREATED))
				 .ForMember(d => d.DocumentNumber, o => o.MapFrom(s => s.DO_CODE))
				 .ForMember(d => d.ProjectCode, o => o.MapFrom(s => s.PROJECT_CODE))
				 .ForMember(d => d.SpeCode, o => o.MapFrom(s => s.AUXIL_CODE))
				 .ForMember(dest => dest.Lines, opt => opt.MapFrom(src => src.TRANSACTION))
				.ReverseMap();
		}
	}
}