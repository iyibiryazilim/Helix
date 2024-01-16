using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels
{
	[QueryProperty(nameof(TransferTransactionModel), nameof(TransferTransactionModel))]
	public partial class ChangeProductViewModel : BaseViewModel
	{
		[ObservableProperty]
		TransferTransactionModel transferTransactionModel;

        public ChangeProductViewModel()
        {
			Title = "Malzeme seçimi";
 
		}

		[RelayCommand]
		async Task AddQuantity(TransferTransactionProduct item)
		{
			item.ChangedQuantity++;
			item.EntryProduct.StockQuantity++;
			item.ExitProduct.StockQuantity--;

		}
		[RelayCommand]

		async Task DeleteQuantity(TransferTransactionProduct item)
		{
			if (item.ChangedQuantity - 1>=0)
			{
				item.ChangedQuantity--;
				item.EntryProduct.StockQuantity--;
				item.ExitProduct.StockQuantity++;
			}


		}

		[RelayCommand]
		async Task GoToEntryProductSelectViewAsync(TransferTransactionProduct transferProduct)
		{
			await Shell.Current.GoToAsync($"{nameof(EntryProductSelectView)}", new Dictionary<string, object>
			{
				[nameof(Product)] = transferProduct.ExitProduct
			});
		}

        [RelayCommand]
		async Task GoToEntryWarehouseSelect()
		{
			if (TransferTransactionModel.Products.Where(x => x.EntryProduct == null).Any())
			{
				await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için Malzeme seçimi yapmanız gerekmektedir", "Tamam");
			}
			else
			{
				await Shell.Current.GoToAsync($"{nameof(EntryWarehouseSelectView)}", new Dictionary<string, object>
				{
					[nameof(TransferTransactionModel)] = TransferTransactionModel
				});
			}
		}
	}
}
