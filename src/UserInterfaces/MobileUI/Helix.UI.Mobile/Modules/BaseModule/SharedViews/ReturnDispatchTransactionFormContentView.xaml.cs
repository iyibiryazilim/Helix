using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ReturnDispatchTransactionFormContentView : ContentView
{
	//Properties
	public static readonly BindableProperty WarehouseProperty = BindableProperty.Create(nameof(Warehouse), typeof(Warehouse), typeof(ReturnDispatchTransactionFormContentView));
	public static readonly BindableProperty SpeCodeListProperty = BindableProperty.Create(nameof(SpeCodeList), typeof(ObservableCollection<SpeCodeModel>), typeof(ReturnDispatchTransactionFormContentView));
	public static readonly BindableProperty CustomerListProperty = BindableProperty.Create(nameof(CustomerList), typeof(ObservableCollection<Customer>), typeof(ReturnDispatchTransactionFormContentView));
	public static readonly BindableProperty PurchaseFormModelProperty = BindableProperty.Create(nameof(SpeCodeList), typeof(PurchaseFormModel), typeof(ReturnDispatchTransactionFormContentView));


	public static readonly BindableProperty IsPickerVisibleProperty = BindableProperty.Create(nameof(IsPickerVisible), typeof(bool), typeof(ReturnDispatchTransactionFormContentView), null);

	//Commands
	public static readonly BindableProperty GetSpeCodeCommandProperty = BindableProperty.Create(nameof(GetSpeCodeCommand), typeof(AsyncRelayCommand), typeof(ReturnDispatchTransactionFormContentView), null);  //WarehouseCommand
	public static readonly BindableProperty GetWarehouseCommandProperty = BindableProperty.Create(nameof(GetWarehouseCommand), typeof(AsyncRelayCommand), typeof(ReturnDispatchTransactionFormContentView), null);

	//customerCommand
	public static readonly BindableProperty GetCustomerCommandProperty = BindableProperty.Create(nameof(GetCustomerCommand), typeof(AsyncRelayCommand), typeof(ReturnDispatchTransactionFormContentView), null);
	public static readonly BindableProperty GoToSuccessPageViewCommandProperty = BindableProperty.Create(nameof(GoToSuccessPageViewCommand), typeof(AsyncRelayCommand), typeof(ReturnDispatchTransactionFormContentView), null);

	public ObservableCollection<SpeCodeModel> SpeCodeList
	{
		get => GetValue(SpeCodeListProperty) as ObservableCollection<SpeCodeModel>;
		set => SetValue(SpeCodeListProperty, value);
	}
	public ObservableCollection<Customer> CustomerList
	{
		get => GetValue(CustomerListProperty) as ObservableCollection<Customer>;
		set => SetValue(CustomerListProperty, value);
	}
	public PurchaseFormModel PurchaseFormModel
	{
		get => GetValue(PurchaseFormModelProperty) as PurchaseFormModel;
		set => SetValue(PurchaseFormModelProperty, value);
	}
	public Warehouse Warehouse
	{
		get => GetValue(WarehouseProperty) as Warehouse;
		set => SetValue(WarehouseProperty, value);
	}
	public bool IsPickerVisible
	{
		get => (bool)GetValue(IsPickerVisibleProperty);
		set => SetValue(IsPickerVisibleProperty, value);
	}
	public AsyncRelayCommand GetWarehouseCommand
	{
		get => GetValue(GetWarehouseCommandProperty) as AsyncRelayCommand;
		set => SetValue(GetWarehouseCommandProperty, value);
	}
	public AsyncRelayCommand GetCustomerCommand
	{
		get => GetValue(GetCustomerCommandProperty) as AsyncRelayCommand;
		set => SetValue(GetCustomerCommandProperty, value);
	}

	public AsyncRelayCommand GoToSuccessPageViewCommand
	{
		get => GetValue(GoToSuccessPageViewCommandProperty) as AsyncRelayCommand;
		set => SetValue(GoToSuccessPageViewCommandProperty, value);
	}
	public AsyncRelayCommand GetSpeCodeCommand
	{
		get => GetValue(GetSpeCodeCommandProperty) as AsyncRelayCommand;
		set => SetValue(GetSpeCodeCommandProperty, value);
	}
	public ReturnDispatchTransactionFormContentView()
	{
		InitializeComponent();
	}
}