using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.TransferTransactionOperationViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels
{
	[QueryProperty(nameof(TransferTransactionModel), nameof(TransferTransactionModel))]
	public partial class TransferTransactionSummaryViewModel : BaseViewModel
	{
		[ObservableProperty]
		TransferTransactionModel transferTransactionModel;

        public TransferTransactionSummaryViewModel()
        {
			Title = "Özet";
        }

        [RelayCommand]
        async Task GoToFormViewAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                await Shell.Current.GoToAsync($"{nameof(TransferTransactionOperationFormView)}", new Dictionary<string, object>
                {
                    [nameof(TransferTransactionModel)] = TransferTransactionModel,
                   
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
		async Task PrograssTransferTransactionAsync()
		{
			await Shell.Current.GoToAsync($"../../../../.." );
		}
    }
}
