using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.Models;

public class Bank : INotifyPropertyChanged
{
	int? referenceId;
	string? code;
	string? definition;
	string? branch;
	string? branchNo;
	string? address;
	string? city;
	string? country;
	string? district;


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

	public string? Code
	{
		get => code;
		set
		{
			code = value;
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

	public string? Branch
	{
		get => branch;
		set
		{
			branch = value;
			NotifyPropertyChanged();
		}
	}

	public string? BranchNo
	{
		get => branchNo;
		set
		{
			branchNo = value;
			NotifyPropertyChanged();
		}
	}
	public string? Address
	{
		get => address;
		set
		{
			address = value;
			NotifyPropertyChanged();
		}
	}
	public string? City
	{
		get => city;
		set
		{
			city = value;
			NotifyPropertyChanged();
		}
	}
	public string? Country
	{
		get => country;
		set
		{
			country = value;
			NotifyPropertyChanged();
		}
	}
	public string? District
	{
		get => district;
		set
		{
			district = value;
			NotifyPropertyChanged();
		}
	}
	

	private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	public event PropertyChangedEventHandler? PropertyChanged;
}
