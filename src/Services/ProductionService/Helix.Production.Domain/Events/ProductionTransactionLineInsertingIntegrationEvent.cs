using Helix.EventBus.Base.Events;
using Helix.ProductionService.Domain.Dtos;

namespace Helix.ProductionService.Domain.Events;

public class ProductionTransactionLineInsertingIntegrationEvent : IntegrationEvent
{
	public int ProductReferenceId { get; private set; }
	public string ProductCode { get; private set; }
	public double Quantity { get; private set; }
	public int SubUnitsetReferenceId { get; private set; }
	public string SubUnitsetCode { get; private set; }
	public DateTime TransactionDate { get; private set; }
	public short TransactionType { get; private set; }
	public string TransactionTypeName { get; private set; }
	public int ReferenceId { get; private set; }
	public string TransactionTime { get; private set; }
	public int ConvertedTime { get; private set; }
	public int IOType { get; private set; }
	public int WarehouseNumber { get; private set; }
	public double UnitPrice { get; private set; }
	public double VatRate { get; private set; }
	public int OrderReferenceId { get; private set; }
	public string Description { get; private set; }
	public int DispatchReferenceId { get; private set; }
	public string SpeCode { get; private set; }
	public double ConversionFactor { get; private set; }
	public double OtherConversionFactor { get; private set; }
	public IList<SeriLotTransactionDto> SeriLotTransactions { get; private set; }

	public ProductionTransactionLineInsertingIntegrationEvent(int productReferenceId, string productCode, double quantity, int subUnitsetReferenceId, string subUnitsetCode, DateTime transactionDate, short transactionType, string transactionTypeName, int referenceId, string transactionTime, int convertedTime, int iOType, int warehouseNumber, double unitPrice, double vatRate, int orderReferenceId, string description, int dispatchReferenceId, string speCode, double conversionFactor, double otherConversionFactor, IList<SeriLotTransactionDto> seriLotTransactions)
	{
		ProductReferenceId = productReferenceId;
		ProductCode = productCode;
		Quantity = quantity;
		SubUnitsetReferenceId = subUnitsetReferenceId;
		SubUnitsetCode = subUnitsetCode;
		TransactionDate = transactionDate;
		TransactionType = transactionType;
		TransactionTypeName = transactionTypeName;
		ReferenceId = referenceId;
		TransactionTime = transactionTime;
		ConvertedTime = convertedTime;
		IOType = iOType;
		WarehouseNumber = warehouseNumber;
		UnitPrice = unitPrice;
		VatRate = vatRate;
		OrderReferenceId = orderReferenceId;
		Description = description;
		DispatchReferenceId = dispatchReferenceId;
		SpeCode = speCode;
		ConversionFactor = conversionFactor;
		OtherConversionFactor = otherConversionFactor;
		SeriLotTransactions = seriLotTransactions;
	}
}
