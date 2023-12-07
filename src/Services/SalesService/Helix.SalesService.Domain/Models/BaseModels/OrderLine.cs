using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SalesService.Domain.Models.BaseModels;

public abstract class OrderLine : INotifyPropertyChanged
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
    //product ref-code-name
    int productReferenceId;

    public int ProductReferenceId
    {
        get => productReferenceId;
        set
        {
            if (value != productReferenceId)
            {
                productReferenceId = value;
                NotifyPropertyChanged(nameof(ProductReferenceId));
            }
        }
    }
    string? productCode;
    public string? ProductCode
    {
        get => productCode;
        set
        {
            productCode = value;
            NotifyPropertyChanged();
        }
    }

    string? productName;
    public string? ProductName
    {
        get => productName;
        set
        {
            productName = value;
            NotifyPropertyChanged();
        }
    }

    ///Unitset ref-code

    int? unitsetReferenceId;

    public int? UnitsetReferenceId
    {
        get => unitsetReferenceId;
        set
        {
            if (value != unitsetReferenceId)
            {
                unitsetReferenceId = value;
                NotifyPropertyChanged(nameof(UnitsetReferenceId));
            }
        }
    }
    string? unitsetCode;
    public string? UnitsetCode
    {
        get => unitsetCode;
        set
        {
            unitsetCode = value;
            NotifyPropertyChanged();
        }
    }
    ///SubUnitset ref-code-name

    int? subUnitsetReferenceId;

    public int? SubUnitsetReferenceId
    {
        get => subUnitsetReferenceId;
        set
        {
            if (value != subUnitsetReferenceId)
            {
                subUnitsetReferenceId = value;
                NotifyPropertyChanged(nameof(SubUnitsetReferenceId));
            }
        }
    }

    string? subUnitsetCode;
    public string? SubUnitsetCode
    {
        get => subUnitsetCode;
        set
        {
            subUnitsetCode = value;
            NotifyPropertyChanged();
        }
    }

    double? quantity;
    public double? Quantity
    {
        get => quantity;
        set
        {
            quantity = value;
            NotifyPropertyChanged();
        }
    }
    double? shippedQuantity;
    public double? ShippedQuantity
    {
        get => shippedQuantity;
        set
        {
            shippedQuantity = value;
            NotifyPropertyChanged();
        }
    }
    double? waitingQuantity;
    public double? WaitingQuantity
    {
        get => waitingQuantity;
        set
        {
            waitingQuantity = value;
            NotifyPropertyChanged();
        }
    }
    double? unitPrice;
    public double? UnitPrice
    {
        get => unitPrice;
        set
        {
            unitPrice = value;
            NotifyPropertyChanged();
        }
    }
    double? vatRate;
    public double? VatRate
    {
        get => vatRate;
        set
        {
            vatRate = value;
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
    //Warehouse ref-name-number
    int? warehousereferenceId;
    public int? WarehouseReferenceId
    {
        get => warehousereferenceId;
        set
        {
            if (value != warehousereferenceId)
            {
                warehousereferenceId = value;
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
    DateTime? dueDate;
    public DateTime? DueDate
    {
        get => dueDate;
        set
        {
            dueDate = value;
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
    //order
    int? orderReferenceId;

    public int? OrderReferenceId
    {
        get => orderReferenceId;
        set
        {
            if (value != orderReferenceId)
            {
                orderReferenceId = value;
                NotifyPropertyChanged(nameof(OrderReferenceId));
            }
        }
    }
    DateTime? orderDate;
    public DateTime? OrderDate
    {
        get => orderDate;
        set
        {
            orderDate = value;
            NotifyPropertyChanged();
        }
    }


    int? orderTransactionType;
    public int? OrderTransactionType
    {
        get => orderTransactionType;
        set
        {
            orderTransactionType = value;
            NotifyPropertyChanged();
        }
    }

    string? orderTransactionTypeName;
    public string? OrderTransactionTypeName
    {
        get => orderTransactionTypeName;
        set
        {
            orderTransactionTypeName = value;
            NotifyPropertyChanged();
        }
    }

    string? orderCode;
    public string? OrderCode
    {
        get => orderCode;
        set
        {
            orderCode = value;
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





    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
