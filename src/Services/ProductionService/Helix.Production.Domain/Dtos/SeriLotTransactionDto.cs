namespace Helix.ProductionService.Domain.Dtos;

public record SeriLotTransactionDto(
	int referenceId,
	DateTime date,
	string stockLocationCode,
	string destinationStockLocationCode,
	int warehouseNumber,
	string productTransactionCode,
	int inProductTransactionLineReferenceId,
	int outProductTransactionLineReferenceId,
	short serilotType,
	double quantity,
	double remainingQuantity,
	double inSerilotTransactionQuantity,
	int iOCode,
	string subUnitsetCode,
	double conversionFactor,
	double otherConversionFactor
	)
{
}
