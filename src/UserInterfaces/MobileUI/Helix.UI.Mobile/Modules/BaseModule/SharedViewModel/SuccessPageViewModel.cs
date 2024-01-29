using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
[QueryProperty(nameof(GroupType), nameof(GroupType))]
[QueryProperty(nameof(SuccessMessage), nameof(SuccessMessage))]
public partial class SuccessPageViewModel : BaseViewModel
{
	[ObservableProperty]
	bool isAnimationStart = false;
	[ObservableProperty]
	public int groupType;

	[ObservableProperty]
	public string successMessage;

	public SuccessPageViewModel()
	{

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
					await Shell.Current.GoToAsync("..");

					break;

				default:
					Application.Current.MainPage = new AppShell();
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
