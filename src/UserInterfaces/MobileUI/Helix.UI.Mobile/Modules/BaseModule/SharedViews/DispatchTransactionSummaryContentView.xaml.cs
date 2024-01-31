using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class DispatchTransactionSummaryContentView : ContentView
{
	public static readonly BindableProperty LinesProperty = BindableProperty.Create(nameof(Lines), typeof(ObservableCollection<DispatchTransactionLine>), typeof(DispatchTransactionSummaryContentView), null);
	public static readonly BindableProperty GoToNextCommandProperty = BindableProperty.Create(nameof(GoToNextCommand), typeof(AsyncRelayCommand), typeof(DispatchTransactionSummaryContentView), null);

	public static readonly BindableProperty CurrentProperty = BindableProperty.Create(nameof(Current), typeof(Current), typeof(DispatchTransactionSummaryContentView), null);
    public static readonly BindableProperty SupplierProperty = BindableProperty.Create(nameof(Supplier), typeof(Supplier), typeof(DispatchTransactionSummaryContentView), null);

    public ObservableCollection<DispatchTransactionLine> Lines
	{
		get => GetValue(LinesProperty) as ObservableCollection<DispatchTransactionLine>;
		set => SetValue(LinesProperty, value);
	}

	public Current Current
	{
		get => GetValue(CurrentProperty) as Current;
		set => SetValue(CurrentProperty, value);
	}
    public Supplier Supplier
    {
        get => GetValue(SupplierProperty) as Supplier;
        set => SetValue(SupplierProperty, value);
    }
    public AsyncRelayCommand GoToNextCommand
	{
		get => GetValue(GoToNextCommandProperty) as AsyncRelayCommand;
		set => SetValue(GoToNextCommandProperty, value);
	}
	public DispatchTransactionSummaryContentView()
	{
		InitializeComponent();
	}
}