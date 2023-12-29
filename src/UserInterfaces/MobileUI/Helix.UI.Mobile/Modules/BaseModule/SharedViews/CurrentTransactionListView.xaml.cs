using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class CurrentTransactionListView : ContentView
{
	#region Properties --> Definition
	public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(CurrentTransactionListView), false);
	public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(CurrentTransactionListView), false);
	#endregion


	#region Lists --> Definition
	public static readonly BindableProperty TransactionListProperty = BindableProperty.Create(nameof(TransactionList), typeof(ObservableCollection<CurrentTransactionLine>), typeof(CurrentTransactionListView), null);
	#endregion

	#region Commands --> Definition
	public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(CurrentTransactionListView), null);
	public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create(nameof(LoadMoreCommand), typeof(AsyncRelayCommand), typeof(CurrentTransactionListView), null);
	public static readonly BindableProperty ReloadCommandProperty = BindableProperty.Create(nameof(ReloadCommand), typeof(AsyncRelayCommand), typeof(CurrentTransactionListView), null);
	public static readonly BindableProperty SortCommandProperty = BindableProperty.Create(nameof(SortCommand), typeof(AsyncRelayCommand), typeof(CurrentTransactionListView), null);
	public static readonly BindableProperty GoToBackCommandProperty = BindableProperty.Create(nameof(GoToBackCommand), typeof(AsyncRelayCommand), typeof(CurrentTransactionListView), null);
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
	public ObservableCollection<CurrentTransactionLine> TransactionList
	{
		get => GetValue(TransactionListProperty) as ObservableCollection<CurrentTransactionLine>;
		set => SetValue(TransactionListProperty, value);
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
	public CurrentTransactionListView()
	{
		InitializeComponent();
	}
}