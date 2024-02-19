using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PanelModule.ViewModels;

public partial class ProfilePageViewModel : BaseViewModel
{
	public ProfilePageViewModel()
	{
		GetUserInformationCommand = new Command(async () => await GetUserInformationAsync());
	}

	[ObservableProperty]
	string userName = string.Empty;

	public Command GetUserInformationCommand { get; }

	async Task GetUserInformationAsync()
	{

		try
		{
			IsBusy = true;

			UserName = await SecureStorage.GetAsync("CurrentUser");

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
