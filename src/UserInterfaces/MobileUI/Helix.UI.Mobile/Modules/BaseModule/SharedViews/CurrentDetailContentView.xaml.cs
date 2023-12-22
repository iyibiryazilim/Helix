using Helix.UI.Mobile.Modules.BaseModule.Models;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class CurrentDetailContentView : ContentView
{
	//Properties
	public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(CurrentDetailContentView), false);
	public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(CurrentDetailContentView), false);
	public static readonly BindableProperty CurrentProperty = BindableProperty.Create(nameof(Current), typeof(Current), typeof(CurrentDetailContentView), null);
	//Properties
	public bool IsRefreshing
	{
		get => (bool)GetValue(IsRefreshingProperty);
		set => SetValue(IsRefreshingProperty, value);
	}
	public bool IsBusy
	{
		get => (bool)GetValue(IsBusyProperty);
		set => SetValue(IsBusyProperty, value);
	}
	public Current Current
	{
		get => (Current)GetValue(CurrentProperty);
		set => SetValue(CurrentProperty, value);
	}
	public CurrentDetailContentView()
	{
		InitializeComponent();
	}
}