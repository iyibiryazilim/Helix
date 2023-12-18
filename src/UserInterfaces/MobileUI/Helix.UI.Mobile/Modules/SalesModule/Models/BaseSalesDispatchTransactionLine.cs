using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.SalesModule.Models
{
	public partial class BaseSalesDispatchTransactionLine : ObservableObject
	{
		[ObservableProperty]
		int referenceId;
		[ObservableProperty]
		short transactionType;
		[ObservableProperty]
		string transactionTypeName;
		[ObservableProperty]
		TimeSpan transactionTime;
		[ObservableProperty]
		int convertedTime;
		[ObservableProperty]
		short iOType;
		[ObservableProperty]
		int productReferenceId;
		[ObservableProperty]
		string productCode;
		[ObservableProperty]
		string productName;
		[ObservableProperty]
		int unitsetReferenceId;
		[ObservableProperty]
		string unitsetCode;
		[ObservableProperty]
		int subUnitsetReferenceId;
		[ObservableProperty]
		string subUnitsetCode;
		[ObservableProperty]
		double quantity;
		[ObservableProperty]
		double unitPrice;
		[ObservableProperty]
		double vatRate;
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
		int orderReferenceId;
		[ObservableProperty]
		string description;
		[ObservableProperty]
		int baseTransactionReferenceId;
		[ObservableProperty]
		string baseTransactionCode;
		[ObservableProperty]
		int supplierReferenceId;
		[ObservableProperty]
		string supplierCode;
		[ObservableProperty]
		string supplierName;
		[ObservableProperty]
		int dispatchReferenceId;
		[ObservableProperty]
		string speCode;
		[ObservableProperty]
		double conversionFactor;
		[ObservableProperty]
		double otherConversionFactor;
	}
}
