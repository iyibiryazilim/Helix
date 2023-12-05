using Microsoft.Extensions.Configuration;

namespace Helix.Queries
{
	public class ProductionOrderQuery : BaseQuery
	{
		public ProductionOrderQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetProductionOrderList() =>
			$@"
SELECT
[ReferenceId] = ProductionOrder.LOGICALREF,
[Code] = ProductionOrder.FICHENO,
[FicheType]=ProductionOrder.FICHETYPE,
[PlannedAmount] = ProductionOrder.PLNAMOUNT,
[ActualAmount] = ProductionOrder.ACTAMOUNT,
[Description] =ProductionOrder.GENEXP2,
[OtherConversionFactor] = ProductionOrder.UINFO2,
[Status]=ProductionOrder.STATUS,
[Cancelled] = ProductionOrder.CANCELLED,
[BeginDate] = ProductionOrder.BEGDATE,
[StartDate] = ProductionOrder.STARTDATE,
[StopDate] = ProductionOrder.STOPDATE,
[DueDate] = ProductionOrder.DUEDATE,
[EndDate] = ProductionOrder.ENDDATE,
[ActualBeginDate] = ProductionOrder.ACTBEGDATE,
[ActualDuration] = ProductionOrder.ACTDURATION,
[ActualEndDate] = ProductionOrder.ACTENDDATE,
[PlannedBeginDate] = ProductionOrder.PLNBEGDATE,
[PlannedDuration] = ProductionOrder.PLNDURATION,
[PlannedEndDate] = ProductionOrder.PLNENDDATE,
[ProductionDate] = ProductionOrder.DATE_,
[ProductReferenceId] = Product.LOGICALREF,
[ProductCode] = Product.CODE,
[ProductName] = Product.NAME,
[CurrentReferenceId] = Current_.LOGICALREF,
[CurrentCode] = Current_.CODE,
[CurrentName] = Current_.NAME,
[UnitsetReferenceId] = Unitset.LOGICALREF,
[UnitsetCode] = Unitset.CODE,
[SubUnitsetReferenceId] = SubUnitset.LOGICALREF,
[SubUnitsetCode] = SubUnitset.CODE

FROM LG_00{FirmNumber}_PRODORD AS ProductionOrder
LEFT JOIN LG_00{FirmNumber}_ITEMS AS Product ON ProductionOrder.ITEMREF = Product.LOGICALREF
LEFT JOIN LG_00{FirmNumber}_CLCARD AS Current_ ON ProductionOrder.CLIENTREF = Current_.LOGICALREF
LEFT JOIN LG_00{FirmNumber}_UNITSETF As Unitset ON Product.UNITSETREF = Unitset.LOGICALREF
LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SubUnitset ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1";

