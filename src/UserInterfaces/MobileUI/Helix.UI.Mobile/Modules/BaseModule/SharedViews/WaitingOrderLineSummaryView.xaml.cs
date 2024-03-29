using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class WaitingOrderLineSummaryView : ContentView
{
	public static readonly BindableProperty LinesProperty = BindableProperty.Create(nameof(Lines), typeof(ObservableCollection<WaitingOrderLine>), typeof(WaitingOrderLineSummaryView), null);
	public static readonly BindableProperty GoToNextCommandProperty = BindableProperty.Create(nameof(GoToNextCommand), typeof(AsyncRelayCommand), typeof(WaitingOrderLineContentView), null);

	public static readonly BindableProperty CurrentProperty = BindableProperty.Create(nameof(Current), typeof(Current), typeof(WaitingOrderLineSummaryView), null);

	public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(WaitingOrderLineSummaryView), false);

	public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(WaitingOrderLineSummaryView), false);

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

	public ObservableCollection<WaitingOrderLine> Lines
	{
		get => GetValue(LinesProperty) as ObservableCollection<WaitingOrderLine>;
		set => SetValue(LinesProperty, value);
	}

	public Current Current
	{
		get => GetValue(CurrentProperty) as Current;
		set => SetValue(CurrentProperty, value);
	}
	public AsyncRelayCommand GoToNextCommand
	{
		get => GetValue(GoToNextCommandProperty) as AsyncRelayCommand;
		set => SetValue(GoToNextCommandProperty, value);
	}
	public WaitingOrderLineSummaryView()
	{
		InitializeComponent();
	}
}