using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.FastProductionModule.Models;
using Helix.UI.Mobile.Modules.FastProductionModule.Views;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;
using Helix.UI.Mobile.MVVMHelper;
using Kotlin.Properties;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.FastProductionModule.ViewModels;

[QueryProperty(name:nameof(SelectedProduct),queryId:nameof(SelectedProduct))]
public partial class FastProductionViewModel : BaseViewModel
{
	[ObservableProperty]
	Product selectedProduct;

	public ObservableCollection<FastProductionCard> FastProductionList { get; } = new();

	public FastProductionViewModel()
	{
		Title = "Hızlı Üretim";
	}

	[RelayCommand]
	async Task GoToFastProductionSelectWarehouseListAsync()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(FastProductionSelectWarehouseListView)}");
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");


		}
		finally
		{
			IsBusy = false;
		}
	}

	
}
