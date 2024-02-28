using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.LoginModule.Models;
using Helix.UI.Mobile.Modules.PanelModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PanelModule.ViewModels;

public partial class ProfilePageViewModel : BaseViewModel
{
	IEmployeeService _employeeService;
	IHttpClientService _httpClientService;

	public ProfilePageViewModel(IEmployeeService employeeService, IHttpClientService httpClientService)
	{
		GetUserInformationCommand = new Command(async () => await GetUserInformationAsync());
		_employeeService = employeeService;
		_httpClientService = httpClientService;
	}

	[ObservableProperty]
	Employee user = new Employee();

	public Command GetUserInformationCommand { get; }

	async Task GetUserInformationAsync()
	{

		try
		{
			IsBusy = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();

			var userResult = await _employeeService.GetObject(httpClient, new Guid(await SecureStorage.GetAsync("EmployeeOid")), "?&expand=Image");
			if (userResult.IsSuccess)
			{
				User = userResult.Data;
			}

		}
		catch (Exception)
		{

			throw;
		}
	}

	[RelayCommand]
	async Task GoToBackAsync()
	{
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync("..");
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
}
