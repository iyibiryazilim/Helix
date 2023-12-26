using AutoMapper;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Helpers.MappingHelper;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
       
		CreateMap<WarehouseDetailCardTypeCount, dynamic>();

	}
}

