using AutoMapper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class TransferTransactionProfile : Profile
	{
        public TransferTransactionProfile()
        {
			CreateMap<TransferTransactionDto, LG_TransferTransaction>()
			  .ForMember(d => d.NUMBER, o => o.MapFrom(s => s.Code))
			  .ForMember(d => d.DATE, o => o.MapFrom(s => s.TransactionDate))
			  .ForMember(d => d.TYPE, o => o.MapFrom(s => s.TransactionType))
			  .ForMember(d => d.GROUP, o => o.MapFrom(s => s.GroupType))
			  .ForMember(d => d.DEST_WH, o => o.MapFrom(s => s.DestinationWarehouseNumber)) 
			  .ForMember(d => d.SOURCE_WH, o => o.MapFrom(s => s.WarehouseNumber))
			  .ForMember(d => d.SOURCE_COST_GRP, o => o.MapFrom(s => s.WarehouseNumber));
		}
    }
}
