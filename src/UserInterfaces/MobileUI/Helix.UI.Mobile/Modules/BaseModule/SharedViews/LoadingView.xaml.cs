namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class LoadingView : ContentView
{
	public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(LoadingView), false);

	public bool IsBusy
	{
		get => (bool)GetValue(IsBusyProperty);
		set => SetValue(IsBusyProperty, value);
	}

	public LoadingView()
	{
		InitializeComponent();
	}
}