using AutoMapper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Helpers.MappingHelper;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
       
		CreateMap<WarehouseDetailCardTypeCount, dynamic>();
		CreateMap<Customer, dynamic>();
        CreateMap<Product, dynamic>();

        CreateMap<WaitingOrderLine, PurchaseOrderLine>().ReverseMap();
		CreateMap<WaitingOrderLine, SalesOrderLine>().ReverseMap();
		CreateMap<WaitingOrder, SalesOrder>().ReverseMap();
		CreateMap<WaitingOrder, PurchaseOrder>().ReverseMap();
        CreateMap<Current, Customer>().ReverseMap();
        CreateMap<WarehouseModel, dynamic>();
        CreateMap<BarcodeAndSubUnitset, dynamic>();
		CreateMap<DispatchTransactionLine, PurchaseOrderLine>().ReverseMap();
		CreateMap<DispatchTransactionLine, SalesOrderLine>().ReverseMap();
		CreateMap<DispatchTransaction, SalesOrder>().ReverseMap();
		CreateMap<DispatchTransaction, PurchaseOrder>().ReverseMap();
        CreateMap<DispatchTransaction, CustomerTransaction>().ReverseMap();
        CreateMap<DispatchTransactionLine, CustomerTransactionLine>().ReverseMap();


    }
}

