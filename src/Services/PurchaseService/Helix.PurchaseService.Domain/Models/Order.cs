using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.PurchaseService.Domain.Models;

public abstract class Order : INotifyPropertyChanged
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
    DateTime? date;
    public DateTime? Date
    {
        get => date;
        set
        {
            date = value;
            NotifyPropertyChanged();
        }
    }
    TimeSpan? time;
    public TimeSpan? Time
    {
        get => time;
        set
        {
            time = value;
            NotifyPropertyChanged();
        }
    }

    int? transactionType;
    public int? TransactionType
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

    short? orderType;
    public short? OrderType
    {
        get => orderType;
        set
        {
            orderType = value;
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
    //Warehouse
    int? warehouseReferenceId;
    public int? WarehouseReferenceId
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



    //Divison
    int? divisionreferenceId;
    public int? DivisionReferenceId
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
    double? total;
    public double? Total
    {
        get => total;
        set
        {
            total = value;
            NotifyPropertyChanged();
        }
    }

    double? totalVat;
    public double? TotalVat
    {
        get => totalVat;
        set
        {
            totalVat = value;
            NotifyPropertyChanged();
        }
    }
    double? netTotal;
    public double? NetTotal
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
    short? status;
    public short? Status
    {
        get => status;
        set
        {
            status = value;
            NotifyPropertyChanged();
        }
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
