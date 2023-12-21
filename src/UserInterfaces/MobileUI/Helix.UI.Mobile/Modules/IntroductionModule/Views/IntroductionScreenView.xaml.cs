using Helix.UI.Mobile.Modules.IntroductionModule.ViewModels;

namespace Helix.UI.Mobile.Modules.IntroductionModule.Views;

public partial class IntroductionScreenView : ContentPage
{
	public IntroductionScreenView()
	{
		InitializeComponent();
		this.BindingContext = new IntroductionScreenViewModel();
	}
}