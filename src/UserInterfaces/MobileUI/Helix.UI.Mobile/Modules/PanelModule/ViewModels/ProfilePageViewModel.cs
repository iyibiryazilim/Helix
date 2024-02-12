using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.MVVMHelper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.PanelModule.ViewModels
{
   public partial class ProfilePageViewModel :BaseViewModel
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
    }
}
