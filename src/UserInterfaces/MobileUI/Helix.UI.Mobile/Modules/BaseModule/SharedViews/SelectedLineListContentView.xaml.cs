using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class SelectedLineListContentView : ContentView
{

    public static readonly BindableProperty SelectedLineListProperty = BindableProperty.Create(nameof(SelectedLineList), typeof(ObservableCollection<WaitingOrderLine>), typeof(SelectedLineListContentView), null);


    //Commands

    //addQauntity command
    public static readonly BindableProperty AddQuantityCommandProperty = BindableProperty.Create(nameof(AddQuantityCommand), typeof(Command), typeof(SelectedLineListContentView), null);
    //deleteQuantity command
    public static readonly BindableProperty DeleteQuantityCommandProperty = BindableProperty.Create(nameof(DeleteQuantityCommand), typeof(Command), typeof(SelectedLineListContentView), null);
    // delete command
    public static readonly BindableProperty RemoveItemCommandProperty = BindableProperty.Create(nameof(RemoveItemCommand), typeof(Command), typeof(SelectedLineListContentView), null);
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(SelectedLineListContentView), null);
    public static readonly BindableProperty SortCommandProperty = BindableProperty.Create(nameof(SortCommand), typeof(AsyncRelayCommand), typeof(SelectedLineListContentView), null);
    public static readonly BindableProperty GoToSummaryCommandProperty = BindableProperty.Create(nameof(GoToSummaryCommand), typeof(AsyncRelayCommand), typeof(SelectedLineListContentView), null);


    //Properties
    public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(SelectedLineListContentView), false);
    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(SelectedLineListContentView), false);



    //List
    public ObservableCollection<WaitingOrderLine> SelectedLineList
    {
        get => GetValue(SelectedLineListProperty) as ObservableCollection<WaitingOrderLine>;
        set => SetValue(SelectedLineListProperty, value);
    }

    //Commands

    //AddQuantityCommand
    public Command AddQuantityCommand
    {
        get => GetValue(AddQuantityCommandProperty) as Command;
        set => SetValue(AddQuantityCommandProperty, value);
    }

    //AddQuantityCommand
    public Command DeleteQuantityCommand
    {
        get => GetValue(DeleteQuantityCommandProperty) as Command;
        set => SetValue(DeleteQuantityCommandProperty, value);
    }
    public AsyncRelayCommand GoToSummaryCommand
    {
        get => GetValue(GoToSummaryCommandProperty) as AsyncRelayCommand;
        set => SetValue(GoToSummaryCommandProperty, value);
    }
    
    public Command SearchCommand
    {
        get => GetValue(SearchCommandProperty) as Command;
        set => SetValue(SearchCommandProperty, value);
    }
    public AsyncRelayCommand SortCommand
    {
        get => GetValue(SortCommandProperty) as AsyncRelayCommand;
        set => SetValue(SortCommandProperty, value);
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

    public Command RemoveItemCommand
    {
        get => GetValue(RemoveItemCommandProperty) as Command;
        set => SetValue(RemoveItemCommandProperty, value);
    }
    public SelectedLineListContentView()
	{
		InitializeComponent();
	}
}