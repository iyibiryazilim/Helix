using Helix.UI.Mobile.Modules.BaseModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class CurrentDetailContentView : ContentView
{
	//Properties
	public static readonly BindableProperty IsRefreshingProperty = BindableProperty.Create(nameof(IsRefreshing), typeof(bool), typeof(CurrentDetailContentView), false);
	public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(CurrentDetailContentView), false);
	public static readonly BindableProperty CurrentProperty = BindableProperty.Create(nameof(Current), typeof(Current), typeof(CurrentDetailContentView), null);
	//List
	public static readonly BindableProperty denemeProperty = BindableProperty.Create(nameof(deneme), typeof(ObservableCollection<string>), typeof(CurrentListView), null);
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
	public ObservableCollection<string> deneme
	{
		get => GetValue(denemeProperty) as ObservableCollection<string>;
		set => SetValue(denemeProperty, value);
	}
	public CurrentDetailContentView()
	{
		InitializeComponent();
	}
}