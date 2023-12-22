using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel.BottomSheetViewModels;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews.BottomSheetViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

[QueryProperty(name: nameof(Product), queryId: nameof(Product))]
public partial class ProductDetailViewModel : BaseViewModel
{
	IServiceProvider _serviceProvider;

	[ObservableProperty]
	Product product;

	public ProductDetailViewModel(IServiceProvider serviceProvider)
	{
		Title = "Ürün Detayı";
		_serviceProvider = serviceProvider;
	}

	[RelayCommand]
	async Task OpenFastOperationBottomSheetAsync()
	{
		if(IsBusy)
			return;
		try
		{
			IsBusy = true;

			ProductFastOperationBottomSheetViewModel viewModel = _serviceProvider.GetService<ProductFastOperationBottomSheetViewModel>();

			ProductFastOperationBottomSheetView sheet = new ProductFastOperationBottomSheetView(viewModel);
			await sheet.ShowAsync();
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}
}
