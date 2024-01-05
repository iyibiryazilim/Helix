using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class SalesDispatchFormContentView : ContentView
{  //list property

    //WarehouseList
	public static readonly BindableProperty WarehouseListProperty = BindableProperty.Create(nameof(WarehouseList),typeof(ObservableCollection<Warehouse>),typeof(SalesDispatchFormContentView));

    //CustomerList
    public static readonly BindableProperty CustomerListProperty = BindableProperty.Create(nameof(CustomerList), typeof(ObservableCollection<Customer>), typeof(SalesDispatchFormContentView));


    //command 
    //WarehouseCommand
    public static readonly BindableProperty GetWarehouseCommandProperty = BindableProperty.Create(nameof(GetWarehouseCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionOperationFormContentView), null);

    //customerCommand
    public static readonly BindableProperty GetCustomerCommandProperty = BindableProperty.Create(nameof(GetCustomerCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionOperationFormContentView), null);


    //get warehouse
    public AsyncRelayCommand GetWarehouseCommand
    {
        get => GetValue(GetWarehouseCommandProperty) as AsyncRelayCommand;
        set => SetValue(GetWarehouseCommandProperty, value);
    }
    //warehouseList
    public ObservableCollection<Warehouse> WarehouseList
    {
        get => GetValue(WarehouseListProperty) as ObservableCollection<Warehouse>;
        set => SetValue(WarehouseListProperty, value);
    }

    //CustomerList
    public ObservableCollection<Customer> CustomerList
    {
        get => GetValue(CustomerListProperty) as ObservableCollection<Customer>;
        set => SetValue(CustomerListProperty, value);
    }
    //get customer
    public AsyncRelayCommand GetCustomerCommand
    {
        get => GetValue(GetCustomerCommandProperty) as AsyncRelayCommand;
        set => SetValue(GetCustomerCommandProperty, value);
    }
    public SalesDispatchFormContentView()
	{
		InitializeComponent();
		
	}
}