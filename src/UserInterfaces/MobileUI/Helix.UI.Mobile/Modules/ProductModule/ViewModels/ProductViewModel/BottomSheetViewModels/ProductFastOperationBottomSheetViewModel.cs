using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.InCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.OutCountingTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ProductionTransactionOperationViews;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.WastageTransactionOperationViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;
using System.Reflection;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel.BottomSheetViewModels;

public partial class ProductFastOperationBottomSheetViewModel : BaseViewModel
{
	[ObservableProperty]
	Product product;

	[RelayCommand]
	async Task GoToProductionTransactionOperationViewAsync()  // Uretimden Giris İslemleri
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			//await Shell.Current.GoToAsync($"{nameof(ProductionTransactionOperationView)}", new Dictionary<string, object>
			//{
			//	["Product"] = Product
			//});
			await Shell.Current.GoToAsync($"{nameof(ProductionTransactionOperationView)}");
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
	async Task GoToConsumableTransactionOperationViewAsync()  // Sarf İşlemleri View
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			//await Shell.Current.GoToAsync($"{nameof(ConsumableTransactionOperationView)}", new Dictionary<string, object>
			//{
			//	["Product"] = Product
			//});
			await Shell.Current.GoToAsync($"{nameof(ConsumableTransactionOperationView)}");
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
	async Task GoToWastageTransactionOperationViewAsync()  // Fire İşlemleri View
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			//await Shell.Current.GoToAsync($"{nameof(WastageTransactionOperationView)}", new Dictionary<string, object>
			//{
			//	["Product"] = Product
			//});
			await Shell.Current.GoToAsync($"{nameof(WastageTransactionOperationView)}");
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

			//await Shell.Current.GoToAsync($"{nameof(InCountingTransactionOperationView)}", new Dictionary<string, object>
			//{
			//	["Product"] = Product
			//});
			await Shell.Current.GoToAsync($"{nameof(InCountingTransactionOperationView)}");

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

			//await Shell.Current.GoToAsync($"{nameof(OutCountingTransactionOperationView)}", new Dictionary<string, object>
			//{
			//	["Product"] = Product
			//});
			await Shell.Current.GoToAsync($"{nameof(OutCountingTransactionOperationView)}");
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
	
}
