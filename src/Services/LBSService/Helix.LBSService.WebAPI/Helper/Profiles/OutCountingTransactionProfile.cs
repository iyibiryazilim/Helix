using AutoMapper;
using Helix.LBSService.Go.Models;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class OutCountingTransactionProfile : Profile
	{
		public OutCountingTransactionProfile()
		{
			CreateMap<OutCountingTransactionDto, LG_OutCountingTransaction>()
				  .ForMember(d => d.NUMBER, o => o.MapFrom(s => s.Code))
				  .ForMember(d => d.DATE, o => o.MapFrom(s => s.TransactionDate))
				  .ForMember(d => d.TYPE, o => o.MapFrom(s => s.TransactionType))
				  .ForMember(d => d.GROUP, o => o.MapFrom(s => s.GroupType))
				  .ForMember(d => d.SOURCE_WH, o => o.MapFrom(s => s.WarehouseNumber))
				  .ForMember(d => d.SOURCE_COST_GRP, o => o.MapFrom(s => s.WarehouseNumber));

			CreateMap<OutCountingTransactionDto, LG_STFICHE>()
				.ForMember(d => d.FICHENO, o => o.MapFrom(s => s.Code))
				 .ForMember(d => d.DATE_, o => o.MapFrom(s => s.TransactionDate))
 				 .ForMember(d => d.TRCODE, o => o.MapFrom(s => s.TransactionType))
				 .ForMember(d => d.IOCODE, o => o.MapFrom(s => s.IOType))
				 .ForMember(d => d.DOCODE, o => o.MapFrom(s => s.DoCode))
 				 .ForMember(d => d.SPECODE, o => o.MapFrom(s => s.SpeCode))
				 .ForMember(d => d.SPECODE, o => o.MapFrom(s => s.SpeCode))
				 .ForMember(d => d.GRPCODE, o => o.MapFrom(s => s.GroupType))
				 .ForMember(d => d.SOURCEINDEX, o => o.MapFrom(s => s.WarehouseNumber));
		}
	}
}