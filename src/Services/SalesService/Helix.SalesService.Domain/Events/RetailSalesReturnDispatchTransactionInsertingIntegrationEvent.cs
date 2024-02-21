using Helix.EventBus.Base.Events;
using Helix.SalesService.Domain.Dtos;

namespace Helix.SalesService.Domain.Events;

public class RetailSalesReturnDispatchTransactionInsertingIntegrationEvent : IntegrationEvent
{

    public int? ReferenceId { get; private set; }
    public DateTime TransactionDate { get; private set; }
    public short? GroupType { get; private set; }
    public short? IOType { get; private set; }
    public short? TransactionType { get; private set; }
    public int? WarehouseNumber { get; private set; }
    public int? CurrentReferenceId { get; private set; }
    public string? CurrentCode { get; private set; }
    public double? Total { get; private set; }
    public double? TotalVat { get; private set; }
    public double? NetTotal { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public short? DispatchType { get; private set; }
    public string SpeCode { get; private set; } = string.Empty;
    public short? DispatchStatus { get; private set; }
    public short? IsEDispatch { get; private set; }
    public string DoCode { get; private set; } = string.Empty;
    public string DocTrackingNumber { get; private set; } = string.Empty;
    public short? IsEInvoice { get; private set; }
    public short? EDispatchProfileId { get; private set; }
    public short? EInvoiceProfileId { get; private set; }
    public string? EmployeeOid { get; set; }
    public List<RetailSalesReturnDispatchTransactionLineDto> Lines { get; set; }

    public RetailSalesReturnDispatchTransactionInsertingIntegrationEvent(int? referenceId, DateTime transactionDate, short? groupType, short? ıOType, short? transactionType, int? warehouseNumber, int? currentReferenceId, string? currentCode, double? total, double? totalVat, double? netTotal, string description, short? dispatchType, string speCode, short? dispatchStatus, short? isEDispatch, string doCode, string docTrackingNumber, short? ısEInvoice, short? eDispatchProfileId, short? eInvoiceProfileId,string? employeeOid, List<RetailSalesReturnDispatchTransactionLineDto> lines)
    {
        ReferenceId = referenceId;
        TransactionDate = transactionDate;

        GroupType = groupType;
        IOType = ıOType;
        TransactionType = transactionType;
        WarehouseNumber = warehouseNumber;
        CurrentReferenceId = currentReferenceId;
        CurrentCode = currentCode;
        Total = total;
        TotalVat = totalVat;
        NetTotal = netTotal;
        Description = description;
        DispatchType = dispatchType;
        SpeCode = speCode;
        DispatchStatus = dispatchStatus;
        IsEDispatch = isEDispatch;
        DoCode = doCode;
        DocTrackingNumber = docTrackingNumber;
        IsEInvoice = ısEInvoice;
        EDispatchProfileId = eDispatchProfileId;
        EInvoiceProfileId = eInvoiceProfileId;
        EmployeeOid = employeeOid;
        Lines = lines;
    }
}
