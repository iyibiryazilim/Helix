using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.InCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.OutCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;
using System.Reflection;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel.BottomSheetViewModels;

public partial class ProductFastOperationBottomSheetViewModel : BaseViewModel
{
	[ObservableProperty]
	Product product;

	[RelayCommand]
	async Task GoToSubUnitsetsAndBarcodeViewAsync()  // Uretimden Giris İslemleri
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			Console.WriteLine(Product);

			await Shell.Current.GoToAsync($"{nameof(ProductDetailSubUnitsetsAndBarcodeView)}", new Dictionary<string, object>
			{
				["Product"] = Product
			});
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex.Message);
			await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	
	[RelayCommand]
	async Task GoToWarehouseTotalViewAsync()  // Sarf İşlemleri View
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(ProductDetailWarehouseTotalView)}", new Dictionary<string, object>
			{
				["Product"] = Product
			});
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	async Task GoToWarehouseParameterViewAsync()  // Fire İşlemleri View
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(ProductDetailWarehouseParametersView)}", new Dictionary<string, object>
			{
				["Product"] = Product
			});
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	async Task GoToInCountingTransactionOperationViewAsync()  // Sayım Fazlası View
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(InCountingTransactionOperationView)}", new Dictionary<string, object>
			{
				["Product"] = Product
			});
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	async Task GoToOutCountingTransactionOperationViewAsync()  // Sayım Eksigi View
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(OutCountingTransactionOperationView)}", new Dictionary<string, object>
			{
				["Product"] = Product
			});
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	/*
	[RelayCommand]
	async Task GoToTransferIslemleriViewAsync()  // Transfer İslemleri View
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			//await Shell.Current.GoToAsync($"{nameof()}", new Dictionary<string, object>
			//{
			//	["Product"] = Product
			//});
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	async Task GoToVirmanIslemleriViewAsync()  // Virman İslemleri View
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			//await Shell.Current.GoToAsync($"{nameof()}", new Dictionary<string, object>
			//{
			//	["Product"] = Product
			//});
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	async Task GoToHizliUretimViewAsync()  // Hızlı Üretim View
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			//await Shell.Current.GoToAsync($"{nameof()}", new Dictionary<string, object>
			//{
			//	["Product"] = Product
			//});
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	async Task GoToDevirViewAsync()  // Devir View
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			//await Shell.Current.GoToAsync($"{nameof()}", new Dictionary<string, object>
			//{
			//	["Product"] = Product
			//});
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
			await Application.Current.MainPage.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}
	*/
}
