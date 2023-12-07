using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.ProductionService.Domain.Models;

public class StopCause : INotifyPropertyChanged
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

	short? affectsCost;

	public short? AffectsCost
	{
		get => affectsCost;
		set
		{
			affectsCost = value;
			NotifyPropertyChanged();
		}
	}

	short? affectsPlan;

	public short? AffectsPlan
	{
		get => affectsPlan;
		set
		{
			affectsPlan = value;
			NotifyPropertyChanged();
		}
	}

	bool? isSelected = false;

	public bool? IsSelected
	{
		get => isSelected;
		set
		{
			isSelected = value;
			NotifyPropertyChanged();
		}
	}




	public event PropertyChangedEventHandler? PropertyChanged;
	public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
