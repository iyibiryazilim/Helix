using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ProductTransactionContentView : ContentView
{
    //Commands
    public static readonly BindableProperty GoToSharedProductListCommandProperty = BindableProperty.Create(nameof(GoToSharedProductListCommand), typeof(Command), typeof(SharedProductListView), null);

    public Command GoToSharedProductListCommand
    {
        get => GetValue(GoToSharedProductListCommandProperty) as Command;
        set => SetValue(GoToSharedProductListCommandProperty, value);
    }

    public ProductTransactionContentView()
	{
        InitializeComponent();

		
	}
    
}