﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ReturnModule.Models.BaseModels;

public partial class BaseTransactionLine : ObservableObject
{
	[ObservableProperty]
	int referenceId;
	[ObservableProperty]
	short transactionType;
	[ObservableProperty]
	string transactionTypeName;
	[ObservableProperty]
	DateTime transactionDate;
	[ObservableProperty]
	TimeSpan transactionTime;
	[ObservableProperty]
	int? convertedTime;
	[ObservableProperty]
	short iOType;
	[ObservableProperty]
	int productReferenceId;
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
	double quantity;
	[ObservableProperty]
	double unitPrice;
	[ObservableProperty]
	double vatRate;
	[ObservableProperty]
	int? divisionReferenceId;
	[ObservableProperty]
	short? divisionNumber;
	[ObservableProperty]
	string? divisionCountry;
	[ObservableProperty]
	string? divisionCity;
	[ObservableProperty]
	int warehouseReferenceId;
	[ObservableProperty]
	string warehouseName;
	[ObservableProperty]
	short warehouseNumber;
	[ObservableProperty]
	int? orderReference;
	[ObservableProperty]
	string description;
	[ObservableProperty]
	int? baseTransactionReferenceId;
	[ObservableProperty]
	string baseTransactionCode;
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
	double conversionFactor;
	[ObservableProperty]
	double otherConversionFactor;

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
