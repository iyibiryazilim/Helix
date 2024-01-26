using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Domain.Dtos
{
    public record TransferTransactionDto(
      int referenceId,
    DateTime transactionDate,
    TimeSpan transactionTime,
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
    string docTrackingNumber, List<TransferTransactionLineDto> lines)
    {

    }
}
