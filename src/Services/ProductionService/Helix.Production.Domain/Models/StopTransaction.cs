using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.ProductionService.Domain.Models;

public class StopTransaction : INotifyPropertyChanged
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
	//workorder ref-status
	int workOrderReferenceId;

	public int WorkorderReferenceId
	{
		get => workOrderReferenceId;
		set
		{
			if (value != workOrderReferenceId)
			{
				workOrderReferenceId = value;
				NotifyPropertyChanged(nameof(WorkorderReferenceId));
			}
		}
	}

	short? workOrderstatus;
	public short? WorkOrderStatus
	{
		get => workOrderstatus;
		set
		{
			workOrderstatus = value;
			NotifyPropertyChanged();
		}
	}
	//Production ref-code

	int productionReferenceId;

	public int ProductionReferenceId
	{
		get => productionReferenceId;
		set
		{
			if (value != productionReferenceId)
			{
				productionReferenceId = value;
				NotifyPropertyChanged(nameof(ProductionReferenceId));
			}
		}
	}


	string? productionCode;
	public string? ProductionCode
	{
		get => productionCode;
		set
		{
			productionCode = value;
			NotifyPropertyChanged();
		}
	}
	//Operation ref-code
	int operationReferenceId;
	public int OperationReferenceId
	{
		get => operationReferenceId;
		set
		{
			if (value != operationReferenceId)
			{
				operationReferenceId = value;
				NotifyPropertyChanged(nameof(OperationReferenceId));
			}
		}
	}
	string? operationCode;
	public string? OperationCode
	{
		get => operationCode;
		set
		{
			operationCode = value;
			NotifyPropertyChanged();
		}
	}

	//Workstation ref-code-spe-permission
	int workstationReferenceId;

	public int WorkStationReferenceId
	{
		get => workstationReferenceId;
		set
		{
			if (value != workstationReferenceId)
			{
				workstationReferenceId = value;
				NotifyPropertyChanged(nameof(WorkStationReferenceId));
			}
		}
	}

	string? workstationCode;
	public string? WorkstationCode
	{
		get => workstationCode;
		set
		{
			workstationCode = value;
			NotifyPropertyChanged();
		}
	}


	string? workstationSpeCode;
	public string? WorkstationSpeCode
	{
		get => workstationSpeCode;
		set
		{
			workstationSpeCode = value;
			NotifyPropertyChanged();
		}
	}

	string? workstationPermissionCode;
	public string? WorkstationPermissionCode
	{
		get => workstationPermissionCode;
		set
		{
			workstationPermissionCode = value;
			NotifyPropertyChanged();
		}
	}
	//StopCause ref-code
	int stopCauseReferenceId;

	public int StopCauseReferenceId
	{
		get => stopCauseReferenceId;
		set
		{
			if (value != stopCauseReferenceId)
			{
				stopCauseReferenceId = value;
				NotifyPropertyChanged(nameof(StopCauseReferenceId));
			}
		}
	}



	string? stopCausecode;
	public string? StopCauseCode
	{
		get => stopCausecode;
		set
		{
			stopCausecode = value;
			NotifyPropertyChanged();
		}
	}

	string? description;
	public string? Description
	{
		get => description;
		set
		{
			description = value;
			NotifyPropertyChanged();
		}
	}

	DateTime? stopDate;
	public DateTime? StopDate
	{
		get => stopDate;
		set
		{
			stopDate = value;
			NotifyPropertyChanged();
		}
	}

	DateTime? startDate;
	public DateTime? StartDate
	{
		get => startDate;
		set
		{
			startDate = value;
			NotifyPropertyChanged();
		}
	}

	TimeSpan? stopTime;
	public TimeSpan? StopTime
	{
		get => stopTime;
		set
		{
			stopTime = value;
			NotifyPropertyChanged();
		}
	}

	TimeSpan? startTime;
	public TimeSpan? StartTime
	{
		get => startTime;
		set
		{
			startTime = value;
			NotifyPropertyChanged();
		}
	}

	double? stopDuration;
	public double? StopDuration
	{
		get => stopDuration;
		set
		{
			stopDuration = value;
			NotifyPropertyChanged();
		}
	}


	private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	public event PropertyChangedEventHandler? PropertyChanged;
}
