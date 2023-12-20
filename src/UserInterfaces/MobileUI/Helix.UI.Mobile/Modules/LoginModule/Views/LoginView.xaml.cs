using Helix.UI.Mobile.Modules.LoginModule.ViewModels;

namespace Helix.UI.Mobile.Modules.LoginModule.Views;

public partial class LoginView : ContentPage
{
	private LoginViewModel _viewModel;
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

}