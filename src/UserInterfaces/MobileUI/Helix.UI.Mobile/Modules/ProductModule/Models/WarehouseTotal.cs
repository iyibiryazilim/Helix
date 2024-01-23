using CommunityToolkit.Mvvm.ComponentModel;
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

		[ObservableProperty]
		double tempOnhand;

		//[ObservableProperty]
		//Microsoft.Maui.Graphics.Color borderColor;

		//[ObservableProperty]
		//string? indicatorColor;

		//public Microsoft.Maui.Graphics.Color WarehouseCountingIndicatorColor
		//{
		//	get
		//	{

		//		if (TempOnhand > OnHand)
		//		{
		//			return Microsoft.Maui.Graphics.Color.FromRgba("#2ca57c");  // Success
		//		}
		//		else if(TempOnhand == OnHand)
		//		{
		//			return Microsoft.Maui.Graphics.Color.FromRgba("#00000000");  // Transparent
		//		}
		//		else
		//		{
		//			return Microsoft.Maui.Graphics.Color.FromRgba("#c1322a");  // Danger
		//		}
		//	}
		//	set
		//	{
		//		OnPropertyChanged();
		//	}
		//}

		public string? IndicatorColor
		{
			get
			{

				if (TempOnhand > OnHand)
				{
					return "#2ca57c";  // Success
				}
				else if (TempOnhand == OnHand)
				{
					return "#00000000";  // Transparent
				}
				else
				{
					return "#c1322a";  // Danger
				}
			}
			set
			{
				OnPropertyChanged();
			}
		}
	}
}
