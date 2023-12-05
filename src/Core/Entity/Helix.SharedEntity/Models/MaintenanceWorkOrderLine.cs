using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.Models;

public class MaintenanceWorkOrderLine : INotifyPropertyChanged
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
    //MaintanceWorkOrder ref-ficheno-date-time
    int? maintanceWorkOrderReferenceId;
    public int? MaintanceWorkOrderReferenceId
    {
        get => maintanceWorkOrderReferenceId;
        set
        {
            if (value != maintanceWorkOrderReferenceId)
            {
                maintanceWorkOrderReferenceId = value;
                NotifyPropertyChanged(nameof(MaintanceWorkOrderReferenceId));
            }
        }
    }
    string? maintanceWorkOrderFicheNo;
    public string? MaintanceWorkOrderFicheNo
    {
        get => maintanceWorkOrderFicheNo;
        set
        {
            maintanceWorkOrderFicheNo = value;
            NotifyPropertyChanged();
        }
    }
    DateTime? maintanceWorkOrderDate;
    public DateTime? MaintanceWorkOrderDate
    {
        get => maintanceWorkOrderDate;
        set
        {
            maintanceWorkOrderDate = value;
            NotifyPropertyChanged();
        }
    }
  

    short? tampletGroupNumber;
    public short? TampletGroupNumber
    {
        get => tampletGroupNumber;
        set
        {
            tampletGroupNumber = value;
            NotifyPropertyChanged();
        }
    }

    string? tampleteCode;
    public string? TampleteCode
    {
        get => tampleteCode;
        set
        {
            tampleteCode = value;
            NotifyPropertyChanged();
        }
    }
    string? tampleteName;
    public string? TampleteName
    {
        get => tampleteName;
        set
        {
            tampleteName = value;
            NotifyPropertyChanged();
        }
    }
    double? tampleteDuration;
    public double? TampleteDuration
    {
        get => tampleteDuration;
        set
        {
            tampleteDuration = value;
            NotifyPropertyChanged();
        }
    }
    short? tampleteDurationType;
    public short? TampleteDurationType
    {
        get => tampleteDurationType;
        set
        {
            tampleteDurationType = value;
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
    short? lineNumber;
    public short? LineNumber
    {
        get => lineNumber;
        set
        {
            lineNumber = value;
            NotifyPropertyChanged();
        }
    }
    double? ısCanceled;
    public double? IsCanceled
    {
        get => ısCanceled;
        set
        {
            ısCanceled = value;
            NotifyPropertyChanged();
        }
    }
    //Warehouse
    int warehouseReferenceId;
    public int WarehouseReferenceId
    {
        get => warehouseReferenceId;
        set
        {
            if (value != warehouseReferenceId)
            {
                warehouseReferenceId = value;
                NotifyPropertyChanged(nameof(WarehouseReferenceId));
            }
        }
    }

    short? warehouseName;
    public short? WarehouseName
    {
        get => warehouseName;
        set
        {
            warehouseName = value;
            NotifyPropertyChanged();
        }
    }


    string? warehouseNumber;
    public string? WarehouseNumber
    {
        get => warehouseNumber;
        set
        {
            warehouseNumber = value;
            NotifyPropertyChanged();
        }
    }



    //Divison
    int? divisionreferenceId;
    public int? DivisionReferenceId
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


    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
