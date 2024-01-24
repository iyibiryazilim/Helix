using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class SelectedLineListContentView : ContentView
{

    public static readonly BindableProperty GroupLineProperty = BindableProperty.Create(nameof(GroupLine), typeof(WaitingOrderLineGroup), typeof(SelectedLineListContentView), null);
	public static readonly BindableProperty LineListProperty = BindableProperty.Create(nameof(LineList), typeof(ObservableCollection<WaitingOrderLine>), typeof(SelectedLineListContentView), null);

	//public static readonly BindableProperty  LineListProperty = BindableProperty.Create(nameof(LineList), typeof(ObservableCollection<WaitingOrderLineGroup>), typeof(SelectedLineListContentView), null);


	//Commands

	//addQauntity command
	public static readonly BindableProperty AddQuantityCommandProperty = BindableProperty.Create(nameof(AddQuantityCommand), typeof(Command), typeof(SelectedLineListContentView), null);
    //deleteQuantity command
    public static readonly BindableProperty DeleteQuantityCommandProperty = BindableProperty.Create(nameof(DeleteQuantityCommand), typeof(Command), typeof(SelectedLineListContentView), null);
    // delete command
    public static readonly BindableProperty RemoveItemCommandProperty = BindableProperty.Create(nameof(RemoveItemCommand), typeof(Command), typeof(SelectedLineListContentView), null);
    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(nameof(SearchCommand), typeof(Command), typeof(SelectedLineListContentView), null);
    public static readonly BindableProperty SortCommandProperty = BindableProperty.Create(nameof(SortCommand), typeof(AsyncRelayCommand), typeof(SelectedLineListContentView), null);
    public static readonly BindableProperty GoToNextCommandProperty = BindableProperty.Create(nameof(GoToNextCommand), typeof(AsyncRelayCommand), typeof(SelectedLineListContentView), null);


    //Properties
    public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(SelectedLineListContentView), false);
    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(SelectedLineListContentView), false);
	public static readonly BindableProperty CodeProperty = BindableProperty.Create(nameof(Code), typeof(string), typeof(DispatchSelectedLineListContentView), null);
	public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(DispatchSelectedLineListContentView), null);
	public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(string), typeof(DispatchSelectedLineListContentView), null);
	public static readonly BindableProperty SubUnitsetCodeProperty = BindableProperty.Create(nameof(SubUnitsetCode), typeof(string), typeof(DispatchSelectedLineListContentView), null);
	public static readonly BindableProperty StockQuantityProperty = BindableProperty.Create(nameof(StockQuantity), typeof(double), typeof(DispatchSelectedLineListContentView), null);
	public static readonly BindableProperty TempQuantityProperty = BindableProperty.Create(nameof(TempQuantity), typeof(double), typeof(DispatchSelectedLineListContentView), null);

	public double StockQuantity
	{
		get => (double)GetValue(StockQuantityProperty);
		set => SetValue(StockQuantityProperty, value);
	}
	public double TempQuantity
	{
		get => (double)GetValue(TempQuantityProperty);
		set => SetValue(TempQuantityProperty, value);
	}
	public string Image
	{
		get => (string)GetValue(ImageProperty);
		set => SetValue(ImageProperty, value);
	}
	public string SubUnitsetCode
	{
		get => (string)GetValue(SubUnitsetCodeProperty);
		set => SetValue(SubUnitsetCodeProperty, value);
	}
	public string Name
	{
		get => (string)GetValue(NameProperty);
		set => SetValue(NameProperty, value);
	}
	public string Code
	{
		get => (string)GetValue(CodeProperty);
		set => SetValue(CodeProperty, value);
	}
	//List
	public WaitingOrderLineGroup GroupLine
    {
        get => GetValue(GroupLineProperty) as WaitingOrderLineGroup;
        set => SetValue(GroupLineProperty, value);
    }
	public ObservableCollection<WaitingOrderLine> LineList
	{
		get => GetValue(LineListProperty) as ObservableCollection<WaitingOrderLine>;
		set => SetValue(LineListProperty, value);
	}
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
    public SelectedLineListContentView()
	{
		InitializeComponent();
	}
}