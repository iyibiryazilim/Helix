using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class WaitingOrderContentView : ContentView
{
    //List
    public static readonly BindableProperty WaitingOrderListProperty = BindableProperty.Create(nameof(WaitingOrderList), typeof(ObservableCollection<WaitingOrder>), typeof(WaitingOrderContentView), null);


    //Commands
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(WaitingOrderContentView), null);
    public static readonly BindableProperty SortCommandProperty = BindableProperty.Create(nameof(SortCommand), typeof(AsyncRelayCommand), typeof(WaitingOrderContentView), null);
    public static readonly BindableProperty ReloadCommandProperty = BindableProperty.Create(nameof(ReloadCommand), typeof(AsyncRelayCommand), typeof(WaitingOrderContentView), null);
    public static readonly BindableProperty CheckedChangeCommandProperty = BindableProperty.Create(nameof(CheckedChangeCommand), typeof(Command), typeof(WaitingOrderContentView), null);


    public static readonly BindableProperty GoToLineCommandProperty = BindableProperty.Create(nameof(GoToLineCommand), typeof(AsyncRelayCommand), typeof(WaitingOrderContentView), null);
    public static readonly BindableProperty SelectCommandProperty = BindableProperty.Create(nameof(SelectCommand), typeof(AsyncRelayCommand), typeof(WaitingOrderContentView), null);


    //Properties
    public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(WaitingOrderContentView), false);
    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(WaitingOrderContentView), false);


    //List
    public ObservableCollection<WaitingOrder> WaitingOrderList
    {
        get => GetValue(WaitingOrderListProperty) as ObservableCollection<WaitingOrder>;
        set => SetValue(WaitingOrderListProperty, value);
    }

    //Commands

    public Command CheckedChangeCommand
    {
        get => GetValue(CheckedChangeCommandProperty) as Command;
        set => SetValue(CheckedChangeCommandProperty, value);
    }
    public Command SearchCommand
    {
        get => GetValue(SearchCommandProperty) as Command;
        set => SetValue(SearchCommandProperty, value);
    }
    public AsyncRelayCommand SelectCommand
    {
        get => GetValue(SelectCommandProperty) as AsyncRelayCommand;
        set => SetValue(SelectCommandProperty, value);
    }


    public AsyncRelayCommand SortCommand
    {

        get => GetValue(SortCommandProperty) as AsyncRelayCommand;
        set => SetValue(SortCommandProperty, value);

    }
    public AsyncRelayCommand GoToLineCommand
    {

        get => GetValue(GoToLineCommandProperty) as AsyncRelayCommand;
        set => SetValue(GoToLineCommandProperty, value);

    }

    public AsyncRelayCommand ReloadCommand
    {

        get => GetValue(ReloadCommandProperty) as AsyncRelayCommand;
        set => SetValue(ReloadCommandProperty, value);

    }

    //Properties
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
    public WaitingOrderContentView()
    {
        InitializeComponent();
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }
}