using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.PanelModule.Models;

public partial class MainPanelModel : ObservableObject
{
	[ObservableProperty]
	double? todayInputTransactionFicheCount = 15; // Bugünkü Giriş Sayısı

	[ObservableProperty]
	double? todayOutputTransactionFicheCount = 24; // Bugünkü Çıkış Sayısı

	[ObservableProperty]
	double? waitingSalesOrderCount = 15; // Bekleyen Satış 

	[ObservableProperty]
	double? waitingPurchaseOrderCount = 24; // Bekleyen Satınalma


}
