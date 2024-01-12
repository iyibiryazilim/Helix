using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Models;

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
    bool isSelected = false;

	[ObservableProperty]
	double onHand = default;

	[ObservableProperty]
	int quantityCounter = 1;

	double tempOnhand;
	public double TempOnhand
	{
		get => OnHand - QuantityCounter;
		set => SetProperty(ref tempOnhand, value);
	}




}
