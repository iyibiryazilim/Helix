﻿using AutoMapper;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Helper.Mappers
{
	public class MappingProfile: Profile
	{
		public MappingProfile()
		{
			CreateMap<ConsumableTransactionDto, LG_ConsumableTransaction>();
			CreateMap<ConsumableTransactionLineDto,LG_ConsumableTransactionLine>();
			CreateMap<WholeSalesDispatchTransactionLineDto,LG_WholeSalesDispatchLine>();
			CreateMap<WholeSalesDispatchTransactionDto, LG_WholeSalesDispatch>();
			CreateMap<RetailSalesDispatchTransactionDto, LG_RetailSalesDispatchTransaction>();
			CreateMap<RetailSalesDispatchTransactionLineDto, LG_RetailSalesDispatchTransactionLine>();
			CreateMap<RetailSalesReturnDispatchTransactionDto, LG_RetailSalesReturnDispatchTransaction>();
			CreateMap<RetailSalesReturnDispatchTransactionLineDto, LG_RetailSalesReturnDispatchTransactionLine>();
			CreateMap<WholeSalesReturnTransactionDto, LG_WholeSalesReturnDispatch>();
			CreateMap<WholeSalesReturnTransactionLineDto, LG_WholeSalesReturnDispatchLine>();
			CreateMap<PurchaseDispatchTransactionDto, LG_PurchaseDispatchTransaction>();
			CreateMap<PurchaseDispatchTransactionLineDto, LG_PurchaseDispatchTransactionLine>();
			CreateMap<PurchaseReturnDispatchTransactionDto, LG_PurchaseReturnDispatchTransaction>();
			CreateMap<PurchaseReturnDispatchTransactionLineDto, LG_PurchaseReturnDispatchTransactionLine>();
			CreateMap<WastageTransactionDto, LG_WastageTransaction>();
			CreateMap<WastageTransactionLineDto, LG_WastageTransactionLine>();
			CreateMap<InCountingTransactionDto, LG_InCountingTransaction>();
			CreateMap<InCountingTransactionLineDto, LG_InCountingTransactionLine>();
			CreateMap<OutCountingTransactionDto, LG_OutCountingTransaction>();
			CreateMap<OutCountingTransactionLineDto, LG_OutCountingTransactionLine>();
			CreateMap<ProductionTransactionDto, LG_ProductionTransaction>();
			CreateMap<ProductionTransactionLineDto, LG_ProductionTransactionLine>();
			CreateMap<TransferTransactionDto, LG_TransferTransaction>();
			CreateMap<TransferTransactionLineDto, LG_TransferTransactionLine>();
		}
	}
}
