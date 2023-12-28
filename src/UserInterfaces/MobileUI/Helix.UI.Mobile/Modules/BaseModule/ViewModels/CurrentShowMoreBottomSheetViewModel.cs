using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Views.Current;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.BaseModule.ViewModels
{
	public partial class CurrentShowMoreBottomSheetViewModel : BaseViewModel
	{
		[ObservableProperty]
		Current current;
		public CurrentShowMoreBottomSheetViewModel()
		{
		}

		[RelayCommand]
		public async Task GoToInputListAsync()
		{
			try
			{
				Customer newCurrent = new Customer()
				{
					CardType = Current.CardType,
					City = Current.City,
					Code = Current.Code,
					Country = Current.Country,
					County = Current.County,
					Definition = Current.Definition,
					Email = Current.Email,
					Image = Current.Image,
					LastTransactionDate = Current.LastTransactionDate,
					LastTransactionTime = Current.LastTransactionTime,
					Name = Current.Name,
					NetTotal = Current.NetTotal,
					OtherTelephone = Current.OtherTelephone,
					ReferenceCount = Current.ReferenceCount,
					ReferenceId = Current.ReferenceId,
					TaxNumber = Current.TaxNumber,
					TaxOffice = Current.TaxOffice,
					Telephone = Current.Telephone,
					WebAddress = Current.WebAddress
				};

				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentInputListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = newCurrent
 
				});
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
			}
		}

		[RelayCommand]
		public async Task GoToOutputListAsync()
		{
			try
			{
				Customer newCurrent = new Customer()
				{
					CardType = Current.CardType,
					City = Current.City,
					Code = Current.Code,
					Country = Current.Country,
					County = Current.County,
					Definition = Current.Definition,
					Email = Current.Email,
					Image = Current.Image,
					LastTransactionDate = Current.LastTransactionDate,
					LastTransactionTime = Current.LastTransactionTime,
					Name = Current.Name,
					NetTotal = Current.NetTotal,
					OtherTelephone = Current.OtherTelephone,
					ReferenceCount = Current.ReferenceCount,
					ReferenceId = Current.ReferenceId,
					TaxNumber = Current.TaxNumber,
					TaxOffice = Current.TaxOffice,
					Telephone = Current.Telephone,
					WebAddress = Current.WebAddress
				};
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentOutputListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = newCurrent
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
			}
		}
		[RelayCommand]
		public async Task GoToPurchaseDispatchListAsync()
		{
			try
			{
				Customer newCurrent = new Customer()
				{
					CardType = Current.CardType,
					City = Current.City,
					Code = Current.Code,
					Country = Current.Country,
					County = Current.County,
					Definition = Current.Definition,
					Email = Current.Email,
					Image = Current.Image,
					LastTransactionDate = Current.LastTransactionDate,
					LastTransactionTime = Current.LastTransactionTime,
					Name = Current.Name,
					NetTotal = Current.NetTotal,
					OtherTelephone = Current.OtherTelephone,
					ReferenceCount = Current.ReferenceCount,
					ReferenceId = Current.ReferenceId,
					TaxNumber = Current.TaxNumber,
					TaxOffice = Current.TaxOffice,
					Telephone = Current.Telephone,
					WebAddress = Current.WebAddress
				};
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentPurchaseDispatchListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = newCurrent
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
			}
		}
		[RelayCommand]
		public async Task GoToSalesDispatchListAsync()
		{
			try
			{
				Customer newCurrent = new Customer()
				{
					CardType = Current.CardType,
					City = Current.City,
					Code = Current.Code,
					Country = Current.Country,
					County = Current.County,
					Definition = Current.Definition,
					Email = Current.Email,
					Image = Current.Image,
					LastTransactionDate = Current.LastTransactionDate,
					LastTransactionTime = Current.LastTransactionTime,
					Name = Current.Name,
					NetTotal = Current.NetTotal,
					OtherTelephone = Current.OtherTelephone,
					ReferenceCount = Current.ReferenceCount,
					ReferenceId = Current.ReferenceId,
					TaxNumber = Current.TaxNumber,
					TaxOffice = Current.TaxOffice,
					Telephone = Current.Telephone,
					WebAddress = Current.WebAddress
				};
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentSalesDispatchListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = newCurrent
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
			}
		}

		[RelayCommand]
		public async Task GoToPurchaseOrderListAsync()
		{
			try
			{
				Customer newCurrent = new Customer()
				{
					CardType = Current.CardType,
					City = Current.City,
					Code = Current.Code,
					Country = Current.Country,
					County = Current.County,
					Definition = Current.Definition,
					Email = Current.Email,
					Image = Current.Image,
					LastTransactionDate = Current.LastTransactionDate,
					LastTransactionTime = Current.LastTransactionTime,
					Name = Current.Name,
					NetTotal = Current.NetTotal,
					OtherTelephone = Current.OtherTelephone,
					ReferenceCount = Current.ReferenceCount,
					ReferenceId = Current.ReferenceId,
					TaxNumber = Current.TaxNumber,
					TaxOffice = Current.TaxOffice,
					Telephone = Current.Telephone,
					WebAddress = Current.WebAddress
				};
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentPurchaseOrderListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = newCurrent
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
			}
		}
		[RelayCommand]
		public async Task GoToSalesOrderListAsync()
		{
			try
			{
				Customer newCurrent = new Customer()
				{
					CardType = Current.CardType,
					City = Current.City,
					Code = Current.Code,
					Country = Current.Country,
					County = Current.County,
					Definition = Current.Definition,
					Email = Current.Email,
					Image = Current.Image,
					LastTransactionDate = Current.LastTransactionDate,
					LastTransactionTime = Current.LastTransactionTime,
					Name = Current.Name,
					NetTotal = Current.NetTotal,
					OtherTelephone = Current.OtherTelephone,
					ReferenceCount = Current.ReferenceCount,
					ReferenceId = Current.ReferenceId,
					TaxNumber = Current.TaxNumber,
					TaxOffice = Current.TaxOffice,
					Telephone = Current.Telephone,
					WebAddress = Current.WebAddress
				};
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentSalesOrderListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = newCurrent
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
			}
		}

		[RelayCommand]
		public async Task GoToPurchaseReturnListAsync()
		{
			try
			{
				Customer newCurrent = new Customer()
				{
					CardType = Current.CardType,
					City = Current.City,
					Code = Current.Code,
					Country = Current.Country,
					County = Current.County,
					Definition = Current.Definition,
					Email = Current.Email,
					Image = Current.Image,
					LastTransactionDate = Current.LastTransactionDate,
					LastTransactionTime = Current.LastTransactionTime,
					Name = Current.Name,
					NetTotal = Current.NetTotal,
					OtherTelephone = Current.OtherTelephone,
					ReferenceCount = Current.ReferenceCount,
					ReferenceId = Current.ReferenceId,
					TaxNumber = Current.TaxNumber,
					TaxOffice = Current.TaxOffice,
					Telephone = Current.Telephone,
					WebAddress = Current.WebAddress
				};
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentPurchaseReturnListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = newCurrent
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
			}
		}
		[RelayCommand]
		public async Task GoToSalesReturnListAsync()
		{
			try
			{
				Customer newCurrent = new Customer()
				{
					CardType = Current.CardType,
					City = Current.City,
					Code = Current.Code,
					Country = Current.Country,
					County = Current.County,
					Definition = Current.Definition,
					Email = Current.Email,
					Image = Current.Image,
					LastTransactionDate = Current.LastTransactionDate,
					LastTransactionTime = Current.LastTransactionTime,
					Name = Current.Name,
					NetTotal = Current.NetTotal,
					OtherTelephone = Current.OtherTelephone,
					ReferenceCount = Current.ReferenceCount,
					ReferenceId = Current.ReferenceId,
					TaxNumber = Current.TaxNumber,
					TaxOffice = Current.TaxOffice,
					Telephone = Current.Telephone,
					WebAddress = Current.WebAddress
				};
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(CurrentSalesReturnListView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = newCurrent
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
			}
		}
	}
}
