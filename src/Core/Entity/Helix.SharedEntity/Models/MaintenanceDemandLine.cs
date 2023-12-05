using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.Models;

public class MaintenanceDemandLine : INotifyPropertyChanged
{

    
    //MaintanceDemand ref-ficheDate-number
    int maintanceDemandReferenceId;
    public int MaintanceDemandReferenceId
    {
        get => maintanceDemandReferenceId;
        set
        {
            if (value != maintanceDemandReferenceId)
            {
                maintanceDemandReferenceId = value;
                NotifyPropertyChanged(nameof(MaintanceDemandReferenceId));
            }
        }
    }
    DateTime? maintanceDemandFicheDate;
    public DateTime? MaintanceDemandFicheDate
    {
        get => maintanceDemandFicheDate;
        set
        {
            maintanceDemandFicheDate = value;
            NotifyPropertyChanged();
        }
    }
    string? maintanceDemandFicheNumber;
    public string? MaintanceDemandFicheNumber
    {
        get => maintanceDemandFicheNumber;
        set
        {
            maintanceDemandFicheNumber = value;
            NotifyPropertyChanged();
        }
    }
    //Product ref-kod-name
    int productreferenceId;
    public int ProductReferenceId
    {
        get => productreferenceId;
        set
        {
            if (value != productreferenceId)
            {
                productreferenceId = value;
                NotifyPropertyChanged(nameof(ProductReferenceId));
            }
        }
    }


    string? productcode;
    public string? ProductCode
    {
        get => productcode;
        set
        {
            productcode = value;
            NotifyPropertyChanged();
        }
    }

    string? productname;
    public string? ProductName
    {
        get => productname;
        set
        {
            productname = value;
            NotifyPropertyChanged();
        }
    }
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
    short? maintanceTypeName;
    public short? MaintanceTypeName
    {
        get => maintanceTypeName;
        set
        {
            maintanceTypeName = value;
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
    //Mold-ref-code-name
    int moldReferenceId;
    public int MoldReferenceId
    {
        get => moldReferenceId;
        set
        {
            if (value != moldReferenceId)
            {
                moldReferenceId = value;
                NotifyPropertyChanged(nameof(MoldReferenceId));
            }
        }
    }


    string? moldcode;
    public string? MoldCode
    {
        get => moldcode;
        set
        {
            moldcode = value;
            NotifyPropertyChanged();
        }
    }

    string? moldname;
    public string? MoldName
    {
        get => moldname;
        set
        {
            moldname = value;
            NotifyPropertyChanged();
        }
    }


    //Workstation ref-code-name
    int workstationReferenceId;
    public int WorkstationReferenceId
    {
        get => workstationReferenceId;
        set
        {
            if (value != workstationReferenceId)
            {
                workstationReferenceId = value;
                NotifyPropertyChanged(nameof(WorkstationReferenceId));
            }
        }
    }

    string? workstationCode;
    public string? WorkstationCode
    {
        get => workstationCode;
        set
        {
            workstationCode = value;
            NotifyPropertyChanged();
        }
    }


    string? workstationName;
    public string? WorkstationName
    {
        get => workstationName;
        set
        {
            workstationName = value;
            NotifyPropertyChanged();
        }
    }
    string? description;
    public string? Description
    {
        get => description;
        set
        {
            description = value;
            NotifyPropertyChanged();
        }
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler? PropertyChanged;
}
