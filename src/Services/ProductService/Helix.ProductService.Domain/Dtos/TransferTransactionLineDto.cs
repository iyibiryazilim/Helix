namespace Helix.ProductService.Domain.Dtos
{
    public record TransferTransactionLineDto(int referenceId,
        short? transactionType,
        string? documentNumber,
        string? documentTrackingNumber,
        DateTime? transactionDate,
        short? iOType,
        int productReferenceId,
        string? productCode,
        int? unitsetReferenceId,
        string? unitsetCode,
        int? subUnitsetReferenceId,
        string? subUnitsetCode,
        double quantity,
        int warehousereferenceId,
        short? warehouseNumber,
        string? description,
        string? speCode,
        double conversionFactor,
        double otherConversionFactor)
    {
    }
}
