﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Models
{
	public partial class BasePurchaseDispatchTransactionLine : ObservableObject
	{
		[ObservableProperty]
		int? referenceId;
		[ObservableProperty]
		short? transactionType;
		[ObservableProperty]
		string transactionTypeName;
        [ObservableProperty]
        string documentNumber;
        [ObservableProperty]
        string documentTrackingNumber;
        [ObservableProperty]
		TimeSpan transactionTime;
		[ObservableProperty]
		DateTime transactionDate;
		[ObservableProperty]
		int? convertedTime;
		[ObservableProperty]
		short? iOType;
		[ObservableProperty]
		int? productReferenceId;
		[ObservableProperty]
		string productCode;
		[ObservableProperty]
		string productName;
		[ObservableProperty]
		int? unitsetReferenceId;
		[ObservableProperty]
		string unitsetCode;
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
		int? orderReferenceId;
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
		int? dispatchReferenceId;
		[ObservableProperty]
		string speCode;
		[ObservableProperty]
		double? conversionFactor;
		[ObservableProperty]
		double? otherConversionFactor;
	}
}
