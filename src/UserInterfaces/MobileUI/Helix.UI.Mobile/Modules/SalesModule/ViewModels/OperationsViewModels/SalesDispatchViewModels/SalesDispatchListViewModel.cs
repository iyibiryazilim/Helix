using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesDispatchViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
public partial class SalesDispatchListViewModel : BaseViewModel
{
	IHttpClientService _httpClient;

	[ObservableProperty]
	Warehouse warehouse;   // Selected Warehouse

	[ObservableProperty]
	string searchText = string.Empty;

	public ObservableCollection<ProductModel> Items { get; } = new();
	public ObservableCollection<ProductModel> Results { get; } = new();

	public Command<string> SearchCommand { get; }
	public Command GetProductModelListCommand { get; }

	public SalesDispatchListViewModel(IHttpClientService httpClient)
	{
		Title = "Sevk İşlemleri";
		_httpClient = httpClient;

		SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
		//GetProductModelListCommand = new Command(async () => await LoadData());
	}

	//[RelayCommand]
	//public async Task ReloadAsync()
	//{
	//	if (IsBusy)
	//		return;
	//	try
	//	{
	//		IsBusy = true;
	//		IsRefreshing = true;

			
	//	}
	//}

	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await MainThread.InvokeOnMainThreadAsync(GetProductModelListAsync);

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

	async Task GetProductModelListAsync()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			IsRefreshing = true;
			IsRefreshing = false;

			Results.Clear();

			foreach(var item in Items)
			{
				Results.Add(item);
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}


	[RelayCommand]
	async Task GoToSharedProductListAsync()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}", new Dictionary<string, object>
			{
				["Warehouse"] = Warehouse,
				["ViewType"] = 7
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
	async Task GoToOperationForm()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;

			if(Items.Count > 0)
			{
				await Shell.Current.GoToAsync($"{nameof(SalesDispatchFormView)}", new Dictionary<string, object>
				{
					[nameof(ProductModel)] = Items,
					[nameof(Warehouse)] = Warehouse
				});
			}
			else
			{
				await Shell.Current.DisplayAlert("Hata", "Form sayfasına gitmek için ürününüzün bulunması gerekmektedir", "Tamam");
			}
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
	async Task RemoveItemAsync(ProductModel item)
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			IsRefreshing = true;
			var httpClient = _httpClient.GetOrCreateHttpClient();

			bool answer = await Application.Current.MainPage.DisplayAlert("Uyarı", $"{item.Name} ürün çıkartılacaktır.Devam etmek istiyor musunuz ?", "Çıkart", "Vazgeç");

			if(answer)
				Items.Remove(item);
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	async Task DeleteQuantityAsync(ProductModel item)
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			IsRefreshing = true;

			if(item.Quantity != 1) 
				item.Quantity--;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	async Task AddQuantityAsync(ProductModel item)
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			IsRefreshing = true;

			item.Quantity++;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
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
					foreach (var item in Items.ToList().Where(x => x.Name.Contains(SearchText) || x.Code.ToString().Contains(SearchText)))
					{
						Results.Add(item);
					}
				}
			}
			else
			{
				SearchText = string.Empty;
				Results.Clear();
				foreach (var item in Items)
				{
					Results.Add(item);
				}
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	public async Task GetBackAsync()
	{
		try
		{
			IsBusy = true;

			if (Items.Count == 0)

				await Shell.Current.GoToAsync("..");
			else
			{
				bool answer = await Shell.Current.DisplayAlert("Uyarı", "Çıkmak İstediğinizden Emin misiniz", "Evet", "Hayır");
				if (answer)
				{
					await Shell.Current.GoToAsync("..");
					Items.Clear();
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");

		}
		finally
		{
			IsBusy = false;
		}
	}


}
