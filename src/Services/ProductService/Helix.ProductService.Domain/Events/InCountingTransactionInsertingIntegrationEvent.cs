﻿using Helix.EventBus.Base.Events;
using Helix.ProductService.Domain.Dtos;

namespace Helix.ProductService.Domain.Events
{
    public class InCountingTransactionInsertingIntegrationEvent : IntegrationEvent
    {
        public int ReferenceId { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string Code { get; private set; }
        public short GroupType { get; private set; }
        public short IOType { get; private set; }
        public short TransactionType { get; private set; }
        public int? WarehouseNumber { get; private set; }
        public int? CurrentReferenceId { get; private set; }
        public string? CurrentCode { get; private set; }
        public string Description { get; private set; }
        public string SpeCode { get; private set; }
        public string DoCode { get; private set; }
        public string DocTrackingNumber { get; private set; }
        public string? EmployeeOid { get; private set; }

        public List<InCountingTransactionLineDto> Lines { get; set; }

        public InCountingTransactionInsertingIntegrationEvent(int referenceId, DateTime transactionDate, string code, short groupType, short iOType, short transactionType, int? warehouseNumber, int? currentReferenceId, string? currentCode, string description, string speCode, string doCode, string docTrackingNumber, string? employeeOid, List<InCountingTransactionLineDto> lines)
        {
            ReferenceId = referenceId;
            TransactionDate = transactionDate;
            Code = code;
            GroupType = groupType;
            IOType = iOType;
            TransactionType = transactionType;
            WarehouseNumber = warehouseNumber;
            CurrentReferenceId = currentReferenceId;
            CurrentCode = currentCode;
            Description = description;
            SpeCode = speCode;
            DoCode = doCode;
            DocTrackingNumber = docTrackingNumber;
            EmployeeOid = employeeOid;
            Lines = lines;
        }
    }
}
