using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.Models;

public class BankAccountTransaction : INotifyPropertyChanged
{
	int? referenceId;
	short? transactionType;
	string? code;
	DateTime? date;
	TimeSpan? time;
	string? description;
	string? speCode;


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

	public short? TransactionType
	{
		get => transactionType;
		set
		{
			transactionType = value;
			NotifyPropertyChanged();
		}
	}

	public string? TransactionTypeName
	{
		get
		{
			switch (TransactionType)
			{
				case 1:
					return "Banka İşlem Fişi";
				case 2:
					return "Virman Fişi";
				case 3:
					return "Gelen Havaleler";
				case 4:
					return "Gönderilen Havaleler";
				default:
					return "Diğer";
			}
		}
	}
	public string? Code
	{
		get => code;
		set
		{
			code = value;
			NotifyPropertyChanged();
		}
	}
	public string? Description
	{
		get => description;
		set
		{
			description = value;
			NotifyPropertyChanged();
		}
	}
	public string? SpeCode
	{
		get => speCode;
		set
		{
			speCode = value;
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


	private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	public event PropertyChangedEventHandler? PropertyChanged;
}
