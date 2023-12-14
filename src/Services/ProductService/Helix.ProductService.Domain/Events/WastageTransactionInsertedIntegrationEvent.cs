using Helix.EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Domain.Events
{
    public class WastageTransactionInsertedIntegrationEvent : IntegrationEvent
    {
        public int ReferenceId { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string TransactionTime { get; private set; }
        public int ConvertedTime { get; private set; }
        public int OrderReference { get; private set; }
        public string Code { get; private set; }
        public short GroupType { get; private set; }
        public short IOType { get; private set; }
        public short TransactionType { get; private set; }
        public string TransactionTypeName { get; private set; }
        public int? WarehouseNumber { get; private set; }
        public int? CurrentReferenceId { get; private set; }
        public string? CurrentCode { get; private set; }
        public double Total { get; private set; }
        public double TotalVat { get; private set; }
        public double NetTotal { get; private set; }
        public string Description { get; private set; }
        public short DispatchType { get; private set; }
        public int CarrierReferenceId { get; private set; }
        public string CarrierCode { get; private set; }
        public int DriverReferenceId { get; private set; }
        public string DriverFirstName { get; private set; }
        public string DriverLastName { get; private set; }
        public string IdentityNumber { get; private set; }
        public string Plaque { get; private set; }
        public int ShipInfoReferenceId { get; private set; }
        public string ShipInfoCode { get; private set; }
        public string ShipInfoName { get; private set; }
        public string SpeCode { get; private set; }
        public short DispatchStatus { get; private set; }
        public short IsEDispatch { get; private set; }
        public string DoCode { get; private set; }
        public string DocTrackingNumber { get; private set; }
        public short IsEInvoice { get; private set; }
        public short EDispatchProfileId { get; private set; }
        public short EInvoiceProfileId { get; private set; }

        public WastageTransactionInsertedIntegrationEvent(int referenceId, DateTime transactionDate, string transactionTime, int convertedTime, int orderReference, string code, short groupType, short ıOType, short transactionType, string transactionTypeName, int? warehouseNumber, int? currentReferenceId, string? currentCode, double total, double totalVat, double netTotal, string description, short dispatchType, int carrierReferenceId, string carrierCode, int driverReferenceId, string driverFirstName, string driverLastName, string ıdentityNumber, string plaque, int shipInfoReferenceId, string shipInfoCode, string shipInfoName, string speCode, short dispatchStatus, short ısEDispatch, string doCode, string docTrackingNumber, short ısEInvoice, short eDispatchProfileId, short eInvoiceProfileId)
        {
            ReferenceId = referenceId;
            TransactionDate = transactionDate;
            TransactionTime = transactionTime;
            ConvertedTime = convertedTime;
            OrderReference = orderReference;
            Code = code;
            GroupType = groupType;
            IOType = ıOType;
            TransactionType = transactionType;
            TransactionTypeName = transactionTypeName;
            WarehouseNumber = warehouseNumber;
            CurrentReferenceId = currentReferenceId;
            CurrentCode = currentCode;
            Total = total;
            TotalVat = totalVat;
            NetTotal = netTotal;
            Description = description;
            DispatchType = dispatchType;
            CarrierReferenceId = carrierReferenceId;
            CarrierCode = carrierCode;
            DriverReferenceId = driverReferenceId;
            DriverFirstName = driverFirstName;
            DriverLastName = driverLastName;
            IdentityNumber = ıdentityNumber;
            Plaque = plaque;
            ShipInfoReferenceId = shipInfoReferenceId;
            ShipInfoCode = shipInfoCode;
            ShipInfoName = shipInfoName;
            SpeCode = speCode;
            DispatchStatus = dispatchStatus;
            IsEDispatch = ısEDispatch;
            DoCode = doCode;
            DocTrackingNumber = docTrackingNumber;
            IsEInvoice = ısEInvoice;
            EDispatchProfileId = eDispatchProfileId;
            EInvoiceProfileId = eInvoiceProfileId;
        }
    }
}
