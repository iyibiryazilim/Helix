using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.Models;

public class BankAccount : INotifyPropertyChanged
{
	int? referenceId;
	short? cardType;
	string? definition;
	string? accountNo;
	int? bankReferenceId;
	string? bankDefinition;
	string? bankCode;
	int? currencyReferenceId;
	string? currencyName;
	string? currencyCode;
	short? currencyType;

	public int? ReferenceId
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

	public int? BankReferenceId
	{
		get => bankReferenceId;
		set
		{
			if (value != bankReferenceId)
			{
				bankReferenceId = value;
				NotifyPropertyChanged(nameof(BankReferenceId));
			}
		}
	}

	public short? CardType
	{
		get => cardType;
		set
		{
			cardType = value;
			NotifyPropertyChanged();
		}
	}
	public string? Definition
	{
		get => definition;
		set
		{
			definition = value;
			NotifyPropertyChanged();
		}
	}
	public string? AccountNo
	{
		get => accountNo;
		set
		{
			accountNo = value;
			NotifyPropertyChanged();
		}
	}
	public string? BankDefinition
	{
		get => bankDefinition;
		set
		{
			bankDefinition = value;
			NotifyPropertyChanged();
		}
	}
	public string? BankCode
	{
		get => bankCode;
		set
		{
			bankCode = value;
			NotifyPropertyChanged();
		}
	}

	public int? CurrencyReferenceId
	{
		get => currencyReferenceId;
		set
		{
			if (value != currencyReferenceId)
			{
				currencyReferenceId = value;
				NotifyPropertyChanged(nameof(CurrencyReferenceId));
			}
		}
	}
	public string? CurrencyName
	{
		get => currencyName;
		set
		{
			currencyName = value;
			NotifyPropertyChanged();
		}
	}
	public string? CurrencyCode
	{
		get => currencyCode;
		set
		{
			currencyCode = value;
			NotifyPropertyChanged();
		}
	}
	public short? CurrencyType
	{
		get => currencyType;
		set
		{
			currencyType = value;
			NotifyPropertyChanged();
		}
	}
	private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	public event PropertyChangedEventHandler? PropertyChanged;
}
