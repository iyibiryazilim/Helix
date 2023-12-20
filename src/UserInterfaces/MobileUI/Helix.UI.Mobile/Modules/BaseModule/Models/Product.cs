using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Models;

public partial class Product :ObservableObject
{
    [ObservableProperty]
    int referenceId;

    [ObservableProperty]
    string code;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string groupName;

    [ObservableProperty]
    int? cardType;

    [ObservableProperty]
    int? unitsetReferenceId;

    [ObservableProperty]
    string unitsetCode;

    [ObservableProperty]
    int? subUnitsetReferenceId;

    [ObservableProperty]
    string subUnitsetCode;

    [ObservableProperty]
    int? brandReferenceId;

    [ObservableProperty]
    string brandCode;

    [ObservableProperty]
    string brandName;

    [ObservableProperty]
    string producerCode;

    [ObservableProperty]
    string speCode;

    [ObservableProperty]
    short trackingType;

    [ObservableProperty]
    short lockTrackingType;

    [ObservableProperty]
    string image;

    [ObservableProperty]
    double stockQuantity;

    [ObservableProperty]
    DateTimeOffset? lastTransactionDate;

}
