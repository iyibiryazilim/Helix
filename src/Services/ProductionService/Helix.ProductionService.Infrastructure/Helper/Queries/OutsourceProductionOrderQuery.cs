using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductionService.Infrastructure.Helper.Queries
{
    public class OutsourceProductionOrderQuery : BaseQuery
    {
        public OutsourceProductionOrderQuery(IConfiguration configuration) : base(configuration)
        {
        }

        public string GetOutsourceProductionOrderList() =>
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
[SubUnitsetCode] = SubUnitset.CODE,
[SupplierReferenceId]=Current_.LOGICALREF,
[SupplierCode]=Current_.CODE,
[SupplierName]=Current_.DEFINITION_

FROM LG_001_PRODORD AS ProductionOrder
LEFT JOIN LG_001_ITEMS AS Product ON ProductionOrder.ITEMREF = Product.LOGICALREF
LEFT JOIN LG_001_CLCARD AS Current_ ON ProductionOrder.CLIENTREF = Current_.LOGICALREF
LEFT JOIN LG_001_UNITSETF As Unitset ON Product.UNITSETREF = Unitset.LOGICALREF
LEFT JOIN LG_001_UNITSETL AS SubUnitset ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1  WHERE ProductionOrder.FICHETYPE=2";

        public string GetOutsourceProductionOrderById(int id) =>
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
[SubUnitsetCode] = SubUnitset.CODE,
[SupplierReferenceId]=Current_.LOGICALREF,
[SupplierCode]=Current_.CODE,
[SupplierName]=Current_.DEFINITION_

FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_PRODORD AS ProductionOrder
LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS Product ON ProductionOrder.ITEMREF = Product.LOGICALREF
LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS Current_ ON ProductionOrder.CLIENTREF = Current_.LOGICALREF
LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF As Unitset ON Product.UNITSETREF = Unitset.LOGICALREF
LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SubUnitset ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
WHERE ProductionOrder.LOGICALREF = {id} AND ProductionOrder.FICHETYPE=2";

        public string GetOutsourceOrderByCode(string code) =>
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
[SubUnitsetCode] = SubUnitset.CODE,
[SupplierReferenceId]=Current_.LOGICALREF,
[SupplierCode]=Current_.CODE,
[SupplierName]=Current_.NAME


FROM LG_001_PRODORD AS ProductionOrder
LEFT JOIN LG_001_ITEMS AS Product ON ProductionOrder.ITEMREF = Product.LOGICALREF
LEFT JOIN LG_001_CLCARD AS Current_ ON ProductionOrder.CLIENTREF = Current_.LOGICALREF
LEFT JOIN LG_001_UNITSETF As Unitset ON Product.UNITSETREF = Unitset.LOGICALREF
LEFT JOIN LG_001_UNITSETL AS SubUnitset ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
WHERE ProductionOrder.FICHENO = '0000000000001012' AND ProductionOrder.FICHETYPE=2";


    }
}
