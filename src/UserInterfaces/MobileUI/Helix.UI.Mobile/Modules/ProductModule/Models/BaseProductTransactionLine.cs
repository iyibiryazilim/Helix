using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Models;

public partial class BaseProductTransactionLine :ObservableObject
{
    [ObservableProperty]
    int referenceId;
    [ObservableProperty]
    DateTime? transactionDate;
    [ObservableProperty]
    TimeSpan? transactionTime;
    [ObservableProperty]
    int productReferenceId;
    [ObservableProperty]
    string? productCode;
    [ObservableProperty]
    string? productName;
    [ObservableProperty]
    int? convertedTime;
    [ObservableProperty]
    int? orderReference;
    [ObservableProperty]
    string? code;
    [ObservableProperty]
    short? groupType;
    [ObservableProperty]
    short? iOType;
    [ObservableProperty]
    short? transactionType;
    [ObservableProperty]
    string documentNumber;
    [ObservableProperty]
    string documentTrackingNumber;
    [ObservableProperty]
    int unitsetReferenceId;
    [ObservableProperty]
    string unitsetCode;
    [ObservableProperty]
    int subUnitsetReferenceId;
    [ObservableProperty]
    string subUnitsetCode;
    public string TransactionTypeName
	{
		get
		{

			switch (TransactionType)
			{
				case 1:
					return "Mal Alım İrsaliyesi";
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
    int divisionreferenceId;
    [ObservableProperty]
    short? divisionNumber;
    [ObservableProperty]
    string? divisionCountry;
    [ObservableProperty]
    string? divisionCity;
    [ObservableProperty]
    int warehouseReferenceId;
    [ObservableProperty]
    string? warehouseName;
    [ObservableProperty]
    short? warehouseNumber;
    [ObservableProperty]
    int? currentReferenceId;
    [ObservableProperty]
    int baseTransactioneReferenceId;
    [ObservableProperty]
    string baseTransactionCode;
    [ObservableProperty]
    string? currentCode;
    [ObservableProperty]
    string? currentName;
    [ObservableProperty]
    double total = default;
    [ObservableProperty]
    double totalVat = default;
    [ObservableProperty]
    double netTotal = default;
    [ObservableProperty]
    string? description;
    [ObservableProperty]
    short dispatchType = default;
    [ObservableProperty]
    int? carrierReferenceId;
    [ObservableProperty]
    string? carrierCode;
    [ObservableProperty]
    int? driverReferenceId;
    [ObservableProperty]
    string? driverFirstName;
    [ObservableProperty]
    string? driverLastName;
    [ObservableProperty]
    string? identityNumber;
    [ObservableProperty]
    string? plaque;
    [ObservableProperty]
    int? shipInfoReferenceId;
    [ObservableProperty]
    string? shipInfoCode;
    [ObservableProperty]
    string? shipInfoName;
    [ObservableProperty]
    string? speCode;
    [ObservableProperty]
    short dispatchStatus = default;
    [ObservableProperty]
    short isEDispatch = default;
    [ObservableProperty]
    string? doCode;
    [ObservableProperty]
    string? docTrackingNumber;
    [ObservableProperty]
    short isEInvoice = default;
    [ObservableProperty]
    short eDispatchProfileId = default;
    [ObservableProperty]
    short eInvoiceProfileId = default;
    [ObservableProperty]
    double? quantity; 

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
