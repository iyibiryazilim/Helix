using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
    public partial class ProductGroup : ObservableObject
    {

        [ObservableProperty]
        string groupDefinition;

        [ObservableProperty]
        string groupCode;

        [ObservableProperty]
        bool isSelected = false;

    }
}
