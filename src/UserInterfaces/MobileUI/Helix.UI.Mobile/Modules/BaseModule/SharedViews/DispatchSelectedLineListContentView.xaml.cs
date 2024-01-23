using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class DispatchSelectedLineListContentView : ContentView
{
    public static readonly BindableProperty GroupLineProperty = BindableProperty.Create(nameof(GroupLine), typeof(DispatchTransactionLineGroup), typeof(DispatchSelectedLineListContentView), null);
	public static readonly BindableProperty LineListProperty = BindableProperty.Create(nameof(LineList), typeof(ObservableCollection<DispatchTransactionLine>), typeof(DispatchSelectedLineListContentView), null);


	//Commands

	//addQauntity command
	public static readonly BindableProperty AddQuantityCommandProperty = BindableProperty.Create(nameof(AddQuantityCommand), typeof(Command), typeof(DispatchSelectedLineListContentView), null);
    //deleteQuantity command
    public static readonly BindableProperty DeleteQuantityCommandProperty = BindableProperty.Create(nameof(DeleteQuantityCommand), typeof(Command), typeof(DispatchSelectedLineListContentView), null);
    // delete command
    public static readonly BindableProperty RemoveItemCommandProperty = BindableProperty.Create(nameof(RemoveItemCommand), typeof(Command), typeof(DispatchSelectedLineListContentView), null);
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(DispatchSelectedLineListContentView), null);
    public static readonly BindableProperty SortCommandProperty = BindableProperty.Create(nameof(SortCommand), typeof(AsyncRelayCommand), typeof(DispatchSelectedLineListContentView), null);
    public static readonly BindableProperty GoToNextCommandProperty = BindableProperty.Create(nameof(GoToNextCommand), typeof(AsyncRelayCommand), typeof(DispatchSelectedLineListContentView), null);


    //Properties
    public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(DispatchSelectedLineListContentView), false);
    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(DispatchSelectedLineListContentView), false);



    //List
    public DispatchSelectedLineListContentView GroupLine
	{
        get => GetValue(GroupLineProperty) as DispatchSelectedLineListContentView;
        set => SetValue(GroupLineProperty, value);
    }
	public ObservableCollection<DispatchTransactionLine> LineList
	{
		get => GetValue(LineListProperty) as ObservableCollection<DispatchTransactionLine>;
		set => SetValue(LineListProperty, value);
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
    public AsyncRelayCommand GoToNextCommand
    {
        get => GetValue(GoToNextCommandProperty) as AsyncRelayCommand;
        set => SetValue(GoToNextCommandProperty, value);
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
    public DispatchSelectedLineListContentView()
	{
		InitializeComponent();
	}
}