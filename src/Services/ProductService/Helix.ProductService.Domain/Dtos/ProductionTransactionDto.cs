namespace Helix.ProductService.Domain.Dtos;

public record ProductionTransactionDto(int referenceId,
    DateTime transactionDate,
    string transactionTime,
    int convertedTime,
    int orderReference,
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
    string docTrackingNumber, List<ProductionTransactionLineDto> lines)
{
    
}
