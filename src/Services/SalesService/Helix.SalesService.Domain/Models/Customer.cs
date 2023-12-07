using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SalesService.Domain.Models;

public class Customer : INotifyPropertyChanged
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
	string? definition;
	public string? Definition
	{
		get => definition;
		set
		{
			definition = value;
			NotifyPropertyChanged();
		}
	}
	string? telephone;
	public string? Telephone
	{
		get => telephone;
		set
		{
			telephone = value;
			NotifyPropertyChanged();
		}
	}
	string? otherTelephone;
	public string? OtherTelephone
	{
		get => otherTelephone;
		set
		{
			otherTelephone = value;
			NotifyPropertyChanged();
		}
	}

	string? email;
	public string? Email
	{
		get => email;
		set
		{
			email = value;
			NotifyPropertyChanged();
		}
	}

	string? webAddress;
	public string? WebAddress
	{
		get => webAddress;
		set
		{
			webAddress = value;
			NotifyPropertyChanged();
		}
	}

	string? taxOffice;
	public string? TaxOffice
	{
		get => taxOffice;
		set
		{
			taxOffice = value;
			NotifyPropertyChanged();
		}
	}
	string? taxNumber;
	public string? TaxNumber
	{
		get => taxNumber;
		set
		{
			taxNumber = value;
			NotifyPropertyChanged();
		}
	}

	short cardType;
	public short CardType
	{
		get => cardType;
		set
		{
			cardType = value;
			NotifyPropertyChanged();
		}
	}
	string? county;
	public string? County
	{
		get => county;
		set
		{
			county = value;
			NotifyPropertyChanged();
		}
	}
	string? city;
	public string? City
	{
		get => city;
		set
		{
			city = value;
			NotifyPropertyChanged();
		}
	}

	string? country;
	public string? Country
	{
		get => country;
		set
		{
			country = value;
			NotifyPropertyChanged();
		}
	}

	int referenceCount;
	public int ReferenceCount
	{
		get => referenceCount;
		set
		{
			if (value != referenceCount)
			{
				referenceCount = value;
				NotifyPropertyChanged(nameof(ReferenceCount));
			}
		}
	}

	double? netTotal;
	public double? NetTotal
	{
		get => netTotal;
		set
		{
			netTotal = value;
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

	TimeSpan? lastTransactionTime;
	public TimeSpan? LastTransactionTime
	{
		get => lastTransactionTime;
		set
		{
			lastTransactionTime = value;
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



	private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}


	public event PropertyChangedEventHandler? PropertyChanged;
}
