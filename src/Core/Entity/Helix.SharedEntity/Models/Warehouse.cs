using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.Models
{
    public class Warehouse : INotifyPropertyChanged
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
        short? number;
        public short? Number
        {
            get => number;
            set
            {
                number = value;
                NotifyPropertyChanged();
            }
        }
        //Division name-number-country-city
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
        string? city;
        public string? City
        {
            get => city;
            set
            {
                city = value;
                NotifyPropertyChanged();
            }
        }
        string? country;
        public string? Country
        {
            get => country;
            set
            {
                country = value;
                NotifyPropertyChanged();
            }
        }
        string? county;
        public string? County
        {
            get => county;
            set
            {
                county = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
