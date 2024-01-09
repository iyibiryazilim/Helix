using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SalesService.Domain.Models;

public class SpeCodeModel : INotifyPropertyChanged
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

    string? definition;
    public string? Definition
    {
        get => definition;
        set
        {
            definition = value;
            NotifyPropertyChanged();
        }
    }


    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
