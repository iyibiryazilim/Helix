using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Domain.Models
{
    public class ProductCustomerAndSupplier : INotifyPropertyChanged
    {
        string? productCode;
        public string? ProductCode
        {
            get => productCode;
            set
            {
                productCode = value;
                NotifyPropertyChanged();
            }
        }

        string? productName;
        public string? ProductName
        {
            get => productName;
            set
            {
                productName = value;
                NotifyPropertyChanged();
            }
        }


        int subUnitsetReferenceId;

        public int SubUnitsetReferenceId
        {
            get => subUnitsetReferenceId;
            set
            {
                if (value != subUnitsetReferenceId)
                {
                    subUnitsetReferenceId = value;
                    NotifyPropertyChanged(nameof(SubUnitsetReferenceId));
                }
            }
        }

        int? currentReferenceId;

        public int? CurrentReferenceId
        {
            get => currentReferenceId;
            set
            {
                if (value != currentReferenceId)
                {
                    currentReferenceId = value;
                    NotifyPropertyChanged(nameof(CurrentReferenceId));
                }
            }
        }

        string? currentCode;
        public string? CurrentCode
        {
            get => currentCode;
            set
            {
                currentCode = value;
                NotifyPropertyChanged();
            }
        }

        string? producerCode;
        public string? ProducerCode
        {
            get => producerCode;
            set
            {
                producerCode = value;
                NotifyPropertyChanged();
            }
        }

        string? currentName;
        public string? CurrentName
        {
            get => currentName;
            set
            {
                currentName = value;
                NotifyPropertyChanged();
            }
        }

        string? subUnitsetCode;
        public string? SubUnitsetCode
        {
            get => subUnitsetCode;
            set
            {
                subUnitsetCode = value;
                NotifyPropertyChanged();
            }
        }

        short? priority;
        public short? Priority
        {
            get => priority;
            set
            {
                priority = value;
                NotifyPropertyChanged();
            }
        }
        short? cardType;
        public short? CardType
        {
            get => cardType;
            set
            {
                cardType = value;
                NotifyPropertyChanged();
            }
        }

        string? barcode;
        public string? Barcode
        {
            get => barcode;
            set
            {
                barcode = value;
                NotifyPropertyChanged();
            }
        }
        double? quantity;
        public double? Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                NotifyPropertyChanged();
            }
        }

        string? customerSupplierCode;
        public string? CustomerSupplierCode
        {
            get => customerSupplierCode;
            set
            {
                customerSupplierCode = value;
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
