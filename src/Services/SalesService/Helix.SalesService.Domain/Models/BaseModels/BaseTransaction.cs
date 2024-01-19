using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SalesService.Domain.Models.BaseModels;

public abstract class BaseTransaction : INotifyPropertyChanged
{
    int referenceId;

    public int ReferenceId
    {
        get => referenceId;
        set
        {
            if (value != referenceId)
            {
                referenceId = value;
                NotifyPropertyChanged(nameof(ReferenceId));
            }
        }

    }

    DateTime? transactionDate;
    public DateTime? TransactionDate
    {
        get => transactionDate;
        set
        {
            transactionDate = value;
            NotifyPropertyChanged();
        }
    }


    TimeSpan? transactionTime;
    public TimeSpan? TransactionTime
    {
        get => transactionTime;
        set
        {
            transactionTime = value;
            NotifyPropertyChanged();
        }
    }


    int? orderReference;
    public int? OrderReference
    {
        get => orderReference;
        set
        {
            orderReference = value;
            NotifyPropertyChanged();
        }
    }
    string? code;
    public string? Code
    {
        get => code;
        set
        {
            code = value;
            NotifyPropertyChanged();
        }
    }
    short? groupType;
    public short? GroupType
    {
        get => groupType;
        set
        {
            groupType = value;
            NotifyPropertyChanged();
        }
    }

    short? iOType;
    public short? IOType
    {
        get => iOType;
        set
        {
            iOType = value;
            NotifyPropertyChanged();
        }
    }
    short? transactionType;
    public short? TransactionType
    {
        get => transactionType;
        set
        {
            transactionType = value;
            NotifyPropertyChanged();
        }
    }
    string? transactionTypeName;
    public string? TransactionTypeName
    {
        get => transactionTypeName;
        set
        {
            transactionTypeName = value;
            NotifyPropertyChanged();
        }
    }
    //Divison
    int divisionreferenceId;
    public int DivisionReferenceId
    {
        get => divisionreferenceId;
        set
        {
            if (value != divisionreferenceId)
            {
                divisionreferenceId = value;
                NotifyPropertyChanged(nameof(DivisionReferenceId));
            }
        }
    }

    short? divisionNumber;
    public short? DivisionNumber
    {
        get => divisionNumber;
        set
        {
            divisionNumber = value;
            NotifyPropertyChanged();
        }
    }

    string? divisionCountry;
    public string? DivisionCountry
    {
        get => divisionCountry;
        set
        {
            divisionCountry = value;
            NotifyPropertyChanged();
        }
    }
    string? divisionCity;
    public string? DivisionCity
    {
        get => divisionCity;
        set
        {
            divisionCity = value;
            NotifyPropertyChanged();
        }
    }
    //Warehouse
    int warehouseReferenceId;
    public int WarehouseReferenceId
    {
        get => warehouseReferenceId;
        set
        {
            if (value != warehouseReferenceId)
            {
                warehouseReferenceId = value;
                NotifyPropertyChanged(nameof(WarehouseReferenceId));
            }
        }
    }

    string? warehouseName;
    public string? WarehouseName
    {
        get => warehouseName;
        set
        {
            warehouseName = value;
            NotifyPropertyChanged();
        }
    }


    short? warehouseNumber;
    public short? WarehouseNumber
    {
        get => warehouseNumber;
        set
        {
            warehouseNumber = value;
            NotifyPropertyChanged();
        }
    }
    //Current
    int? currentReferenceId;

    public int? CurrentReferenceId
    {
        get => currentReferenceId;
        set
        {
            if (value != currentReferenceId)
            {
                currentReferenceId = value;
                NotifyPropertyChanged(nameof(CurrentReferenceId));
            }
        }
    }

    string? currentCode;
    public string? CurrentCode
    {
        get => currentCode;
        set
        {
            currentCode = value;
            NotifyPropertyChanged();
        }
    }

    string? currentName;
    public string? CurrentName
    {
        get => currentName;
        set
        {
            currentName = value;
            NotifyPropertyChanged();
        }
    }
    double total = default;
    public double Total
    {
        get => total;
        set
        {
            total = value;
            NotifyPropertyChanged();
        }
    }

