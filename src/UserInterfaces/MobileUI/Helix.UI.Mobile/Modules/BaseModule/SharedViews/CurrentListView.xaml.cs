using Helix.UI.Mobile.Modules.BaseModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class CurrentListView : ContentView
{
	public static readonly BindableProperty CurrentListProperty = BindableProperty.Create(nameof(CurrentList), typeof(ObservableCollection<Current>), typeof(CurrentListView), null);
	public ObservableCollection<Current> CurrentList
	{
		get => GetValue(CurrentListProperty) as ObservableCollection<Current>;
		set => SetValue(CurrentListProperty, value);
	}
	public CurrentListView()
	{
		InitializeComponent();
	}
}