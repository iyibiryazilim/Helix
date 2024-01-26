namespace Helix.ProductService.Domain.Dtos
{
    public record OutCountingTransactionLineDto(int referenceId, short? transactionType, string? documentNumber, string? documentTrackingNumber, DateTime? transactionDate, TimeSpan? transactionTime, short? iOType, int productReferenceId, string? productCode, int? unitsetReferenceId, string? unitsetCode, int? subUnitsetReferenceId, string? subUnitsetCode, double quantity, int warehousereferenceId, short? warehouseNumber, string? description, int ficheReferenceId, string? ficheCode, string? speCode, double conversionFactor, double otherConversionFactor)
    {
    }
}
