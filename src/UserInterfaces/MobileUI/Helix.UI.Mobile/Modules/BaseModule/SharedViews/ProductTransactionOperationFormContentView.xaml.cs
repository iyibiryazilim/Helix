using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ProductTransactionOperationFormContentView : ContentView
{
    public static readonly BindableProperty GoToOperationFormCommandProperty = BindableProperty.Create(nameof(GoToOperationFormCommand), typeof(Command), typeof(ProductTransactionOperationFormContentView), null);

    //Warehouselist
    public static readonly BindableProperty GetWarehouseCommandProperty = BindableProperty.Create(nameof(GetWarehouseCommand), typeof(Command), typeof(ProductTransactionOperationFormContentView), null);


    public Command GoToOperationFormCommand
    {
        get => GetValue(GoToOperationFormCommandProperty) as Command;
        set => SetValue(GoToOperationFormCommandProperty, value);
    }

    //get warehouse
    public Command GetWarehouseCommand
    {
        get => GetValue(GetWarehouseCommandProperty) as Command;
        set => SetValue(GetWarehouseCommandProperty, value);
    }

    public ProductTransactionOperationFormContentView()
	{
		InitializeComponent();
       
    }
}