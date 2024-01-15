using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.OperationsViews.DispatchByPurchaseOrderLineViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderLineViewModels
{
	[QueryProperty(nameof(WaitingOrderLine), nameof(WaitingOrderLine))]
	public partial class DispatchByPurchaseOrderLineSelectedLineListViewModel : BaseViewModel
	{
		public DispatchByPurchaseOrderLineSelectedLineListViewModel()
		{
			Title = "Satınalma Ürünleri Düzenleme";
			GetOrderLinesCommand = new Command(async () => await LoadData());
			SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

		}
		[ObservableProperty]
		ObservableCollection<WaitingOrderLine> waitingOrderLine;

		[ObservableProperty]
		string searchText = string.Empty;
		public ObservableCollection<WaitingOrderLine> Results { get; set; } = new();
		public Command GetOrderLinesCommand { get; }
		public Command SearchCommand { get; }

		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await MainThread.InvokeOnMainThreadAsync(GetPurchaseOrderLinesAsync);

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}
		async Task GetPurchaseOrderLinesAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				Results.Clear();
				foreach (var item in WaitingOrderLine)
				{
					Results.Add(item);
				}


			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}

		public async Task PerformSearchAsync(string text)
		{
			if (IsBusy)
				return;
			try
			{
				if (!string.IsNullOrEmpty(text))
				{
					if (text.Length >= 3)
					{
						SearchText = text;
						Results.Clear();
						foreach (var item in WaitingOrderLine.ToList().Where(x => x.OrderCode.Contains(SearchText) || x.ProductCode.Contains(SearchText) || x.ProductName.Contains(SearchText)))
						{
							Results.Add(item);
						}
					}
				}
				else
				{
					SearchText = string.Empty;
					Results.Clear();
					foreach (var item in WaitingOrderLine)
					{
						Results.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}

		[RelayCommand]
		async Task SortAsync()
		{
			if (IsBusy) return;
			try
			{
				string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Termin Tarihi Büyükten Küçüğe", "Termin Tarihi Küçükten Büyüğe", "Bekleyen Miktar Büyükten Küçüğe", "Bekleyen Miktar Küçükten Büyüğe");
				if (!string.IsNullOrEmpty(response))
				{
					await Task.Delay(100);
					switch (response)
					{
						case "Termin Tarihi Büyükten Küçüğe":
							Results.Clear();
							foreach (var item in WaitingOrderLine.OrderByDescending(x => x.DueDate).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Termin Tarihi Küçükten Büyüğe":
							Results.Clear();
							foreach (var item in WaitingOrderLine.OrderBy(x => x.DueDate).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Bekleyen Miktar Büyükten Küçüğe":
							Results.Clear();
							foreach (var item in WaitingOrderLine.OrderByDescending(x => x.TempQuantity).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Bekleyen Miktar Küçükten Büyüğe":
							Results.Clear();
							foreach (var item in WaitingOrderLine.OrderBy(x => x.TempQuantity).ToList())
							{
								Results.Add(item);
							}
							break;
						default:
							await GetPurchaseOrderLinesAsync();
							break;

					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}

		[RelayCommand]
		async Task RemoveItemAsync(WaitingOrderLine item)
		{

			if (IsBusy)
				return;

			try
			{

				IsBusy = true;
				IsRefreshing = true;

				bool answer = await Application.Current.MainPage.DisplayAlert("Uyarı", $"{item.OrderCode} sipariş numaralı {item.ProductName} isimli ürün çıkartılacaktır.Devam etmek istiyor musunuz ?", "Çıkart", "Vazgeç");
				if (answer)
				{
					Results.Remove(item);
					WaitingOrderLine.Remove(item);
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error : ", $"Bir Hata Oluştu:{ex.Message}", "Kapat");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}

		}

		[RelayCommand]
		async Task AddQuantity(WaitingOrderLine item)
		{


			if (item.TempQuantity + 1 > item.WaitingQuantity)
			{
				await Shell.Current.DisplayAlert("Uyarı", "Eklemek istediğiniz miktar bekleyen miktardan fazla", "Tamam");
			}
			else
			{
				item.TempQuantity++;
			}


		}
		[RelayCommand]
		async Task DeleteQuantity(WaitingOrderLine item)
		{
			if (item.TempQuantity - 1 >= 0)
			{
				item.TempQuantity--;
			}
			else
			{
				await Shell.Current.DisplayAlert("Uyarı", "Düşürmek istediğiniz miktar sıfırın altına düşüyor", "Tamam");

			}

		}

		[RelayCommand]
		async Task GoToSummaryAsync()
		{
			await Task.Delay(500);
			await Shell.Current.GoToAsync($"{nameof(DispatchByPurchaseOrderLineSummaryView)}", new Dictionary<string, object>
			{
				[nameof(WaitingOrderLine)] = WaitingOrderLine
			});
		}
	}
}
