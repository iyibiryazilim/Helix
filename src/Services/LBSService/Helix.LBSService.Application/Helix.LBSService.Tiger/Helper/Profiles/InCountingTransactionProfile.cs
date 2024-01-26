using AutoMapper;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.LBSService.Tiger.Helper.Profiles
{
	public class InCountingTransactionProfile : Profile
	{
        public InCountingTransactionProfile()
        {
			CreateMap<InCountingTransactionDto,LG_InCountingTransaction>()
				  .ForMember(d => d.NUMBER, o => o.MapFrom(s => s.Code))
				  .ForMember(d => d.DATE, o => o.MapFrom(s => s.TransactionDate))
				  .ForMember(d => d.TYPE, o => o.MapFrom(s => s.TransactionType))
				  .ForMember(d => d.GROUP, o => o.MapFrom(s => s.GroupType))
				  .ForMember(d => d.SOURCE_WH, o => o.MapFrom(s => s.WarehouseNumber))
				  .ForMember(d => d.SOURCE_COST_GRP, o => o.MapFrom(s => s.WarehouseNumber));
		}
    }
}
