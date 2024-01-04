using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesDispatchViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;

public partial class SalesDispatchListViewModel : BaseViewModel
{
	IHttpClientService _httpClient;
	public ObservableCollection<ProductModel> Items { get; } = new();

	public SalesDispatchListViewModel(IHttpClientService httpClient)
	{
		Title = "Sevk İşlemleri";
		_httpClient = httpClient;
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
					[nameof(ProductModel)] = Items
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
				bool answer = await Shell.Current.DisplayAlert("Sayım Eksiği :: Vazgeç", "Çıkmak İstediğinizden Emin misiniz", "Evet", "Hayır");
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
