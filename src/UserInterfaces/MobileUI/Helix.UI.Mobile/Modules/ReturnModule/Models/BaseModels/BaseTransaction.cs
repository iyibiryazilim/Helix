﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.ReturnModule.Models.BaseModels;

public partial class BaseTransaction : ObservableObject
{
	[ObservableProperty]
	int referenceId;
	[ObservableProperty]
	DateTime transactionDate;
	[ObservableProperty]
	TimeSpan transactionTime;
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
	[ObservableProperty]
	string transactionTypeName;
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
