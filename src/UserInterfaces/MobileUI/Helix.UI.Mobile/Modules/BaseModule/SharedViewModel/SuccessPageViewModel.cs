using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.MVVMHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;

public partial class SuccessPageViewModel : BaseViewModel
{
	[ObservableProperty]
	bool isAnimationStart = false;

	public Command StartAnimationCommand { get; }
	public SuccessPageViewModel()
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
