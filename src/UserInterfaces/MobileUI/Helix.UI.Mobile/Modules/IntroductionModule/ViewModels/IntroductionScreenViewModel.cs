using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.IntroductionModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.IntroductionModule.ViewModels
{
	public partial class IntroductionScreenViewModel : BaseViewModel
	{
		
		[ObservableProperty]
		string buttonText = "İleri";

		private int position;

		public int Position
		{
			get => position;
			set
			{
				SetProperty(ref position, value);
				if (value==Screens.Count-1)
				{
					ButtonText = "Başla";

				}
				else
				{
					ButtonText = "İleri";
				}
			}
		}


		public ObservableCollection<IntroductionScreenModel> Screens { get; set; } = new();

        public IntroductionScreenViewModel()
        {
            Screens.Add(new IntroductionScreenModel()
            {
                IntroTitle = "Satış Modülü",
                IntroDescription = "Satış için tüm işlemler",
                IntroImage="dotnet_bot"
            });
			Screens.Add(new IntroductionScreenModel()
			{
				IntroTitle = "Satınalma Modülü",
				IntroDescription = "Satınalma için tüm işlemler",
				IntroImage = "dotnet_bot"
			});
			Screens.Add(new IntroductionScreenModel()
			{
				IntroTitle = "Mazleme Modülü",
				IntroDescription = "Malzemeler için tüm işlemler",
				IntroImage = "dotnet_bot"
			});
			
		}

		[RelayCommand]
		async Task NextAsync()
		{
			if (Position>=Screens.Count-1)
			{
				Application.Current.MainPage = new AppShell();
				await SecureStorage.Default.SetAsync("isWatch", "true");

			}
			else
			{
				Position++;
			}
		}

		[RelayCommand]
		async Task CloseAsync()
		{
			Application.Current.MainPage = new AppShell();
			await SecureStorage.Default.SetAsync("isWatch", "true");
		}
	}
}
