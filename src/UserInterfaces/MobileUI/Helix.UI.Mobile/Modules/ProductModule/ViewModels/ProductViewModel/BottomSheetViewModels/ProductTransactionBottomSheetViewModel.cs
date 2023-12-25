using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel.BottomSheetViewModels;

public partial class ProductTransactionBottomSheetViewModel : BaseViewModel
{
	[ObservableProperty]
	Product product;

	[RelayCommand]
	async Task GoToProductDetailInputReturnListViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync($"{nameof(ProductDetailInputReturnListView)}", new Dictionary<string, object>
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
	async Task GoToProductDetailInputTransactionListViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync($"{nameof(ProductDetailInputTransactionListView)}", new Dictionary<string, object>
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
	async Task GoToProductDetailOutputReturnListViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync($"{nameof(ProductDetailOutputReturnListView)}", new Dictionary<string, object>
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
	async Task GoToProductDetailOutputTransactionListViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync($"{nameof(ProductDetailOutputTransactionListView)}", new Dictionary<string, object>
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
	async Task GoToProductDetailPurchaseDispatchListViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync($"{nameof(ProductDetailPurchaseDispatchListView)}", new Dictionary<string, object>
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
	async Task GoToProductDetailPurchaseOrderListViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync($"{nameof(ProductDetailPurchaseOrderListView)}", new Dictionary<string, object>
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
	async Task GoToProductDetailSalesDispatchListViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync($"{nameof(ProductDetailSalesDispatchListView)}", new Dictionary<string, object>
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
	async Task GoToProductDetailSalesOrderListViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			await Shell.Current.GoToAsync($"{nameof(ProductDetailSalesOrderListView)}", new Dictionary<string, object>
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
}
