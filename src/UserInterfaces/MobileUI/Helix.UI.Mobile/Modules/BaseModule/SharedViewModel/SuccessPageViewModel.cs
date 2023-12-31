﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.MVVMHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
[QueryProperty(nameof(GroupType), nameof(GroupType))]
public partial class SuccessPageViewModel : BaseViewModel
{
	[ObservableProperty]
	bool isAnimationStart = false;
    [ObservableProperty]
    public int groupType;

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
			switch (GroupType)
			{
				case 3:

                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");

                    break;
					
				default:
					break;
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
}
