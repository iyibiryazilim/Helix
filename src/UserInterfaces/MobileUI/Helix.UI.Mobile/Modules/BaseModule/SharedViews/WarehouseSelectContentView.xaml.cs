using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using IntelliJ.Lang.Annotations;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class WarehouseSelectContentView : ContentView
{
    public static readonly BindableProperty SortCommandProperty = BindableProperty.Create(nameof(SortCommand), typeof(AsyncRelayCommand), typeof(WarehouseSelectContentView), null);
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(WarehouseSelectContentView), null);
    public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(WarehouseSelectContentView), false);
    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(WarehouseSelectContentView), false);
    public static readonly BindableProperty WarehouseListProperty = BindableProperty.Create(nameof(WarehouseList), typeof(ObservableCollection<Warehouse>), typeof(WarehouseSelectContentView), null);
    public static readonly BindableProperty ReloadCommandProperty = BindableProperty.Create(nameof(ReloadCommand), typeof(AsyncRelayCommand), typeof(WarehouseSelectContentView), null);

    public static readonly BindableProperty ToggleSelectionCommandProperty = BindableProperty.Create(nameof(ToggleSelectionCommand), typeof(AsyncRelayCommand), typeof(WarehouseSelectContentView), null);
    public static readonly BindableProperty GoToNextCommandProperty = BindableProperty.Create(nameof(GoToNextCommand), typeof(AsyncRelayCommand), typeof(WarehouseSelectContentView), null);
    public ObservableCollection<Warehouse> WarehouseList
    {
        get => GetValue(WarehouseListProperty) as ObservableCollection<Warehouse>;
        set => SetValue(WarehouseListProperty, value);
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
    public WarehouseSelectContentView()
	{
		InitializeComponent();
	}
}