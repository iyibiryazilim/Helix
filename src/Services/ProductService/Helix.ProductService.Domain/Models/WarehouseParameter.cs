using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductService.Domain.Models
{
    public class WarehouseParameter : INotifyPropertyChanged
    {
        short? warehouseNumber;
        public short? WarehouseNumber
        {
            get => warehouseNumber;
            set
            {
                warehouseNumber = value;
                NotifyPropertyChanged();
            }
        }

        string? warehouseName;
        public string? WarehouseName
        {
            get => warehouseName;
            set
            {
                warehouseName = value;
                NotifyPropertyChanged();
            }
        }

        double? minLevel;
        public double? MinLevel
        {
            get => minLevel;
            set
            {
                minLevel = value;
                NotifyPropertyChanged();
            }
        }

        double? maxLevel;
        public double? MaxLevel
        {
            get => maxLevel;
            set
            {
                maxLevel = value;
                NotifyPropertyChanged();
            }
        }

        double? safeLevel;
        public double? SafeLevel
        {
            get => safeLevel;
            set
            {
                safeLevel = value;
                NotifyPropertyChanged();
            }
        }

        double? stockQuantity;
        public double? StockQuantity
        {
            get => stockQuantity;
            set
            {
                stockQuantity = value;
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
