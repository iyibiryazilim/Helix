using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ProductDetailWaitingOrderLineContentView : ContentView
{
	#region List Definition
	public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items), typeof(ObservableCollection<WaitingOrderLine>), typeof(ProductDetailWaitingOrderLineContentView), null);
	#endregion

	#region Commands Definition
	public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(ProductDetailWaitingOrderLineContentView), null);
	public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create(nameof(LoadMoreCommand), typeof(AsyncRelayCommand), typeof(ProductDetailWaitingOrderLineContentView), null);
	public static readonly BindableProperty SortCommandProperty = BindableProperty.Create(nameof(SortCommand), typeof(AsyncRelayCommand), typeof(ProductDetailWaitingOrderLineContentView), null);
	public static readonly BindableProperty ReloadCommandProperty = BindableProperty.Create(nameof(ReloadCommand), typeof(AsyncRelayCommand), typeof(ProductDetailWaitingOrderLineContentView), null);
	public static readonly BindableProperty GoToBackCommandProperty = BindableProperty.Create(nameof(GoToBackCommand), typeof(AsyncRelayCommand), typeof(ProductDetailWaitingOrderLineContentView), null);
	#endregion

	#region Properties Definition
	public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ProductDetailWaitingOrderLineContentView), null);
	public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(ProductDetailWaitingOrderLineContentView), false);
	public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(ProductDetailWaitingOrderLineContentView), false);
	#endregion

	#region List
	public ObservableCollection<WaitingOrderLine> Items
	{
		get => GetValue(ItemsProperty) as ObservableCollection<WaitingOrderLine>;
		set => SetValue(ItemsProperty, value);
	}

	#endregion

	#region Commands
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

	public AsyncRelayCommand SortCommand
	{
		get => GetValue(SortCommandProperty) as AsyncRelayCommand;
		set => SetValue(SortCommandProperty, value);
	}

	public AsyncRelayCommand ReloadCommand
	{
		get => GetValue(ReloadCommandProperty) as AsyncRelayCommand;
		set => SetValue(ReloadCommandProperty, value);
	}
	#endregion

	public AsyncRelayCommand GoToBackCommand
	{
		get => GetValue(GoToBackCommandProperty) as AsyncRelayCommand;
		set => SetValue(GoToBackCommandProperty, value);
	}

	#region Properties
	public string Title
	{
		get => GetValue(TitleProperty) as string;
		set => SetValue(TitleProperty, value);
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

	#endregion

	public ProductDetailWaitingOrderLineContentView()
	{
		InitializeComponent();
	}
}