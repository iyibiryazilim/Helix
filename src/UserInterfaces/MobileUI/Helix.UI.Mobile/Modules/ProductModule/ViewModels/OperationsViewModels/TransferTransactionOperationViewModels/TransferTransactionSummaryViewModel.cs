using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;

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
    }
}
