using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.Models;

public class BankAccountTransactionLine : INotifyPropertyChanged
{
	int? referenceId;
	//short? transactionType;
	//string? transactionTypeName;
	short? transactionTypeCode;
	string? transactionTypeCodeName;
	DateTime? date;
	TimeSpan? time;
	double? total;
	short? branch;
	string? description;
	int? currentReferenceId;
	string? currentCode;
	string? currentName;
	int? bankReferenceId;
	string? bankCode;
	string? bankDefinition;
	int? bankAccountReferenceId;
	string? bankAccountCode;
	string? bankAccountDefinition;
	int? bankAccountTransactionReferenceId;
	string? bankAccountTransactionCode;
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

	//public short? TransactionType
	//{
	//	get => transactionType;
	//	set
	//	{
	//		transactionType = value;
	//		NotifyPropertyChanged();
	//	}
	//}
	public short? TransactionTypeCode
	{
		get => transactionTypeCode;
		set
		{
			transactionTypeCode = value;
			NotifyPropertyChanged();
		}
	}

	public string? TransactionTypeCodeName
	{
		get
		{
			switch (TransactionTypeCode)
			{
				case 1:
					return "Banka İşlemi";
				case 2:
					return "Virman İşlemi";
				case 3:
					return "Gelen Havale";
				case 4:
					return "Gönderilen Havale";
				case 5:
					return "Açılış İşlemi";
				default:
					return "Diğer";
			}
		}
	}
	//public string? TransactionTypeName
	//{
	//	get
	//	{
	//		switch (TransactionType)
	//		{
	//			case 1:
	//				return "Banka İşlemi";
	//			case 2:
	//				return "Virman İşlemi";
	//			case 3:
	//				return "Gelen Havale";
	//			case 4:
	//				return "Gönderilen Havale";
	//			case 5:
	//				return "Açılış İşlemi";
	//			default:
	//				return "Diğer";
	//		}
	//	}
	
	//}

	public string? Description
	{
		get => description;
		set
		{
			description = value;
			NotifyPropertyChanged();
		}
	}
	public short? Branch
	{
		get => branch;
		set
		{
			branch = value;
			NotifyPropertyChanged();
		}
	}
	public DateTime? Date
	{
		get => date;
		set
		{
			date = value;
			NotifyPropertyChanged();
		}
	}

	public TimeSpan? Time
	{
		get => time;
		set
		{
			time = value;
			NotifyPropertyChanged();
		}
	}
	public double? Total
	{
		get => total;
		set
		{
			total = value;
			NotifyPropertyChanged();
		}
	}

	public int? CurrentReferenceId
	{
		get => currentReferenceId;
		set
		{
			if (value != currentReferenceId)
			{
				currentReferenceId = value;
				NotifyPropertyChanged(nameof(CurrentReferenceId));
			}
		}
	}

	public string? CurrentCode
	{
		get => currentCode;
		set
		{
			currentCode = value;
			NotifyPropertyChanged();
		}
	}

	public string? CurrentName
	{
		get => currentName;
		set
		{
			currentName = value;
			NotifyPropertyChanged();
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

	public string? BankCode
	{
		get => bankCode;
		set
		{
			bankCode = value;
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
	public int? BankAccountReferenceId
	{
		get => bankAccountReferenceId;
		set
		{
			if (value != bankAccountReferenceId)
			{
				bankAccountReferenceId = value;
				NotifyPropertyChanged(nameof(BankAccountReferenceId));
			}
		}
	}

	public string? BankAccountCode
	{
		get => bankAccountCode;
		set
		{
			bankAccountCode = value;
			NotifyPropertyChanged();
		}
	}

	public string? BankAccountDefinition
	{
		get => bankAccountDefinition;
		set
		{
			bankAccountDefinition = value;
			NotifyPropertyChanged();
		}
	}

	public int? BankAccountTransactionReferenceId
	{
		get => bankAccountTransactionReferenceId;
		set
		{
			if (value != bankAccountTransactionReferenceId)
			{
				bankAccountTransactionReferenceId = value;
				NotifyPropertyChanged(nameof(BankAccountTransactionReferenceId));
			}
		}
	}

	public string? BankAccountTransactionCode
	{
		get => bankAccountTransactionCode;
		set
		{
			bankAccountTransactionCode = value;
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
