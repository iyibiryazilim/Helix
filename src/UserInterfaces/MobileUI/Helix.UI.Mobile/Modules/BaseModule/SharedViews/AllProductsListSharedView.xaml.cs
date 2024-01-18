using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class AllProductsListSharedView : ContentView
{
	#region Property Definitions
	public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(AllProductsListSharedView), false);
	public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(AllProductsListSharedView), false);
	#endregion

	#region List Definition
	public static readonly BindableProperty ProductListProperty = BindableProperty.Create(nameof(ProductList), typeof(ObservableCollection<Product>), typeof(AllProductsListSharedView), null);

	public static readonly BindableProperty SelectedProductListProperty = BindableProperty.Create(nameof(SelectedProductList), typeof(ObservableCollection<Product>), typeof(AllProductsListSharedView), null);

	#endregion

	#region Command Definitions
	public static readonly BindableProperty ReloadCommandProperty = BindableProperty.Create(nameof(ReloadCommand), typeof(AsyncRelayCommand), typeof(AllProductsListSharedView), null);
	public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create(nameof(LoadMoreCommand), typeof(AsyncRelayCommand), typeof(AllProductsListSharedView), null);
	public static readonly BindableProperty SortCommandProperty = BindableProperty.Create(nameof(SortCommand), typeof(AsyncRelayCommand), typeof(AllProductsListSharedView), null);
	public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(AllProductsListSharedView), null);
	public static readonly BindableProperty GoToNextCommandProperty = BindableProperty.Create(nameof(GoToNextCommand), typeof(AsyncRelayCommand), typeof(AllProductsListSharedView), null);
	public static readonly BindableProperty ToggleSelectionCommandProperty = BindableProperty.Create(nameof(ToggleSelectionCommand), typeof(AsyncRelayCommand), typeof(AllProductsListSharedView), null);
	public static readonly BindableProperty SelectAllCommandProperty = BindableProperty.Create(nameof(SelectAllCommand), typeof(AsyncRelayCommand), typeof(AllProductsListSharedView), null);

	#endregion


	#region Properties
	public bool IsBusy
	{
		get => (bool)GetValue(IsBusyProperty);
		set => SetValue(IsBusyProperty, value);
	}

	public bool IsRefreshing
	{
		get => (bool)GetValue(IsRefreshingProperty);
		set => SetValue(IsRefreshingProperty, value);
	}

	#endregion

	#region Lists
	public ObservableCollection<Product> ProductList
	{
		get => GetValue(ProductListProperty) as ObservableCollection<Product>;
		set => SetValue(ProductListProperty, value);
	}

	public ObservableCollection<Product> SelectedProductList
	{
		get => GetValue(SelectedProductListProperty) as ObservableCollection<Product>;
		set => SetValue(SelectedProductListProperty, value);
	}
	#endregion

	#region Commands
	public AsyncRelayCommand ReloadCommand
	{
		get => GetValue(ReloadCommandProperty) as AsyncRelayCommand;
		set => SetValue(ReloadCommandProperty, value);
	}

	public AsyncRelayCommand LoadMoreCommand
	{
		get => GetValue(LoadMoreCommandProperty) as AsyncRelayCommand;
		set => SetValue(LoadMoreCommandProperty, value);
	}

	public AsyncRelayCommand SortCommand
	{
		get => GetValue(SortCommandProperty) as AsyncRelayCommand;
		set => SetValue(SortCommandProperty, value);
	}

	public Command SearchCommand
	{
		get => GetValue(SearchCommandProperty) as Command;
		set => SetValue(SearchCommandProperty, value);
	}

	public AsyncRelayCommand GoToNextCommand
	{
		get => GetValue(GoToNextCommandProperty) as AsyncRelayCommand;
		set => SetValue(GoToNextCommandProperty, value);
	}

	public AsyncRelayCommand ToggleSelectionCommand
	{
		get => GetValue(ToggleSelectionCommandProperty) as AsyncRelayCommand;
		set => SetValue(ToggleSelectionCommandProperty, value);
	}
	public AsyncRelayCommand SelectAllCommand
	{
		get => GetValue(SelectAllCommandProperty) as AsyncRelayCommand;
		set => SetValue(SelectAllCommandProperty, value);
	}
	#endregion


	public AllProductsListSharedView()
	{
		InitializeComponent();
	}
}