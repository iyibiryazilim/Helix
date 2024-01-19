﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
	public partial class WarehouseTotal : ObservableObject
	{
		[ObservableProperty]
		DateTime? transactionDate;

		[ObservableProperty]
		int warehousereferenceId;

		[ObservableProperty]
		string warehouseName;

		[ObservableProperty]
		short? warehouseNumber;

		[ObservableProperty]
		double onHand = default;

		[ObservableProperty]
		int productReferenceId;

		[ObservableProperty]
		string? productCode;

		[ObservableProperty]
		string? productName;

		[ObservableProperty]
		int subUnitsetReferenceId;

		[ObservableProperty]
		string? subUnitsetCode;

		[ObservableProperty]
		int unitsetReferenceId;

		[ObservableProperty]
		string? unitsetCode;

		[ObservableProperty]
		string? image;

		[ObservableProperty]
		bool isSelected = false;

		[ObservableProperty]
		int quantityCounter = 0;

		double tempOnhand;


		public double TempOnhand
		{
			get => OnHand;
			set => SetProperty(ref tempOnhand, value);
		}


		public Microsoft.Maui.Graphics.Color BorderLineColor
		{
			get
			{
				if (TempOnhand != OnHand)
				{
					return Microsoft.Maui.Graphics.Color.FromRgba("#ffd300");
				}
				else
				{
					return Microsoft.Maui.Graphics.Color.FromRgba("#fff");
				}
			}
			set
			{

			}
		}
	}
}
