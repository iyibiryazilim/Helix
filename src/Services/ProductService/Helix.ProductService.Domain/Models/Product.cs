using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.ProductService.Domain.Models;

public class Product : INotifyPropertyChanged

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


    string? code;
    public string? Code
    {
        get => code;
        set
        {
            code = value;
            NotifyPropertyChanged();
        }
    }

    string? name;
    public string? Name
    {
        get => name;
        set
        {
            name = value;
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

    //Product Unitset
    int? unitsetReferenceId;

    public int? UnitsetReferenceId
    {
        get => unitsetReferenceId;
        set
        {
            if (value != unitsetReferenceId)
            {
                unitsetReferenceId = value;
                NotifyPropertyChanged(nameof(UnitsetReferenceId));
            }
        }
    }


    string? unitsetCode;
    public string? UnitsetCode
    {
        get => unitsetCode;
        set
        {
            unitsetCode = value;
            NotifyPropertyChanged();
        }
    }
    //Product SubUnitset
    int? subUnitsetReferenceId;

    public int? SubUnitsetReferenceId
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
	string? groupName;
	public string? GroupName
	{
		get => groupName;
		set
		{
			groupName = value;
			NotifyPropertyChanged();
		}
	}
	//Brand  ref-code-name
	int? brandReferenceId;

    public int? BrandReferenceId
    {
        get => brandReferenceId;
        set
        {
            if (value != brandReferenceId)
            {
                brandReferenceId = value;
                NotifyPropertyChanged(nameof(BrandReferenceId));
            }
        }
    }


    string? brandCode;
    public string? BrandCode
    {
        get => brandCode;
        set
        {
            brandCode = value;
            NotifyPropertyChanged();
        }
    }

	DateTime? lastTransactionDate;
	public DateTime? LastTransactionDate
	{
		get => lastTransactionDate;
		set
		{
			lastTransactionDate = value;
			NotifyPropertyChanged();
		}
	}
	string? image;
	public string? Image
	{
		get => image;
		set
		{
			image = value;
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
	string? brandName;
    public string? BrandName
    {
        get => brandName;
        set
        {
            brandName = value;
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

    string? speCode;
    public string? SpeCode
    {
        get => speCode;
        set
        {
            speCode = value;
            NotifyPropertyChanged();
        }
    }

    short? trackingType;
    public short? TrackingType
    {
        get => trackingType;
        set
        {
            trackingType = value;
            NotifyPropertyChanged();
        }
    }

    short? lockTrackingType;
    public short? LockTrackingType
    {
        get => lockTrackingType;
        set
        {
            lockTrackingType = value;
            NotifyPropertyChanged();
        }
    }


    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler? PropertyChanged;




}