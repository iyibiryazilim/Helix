using AutoMapper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Helpers.MappingHelper;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
       
		CreateMap<WarehouseDetailCardTypeCount, dynamic>();
		CreateMap<Customer, dynamic>();


	}
}

