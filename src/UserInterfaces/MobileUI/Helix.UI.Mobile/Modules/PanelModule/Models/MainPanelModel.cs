using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.PanelModule.Models;

public partial class MainPanelModel : ObservableObject
{
	[ObservableProperty]
	double? inputCount; // Bugünkü Giriş Sayısı

	[ObservableProperty]
	double? outputCount; // Bugünkü Çıkış Sayısı

	[ObservableProperty]
	double? waitingSalesOrderCount; // Bekleyen Satış 

	[ObservableProperty]
	double? waitingPurchaseOrderCount; // Bekleyen Satınalma


}
