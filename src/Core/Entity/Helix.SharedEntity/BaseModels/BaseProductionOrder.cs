using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.SharedEntity.BaseModels
{
    public abstract class BaseProductionOrder : INotifyPropertyChanged
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

        DateTime? productionDate;
        public DateTime? ProductionDate
        {
            get => productionDate;
            set
            {
                productionDate = value;
                NotifyPropertyChanged();
            }
        }

        DateTime? beginDate;
        public DateTime? BeginDate
        {
            get => beginDate;
            set
            {
                beginDate = value;
                NotifyPropertyChanged();
            }
        }


        DateTime? endDate;
        public DateTime? EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                NotifyPropertyChanged();
            }
        }

        DateTime? dueDate;
        public DateTime? DueDate
        {
            get => dueDate;
            set
            {
                dueDate = value;
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

        DateTime? plannedBeginDate;
        public DateTime? PlannedBeginDate
        {
            get => plannedBeginDate;
            set
            {

                plannedBeginDate = value;
                NotifyPropertyChanged();
            }
        }

        DateTime? plannedEndDate;
        public DateTime? PlannedEndDate
        {
            get => plannedEndDate;
            set
            {

                plannedEndDate = value;
                NotifyPropertyChanged();
            }
        }
        double? plannedDuration;
        public double? PlannedDuration
        {
            get => plannedDuration;
            set
            {

                plannedDuration = value;
                NotifyPropertyChanged();
            }
        }

        DateTime? actualBeginDate;
        public DateTime? ActualbeginDate
        {
            get => actualBeginDate;
            set
            {

                actualBeginDate = value;
                NotifyPropertyChanged();
            }
        }

        DateTime? actualEndDate;
        public DateTime? ActualEndDate
        {
            get => actualEndDate;
            set
            {

                actualEndDate = value;
                NotifyPropertyChanged();
            }
        }

        double? actualDuration;
        public double? ActualDuration
        {
            get => actualDuration;
            set
            {

                actualDuration = value;
                NotifyPropertyChanged();
            }
        }

        short? ficheType;
        public short? FicheType
        {
            get => ficheType;
            set
            {
                ficheType = value;
                NotifyPropertyChanged();
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

        //product ref-code-name
        int? productReferenceId;

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

        ///Current ref-code-FullName

        int? currentReferenceId;

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

        string? currentCode;
        public string? CurrentCode
        {
            get => currentCode;
            set
            {
                currentCode = value;
                NotifyPropertyChanged();
            }
        }

        string? currentName;
        public string? CurrentName
        {
            get => currentName;
            set
            {
                currentName = value;
                NotifyPropertyChanged();
            }
        }

        ///SubUnitset ref-code-name

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

        ///Unitset ref-code-name

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


        short? status;
        public short? Status
        {
            get => status;
            set
            {
                status = value;
                NotifyPropertyChanged();
            }
        }

        string? statusName;
        public string? StatusName
        {
            get => statusName;
            set
            {
                statusName = value;
                NotifyPropertyChanged();
            }
        }

        short? cancelled;
        public short? Cancelled
        {
            get => cancelled;
            set
            {
                cancelled = value;
                NotifyPropertyChanged();
            }
        }


        

        double plannedAmount;
        public double PlannedAmount
        {
            get => plannedAmount;
            set
            {
                plannedAmount = value;
                NotifyPropertyChanged();
            }
        }
        

        double actualAmount;
        public double ActualAmount
        {
            get => actualAmount;
            set
            {
                actualAmount = value;
                NotifyPropertyChanged();
            }
        }

        double? conversionFactor;
        public double? ConversionFactor
        {
            get => conversionFactor;
            set
            {
                conversionFactor = value;
                NotifyPropertyChanged();
            }
        }

        double? otherConversionFactor;
        public double? OtherConversionFactor
        {
            get => otherConversionFactor;
            set
            {
                otherConversionFactor = value;
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
        double? stackQuantity;
        public double? StackQuantity
        {
            get => stackQuantity;
            set
            {
                stackQuantity = value;
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


        /// <summary>
        /// /
        /// </summary>
        /// 
        double actualRate = 0;
        public double ActualRate
        {
            get
            {
                if (actualAmount == 0) return actualRate; 

                return actualRate = (actualAmount / plannedAmount) ;
            }
            set
            {
                actualRate = value;
                NotifyPropertyChanged();
            }
        }




        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}