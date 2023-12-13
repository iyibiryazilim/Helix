using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Domain.Dtos
{
    public record InCountingTransactionDto(
          int referenceId,
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
     double total,
     double totalVat,
     double netTotal,
     string description,
     short dispatchType,
     int carrierReferenceId,
     string carrierCode,
     int driverReferenceId,
     string driverFirstName,
     string driverLastName,
     string identityNumber,
     string plaque,
     int shipInfoReferenceId,
     string shipInfoCode,
     string shipInfoName,
     string speCode,
     short dispatchStatus,
     short isEDispatch,
     string doCode,
     string docTrackingNumber,
     short isEInvoice,
     short eDispatchProfileId,
     short eInvoiceProfileId
        )
    {
    }
}