    double totalVat = default;
    public double TotalVat
    {
        get => totalVat;
        set
        {
            totalVat = value;
            NotifyPropertyChanged();
        }
    }
    double netTotal = default;
    public double NetTotal
    {
        get => netTotal;
        set
        {
            netTotal = value;
            NotifyPropertyChanged();
        }
    }
    string? description;
    public string? Description
    {
        get => description;
        set
        {
            description = value;
            NotifyPropertyChanged();
        }
    }
    short dispatchType = default;
    public short DispatchType
    {
        get => dispatchType;
        set
        {
            dispatchType = value;
            NotifyPropertyChanged();
        }
    }
    int? carrierReferenceId;
    public int? CarrierReferenceId
    {
        get => carrierReferenceId;
        set
        {
            carrierReferenceId = value;
            NotifyPropertyChanged();
        }
    }
    string? carrierCode;
    public string? CarrierCode
    {
        get => carrierCode;
        set
        {
            carrierCode = value;
            NotifyPropertyChanged();
        }
    }
    int? driverReferenceId;
    public int? DriverReferenceId
    {
        get => driverReferenceId;
        set
        {
            driverReferenceId = value;
            NotifyPropertyChanged();
        }
    }

    string? driverFirstName;
    public string? DriverFirstName
    {
        get => driverFirstName;
        set
        {
            driverFirstName = value;
            NotifyPropertyChanged();
        }
    }

    string? driverLastName;
    public string? DriverLastName
    {
        get => driverLastName;
        set
        {
            driverLastName = value;
            NotifyPropertyChanged();
        }
    }

    string? identityNumber;
    public string? IdentityNumber
    {
        get => identityNumber;
        set
        {
            identityNumber = value;
            NotifyPropertyChanged();
        }
    }

    string? plaque;
    public string? Plaque
    {
        get => plaque;
        set
        {
            plaque = value;
            NotifyPropertyChanged();
        }
    }
    int? shipInfoReferenceId;
    public int? ShipInfoReferenceId
    {
        get => shipInfoReferenceId;
        set
        {
            shipInfoReferenceId = value;
            NotifyPropertyChanged();
        }
    }
    string? shipInfoCode;
    public string? ShipInfoCode
    {
        get => shipInfoCode;
        set
        {
            shipInfoCode = value;
            NotifyPropertyChanged();
        }
    }
    string? shipInfoName;
    public string? ShipInfoName
    {
        get => shipInfoName;
        set
        {
            shipInfoName = value;
            NotifyPropertyChanged();
        }
    }
    string? speCode;
    public string? SpeCode
    {
        get => speCode;
        set
        {
            speCode = value;
            NotifyPropertyChanged();
        }
    }
    short dispatchStatus = default;
    public short DispatchStatus
    {
        get => dispatchStatus;
        set
        {
            dispatchStatus = value;
            NotifyPropertyChanged();
        }
    }
    short isEDispatch = default;
    public short IsEDispatch
    {
        get => isEDispatch;
        set
        {
            isEDispatch = value;
            NotifyPropertyChanged();
        }
    }

    string? doCode;
    public string? DoCode
    {
        get => doCode;
        set
        {
            doCode = value;
            NotifyPropertyChanged();
        }
    }

    string? docTrackingNumber;
    public string? DocTrackingNumber
    {
        get => docTrackingNumber;
        set
        {
            docTrackingNumber = value;
            NotifyPropertyChanged();
        }
    }
    short isEInvoice = default;
    public short IsEInvoice
    {
        get => isEInvoice;
        set
        {
            isEInvoice = value;
            NotifyPropertyChanged();
        }
    }
    short eDispatchProfileId = default;
    public short EDispatchProfileId
    {
        get => eDispatchProfileId;
        set
        {
            eDispatchProfileId = value;
            NotifyPropertyChanged();
        }
    }
    short eInvoiceProfileId = default;
    public short EInvoiceProfileId
    {
        get => eInvoiceProfileId;
        set
        {
            eInvoiceProfileId = value;
            NotifyPropertyChanged();
        }
    }



    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
