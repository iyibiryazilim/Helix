using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ProductTransactionContentView : ContentView
{
    //Commands
    public static readonly BindableProperty GoToSharedProductListCommandProperty = BindableProperty.Create(nameof(GoToSharedProductListCommand), typeof(Command), typeof(SharedProductListView), null);

    public static readonly BindableProperty DenemeCommandProperty = BindableProperty.Create(nameof(DenemeCommand), typeof(Command), typeof(SharedProductListView), null);
    // delete command
    public static readonly BindableProperty RemoveItemCommandProperty = BindableProperty.Create(nameof(RemoveItemCommand), typeof(Command), typeof(ProductTransactionContentView), null); 


    //ProductModellist
    public static readonly BindableProperty ProductModelListProperty = BindableProperty.Create(nameof(ProductModelList), typeof(ObservableCollection<ProductModel>), typeof(ProductListContentView), null);

    // delete command
    public static readonly BindableProperty RemoveItemCommandProperty = BindableProperty.Create(nameof(RemoveItemCommand), typeof(Command), typeof(ProductTransactionContentView), null);

    //plus command
    public static readonly BindableProperty AddQuantityCommandProperty = BindableProperty.Create(nameof(AddQuantityCommand), typeof(Command), typeof(ProductTransactionContentView), null);


    //ProductModellist
    public static readonly BindableProperty ProductModelListProperty = BindableProperty.Create(nameof(ProductModelList), typeof(ObservableCollection<ProductModel>), typeof(ProductListContentView), null);

    public Command GoToSharedProductListCommand
    {
        get => GetValue(GoToSharedProductListCommandProperty) as Command;
        set => SetValue(GoToSharedProductListCommandProperty, value);
    }
    //ProductModelList
    public ObservableCollection<ProductModel> ProductModelList
    {
        get => GetValue(ProductModelListProperty) as ObservableCollection<ProductModel>;
        set => SetValue(ProductModelListProperty, value);
    }
    public Command DenemeCommand
    {
        get => GetValue(DenemeCommandProperty) as Command;
        set => SetValue(DenemeCommandProperty, value);
    }
    public Command AddQuantityCommand
    {
        get => GetValue(AddQuantityCommandProperty) as Command;
        set => SetValue(AddQuantityCommandProperty, value);
    }


    public Command RemoveItemCommand
    {
        get => GetValue(RemoveItemCommandProperty) as Command;
        set => SetValue(RemoveItemCommandProperty, value);
    }
    public ProductTransactionContentView()
	{
        InitializeComponent();
        

    }
   

}