using AutoMapper;
using Helix.LBSService.Go.Models;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Helper.Profiles
{
	public class RetailSalesReturnDispatchTransactionProfile : Profile
	{
        public RetailSalesReturnDispatchTransactionProfile()
        {
			CreateMap<RetailSalesReturnDispatchTransactionDto, LG_RetailSalesReturnDispatchTransaction>()
			 .ForMember(d => d.NUMBER, o => o.MapFrom(s => s.Code))
				.ForMember(d => d.DATE, o => o.MapFrom(s => s.TransactionDate))
				.ForMember(d => d.TYPE, o => o.MapFrom(s => s.TransactionType))
				.ForMember(d => d.GROUP, o => o.MapFrom(s => s.GroupType))
				.ForMember(d => d.ARP_CODE, o => o.MapFrom(s => s.CurrentCode))
				.ForMember(d => d.TOTAL_VAT, o => o.MapFrom(s => s.TotalVat))
				.ForMember(d => d.SHIPPING_AGENT, o => o.MapFrom(s => s.CarrierCode))
				.ForMember(d => d.EINVOICE_DRIVERNAME1, o => o.MapFrom(s => s.DriverFirstName))
				.ForMember(d => d.EINVOICE_DRIVERSURNAME1, o => o.MapFrom(s => s.DriverLastName))
				.ForMember(d => d.EINVOICE_DRIVERTCKNO1, o => o.MapFrom(s => s.IdentityNumber))
				.ForMember(d => d.EINVOICE_PLATENUM1, o => o.MapFrom(s => s.Plaque))
				//.ForMember(d => d.TIME, o => o.MapFrom(s => s.TransactionTime))
				.ForMember(d => d.NOTES1, o => o.MapFrom(s => s.Description))
				.ForMember(d => d.NOTES2, o => o.MapFrom(s => s.Description))
				.ForMember(d => d.NOTES3, o => o.MapFrom(s => s.Description))
				.ForMember(d => d.NOTES4, o => o.MapFrom(s => s.Description))
				.ForMember(d => d.NOTES5, o => o.MapFrom(s => s.Description))
				.ForMember(d => d.SHIPLOC_CODE, o => o.MapFrom(s => s.ShipInfoCode))
				//.ForMember(d => d.SHIPLOC_DEF, o => o.MapFrom(s => s.ship))
				.ForMember(d => d.DISP_STATUS, o => o.MapFrom(s => s.DispatchStatus))
				.ForMember(d => d.EDESPATCH, o => o.MapFrom(s => s.IsEDispatch))
				.ForMember(d => d.EINVOICE, o => o.MapFrom(s => s.IsEInvoice))
				.ForMember(d => d.DOC_NUMBER, o => o.MapFrom(s => s.DoCode))
				.ForMember(d => d.EDESPATCH_PROFILEID, o => o.MapFrom(s => s.EDispatchProfileId))
				.ForMember(d => d.EINVOICE_PROFILEID, o => o.MapFrom(s => s.EInvoiceProfileId))
				.ForMember(d => d.DOC_TRACK_NR, o => o.MapFrom(s => s.DocTrackingNumber))
				.ForMember(d => d.SOURCE_WH, o => o.MapFrom(s => s.WarehouseNumber))
				.ForMember(d => d.SOURCE_COST_GRP, o => o.MapFrom(s => s.WarehouseNumber))
				.ForMember(d => d.TOTAL_NET, o => o.MapFrom(s => s.NetTotal));

			CreateMap<RetailSalesReturnDispatchTransactionDto, LG_STFICHE>()
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
 