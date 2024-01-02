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
	bool isAnimationStart;
	public SuccessPageViewModel()
	{
		IsAnimationStart = false;
	}

	[RelayCommand]
	public void StartAnimationHandler()
	{
		IsAnimationStart = true;
	}

	public async Task CloseButtonHandlerAsync()
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
