using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.Models;
public class Employee : INotifyPropertyChanged
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

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
