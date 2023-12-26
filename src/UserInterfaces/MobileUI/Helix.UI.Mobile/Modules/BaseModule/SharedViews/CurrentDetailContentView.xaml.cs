using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class CurrentDetailContentView : ContentView
{
	//Properties
	public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(CurrentDetailContentView), false);
	public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(CurrentDetailContentView), false);
	public static readonly BindableProperty CurrentProperty = BindableProperty.Create(nameof(Current), typeof(Current), typeof(CurrentDetailContentView), null);
	//List
	public static readonly BindableProperty TransactionListProperty = BindableProperty.Create(nameof(TransactionList), typeof(ObservableCollection<CurrentTransactionLine>), typeof(CurrentListView), null);
	//public static readonly BindableProperty ChartProperty = BindableProperty.Create(nameof(Chart), typeof(LineChart), typeof(CurrentListView), null);
	//Command
	public static readonly BindableProperty OpenShowMoreBottomSheetCommandProperty = BindableProperty.Create(nameof(OpenShowMoreBottomSheetCommand), typeof(AsyncRelayCommand), typeof(CurrentListView), null);
	public static readonly BindableProperty OpenFastOperationBottomSheetCommandProperty = BindableProperty.Create(nameof(OpenFastOperationBottomSheetCommand), typeof(AsyncRelayCommand), typeof(CurrentListView), null);

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
	public Current Current
	{
		get => (Current)GetValue(CurrentProperty);
		set => SetValue(CurrentProperty, value);
	}
	public ObservableCollection<CurrentTransactionLine> TransactionList
	{
		get => GetValue(TransactionListProperty) as ObservableCollection<CurrentTransactionLine>;
		set => SetValue(TransactionListProperty, value);
	}

	//public LineChart Chart
	//{
	//	get => GetValue(ChartProperty) as LineChart;
	//	set => SetValue(ChartProperty, value);
	//}
	public AsyncRelayCommand OpenShowMoreBottomSheetCommand
	{

		get => GetValue(OpenShowMoreBottomSheetCommandProperty) as AsyncRelayCommand;
		set => SetValue(OpenShowMoreBottomSheetCommandProperty, value);

	}
	public AsyncRelayCommand OpenFastOperationBottomSheetCommand
	{

		get => GetValue(OpenFastOperationBottomSheetCommandProperty) as AsyncRelayCommand;
		set => SetValue(OpenFastOperationBottomSheetCommandProperty, value);

	}

	public CurrentDetailContentView()
	{
		InitializeComponent();
	}
}