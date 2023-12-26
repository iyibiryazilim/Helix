using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Models
{
	public abstract partial class CurrentTransaction : ObservableObject
    {
        [ObservableProperty]
        int referenceId;
        [ObservableProperty]
        DateTime? transactionDate;
        [ObservableProperty]
        TimeSpan? transactionTime;
        [ObservableProperty]
        int convertedTime;
        [ObservableProperty]
        int orderReference;
        [ObservableProperty]
        string code;
        [ObservableProperty]
        short groupType;
        [ObservableProperty]
        short iOType;
        [ObservableProperty]
        short transactionType;
		public string TransactionTypeName
		{
			get
			{

				switch (TransactionType)
				{
					case 1:
						return "Satınalma İrsaliyesi";
					case 2:
						return "Perakende Satış İade İrsaliyesi";
					case 3:
						return "Toptan Satış İade İrsaliyesi";
					case 4:
						return "Konsinye Çıkış İade İrsaliyesi";
					case 5:
						return "Konsinye Giriş İade İrsaliyesi";
					case 6:
						return "Alım İade İrsaliyesi";
					case 7:
						return "Perakende Satış İrsaliyesi";
					case 8:
						return "Toptan Satış İrsaliyesi";
					case 9:
						return "Konsinye Çıkış İrsaliyesi";
					case 10:
						return "Konsinye Giriş İade İrsaliyesi";
					case 13:
						return "Üretimden Giriş Fişi";
					case 14:
						return "Devir Fişi";
					case 12:
						return "Sarf Fişi";
					case 11:
						return "Fire Fişi";
					case 25:
						return "Ambar Fişi";
					case 26:
						return "Mustahsil İrsaliyesi";
					case 50:
						return "Sayım Fazlası Fişi";
					case 51:
						return "Sayım Eksiği Fişi";
					default:
						return "Diğer";
				}
			}
		}
		[ObservableProperty]
        int divisionReferenceId;
        [ObservableProperty]
        short divisionNumber;
        [ObservableProperty]
        string divisionCountry;
        [ObservableProperty]
        string divisionCity;
        [ObservableProperty]
        int warehouseReferenceId;
        [ObservableProperty]
        string warehouseName;
        [ObservableProperty]
        short warehouseNumber;
        [ObservableProperty]
        int currentReferenceId;
        [ObservableProperty]
        string currentCode;
        [ObservableProperty]
        string currentName;
        [ObservableProperty]
        double total;
        [ObservableProperty]
        double totalVat;
        [ObservableProperty]
        double netTotal;
        [ObservableProperty]
        string description;
        [ObservableProperty]
        short dispatchType;
        [ObservableProperty]
        int carrierReferenceId;
        [ObservableProperty]
        string carrierCode;
        [ObservableProperty]
        int driverReferenceId;
        [ObservableProperty]
        string driverFirstName;
        [ObservableProperty]
        string driverLastName;
        [ObservableProperty]
        string identityNumber;
        [ObservableProperty]
        string plaque;
        [ObservableProperty]
        int shipInfoReferenceId;
        [ObservableProperty]
        string shipInfoCode;
        [ObservableProperty]
        string shipInfoName;
        [ObservableProperty]
        string speCode;
        [ObservableProperty]
        short dispatchStatus;
        [ObservableProperty]
        short isEDispatch;
        [ObservableProperty]
        string doCode;
        [ObservableProperty]
        string docTrackingNumber;
        [ObservableProperty]
        short isEInvoice;
        [ObservableProperty]
        short eDispatchProfileId;
        [ObservableProperty]
        short eInvoiceProfileId;
    }
}
