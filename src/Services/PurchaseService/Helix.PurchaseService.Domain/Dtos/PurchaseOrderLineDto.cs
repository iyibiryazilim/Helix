namespace Helix.PurchaseService.Domain.Dtos
{
	public record PurchaseOrderLineDto(
		int? referenceId,
		int? transactionType,
		int? productReferenceId,
		 string? documentNumber,
		string? documentTrackingNumber,
		string? productcode,
		int? unitsetReferenceId,
		string? unitsetCode,
		int? subUnitsetReferenceId,
		string? subUnitsetCode,
		double? quantity,
		double? unitPrice,
		double? vatRate,
		int divisionReferenceId,
		int divisionNumber,
		int warehouseNumber,
		DateTime? dueDate,
 		int? orderReferenceId,
		string? description,
		int? currentReferenceId,
		string? currentCode,
		int? dispatchReference,
		string? speCode,
		double? conversionFactor,
 		double? otherConversionFactor,
		double? totalDiscount,
		double? totalVat,
		double? netTotal,
		double? total,
		short? currencyType)
	{
	}
}