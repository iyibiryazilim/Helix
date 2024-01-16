using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ProductTransactionContentView : ContentView
{
	//Commands
	public static readonly BindableProperty GoToSharedProductListCommandProperty = BindableProperty.Create(nameof(GoToSharedProductListCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionContentView), null);

	public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(ProductTransactionContentView), null);

	public static readonly BindableProperty GoToOperationFormCommandProperty = BindableProperty.Create(nameof(GoToOperationFormCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionContentView), null);

	public static readonly BindableProperty GetBackCommandProperty = BindableProperty.Create(nameof(GetBackCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionContentView), null);

	public static readonly BindableProperty GoToConsumableTransactionFormCommandProperty = BindableProperty.Create(nameof(GoToConsumableTransactionFormCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionContentView), null);

	
	public static readonly BindableProperty RemoveItemCommandProperty = BindableProperty.Create(nameof(RemoveItemCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionContentView), null);

	public static readonly BindableProperty AddQuantityCommandProperty = BindableProperty.Create(nameof(AddQuantityCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionContentView), null);


	public static readonly BindableProperty DeleteQuantityCommandProperty = BindableProperty.Create(nameof(DeleteQuantityCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionContentView), null);

	//Warehouselist
	public static readonly BindableProperty GetWarehouseCommandProperty = BindableProperty.Create(nameof(GetWarehouseCommand), typeof(Command), typeof(ProductTransactionContentView), null);

	// Lists
	public static readonly BindableProperty WarehouseListProperty = BindableProperty.Create(nameof(WarehouseList), typeof(ObservableCollection<Warehouse>), typeof(ProductTransactionContentView), null);

	public static readonly BindableProperty ProductModelListProperty = BindableProperty.Create(nameof(ProductModelList), typeof(ObservableCollection<ProductModel>), typeof(ProductTransactionContentView), null);

	// Properties
	public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(ProductTransactionContentView), false);

	public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(ProductTransactionContentView), false);


	public AsyncRelayCommand GoToSharedProductListCommand
	{
		get => GetValue(GoToSharedProductListCommandProperty) as AsyncRelayCommand;
		set => SetValue(GoToSharedProductListCommandProperty, value);
	}

	public Command SearchCommand
	{
		get => GetValue(SearchCommandProperty) as Command;
		set => SetValue(SearchCommandProperty, value);
	}

	public Command GetWarehouseCommand
	{
		get => GetValue(GetWarehouseCommandProperty) as Command;
		set => SetValue(GetWarehouseCommandProperty, value);
	}

	public ObservableCollection<Warehouse> WarehouseList
	{
		get => GetValue(WarehouseListProperty) as ObservableCollection<Warehouse>;
		set => SetValue(WarehouseListProperty, value);
	}

	public AsyncRelayCommand GoToConsumableTransactionFormCommand
	{
		get => GetValue(GoToConsumableTransactionFormCommandProperty) as AsyncRelayCommand;
		set => SetValue(GoToConsumableTransactionFormCommandProperty, value);
	}

	public AsyncRelayCommand GetBackCommand
	{
		get => GetValue(GetBackCommandProperty) as AsyncRelayCommand;
		set => SetValue(GetBackCommandProperty, value);
	}

	public AsyncRelayCommand GoToOperationFormCommand
	{
		get => GetValue(GoToOperationFormCommandProperty) as AsyncRelayCommand;
		set => SetValue(GoToOperationFormCommandProperty, value);
	}

	public ObservableCollection<ProductModel> ProductModelList
	{
		get => GetValue(ProductModelListProperty) as ObservableCollection<ProductModel>;
		set => SetValue(ProductModelListProperty, value);
	}

	public AsyncRelayCommand AddQuantityCommand
	{
		get => GetValue(AddQuantityCommandProperty) as AsyncRelayCommand;
		set => SetValue(AddQuantityCommandProperty, value);
	}

	public AsyncRelayCommand DeleteQuantityCommand
	{
		get => GetValue(DeleteQuantityCommandProperty) as AsyncRelayCommand;
		set => SetValue(DeleteQuantityCommandProperty, value);
	}


	public AsyncRelayCommand RemoveItemCommand
	{
		get => GetValue(RemoveItemCommandProperty) as AsyncRelayCommand;
		set => SetValue(RemoveItemCommandProperty, value);
	}

	public bool IsRefreshing
	{
		get => (bool)GetValue(IsRefreshingProperty);
		set => SetValue(IsRefreshingProperty, value);
	}

	public bool IsBusy
	{
		get => (bool)GetValue(IsBusyProperty);
		set => SetValue(IsBusyProperty, value);
	}

	public ProductTransactionContentView()
	{
		InitializeComponent();
	}
}