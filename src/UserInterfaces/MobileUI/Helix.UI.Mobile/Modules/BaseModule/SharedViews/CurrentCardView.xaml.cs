using AndroidX.CardView.Widget;
using Helix.UI.Mobile.Modules.BaseModule.Models;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class CurrentCardView : ContentView
{
	public static readonly BindableProperty CurrentProperty = BindableProperty.Create(nameof(Current), typeof(Current), typeof(CardView), null);

	public Current Current
	{
		get => (Current)GetValue(CurrentCardView.CurrentProperty);
		set => SetValue(CurrentCardView.CurrentProperty, value);
	}

	public CurrentCardView()
	{
		InitializeComponent();
	}
}