using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ShipInfoSelectContentView : ContentView
{
    public static readonly BindableProperty SortCommandProperty = BindableProperty.Create(nameof(SortCommand), typeof(AsyncRelayCommand), typeof(ShipInfoSelectContentView), null);
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(ShipInfoSelectContentView), null);
    public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(ShipInfoSelectContentView), false);
    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(ShipInfoSelectContentView), false);
    public static readonly BindableProperty ShipInfoListProperty = BindableProperty.Create(nameof(ShipInfoList), typeof(ObservableCollection<ShipInfo>), typeof(ShipInfoSelectContentView), null);
    public static readonly BindableProperty ReloadCommandProperty = BindableProperty.Create(nameof(ReloadCommand), typeof(AsyncRelayCommand), typeof(ShipInfoSelectContentView), null);

    public static readonly BindableProperty ToggleSelectionCommandProperty = BindableProperty.Create(nameof(ToggleSelectionCommand), typeof(AsyncRelayCommand), typeof(ShipInfoSelectContentView), null);
    public static readonly BindableProperty GoToNextCommandProperty = BindableProperty.Create(nameof(GoToNextCommand), typeof(AsyncRelayCommand), typeof(ShipInfoSelectContentView), null);
    public ObservableCollection<ShipInfo> ShipInfoList
    {
        get => GetValue(ShipInfoListProperty) as ObservableCollection<ShipInfo>;
        set => SetValue(ShipInfoListProperty, value);
    }
    public AsyncRelayCommand ReloadCommand
    {
        get => GetValue(ReloadCommandProperty) as AsyncRelayCommand;
        set => SetValue(ReloadCommandProperty, value);
    }

    public AsyncRelayCommand ToggleSelectionCommand
    {
        get => GetValue(ToggleSelectionCommandProperty) as AsyncRelayCommand;
        set => SetValue(ToggleSelectionCommandProperty, value);
    }
    public AsyncRelayCommand GoToNextCommand
    {
        get => GetValue(GoToNextCommandProperty) as AsyncRelayCommand;
        set => SetValue(GoToNextCommandProperty, value);
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
    public ShipInfoSelectContentView()
	{
		InitializeComponent();
	}
}