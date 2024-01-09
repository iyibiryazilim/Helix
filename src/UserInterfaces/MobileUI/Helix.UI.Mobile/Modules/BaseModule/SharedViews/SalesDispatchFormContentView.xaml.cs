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

    //DriverList
    public static readonly BindableProperty DriverListProperty = BindableProperty.Create(nameof(DriverList), typeof(ObservableCollection<Driver>), typeof(SalesDispatchFormContentView));

    //CarrierList
    public static readonly BindableProperty CarrierListProperty = BindableProperty.Create(nameof(CarrierList), typeof(ObservableCollection<Carrier>), typeof(SalesDispatchFormContentView));

    //SpeCodeList
    public static readonly BindableProperty SpeCodeListProperty = BindableProperty.Create(nameof(SpeCodeList), typeof(ObservableCollection<SpeCodeModel>), typeof(SalesDispatchFormContentView));




    //command 
    //WarehouseCommand
    public static readonly BindableProperty GetWarehouseCommandProperty = BindableProperty.Create(nameof(GetWarehouseCommand), typeof(AsyncRelayCommand), typeof(SalesDispatchFormContentView), null);

    //customerCommand
    public static readonly BindableProperty GetCustomerCommandProperty = BindableProperty.Create(nameof(GetCustomerCommand), typeof(AsyncRelayCommand), typeof(SalesDispatchFormContentView), null);

    //DriverCommand
    public static readonly BindableProperty GetDriverCommandProperty = BindableProperty.Create(nameof(GetDriverCommand), typeof(AsyncRelayCommand), typeof(SalesDispatchFormContentView), null);

    //CarrierCommand
    public static readonly BindableProperty GetCarrierCommandProperty = BindableProperty.Create(nameof(GetCarrierCommand), typeof(AsyncRelayCommand), typeof(SalesDispatchFormContentView), null);

    //SpeCodeCommand
    public static readonly BindableProperty GetSpeCodeCommandProperty = BindableProperty.Create(nameof(GetSpeCodeCommand), typeof(AsyncRelayCommand), typeof(SalesDispatchFormContentView), null);


    //
    public static readonly BindableProperty SalesFormModelProperty = BindableProperty.Create(nameof(SalesFormModel), typeof(SalesFormModel), typeof(SalesDispatchFormContentView), null);



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

    //model
    public SalesFormModel SalesFormModel
    {
        get => GetValue(SalesFormModelProperty) as SalesFormModel;
        set => SetValue(SalesFormModelProperty, value);
    }

    //get driver
    public AsyncRelayCommand GetDriverCommand
    {
        get => GetValue(GetDriverCommandProperty) as AsyncRelayCommand;
        set => SetValue(GetDriverCommandProperty, value);
    }

    //DriverList
    public ObservableCollection<Driver> DriverList
    {
        get => GetValue(DriverListProperty) as ObservableCollection<Driver>;
        set => SetValue(DriverListProperty, value);
    }

    //get warehouse
    public AsyncRelayCommand GetCarrierCommand
    {
        get => GetValue(GetCarrierCommandProperty) as AsyncRelayCommand;
        set => SetValue(GetCarrierCommandProperty, value);
    }

    //carrierList
    public ObservableCollection<Carrier> CarrierList
    {
        get => GetValue(CarrierListProperty) as ObservableCollection<Carrier>;
        set => SetValue(CarrierListProperty, value);
    }

    //get speCode
    public AsyncRelayCommand GetSpeCodeCommand
    {
        get => GetValue(GetSpeCodeCommandProperty) as AsyncRelayCommand;
        set => SetValue(GetSpeCodeCommandProperty, value);
    }
    //SpeCodeList
    public ObservableCollection<SpeCodeModel> SpeCodeList
    {
        get => GetValue(SpeCodeListProperty) as ObservableCollection<SpeCodeModel>;
        set => SetValue(SpeCodeListProperty, value);
    }
    public SalesDispatchFormContentView()
	{
		InitializeComponent();
		
	}
}