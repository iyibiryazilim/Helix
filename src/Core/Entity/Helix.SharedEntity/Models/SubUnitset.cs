using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.Models;

public class SubUnitset : INotifyPropertyChanged
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

    bool? isActive;
    public bool? IsActive
    {
        get => isActive;
        set
        {
            isActive = value;
            NotifyPropertyChanged();
        }
    }
    short? isMainUnit;
    public short? IsMainUnit
    {
        get => isMainUnit;
        set
        {
            isMainUnit = value;
            NotifyPropertyChanged();
        }
    }
    double? conversionFactor;
    public double? ConversionFactor
    {
        get => conversionFactor;
        set
        {
            conversionFactor = value;
            NotifyPropertyChanged();
        }
    }
    double? otherConversionFactor;
    public double? OtherConversionFactor
    {
        get => otherConversionFactor;
        set
        {
            otherConversionFactor = value;
            NotifyPropertyChanged();
        }
    }




    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
