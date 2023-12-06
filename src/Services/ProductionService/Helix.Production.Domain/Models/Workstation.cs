using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.ProductionService.Domain.Models;

public class Workstation : INotifyPropertyChanged
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

	string? permissionCode;
	public string? PermissionCode
	{
		get => permissionCode;
		set
		{
			permissionCode = value;
			NotifyPropertyChanged();
		}
	}

	//WorkstationGroup ref-code-name

	int workstationGroupReferenceId;
	public int WorkstationGroupReferenceId
	{
		get => workstationGroupReferenceId;
		set
		{
			if (value != workstationGroupReferenceId)
			{
				workstationGroupReferenceId = value;
				NotifyPropertyChanged(nameof(WorkstationGroupReferenceId));
			}
		}
	}

	string? workstationGroupCode;
	public string? WorkstationGroupCode
	{
		get => workstationGroupCode;
		set
		{
			workstationGroupCode = value;
			NotifyPropertyChanged();
		}
	}

	string? workstationGroupName;
	public string? WorkstationGroupName
	{
		get => workstationGroupName;
		set
		{
			workstationGroupName = value;
			NotifyPropertyChanged();
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;
	public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
