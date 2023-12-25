using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.FinanceService.Domain.Models.BaseModels;

public class BankAccount : INotifyPropertyChanged
{
    int referenceId;
    string? code;
    string? name;
    string? accountNumber;
    string? iBAN;
    int? bankReferenceId;
    string? bankCode;
    string? bankName;
    int? currencyReferenceId;
    string? currencyName;
    double? debit;
    double? credit;
    double? balance;
    DateTime? lastTransactionDate;
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
    public string? Code
    {
        get => code;
        set
        {
            code = value;
            NotifyPropertyChanged(nameof(Code));
        }
    }
    public string? Name
    {
        get => name;
        set
        {
            name = value;
            NotifyPropertyChanged(nameof(Name));
        }
    }
    public string? AccountNumber
    {
        get => accountNumber;
        set
        {
            accountNumber = value;
            NotifyPropertyChanged(nameof(AccountNumber));
        }
    }
    public string? IBAN
    {
        get => iBAN;
        set
        {
            iBAN = value;
            NotifyPropertyChanged(nameof(IBAN));
        }
    }
    public int? BankReferenceId
    {
        get => bankReferenceId;
        set
        {
            if (value != bankReferenceId)
            {
                bankReferenceId = value;
                NotifyPropertyChanged(nameof(BankReferenceId));
            }
        }
    }
    public string? BankCode
    {
        get => bankCode;
        set
        {
            bankCode = value;
            NotifyPropertyChanged(nameof(BankCode));
        }
    }
    public string? BankName
    {
        get => bankName;
        set
        {
            bankName = value;
            NotifyPropertyChanged(nameof(BankName));
        }
    }
    public int? CurrencyReferenceId
    {
        get => currencyReferenceId;
        set
        {
            if (value != bankReferenceId)
            {
                bankReferenceId = value;
                NotifyPropertyChanged(nameof(BankReferenceId));
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
    public double? Debit
    {
        get => debit;
        set
        {
            debit = value;
            NotifyPropertyChanged(nameof(Debit));
        }
    }
    public double? Credit
    {
        get => credit;
        set
        {
            credit = value;
            NotifyPropertyChanged(nameof(Credit));
        }
    }
    public double? Balance
    {
        get => balance;
        set
        {
            balance = value;
            NotifyPropertyChanged(nameof(Balance));
        }
    }
    public DateTime? LastTransactionDate
    {
        get => lastTransactionDate;
        set
        {
            lastTransactionDate = value;
            NotifyPropertyChanged(nameof(LastTransactionDate));
        }
    }
    public bool? IsSelected
    {
        get => isSelected;
        set
        {
            isSelected = value;
            NotifyPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
