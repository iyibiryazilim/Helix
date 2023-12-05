using Helix.SharedEntity.BaseModels;
using System.ComponentModel;

namespace Helix.SharedEntity.Models;

public class OutSourceProductionOrder :BaseProductionOrder
{
    int supplierReferenceId;
    public int SupplierReferenceId
    {
        get => supplierReferenceId;
        set
        {
            if (value != supplierReferenceId)
            {
                supplierReferenceId = value;
                NotifyPropertyChanged(nameof(SupplierReferenceId));
            }
        }
    }
    string? supplierCode;
    public string? SupplierCode
    {
        get => supplierCode;
        set
        {
            supplierCode = value;
            NotifyPropertyChanged();
        }
    }

    string? supplierName;
    public string? SupplierName
    {
        get => supplierName;
        set
        {
            supplierName = value;
            NotifyPropertyChanged();
        }
    }

}