		public string GetProductionOrderById(int id) =>
	$@"
SELECT
[ReferenceId] = ProductionOrder.LOGICALREF,
[Code] = ProductionOrder.FICHENO,
[FicheType]=ProductionOrder.FICHETYPE,
[PlannedAmount] = ProductionOrder.PLNAMOUNT,
[ActualAmount] = ProductionOrder.ACTAMOUNT,
[Description] =ProductionOrder.GENEXP2,
[OtherConversionFactor] = ProductionOrder.UINFO2,
[Status]=ProductionOrder.STATUS,
[Cancelled] = ProductionOrder.CANCELLED,
[BeginDate] = ProductionOrder.BEGDATE,
[StartDate] = ProductionOrder.STARTDATE,
[StopDate] = ProductionOrder.STOPDATE,
[DueDate] = ProductionOrder.DUEDATE,
[EndDate] = ProductionOrder.ENDDATE,
[ActualBeginDate] = ProductionOrder.ACTBEGDATE,
[ActualDuration] = ProductionOrder.ACTDURATION,
[ActualEndDate] = ProductionOrder.ACTENDDATE,
[PlannedBeginDate] = ProductionOrder.PLNBEGDATE,
[PlannedDuration] = ProductionOrder.PLNDURATION,
[PlannedEndDate] = ProductionOrder.PLNENDDATE,
[ProductionDate] = ProductionOrder.DATE_,
[ProductReferenceId] = Product.LOGICALREF,
[ProductCode] = Product.CODE,
[ProductName] = Product.NAME,
[CurrentReferenceId] = Current_.LOGICALREF,
[CurrentCode] = Current_.CODE,
[CurrentName] = Current_.NAME,
[UnitsetReferenceId] = Unitset.LOGICALREF,
[UnitsetCode] = Unitset.CODE,
[SubUnitsetReferenceId] = SubUnitset.LOGICALREF,
[SubUnitsetCode] = SubUnitset.CODE

FROM LG_00{FirmNumber}_PRODORD AS ProductionOrder
LEFT JOIN LG_00{FirmNumber}_ITEMS AS Product ON ProductionOrder.ITEMREF = Product.LOGICALREF
LEFT JOIN LG_00{FirmNumber}_CLCARD AS Current_ ON ProductionOrder.CLIENTREF = Current_.LOGICALREF
LEFT JOIN LG_00{FirmNumber}_UNITSETF As Unitset ON Product.UNITSETREF = Unitset.LOGICALREF
LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SubUnitset ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
WHERE ProductionOrder.LOGICALREF = {id}";

		public string GetProductionOrderByCode(string code) =>
$@"
SELECT
[ReferenceId] = ProductionOrder.LOGICALREF,
[Code] = ProductionOrder.FICHENO,
[FicheType]=ProductionOrder.FICHETYPE,
[PlannedAmount] = ProductionOrder.PLNAMOUNT,
[ActualAmount] = ProductionOrder.ACTAMOUNT,
[Description] =ProductionOrder.GENEXP2,
[OtherConversionFactor] = ProductionOrder.UINFO2,
[Status]=ProductionOrder.STATUS,
[Cancelled] = ProductionOrder.CANCELLED,
[BeginDate] = ProductionOrder.BEGDATE,
[StartDate] = ProductionOrder.STARTDATE,
[StopDate] = ProductionOrder.STOPDATE,
[DueDate] = ProductionOrder.DUEDATE,
[EndDate] = ProductionOrder.ENDDATE,
[ActualBeginDate] = ProductionOrder.ACTBEGDATE,
[ActualDuration] = ProductionOrder.ACTDURATION,
[ActualEndDate] = ProductionOrder.ACTENDDATE,
[PlannedBeginDate] = ProductionOrder.PLNBEGDATE,
[PlannedDuration] = ProductionOrder.PLNDURATION,
[PlannedEndDate] = ProductionOrder.PLNENDDATE,
[ProductionDate] = ProductionOrder.DATE_,
[ProductReferenceId] = Product.LOGICALREF,
[ProductCode] = Product.CODE,
[ProductName] = Product.NAME,
[CurrentReferenceId] = Current_.LOGICALREF,
[CurrentCode] = Current_.CODE,
[CurrentName] = Current_.NAME,
[UnitsetReferenceId] = Unitset.LOGICALREF,
[UnitsetCode] = Unitset.CODE,
[SubUnitsetReferenceId] = SubUnitset.LOGICALREF,
[SubUnitsetCode] = SubUnitset.CODE

FROM LG_00{FirmNumber}_PRODORD AS ProductionOrder
LEFT JOIN LG_00{FirmNumber}_ITEMS AS Product ON ProductionOrder.ITEMREF = Product.LOGICALREF
LEFT JOIN LG_00{FirmNumber}_CLCARD AS Current_ ON ProductionOrder.CLIENTREF = Current_.LOGICALREF
LEFT JOIN LG_00{FirmNumber}_UNITSETF As Unitset ON Product.UNITSETREF = Unitset.LOGICALREF
LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SubUnitset ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
WHERE ProductionOrder.CODE = {code}";

	}
}
