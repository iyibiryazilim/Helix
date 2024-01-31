﻿namespace Helix.PurchaseService.Domain.Dtos;

public record PurchaseDispatchTransactionDto(int? referenceId,
 DateTime transactionDate,
  int? orderReference,
  string? code,
  short? groupType,
  short? iOType,
  short? transactionType,
  int? warehouseNumber,
  int? currentReferenceId,
  string? currentCode,
  double? total,
  double? totalVat,
  double? netTotal,
  string? description,
  short? dispatchType,
  string? speCode,
  short? dispatchStatus,
  short? isEDispatch,
  string? doCode,
  string? docTrackingNumber,
  short? isEInvoice,
  short? eDispatchProfileId,
  short? eInvoiceProfileId,List<PurchaseDispatchTransactionLineDto> lines)
{
}
