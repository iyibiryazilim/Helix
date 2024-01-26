namespace Helix.ProductService.Domain.Dtos
{
    public record InCountingTransactionDto(
   int referenceId,
    DateTime transactionDate,
    string code,
    short groupType,
    short iOType,
    short transactionType,
    int? warehouseNumber,
    int? currentReferenceId,
    string? currentCode,
    string description,
    string speCode,
    string doCode,
    string docTrackingNumber,
    List<InCountingTransactionLineDto> lines
        )
    {
    }
}
