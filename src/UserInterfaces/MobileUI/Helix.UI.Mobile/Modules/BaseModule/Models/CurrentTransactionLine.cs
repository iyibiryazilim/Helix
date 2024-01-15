using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Models
{
	public abstract partial class CurrentTransactionLine : ObservableObject
    {
        [ObservableProperty]
        int? referenceId;
        [ObservableProperty]
        short? transactionType;
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
        DateTime? transactionDate;
        [ObservableProperty]
        string documentNumber;
        [ObservableProperty]
        string documentTrackingNumber;
        [ObservableProperty]
        TimeSpan? transactionTime;
        [ObservableProperty]
        int? convertedTime;
        [ObservableProperty]
        short? iOType;
        [ObservableProperty]
        int? productReferenceId;
        [ObservableProperty]
        string? productCode = string.Empty;
        [ObservableProperty]
        string? productName = string.Empty;
		[ObservableProperty]
        int? unitsetReferenceId;
        [ObservableProperty]
        string unitsetCode = string.Empty;
        [ObservableProperty]
        int? subUnitsetReferenceId;
        [ObservableProperty]
        string subUnitsetCode;
        [ObservableProperty]
        double? quantity;
        [ObservableProperty]
        double? unitPrice;
        [ObservableProperty]
        double? vatRate;
        [ObservableProperty]
        int? divisionReferenceId;
        [ObservableProperty]
        short? divisionNumber;
        [ObservableProperty]
        string divisionCountry;
        [ObservableProperty]
        string divisionCity;
        [ObservableProperty]
        int? warehouseReferenceId;
        [ObservableProperty]
        string warehouseName;
        [ObservableProperty]
        short? warehouseNumber;
        [ObservableProperty]
        int? orderReference;
        [ObservableProperty]
        string description;
        [ObservableProperty]
        int? ficheReferenceId;
        [ObservableProperty]
        string ficheCode;
        [ObservableProperty]
        int? currentReferenceId;
        [ObservableProperty]
        string currentCode;
        [ObservableProperty]
        string currentName;
        [ObservableProperty]
        int? dispatchReference;
        [ObservableProperty]
        string speCode;
        [ObservableProperty]
        double? conversionFactor;
        [ObservableProperty]
        double? otherConversionFactor;
		public Microsoft.Maui.Graphics.Color ListColor
		{
			get
			{
				if (IOType != 0)
				{
					switch (IOType)
					{
						case 1:
							return Microsoft.Maui.Graphics.Color.FromRgba("#2ca57c");
						case 2:
							return Microsoft.Maui.Graphics.Color.FromRgba("#2ca57c");
						case 3:
							return Microsoft.Maui.Graphics.Color.FromRgba("#c1322a");
						case 4:
							return Microsoft.Maui.Graphics.Color.FromRgba("#c1322a");
						default:
							return Microsoft.Maui.Graphics.Color.FromRgba("#c1322a");
					}
				}
				else
				{
					return Microsoft.Maui.Graphics.Color.FromRgba("#42ba96");
				}

			}
			set
			{

			}
		}
	}

	 
}
