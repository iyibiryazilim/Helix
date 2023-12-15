using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.MVVMHelper
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {
        }

        //[AlsoNotifyChangeFor(nameof(IsNotBusy))]
        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        bool isRefreshing;

        public bool IsNotBusy => !IsBusy;

    }
}
