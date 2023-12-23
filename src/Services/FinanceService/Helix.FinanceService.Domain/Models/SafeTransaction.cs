using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.FinanceService.Domain.Models;

public class SafeTransaction : INotifyPropertyChanged
{
    int referenceId;
    DateTime? transactionDate;
    string? code;
    int? safeReferenceId;
    string? safeCode;
    string? safeName;
    int? customerReferenceId;
    string? customerCode;
    string? customerName;
    int? currencyReferenceId;
    string? currencyName;
    string? ioType;
    double? total;
    string? description;
    bool? isSelected = false;

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
    public DateTime? TransactionDate
    {
        get => transactionDate;
        set
        {
            transactionDate = value;
            NotifyPropertyChanged(nameof(TransactionDate));
        }
    }
    public string? Code
    {
        get => code;
        set
        {
            code = value;
            NotifyPropertyChanged(nameof(Code));
        }
    }
    public int? SafeReferenceId
    {
        get => safeReferenceId;
        set
        {
            if (value != safeReferenceId)
            {
                safeReferenceId = value;
                NotifyPropertyChanged(nameof(SafeReferenceId));
            }
        }
    }
    public string? SafeCode
    {
        get => safeCode;
        set
        {
            safeCode = value;
            NotifyPropertyChanged(nameof(SafeCode));
        }
    }
    public string? SafeName
    {
        get => safeName;
        set
        {
            safeName = value;
            NotifyPropertyChanged(nameof(SafeName));
        }
    }
    public int? CustomerReferenceId
    {
        get => customerReferenceId;
        set
        {
            if (value != customerReferenceId)
            {
                customerReferenceId = value;
                NotifyPropertyChanged(nameof(CustomerReferenceId));
            }
        }
    }
    public string? CustomerCode
    {
        get => customerCode;
        set
        {
            customerCode = value;
            NotifyPropertyChanged(nameof(CustomerCode));
        }
    }
    public string? CustomerName
    {
        get => customerName;
        set
        {
            customerName = value;
            NotifyPropertyChanged(nameof(CustomerName));
        }
    }
    public int? CurrencyReferenceId
    {
        get => currencyReferenceId;
        set
        {
            if (value != currencyReferenceId)
            {
                currencyReferenceId = value;
                NotifyPropertyChanged(nameof(CurrencyReferenceId));
            }
        }
    }
    public string? CurrencyName
    {
        get => currencyName;
        set
        {
            currencyName = value;
            NotifyPropertyChanged(nameof(CurrencyName));
        }
    }
    public string? IOType
    {
        get => ioType;
        set
        {
            ioType = value;
            NotifyPropertyChanged(nameof(IOType));
        }
    }
    public double? Total
    {
        get => total;
        set
        {
            if (value != total)
            {
                total = value;
                NotifyPropertyChanged(nameof(Total));
            }
        }
    }
    public string? Description
    {
        get => description;
        set
        {
            description = value;
            NotifyPropertyChanged(nameof(Description));
        }
    }
    public bool? IsSelected
    {
        get => isSelected;
        set
        {
            isSelected = value;
            NotifyPropertyChanged(nameof(IsSelected));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
