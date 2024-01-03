using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;

public partial class FailedPageViewModel : BaseViewModel
{
	[ObservableProperty]
	bool isAnimationStart = false;

	public Command StartAnimationCommand { get; }
	public FailedPageViewModel()
	{

		IsAnimationStart = false;
		StartAnimationCommand = new Command(async () => await StartAnimationAsync());
	}

	public async Task StartAnimationAsync()
	{
		await Task.Delay(50);
		IsAnimationStart = true;
	}

	[RelayCommand]
	public async Task CloseButtonHandlerAsync()
	{
		try
		{
			IsBusy = true;
			//await Shell.Current.GoToAsync("..");
			Application.Current.MainPage = new AppShell();
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
