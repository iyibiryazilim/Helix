namespace Helix.ProductService.Domain.Dtos
{
    public record InCountingTransactionDto(
   int referenceId,
    DateTime transactionDate,
    TimeSpan transactionTime,
    string code,
    short groupType,
    short iOType,
    short transactionType,
    string transactionTypeName,
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
