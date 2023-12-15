namespace Helix.ProductionService.Domain.Dtos;

public record ProductionTransactionLineDto(
	int productReferenceId,
	string productCode,
	double quantity,
	int subUnitsetReferenceId,
	string subUnitsetCode,
	DateTime transactionDate,
	short transactionType,
	string transactionTypeName,
	int referenceId,
	string transactionTime,
	int convertedTime,
	int iOType,
	int warehouseNumber,
	double unitPrice,
	double vatRate,
	int orderReferenceId,
	string description,
	int dispatchReferenceId,
	string speCode,
	double conversionFactor,
	double otherConversionFactor,
	IList<SeriLotTransactionDto> seriLotTransactions
	)
{
}
