using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
[QueryProperty(nameof(GroupType), nameof(GroupType))]
public partial class SuccessPageViewModel : BaseViewModel
{
    [ObservableProperty]
    bool isAnimationStart = false;
    [ObservableProperty]
    public int groupType;

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
                case 1:
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    break;
                case 2:
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    break;
                case 3:

                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");

                    break;
                case 7:
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");

                    break;
                case 8:
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
                    break;
                case 10:
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync("..");
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
