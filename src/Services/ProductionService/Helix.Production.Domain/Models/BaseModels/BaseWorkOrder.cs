using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.ProductionService.Domain.Models.BaseModels;

public abstract class BaseWorkOrder : INotifyPropertyChanged
{

	int referenceId;
	short status = default;
	string statusName = string.Empty;
	DateTime? operationBeginDate;
	string code = string.Empty;
	string subUnitsetCode = string.Empty;
	//string currentName = string.Empty;
	double quantity = 0;
	double actualRate = 0;
	double actualQuantity = 0;


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

	public short Status
	{
		get => status;
		set
		{
			status = value;
			NotifyPropertyChanged();
		}
	}

	public string StatusName
	{
		get => statusName;
		set
		{
			statusName = value;
			NotifyPropertyChanged();
		}
	}

	public DateTime? OperationBeginDate
	{
		get => operationBeginDate;
		set
		{
			operationBeginDate = value;
			NotifyPropertyChanged();
		}
	}


	TimeSpan? operationBeginTime;
	public TimeSpan? OperationBeginTime
	{
		get => operationBeginTime;
		set
		{
			operationBeginTime = value;
			NotifyPropertyChanged();
		}
	}

	DateTime? operationDueDate;
	public DateTime? OperationDueDate
	{
		get => operationDueDate;
		set
		{
			operationDueDate = value;
			NotifyPropertyChanged();
		}
	}

	TimeSpan? operationDueTime;
	public TimeSpan? OperationDueTime
	{
		get => operationDueTime;
		set
		{
			operationDueTime = value;
			NotifyPropertyChanged();
		}
	}


	DateTime? operationActualBeginDate;
	public DateTime? OperationActualBeginDate
	{
		get => operationActualBeginDate;
		set
		{
			operationActualBeginDate = value;
			NotifyPropertyChanged();
		}
	}


	TimeSpan? operationActualBeginTime;
	public TimeSpan? OperationActualBeginTime
	{
		get => operationActualBeginTime;
		set
		{
			operationActualBeginTime = value;
			NotifyPropertyChanged();
		}
	}

	DateTime? operationActualDueDate;
	public DateTime? OperationActualDueDate
	{
		get => operationActualDueDate;
		set
		{
			operationActualDueDate = value;
			NotifyPropertyChanged();
		}
	}



	TimeSpan? operationActualDueTime;
	public TimeSpan? OperationActualDueTime
	{
		get => operationActualDueTime;
		set
		{
			operationActualDueTime = value;
			NotifyPropertyChanged();
		}
	}

	//Operation ref-code-name
	int? operationReferenceId;

	public int? OperationReferenceId
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

	string? operationName;
	public string? OperationName
	{
		get => operationName;
		set
		{
			operationName = value;
			NotifyPropertyChanged();
		}
	}

	//Workstation ref-code-name
	int? workstationReferenceId = default;

	public int? WorkStationReferenceId
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

	string? workstationName;
	public string? WorkstationName
	{
		get => workstationName;
		set
		{
			workstationName = value;
			NotifyPropertyChanged();
		}
	}

	//product ref-code-name
	int? productReferenceId = default;

	public int? ProductReferenceId
	{
		get => productReferenceId;
		set
		{
			if (value != productReferenceId)
			{
				productReferenceId = value;
				NotifyPropertyChanged(nameof(ProductReferenceId));
			}
		}
	}


	string? productCode;
	public string? ProductCode
	{
		get => productCode;
		set
		{
			productCode = value;
			NotifyPropertyChanged();
		}
	}

	string? productName;
	public string? ProductName
	{
		get => productName;
		set
		{
			productName = value;
			NotifyPropertyChanged();
		}
	}
	string? produtImage;
	public string? ProdutImage
	{
		get => produtImage;
		set
		{
			produtImage = value;
			NotifyPropertyChanged();
		}
	}

	///ProductUnitset ref-code-name
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

	///ProductBrand ref-code-name
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

	//Production ref-code-name

	int? productionReferenceId;

	public int? ProductionReferenceId
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

	string? productionName;
	public string? ProductionName
	{
		get => productionName;
		set
		{
			productionName = value;
			NotifyPropertyChanged();
		}
	}

	///Current ref-code-FullName

	//int? currentReferenceId;

	//public int? CurrentReferenceId
	//{
	//	get => currentReferenceId;
	//	set
	//	{
	//		if (value != currentReferenceId)
	//		{
	//			currentReferenceId = value;
	//			NotifyPropertyChanged(nameof(CurrentReferenceId));
	//		}
	//	}
	//}

	//string? currentCode;
	//public string? CurrentCode
	//{
	//	get => currentCode;
	//	set
	//	{
	//		currentCode = value;
	//		NotifyPropertyChanged();
	//	}
	//}

	//public string CurrentName
	//{
	//	get => currentName;
	//	set
	//	{
	//		currentName = value;
	//		NotifyPropertyChanged();
	//	}
	//}


	///ProductionSubUnitset ref-code-name

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

	public string SubUnitsetCode
	{
		get => subUnitsetCode;
		set
		{
			subUnitsetCode = value;
			NotifyPropertyChanged();
		}
	}

	public string Code
	{
		get => code;
		set
		{
			code = value;
			NotifyPropertyChanged();
		}
	}

	public double PlanningQuantity
	{
		get => quantity;
		set
		{
			quantity = value;
			NotifyPropertyChanged();
		}
	}

	public double ActualQuantity
	{
		get => actualQuantity;
		set
		{
			actualQuantity = value;
			NotifyPropertyChanged();
		}
	}


	public double ActualRate => PlanningQuantity > 0 ?(ActualQuantity / PlanningQuantity) * 100 : default;

	public event PropertyChangedEventHandler? PropertyChanged;
	public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}