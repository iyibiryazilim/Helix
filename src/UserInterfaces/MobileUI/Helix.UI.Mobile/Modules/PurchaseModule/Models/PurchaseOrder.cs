﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Models
{
	public partial class PurchaseOrder : ObservableObject
	{
		[ObservableProperty]
		int? referenceId;
		[ObservableProperty]
		DateTime? date;
		[ObservableProperty]
		TimeSpan? time;
		[ObservableProperty]
		int? transactionType;
		[ObservableProperty]
		string transactionTypeName;
		[ObservableProperty]
		short? orderType;
		[ObservableProperty]
		string code;
		[ObservableProperty]
		int? warehouseReferenceId;
		[ObservableProperty]
		string warehouseName;
		[ObservableProperty]
		short? warehouseNumber;
		[ObservableProperty]
		int? divisionReferenceId;
		[ObservableProperty]
		short? divisionNumber;
		[ObservableProperty]
		string divisonCountry;
		[ObservableProperty]
		string divisionCity;
		[ObservableProperty]
		int? currentReferenceId;
		[ObservableProperty]
		string currentCode;
		[ObservableProperty]
		string currentName;
		[ObservableProperty]
		double? total;
		[ObservableProperty]
		double? totalVat;
		[ObservableProperty]
		double? netTotal;
		[ObservableProperty]
		string description;
		[ObservableProperty]
		short? status;
	}
}
