using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class PurchaseDispatchOperationFormContentView : ContentView
{
    public static readonly BindableProperty CurrentProperty = BindableProperty.Create(nameof(Current), typeof(Supplier), typeof(PurchaseDispatchOperationFormContentView));
    public static readonly BindableProperty WarehouseProperty = BindableProperty.Create(nameof(Warehouse), typeof(Warehouse), typeof(PurchaseDispatchOperationFormContentView));


    //command 
    //WarehouseCommand
    public static readonly BindableProperty GetWarehouseCommandProperty = BindableProperty.Create(nameof(GetWarehouseCommand), typeof(AsyncRelayCommand), typeof(PurchaseDispatchOperationFormContentView), null);

    //customerCommand
    public static readonly BindableProperty GetSupplierCommandProperty = BindableProperty.Create(nameof(GetSupplierCommand), typeof(AsyncRelayCommand), typeof(PurchaseDispatchOperationFormContentView), null);
    //
    public static readonly BindableProperty PurchaseFormModelProperty = BindableProperty.Create(nameof(PurchaseFormModel), typeof(PurchaseFormModel), typeof(PurchaseDispatchOperationFormContentView), null);

    //SpeCodeList
    public static readonly BindableProperty SpeCodeListProperty = BindableProperty.Create(nameof(SpeCodeList), typeof(ObservableCollection<SpeCodeModel>), typeof(PurchaseDispatchOperationFormContentView));
    public static readonly BindableProperty SupplierListProperty = BindableProperty.Create(nameof(SupplierList), typeof(ObservableCollection<Supplier>), typeof(PurchaseDispatchOperationFormContentView));

    //SpeCodeCommand
    public static readonly BindableProperty GetSpeCodeCommandProperty = BindableProperty.Create(nameof(GetSpeCodeCommand), typeof(AsyncRelayCommand), typeof(PurchaseDispatchOperationFormContentView), null);

    public static readonly BindableProperty GoToSuccessPageViewCommandProperty = BindableProperty.Create(nameof(GoToSuccessPageViewCommand), typeof(AsyncRelayCommand), typeof(PurchaseDispatchOperationFormContentView), null);

    //get warehouse

    public Supplier Current
    {
        get => GetValue(CurrentProperty) as Supplier;
        set => SetValue(CurrentProperty, value);
    }
    public Warehouse Warehouse
    {
        get => GetValue(WarehouseProperty) as Warehouse;
        set => SetValue(WarehouseProperty, value);
    }
 
    public AsyncRelayCommand GetWarehouseCommand
    {
        get => GetValue(GetWarehouseCommandProperty) as AsyncRelayCommand;
        set => SetValue(GetWarehouseCommandProperty, value);
    }

    public AsyncRelayCommand GetSupplierCommand
    {
        get => GetValue(GetSupplierCommandProperty) as AsyncRelayCommand;
        set => SetValue(GetSupplierCommandProperty, value);
    }
    //model
    public PurchaseFormModel PurchaseFormModel
    {
        get => GetValue(PurchaseFormModelProperty) as PurchaseFormModel;
        set => SetValue(PurchaseFormModelProperty, value);
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

    public ObservableCollection<Supplier> SupplierList
    {
        get => GetValue(SupplierListProperty) as ObservableCollection<Supplier>;
        set => SetValue(SupplierListProperty, value);
    }

    public AsyncRelayCommand GoToSuccessPageViewCommand
    {
        get => GetValue(GoToSuccessPageViewCommandProperty) as AsyncRelayCommand;
        set => SetValue(GoToSuccessPageViewCommandProperty, value);
    }
    public PurchaseDispatchOperationFormContentView()
	{
		InitializeComponent();
	}
}