using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.FinanceService.Domain.Models;

public class Bank : INotifyPropertyChanged
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

    string? name;

    public string? Name
    {
        get => name;
        set
        {
            name = value;
            NotifyPropertyChanged();
        }
    }

    bool? isSelected = false;

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
