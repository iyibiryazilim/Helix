using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Models
{
	public partial class WaitingOrderLine : ObservableObject
	{
		[ObservableProperty]
		int? referenceId;
		[ObservableProperty]
		short? transactionType;
		[ObservableProperty]
		string transactionTypeName;
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
		double? shippedQuantity;
		[ObservableProperty]
		double? waitingQuantity;
		[ObservableProperty]
		double? unitPrice;
		[ObservableProperty]
		double? vatRate;
		[ObservableProperty]
		int? divisonReferenceId;
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
		DateTime? dueDate;
		[ObservableProperty]
		double? total;
		[ObservableProperty]
		double? totalVat;
		[ObservableProperty]
		double? netTotal;
		[ObservableProperty]
		string description;
		[ObservableProperty]
		int? orderReferenceId;
		[ObservableProperty]
		DateTime? orderDate;
		[ObservableProperty]
		int? orderTransactionType;
		[ObservableProperty]
		int? orderTransactionTypeName;
		[ObservableProperty]
		string orderCode;
		[ObservableProperty]
		int? currentReferenceId;
		[ObservableProperty]
		string currentCode;
		[ObservableProperty]
		string currentName;
		[ObservableProperty]
		bool isSelected;


		private double? tempQuantity;

		public double? TempQuantity
		{
			get
			{
				tempQuantity = WaitingQuantity;
				return tempQuantity;
			}
			set => SetProperty(ref tempQuantity, value);
		}


	}
}
