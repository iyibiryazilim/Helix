using Helix.SharedEntity.BaseModels;

namespace Helix.SharedEntity.Models;

public class OutSourceWorkOrder :BaseWorkOrder
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

    string? suppliername;
    public string? SupplierName
    {
        get => suppliername;
        set
        {
            suppliername = value;
            NotifyPropertyChanged();
        }
    }

}
