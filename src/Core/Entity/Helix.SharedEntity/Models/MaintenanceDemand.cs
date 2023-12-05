using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.Models;

public class MaintenanceDemand : INotifyPropertyChanged
{
    int? referenceId;
    public int? ReferenceId
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
    DateTime? ficheDate;
    public DateTime? FicheDate
    {
        get => ficheDate;
        set
        {
            ficheDate = value;
            NotifyPropertyChanged();
        }
    }
    string? ficheNumber;
    public string? FicheNumber
    {
        get => ficheNumber;
        set
        {
            ficheNumber = value;
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
    //Division name-number-country-city
        int? divisionReferenceId;
        public int? DivisionReferenceId
        {
            get => divisionReferenceId;
            set
            {
                if (value != divisionReferenceId)
                {
                divisionReferenceId = value;
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



    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
