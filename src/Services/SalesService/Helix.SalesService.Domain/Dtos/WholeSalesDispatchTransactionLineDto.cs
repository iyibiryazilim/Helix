namespace Helix.SalesService.Domain.Dtos
{
    public record WholeSalesDispatchTransactionLineDto(int referenceId,
    short? transactionType,
    string? documentNumber,
    string? documentTrackingNumber,
    DateTime? transactionDate,
    short? iOType,
    int? productReferenceId,
    string? productCode,
    int? unitsetReferenceId,
    string? unitsetCode,
    int? subUnitsetReferenceId,
    string? subUnitsetCode,
    double? quantity,
    double? unitPrice,
    double? vatRate,
    short? warehouseNumber,
    int? orderReferenceId,
    string? description,
    int? currentReferenceId,
    string? currentCode,
    int? dispatchReference,
    string? speCode,
    double? conversionFactor,
    double? otherConversionFactor)
    {
    }
}
