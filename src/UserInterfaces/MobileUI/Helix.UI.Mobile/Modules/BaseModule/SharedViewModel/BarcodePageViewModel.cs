using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;

public partial class BarcodePageViewModel : BaseViewModel
{
	IServiceProvider _serviceProvider;

	public BarcodePageViewModel(IServiceProvider serviceProvider)
	{
		Title = "Barkod Okutma";
		_serviceProvider = serviceProvider;

	}

	[RelayCommand]
	public async Task WarehouseTransferOperationViewModelBarcodeScannerAsync()
	{
		try
		{
			WarehouseTransferOperationViewModel viewModel = _serviceProvider.GetService<WarehouseTransferOperationViewModel>();
			

		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		finally
		{
			IsBusy = false;
		}

	}

	[RelayCommand]
	async Task GoToBackAsync()
	{
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync("..");
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex.Message);
		}
		finally
		{
			IsBusy = false;
		}
	}

}
