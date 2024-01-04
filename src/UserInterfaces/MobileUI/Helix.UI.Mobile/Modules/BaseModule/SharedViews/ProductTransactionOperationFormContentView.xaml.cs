using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
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

    //fiþ adýný getiriyo
    public static readonly BindableProperty TransactionTypeNameProperty = BindableProperty.Create(nameof(TransactionTypeName), typeof(string), typeof(ProductTransactionOperationFormContentView), null);

    //ambar adýný seçme
    public static readonly BindableProperty ProductTransactionFormModelProperty = BindableProperty.Create(nameof(ProductTransactionFormModel), typeof(ProductTransactionFormModel), typeof(ProductTransactionOperationFormContentView), null);



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

    //warehouse
    public ProductTransactionFormModel ProductTransactionFormModel
    {
        get => GetValue(ProductTransactionFormModelProperty) as ProductTransactionFormModel;
        set => SetValue(ProductTransactionFormModelProperty, value);
    }



    public ProductTransactionOperationFormContentView()
	{
		InitializeComponent();
       
    }
}