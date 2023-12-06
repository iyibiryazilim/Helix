using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.PurchaseService.Domain.Models;

public class BaseTransactionLine : INotifyPropertyChanged
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
    int? convertedTime;
    public int? ConvertedTime
    {
        get => convertedTime;
        set
        {
            convertedTime = value;
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
    ///Product ref-code-name
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
    double quantity = default;
    public double Quantity
    {
        get => quantity;
        set
        {
            quantity = value;
            NotifyPropertyChanged();
        }
    }

    double unitPrice = default;
    public double UnitPrice
    {
        get => unitPrice;
        set
        {
            unitPrice = value;
            NotifyPropertyChanged();
        }
    }
    double vatRate = default;
    public double VatRate
    {
        get => vatRate;
        set
        {
            vatRate = value;
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

    short divisionNumber = default;
    public short DivisionNumber
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
    int warehousereferenceId;
    public int WarehouseReferenceId
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

    //ProductTransaction--->BaseTransaction
    //ref
    int baseTransactionReferenceId;
    public int BaseTransactioneReferenceId
    {
        get => baseTransactionReferenceId;
        set
        {
            if (value != baseTransactionReferenceId)
            {
                baseTransactionReferenceId = value;
                NotifyPropertyChanged(nameof(BaseTransactioneReferenceId));
            }
        }
    }
    string? baseTransactioncode;
    public string? BaseTransactionCode
    {
        get => baseTransactioncode;
        set
        {
            baseTransactioncode = value;
            NotifyPropertyChanged();
        }
    }

    //Current ref-code-name
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


    int? dispatchReference;
    public int? DispatchReference
    {
        get => dispatchReference;
        set
        {
            dispatchReference = value;
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

    double conversionFactor = default;
    public double ConversionFactor
    {
        get => conversionFactor;
        set
        {
            conversionFactor = value;
            NotifyPropertyChanged();
        }
    }
    double otherConversionFactor = default;
    public double OtherConversionFactor
    {
        get => otherConversionFactor;
        set
        {
            otherConversionFactor = value;
            NotifyPropertyChanged();
        }
    }


    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
