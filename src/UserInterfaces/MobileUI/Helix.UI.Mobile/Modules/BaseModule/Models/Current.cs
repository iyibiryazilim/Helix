using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Models
{
	public abstract partial class Current : ObservableObject 
	{
		[ObservableProperty]
		int referenceId;
		[ObservableProperty]
		string code;
		[ObservableProperty]
		string name;
		[ObservableProperty]
		string definition;
		[ObservableProperty]
		string telephone;
		[ObservableProperty]
		string otherTelephone;
		[ObservableProperty]
		string email;
		[ObservableProperty]
		string webAddress;
		[ObservableProperty]
		string taxOffice;
		[ObservableProperty]
		string taxNumber;
		[ObservableProperty]
		short? cardType;
		[ObservableProperty]
		string county;
		[ObservableProperty]
		string city;
		[ObservableProperty]
		string country;
		[ObservableProperty]
		int? referenceCount;
		[ObservableProperty]
		double? netTotal;
		[ObservableProperty]
		DateTime? lastTransactionDate;
		[ObservableProperty]
		TimeSpan? lastTransactionTime;
		[ObservableProperty]
		string image;
	}
}
