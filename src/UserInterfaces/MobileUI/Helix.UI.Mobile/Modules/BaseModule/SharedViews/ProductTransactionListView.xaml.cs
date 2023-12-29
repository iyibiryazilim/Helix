using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ProductTransactionListView : ContentView
{
	#region Properties --> Definition
	public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(ProductTransactionListView), false);
	public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(ProductTransactionListView), false);
	#endregion


	#region Lists --> Definition
	public static readonly BindableProperty ProductTransactionListProperty = BindableProperty.Create(nameof(ProductTransactionList), typeof(ObservableCollection<ProductTransactionLine>), typeof(ProductTransactionListView), null);
	#endregion

	#region Commands --> Definition
	public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(ProductTransactionListView), null);
	public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create(nameof(LoadMoreCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionListView), null);
	public static readonly BindableProperty ReloadCommandProperty = BindableProperty.Create(nameof(ReloadCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionListView), null);
	public static readonly BindableProperty SortCommandProperty = BindableProperty.Create(nameof(SortCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionListView), null);
	public static readonly BindableProperty GoToBackCommandProperty = BindableProperty.Create(nameof(GoToBackCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionListView), null);
	#endregion

	#region Properties --> Getter and Setter
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
	#endregion

	#region Lists --> Getter and Setter
	public ObservableCollection<ProductTransactionLine> ProductTransactionList
	{
		get => GetValue(ProductTransactionListProperty) as ObservableCollection<ProductTransactionLine>;
		set => SetValue(ProductTransactionListProperty, value);
	}
	#endregion

	#region Commands --> Getter and Setter
	public Command SearchCommand
	{
		get => GetValue(SearchCommandProperty) as Command;
		set => SetValue(SearchCommandProperty, value);
	}

	public AsyncRelayCommand LoadMoreCommand
	{
		get => GetValue(LoadMoreCommandProperty) as AsyncRelayCommand;
		set => SetValue(LoadMoreCommandProperty, value);
	}

	public AsyncRelayCommand ReloadCommand
	{
		get => GetValue(ReloadCommandProperty) as AsyncRelayCommand;
		set => SetValue(ReloadCommandProperty, value);
	}

	public AsyncRelayCommand SortCommand
	{
		get => GetValue(SortCommandProperty) as AsyncRelayCommand;
		set => SetValue(SortCommandProperty, value);
	}

	public AsyncRelayCommand GoToBackCommand
	{
		get => GetValue(GoToBackCommandProperty) as AsyncRelayCommand;
		set => SetValue(GoToBackCommandProperty, value);
	}

	#endregion

	public ProductTransactionListView()
	{
		InitializeComponent();
	}
}