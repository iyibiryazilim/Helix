using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.FinanceService.Domain.Models.BaseModels;

public class Current : INotifyPropertyChanged
{
    int referenceId;
    string? code;
    string? name;
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
            NotifyPropertyChanged();
        }
    }
    public string? Name
    {
        get => name;
        set
        {
            name = value;
            NotifyPropertyChanged();
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
