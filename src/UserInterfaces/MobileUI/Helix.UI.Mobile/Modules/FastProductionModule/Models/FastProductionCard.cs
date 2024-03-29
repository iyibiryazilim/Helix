﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.FastProductionModule.Models;

public partial class FastProductionCard : ObservableObject
{

	#region Product field
	[ObservableProperty]
	int productReferenceId;

	[ObservableProperty]
	string productCode;

	[ObservableProperty]
	string productName;

	[ObservableProperty]
	string subUnitsetCode;

	[ObservableProperty]
	int subUnitsetReferenceId;

	[ObservableProperty]
	double onHand;

	[ObservableProperty]
	string image;
	#endregion

	#region Warehouse field

	[ObservableProperty]
	int warehouseReferenceId;
	[ObservableProperty]
	string warehouseName;
	[ObservableProperty]
	short warehouseNumber;
	[ObservableProperty]
	DateTime? lastTransactionDate; 
	#endregion

}
