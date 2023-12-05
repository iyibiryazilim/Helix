using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.Models;

public class MaintenanceWorkOrder : INotifyPropertyChanged
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

    string? ficheNo;
    public string? FicheNo
    {
        get => ficheNo;
        set
        {
            ficheNo = value;
            NotifyPropertyChanged();
        }
    }
    DateTime? date;
    public DateTime? Date
    {
        get => date;
        set
        {
            date = value;
            NotifyPropertyChanged();
        }
    }
    int? time;
    public int? Time
    {
        get => time;
        set
        {
            time = value;
            NotifyPropertyChanged();
        }
    }

    string? documentNumber;
    public string? DocumentNumber
    {
        get => documentNumber;
        set
        {
            documentNumber = value;
            NotifyPropertyChanged();
        }
    }
    string? specialCode;
    public string? SpecialCode
    {
        get => specialCode;
        set
        {
            specialCode = value;
            NotifyPropertyChanged();
        }
    }
    //Division ref-name-number-country-city
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
    //Warehouse ref-name-number
    int warehousereferenceId;
    public int WarehouseReferenceId
    {
        get => warehousereferenceId;
        set
        {
            if (value != warehousereferenceId)
            {
                warehousereferenceId = value;
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
    //product ref-code-name
    int productReferenceId;

    public int ProductReferenceId
    {
        get => productReferenceId;
        set
        {
            if (value != productReferenceId)
            {
                productReferenceId = value;
                NotifyPropertyChanged(nameof(ProductReferenceId));
            }
        }
    }


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
    //Workstation ref-code-name
    int? workstationreferenceId;
    public int? WorkstationReferenceId
    {
        get => workstationreferenceId;
        set
        {
            if (value != workstationreferenceId)
            {
                workstationreferenceId = value;
                NotifyPropertyChanged(nameof(WorkstationReferenceId));
            }
        }
    }
    string? workstationcode;
    public string? WorkstationCode
    {
        get => workstationcode;
        set
        {
            workstationcode = value;
            NotifyPropertyChanged();
        }
    }

    string? workstationname;
    public string? WorkstationName
    {
        get => workstationname;
        set
        {
            workstationname = value;
            NotifyPropertyChanged();
        }
    }


    //Employee ref-code-name
    int employeeReferenceId;

    public int EmployeeReferenceId
    {
        get => employeeReferenceId;
        set
        {
            if (value != employeeReferenceId)
            {
                employeeReferenceId = value;
                NotifyPropertyChanged(nameof(employeeReferenceId));
            }
        }
    }

    string? employeeCode;
    public string? EmployeeCode
    {
        get => employeeCode;
        set
        {
            employeeCode = value;
            NotifyPropertyChanged();
        }
    }

    string? employeeName;
    public string? EmployeeName
    {
        get => employeeName;
        set
        {
            employeeName = value;
            NotifyPropertyChanged();
        }
    }

    DateTime? plannedBegingDate;
    public DateTime? PlannedBegingDate
    {
        get => plannedBegingDate;
        set
        {
            plannedBegingDate = value;
            NotifyPropertyChanged();
        }
    }

    int? plannedBegingTime;
    public int? PlannedBegingTime
    {
        get => plannedBegingTime;
        set
        {
            plannedBegingTime = value;
            NotifyPropertyChanged();
        }
    }
    DateTime? plannedEndDate;
    public DateTime? PlannedEndDate
    {
        get => plannedEndDate;
        set
        {
            plannedEndDate = value;
            NotifyPropertyChanged();
        }
    }

    int? plannedEndTime;
    public int? PlannedEndTime
    {
        get => plannedEndTime;
        set
        {
            plannedEndTime = value;
            NotifyPropertyChanged();
        }
    }
    DateTime? actualEndDate;
    public DateTime? ActualEndDate
    {
        get => actualEndDate;
        set
        {
            actualEndDate = value;
            NotifyPropertyChanged();
        }
    }

    int? actualEndTime;
    public int? ActualEndTime
    {
        get => actualEndTime;
        set
        {
            actualEndTime = value;
            NotifyPropertyChanged();
        }
    }
    DateTime? actualBegingDate;
    public DateTime? ActualBegingDate
    {
        get => actualBegingDate;
        set
        {
            actualBegingDate = value;
            NotifyPropertyChanged();
        }
    }

    int? actualBegingTime;
    public int? ActualBegingTime
    {
        get => actualBegingTime;
        set
        {
            actualBegingTime = value;
            NotifyPropertyChanged();
        }
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler? PropertyChanged;

}
