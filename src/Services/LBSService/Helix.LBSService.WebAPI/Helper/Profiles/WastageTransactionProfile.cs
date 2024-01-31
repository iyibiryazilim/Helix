﻿using AutoMapper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class WastageTransactionProfile : Profile
	{
		public WastageTransactionProfile()
		{
			CreateMap<WastageTransactionDto, LG_WastageTransaction>()
				  .ForMember(d => d.NUMBER, o => o.MapFrom(s => s.Code))
				  .ForMember(d => d.DATE, o => o.MapFrom(s => s.TransactionDate))
				  .ForMember(d => d.TYPE, o => o.MapFrom(s => s.TransactionType))
				  .ForMember(d => d.GROUP, o => o.MapFrom(s => s.GroupType))
				  .ForMember(d => d.SOURCE_WH, o => o.MapFrom(s => s.WarehouseNumber))
				  .ForMember(d => d.SOURCE_COST_GRP, o => o.MapFrom(s => s.WarehouseNumber));
		}
	}
}
