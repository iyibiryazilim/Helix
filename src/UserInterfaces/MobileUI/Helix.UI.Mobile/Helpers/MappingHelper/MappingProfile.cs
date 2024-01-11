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
		CreateMap<WaitingOrderLine, PurchaseOrderLine>().ReverseMap();
		CreateMap<WaitingOrderLine, SalesOrderLine>().ReverseMap();
		CreateMap<WaitingOrder, SalesOrder>().ReverseMap();
		CreateMap<WaitingOrder, PurchaseOrder>().ReverseMap();
        CreateMap<Current, Customer>().ReverseMap();
        CreateMap<WarehouseModel, dynamic>();
        CreateMap<BarcodeAndSubUnitset, dynamic>();





    }
}

