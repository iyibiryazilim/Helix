using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SalesService.Domain.Models
{
    public class Driver : INotifyPropertyChanged
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

        string? surname;
        public string? Surname
        {
            get => name;
            set
            {
                surname = value;
                NotifyPropertyChanged();
            }
        }
        string? identityNumber;
        public string? IdentityNumber
        {
            get => identityNumber;
            set
            {
                identityNumber = value;
                NotifyPropertyChanged();
            }
        }

        string? plateNumber;
        public string? PlateNumber
        {
            get => plateNumber;
            set
            {
                plateNumber = value;
                NotifyPropertyChanged();
            }
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }



}
