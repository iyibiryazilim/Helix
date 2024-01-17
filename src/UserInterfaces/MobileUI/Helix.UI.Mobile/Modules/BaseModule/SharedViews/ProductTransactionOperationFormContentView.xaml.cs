using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using IntelliJ.Lang.Annotations;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ProductTransactionOperationFormContentView : ContentView
{
    public static readonly BindableProperty GoToOperationFormCommandProperty = BindableProperty.Create(nameof(GoToOperationFormCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionOperationFormContentView), null);

    public static readonly BindableProperty GoToSuccessPageViewCommandProperty = BindableProperty.Create(nameof(GoToSuccessPageViewCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionOperationFormContentView), null);

    //Warehouselist
    public static readonly BindableProperty GetWarehouseCommandProperty = BindableProperty.Create(nameof(GetWarehouseCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionOperationFormContentView), null);

    //WarehouseModellist
    public static readonly BindableProperty WarehouseListProperty = BindableProperty.Create(nameof(WarehouseList), typeof(ObservableCollection<Warehouse>), typeof(ProductTransactionOperationFormContentView), null);

    public static readonly BindableProperty TransactionTypeNameProperty = BindableProperty.Create(nameof(TransactionTypeName), typeof(string), typeof(ProductTransactionOperationFormContentView), null);
    public static readonly BindableProperty WarehouseProperty = BindableProperty.Create(nameof(Warehouse), typeof(Warehouse), typeof(ProductTransactionOperationFormContentView), null);

    //ambar adýný seçme
    public static readonly BindableProperty ProductTransactionFormModelProperty = BindableProperty.Create(nameof(ProductTransactionFormModel), typeof(ProductTransactionFormModel), typeof(ProductTransactionOperationFormContentView), null);

    //spe code seçme
    //SpeCodeList
    public static readonly BindableProperty SpeCodeListProperty = BindableProperty.Create(nameof(SpeCodeList), typeof(ObservableCollection<SpeCodeModel>), typeof(SalesDispatchFormContentView));

    //SpeCodeCommand
    public static readonly BindableProperty GetSpeCodeCommandProperty = BindableProperty.Create(nameof(GetSpeCodeCommand), typeof(AsyncRelayCommand), typeof(SalesDispatchFormContentView), null);



    public AsyncRelayCommand GoToOperationFormCommand
    {
        get => GetValue(GoToOperationFormCommandProperty) as AsyncRelayCommand;
        set => SetValue(GoToOperationFormCommandProperty, value);
    }

    //goto successPage
    public AsyncRelayCommand GoToSuccessPageViewCommand
    {
        get => GetValue(GoToSuccessPageViewCommandProperty) as AsyncRelayCommand;
        set => SetValue(GoToSuccessPageViewCommandProperty, value);
    }

    //get warehouse
    public AsyncRelayCommand GetWarehouseCommand
    {
        get => GetValue(GetWarehouseCommandProperty) as AsyncRelayCommand;
        set => SetValue(GetWarehouseCommandProperty, value);
    }
    //WarehouseList
    public ObservableCollection<Warehouse> WarehouseList
    {
        get => GetValue(WarehouseListProperty) as ObservableCollection<Warehouse>;
        set => SetValue(WarehouseListProperty, value);
    }
    public string TransactionTypeName
    {
        get => GetValue(TransactionTypeNameProperty) as string;
        set => SetValue(TransactionTypeNameProperty, value);
    }

    public Warehouse Warehouse
    {
        get => GetValue(WarehouseProperty) as Warehouse;
        set => SetValue(WarehouseProperty, value);
    }

    //warehouse
    public ProductTransactionFormModel ProductTransactionFormModel
    {
        get => GetValue(ProductTransactionFormModelProperty) as ProductTransactionFormModel;
        set => SetValue(ProductTransactionFormModelProperty, value);
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



    public ProductTransactionOperationFormContentView()
	{
		InitializeComponent();
       
    }
}