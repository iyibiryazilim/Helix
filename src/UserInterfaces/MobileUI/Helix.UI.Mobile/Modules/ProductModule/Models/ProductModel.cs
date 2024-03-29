﻿using CommunityToolkit.Mvvm.ComponentModel;


namespace Helix.UI.Mobile.Modules.ProductModule.Models;

public partial class ProductModel :ObservableObject
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
    int cardType;

    [ObservableProperty]
    int unitsetReferenceId;

    [ObservableProperty]
    string unitsetCode;

    [ObservableProperty]
    int subUnitsetReferenceId;

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
    DateTimeOffset? lastTransactionDate;

    [ObservableProperty]
    double stockQuantity;

    [ObservableProperty]
    double quantity;

    [ObservableProperty]
    bool isSelected = false;

    [ObservableProperty]
    int locationReferenceId;

    [ObservableProperty]
    string locationCode;

    [ObservableProperty]
    string locationName;

}
