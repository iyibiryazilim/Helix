using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.ProductionService.Infrastructure.Helper.Queries
{
    public class OutsourceWorkOrderQuery : BaseQuery
    {
        public OutsourceWorkOrderQuery(IConfiguration configuration) : base(configuration)
        {
        }

        public string GetOutsourceProductionOrderList() =>
          @$"SELECT
   [ReferenceId] = WorkOrder.LOGICALREF,
    [Status] = WorkOrder.LINESTATUS,
    [StatusName] = 
        CASE WorkOrder.LINESTATUS
            WHEN 0 THEN 'Başlamadı'
            WHEN 1 THEN 'Devam Ediyor'
            WHEN 2 THEN 'Durduruldu'
            WHEN 3 THEN 'Tamamlandı'
            WHEN 4 THEN 'Kapandı'
            ELSE 'Diğer'
        END,
		[Code] = WorkOrder.LINENO_,
	[OperationBeginDate] = WorkOrder.OPBEGDATE,
	[OperationDueDate] = WorkOrder.OPDUEDATE,
	[OperationActualBeginDate] = WorkOrder.ACTBEGDATE,
	[OperationActualDueDate] = WorkOrder.ACTDUEDATE,
	[OperationBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPBEGTIME),
	[OperationDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPDUETIME),
	[OperationActualBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTBEGTIME),
	[OperationActualDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTDUETIME),
	[OperationReferenceId] = WorkOrder.OPERATIONREF,
	[OperationCode] = Operation.CODE,
	[OperationName] = Operation.NAME,
	[WorkstationReferenceId] = WorkOrder.WSREF,
	[WorkstationCode] = Workstation.CODE,
	[WorkstationName] = Workstation.NAME,
	[ProductReferenceId] = WorkOrder.ITEMREF,
	[ProductCode] = Product.CODE,
	[ProductName] = Product.NAME,
	[UnitsetReferenceId] = Unitset.LOGICALREF,
	[UnitsetCode] = Unitset.CODE,
	[BrandReferenceId] = Brand.LOGICALREF,
	[BrandCode] = Brand.CODE,
	[BrandName] = Brand.DESCR,
	[ProductionReferenceId] = WorkOrder.PRODORDREF,
	[ProductionCode] = ProductionOrder.FICHENO,
	[SubUnitsetReferenceId] = SubUnitset.LOGICALREF,
	[SubUnitsetCode] = SubUnitset.CODE ,
    [SupplierReferenceId]=Supplier.LOGICALREF,
	[SupplierCode]=Supplier.CODE,
	[SupplierName]=Supplier.DEFINITION_,
	[PlanningQuantity] = ISNULL(Poline.AMOUNT,0),
	[ActualQuantity] = ISNULL((SELECT SUM(STLINE.AMOUNT) FROM LG_003_01_STLINE AS STLINE WITH(NOLOCK) WHERE STLINE.SOURCEPOLNREF = WorkOrder.LOGICALREF AND STLINE.STOCKREF = Product.LOGICALREF AND STLINE.TRCODE = 13 ),0)
	
	FROM
    LG_001_DISPLINE AS WorkOrder WITH(NOLOCK) 
	LEFT JOIN LG_001_ITEMS AS Product WITH(NOLOCK) ON WorkOrder.ITEMREF = Product.LOGICALREF
	LEFT JOIN LG_001_OPERTION As Operation WITH(NOLOCK) ON WorkOrder.OPERATIONREF = Operation.LOGICALREF
	LEFT JOIN LG_001_UNITSETF As Unitset WITH(NOLOCK) ON Product.UNITSETREF = Unitset.LOGICALREF
	LEFT JOIN LG_001_UNITSETL AS SubUnitset WITH(NOLOCK) ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
	LEFT JOIN LG_001_WORKSTAT AS Workstation WITH(NOLOCK) ON WorkOrder.WSREF = Workstation.LOGICALREF
	LEFT JOIN LG_001_PRODORD AS ProductionOrder WITH(NOLOCK) ON WorkOrder.PRODORDREF = ProductionOrder.LOGICALREF
	LEFT JOIN LG_001_CLCARD AS Supplier WITH(NOLOCK) ON ProductionOrder.CLIENTREF = Supplier.LOGICALREF
	LEFT JOIN LG_001_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4 WHERE ProductionOrder.FICHETYPE=2
";
        public string GetOutsourceProductionOrderByStatus(int[] status)
        {
            string[] statusStrings = Array.ConvertAll(status, x => x.ToString());

            // Join the string array using a separator (e.g., comma)
            string statusString = string.Join(",", statusStrings);

            var query = @$"SELECT
   [ReferenceId] = WorkOrder.LOGICALREF,
    [Status] = WorkOrder.LINESTATUS,
    [StatusName] = 
        CASE WorkOrder.LINESTATUS
            WHEN 0 THEN 'Başlamadı'
            WHEN 1 THEN 'Devam Ediyor'
            WHEN 2 THEN 'Durduruldu'
            WHEN 3 THEN 'Tamamlandı'
            WHEN 4 THEN 'Kapandı'
            ELSE 'Diğer'
        END,
		[Code] = WorkOrder.LINENO_,
	[OperationBeginDate] = WorkOrder.OPBEGDATE,
	[OperationDueDate] = WorkOrder.OPDUEDATE,
	[OperationActualBeginDate] = WorkOrder.ACTBEGDATE,
	[OperationActualDueDate] = WorkOrder.ACTDUEDATE,
	[OperationBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPBEGTIME),
	[OperationDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPDUETIME),
	[OperationActualBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTBEGTIME),
	[OperationActualDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTDUETIME),
	[OperationReferenceId] = WorkOrder.OPERATIONREF,
	[OperationCode] = Operation.CODE,
	[OperationName] = Operation.NAME,
	[WorkstationReferenceId] = WorkOrder.WSREF,
	[WorkstationCode] = Workstation.CODE,
	[WorkstationName] = Workstation.NAME,
	[ProductReferenceId] = WorkOrder.ITEMREF,
	[ProductCode] = Product.CODE,
	[ProductName] = Product.NAME,
	[UnitsetReferenceId] = Unitset.LOGICALREF,
	[UnitsetCode] = Unitset.CODE,
	[BrandReferenceId] = Brand.LOGICALREF,
	[BrandCode] = Brand.CODE,
	[BrandName] = Brand.DESCR,
	[ProductionReferenceId] = WorkOrder.PRODORDREF,
	[ProductionCode] = ProductionOrder.FICHENO,
	[SubUnitsetReferenceId] = SubUnitset.LOGICALREF,
	[SubUnitsetCode] = SubUnitset.CODE ,
    [SupplierReferenceId]=Supplier.LOGICALREF,
	[SupplierCode]=Supplier.CODE,
	[SupplierName]=Supplier.DEFINITION_,
	[PlanningQuantity] = ISNULL(Poline.AMOUNT,0),
	[ActualQuantity] = ISNULL((SELECT SUM(STLINE.AMOUNT) FROM LG_003_01_STLINE AS STLINE WITH(NOLOCK) WHERE STLINE.SOURCEPOLNREF = WorkOrder.LOGICALREF AND STLINE.STOCKREF = Product.LOGICALREF AND STLINE.TRCODE = 13 ),0)
	
	FROM
    LG_001_DISPLINE AS WorkOrder WITH(NOLOCK) 
	LEFT JOIN LG_001_ITEMS AS Product WITH(NOLOCK) ON WorkOrder.ITEMREF = Product.LOGICALREF
	LEFT JOIN LG_001_OPERTION As Operation WITH(NOLOCK) ON WorkOrder.OPERATIONREF = Operation.LOGICALREF
	LEFT JOIN LG_001_UNITSETF As Unitset WITH(NOLOCK) ON Product.UNITSETREF = Unitset.LOGICALREF
	LEFT JOIN LG_001_UNITSETL AS SubUnitset WITH(NOLOCK) ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
	LEFT JOIN LG_001_WORKSTAT AS Workstation WITH(NOLOCK) ON WorkOrder.WSREF = Workstation.LOGICALREF
	LEFT JOIN LG_001_PRODORD AS ProductionOrder WITH(NOLOCK) ON WorkOrder.PRODORDREF = ProductionOrder.LOGICALREF
    LEFT JOIN LG_001_CLCARD AS Supplier WITH(NOLOCK) ON ProductionOrder.CLIENTREF = Supplier.LOGICALREF
	LEFT JOIN LG_001_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4 WHERE ProductionOrder.FICHETYPE=1
	AND WorkOrder.LINESTATUS IN ({statusString})";
            return query;
        }
        public string GetOutsourceProductionOrderById(int id)
        {
            string query = @$"SELECT
   [ReferenceId] = WorkOrder.LOGICALREF,
    [Status] = WorkOrder.LINESTATUS,
    [StatusName] = 
        CASE WorkOrder.LINESTATUS
            WHEN 0 THEN 'Başlamadı'
            WHEN 1 THEN 'Devam Ediyor'
            WHEN 2 THEN 'Durduruldu'
            WHEN 3 THEN 'Tamamlandı'
            WHEN 4 THEN 'Kapandı'
            ELSE 'Diğer'
        END,
		[Code] = WorkOrder.LINENO_,
	[OperationBeginDate] = WorkOrder.OPBEGDATE,
	[OperationDueDate] = WorkOrder.OPDUEDATE,
	[OperationActualBeginDate] = WorkOrder.ACTBEGDATE,
	[OperationActualDueDate] = WorkOrder.ACTDUEDATE,
	[OperationBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPBEGTIME),
	[OperationDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPDUETIME),
	[OperationActualBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTBEGTIME),
	[OperationActualDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTDUETIME),
	[OperationReferenceId] = WorkOrder.OPERATIONREF,
	[OperationCode] = Operation.CODE,
	[OperationName] = Operation.NAME,
	[WorkstationReferenceId] = WorkOrder.WSREF,
	[WorkstationCode] = Workstation.CODE,
	[WorkstationName] = Workstation.NAME,
	[ProductReferenceId] = WorkOrder.ITEMREF,
	[ProductCode] = Product.CODE,
	[ProductName] = Product.NAME,
	[UnitsetReferenceId] = Unitset.LOGICALREF,
	[UnitsetCode] = Unitset.CODE,
	[BrandReferenceId] = Brand.LOGICALREF,
	[BrandCode] = Brand.CODE,
	[BrandName] = Brand.DESCR,
	[ProductionReferenceId] = WorkOrder.PRODORDREF,
	[ProductionCode] = ProductionOrder.FICHENO,
	[SubUnitsetReferenceId] = SubUnitset.LOGICALREF,
	[SubUnitsetCode] = SubUnitset.CODE ,
    [SupplierReferenceId]=Supplier.LOGICALREF,
	[SupplierCode]=Supplier.CODE,
	[SupplierName]=Supplier.DEFINITION_,
	[PlanningQuantity] = ISNULL(Poline.AMOUNT,0),
	[ActualQuantity] = ISNULL((SELECT SUM(STLINE.AMOUNT) FROM LG_003_01_STLINE AS STLINE WITH(NOLOCK) WHERE STLINE.SOURCEPOLNREF = WorkOrder.LOGICALREF AND STLINE.STOCKREF = Product.LOGICALREF AND STLINE.TRCODE = 13 ),0)
	
	FROM
    LG_00{FirmNumber}_DISPLINE AS WorkOrder WITH(NOLOCK) 
	LEFT JOIN LG_00{FirmNumber}_ITEMS AS Product WITH(NOLOCK) ON WorkOrder.ITEMREF = Product.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_OPERTION As Operation WITH(NOLOCK) ON WorkOrder.OPERATIONREF = Operation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETF As Unitset WITH(NOLOCK) ON Product.UNITSETREF = Unitset.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SubUnitset WITH(NOLOCK) ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
	LEFT JOIN LG_00{FirmNumber}_WORKSTAT AS Workstation WITH(NOLOCK) ON WorkOrder.WSREF = Workstation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_PRODORD AS ProductionOrder WITH(NOLOCK) ON WorkOrder.PRODORDREF = ProductionOrder.LOGICALREF
    LEFT JOIN LG_00{FirmNumber}_CLCARD AS Supplier WITH(NOLOCK) ON ProductionOrder.CLIENTREF = Supplier.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4 WHERE ProductionOrder.FICHETYPE=1
	AND WorkOrder.LOGICALREF = {id}";

            return query;
        }

        #region Workstation Filter
        public string GetOutsourceByWorkstationId(int id) =>
    @$"SELECT
   [ReferenceId] = WorkOrder.LOGICALREF,
    [Status] = WorkOrder.LINESTATUS,
    [StatusName] = 
        CASE WorkOrder.LINESTATUS
            WHEN 0 THEN 'Başlamadı'
            WHEN 1 THEN 'Devam Ediyor'
            WHEN 2 THEN 'Durduruldu'
            WHEN 3 THEN 'Tamamlandı'
            WHEN 4 THEN 'Kapandı'
            ELSE 'Diğer'
        END,
		[Code] = WorkOrder.LINENO_,
	[OperationBeginDate] = WorkOrder.OPBEGDATE,
	[OperationDueDate] = WorkOrder.OPDUEDATE,
	[OperationActualBeginDate] = WorkOrder.ACTBEGDATE,
	[OperationActualDueDate] = WorkOrder.ACTDUEDATE,
	[OperationBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPBEGTIME),
	[OperationDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPDUETIME),
	[OperationActualBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTBEGTIME),
	[OperationActualDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTDUETIME),
	[OperationReferenceId] = WorkOrder.OPERATIONREF,
	[OperationCode] = Operation.CODE,
	[OperationName] = Operation.NAME,
	[WorkstationReferenceId] = WorkOrder.WSREF,
	[WorkstationCode] = Workstation.CODE,
	[WorkstationName] = Workstation.NAME,
	[ProductReferenceId] = WorkOrder.ITEMREF,
	[ProductCode] = Product.CODE,
	[ProductName] = Product.NAME,
	[UnitsetReferenceId] = Unitset.LOGICALREF,
	[UnitsetCode] = Unitset.CODE,
	[BrandReferenceId] = Brand.LOGICALREF,
	[BrandCode] = Brand.CODE,
	[BrandName] = Brand.DESCR,
	[ProductionReferenceId] = WorkOrder.PRODORDREF,
	[ProductionCode] = ProductionOrder.FICHENO,
	[SubUnitsetReferenceId] = SubUnitset.LOGICALREF,
	[SubUnitsetCode] = SubUnitset.CODE ,
    [SupplierReferenceId]=Supplier.LOGICALREF,
	[SupplierCode]=Supplier.CODE,
	[SupplierName]=Supplier.DEFINITION_,
	[PlanningQuantity] = ISNULL(Poline.AMOUNT,0),
	[ActualQuantity] = ISNULL((SELECT SUM(STLINE.AMOUNT) FROM LG_003_01_STLINE AS STLINE WITH(NOLOCK) WHERE STLINE.SOURCEPOLNREF = WorkOrder.LOGICALREF AND STLINE.STOCKREF = Product.LOGICALREF AND STLINE.TRCODE = 13 ),0)
	
	FROM
    LG_00{FirmNumber}_DISPLINE AS WorkOrder WITH(NOLOCK) 
	LEFT JOIN LG_00{FirmNumber}_ITEMS AS Product WITH(NOLOCK) ON WorkOrder.ITEMREF = Product.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_OPERTION As Operation WITH(NOLOCK) ON WorkOrder.OPERATIONREF = Operation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETF As Unitset WITH(NOLOCK) ON Product.UNITSETREF = Unitset.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SubUnitset WITH(NOLOCK) ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
	LEFT JOIN LG_00{FirmNumber}_WORKSTAT AS Workstation WITH(NOLOCK) ON WorkOrder.WSREF = Workstation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_PRODORD AS ProductionOrder WITH(NOLOCK) ON WorkOrder.PRODORDREF = ProductionOrder.LOGICALREF
    LEFT JOIN LG_001_CLCARD AS Supplier WITH(NOLOCK) ON ProductionOrder.CLIENTREF = Supplier.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4 WHERE ProductionOrder.FICHETYPE=1
	AND Workstation.LOGICALREF = {id}";
        public string GetOutsourceByWorkstationCode(string code) =>
    @$"SELECT
   [ReferenceId] = WorkOrder.LOGICALREF,
    [Status] = WorkOrder.LINESTATUS,
    [StatusName] = 
        CASE WorkOrder.LINESTATUS
            WHEN 0 THEN 'Başlamadı'
            WHEN 1 THEN 'Devam Ediyor'
            WHEN 2 THEN 'Durduruldu'
            WHEN 3 THEN 'Tamamlandı'
            WHEN 4 THEN 'Kapandı'
            ELSE 'Diğer'
        END,
		[Code] = WorkOrder.LINENO_,
	[OperationBeginDate] = WorkOrder.OPBEGDATE,
	[OperationDueDate] = WorkOrder.OPDUEDATE,
	[OperationActualBeginDate] = WorkOrder.ACTBEGDATE,
	[OperationActualDueDate] = WorkOrder.ACTDUEDATE,
	[OperationBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPBEGTIME),
	[OperationDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPDUETIME),
	[OperationActualBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTBEGTIME),
	[OperationActualDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTDUETIME),
	[OperationReferenceId] = WorkOrder.OPERATIONREF,
	[OperationCode] = Operation.CODE,
	[OperationName] = Operation.NAME,
	[WorkstationReferenceId] = WorkOrder.WSREF,
	[WorkstationCode] = Workstation.CODE,
	[WorkstationName] = Workstation.NAME,
	[ProductReferenceId] = WorkOrder.ITEMREF,
	[ProductCode] = Product.CODE,
	[ProductName] = Product.NAME,
	[UnitsetReferenceId] = Unitset.LOGICALREF,
	[UnitsetCode] = Unitset.CODE,
	[BrandReferenceId] = Brand.LOGICALREF,
	[BrandCode] = Brand.CODE,
	[BrandName] = Brand.DESCR,
	[ProductionReferenceId] = WorkOrder.PRODORDREF,
	[ProductionCode] = ProductionOrder.FICHENO,
	[SubUnitsetReferenceId] = SubUnitset.LOGICALREF,
	[SubUnitsetCode] = SubUnitset.CODE ,
    [SupplierReferenceId]=Supplier.LOGICALREF,
	[SupplierCode]=Supplier.CODE,
	[SupplierName]=Supplier.DEFINITION_,
	[PlanningQuantity] = ISNULL(Poline.AMOUNT,0),
	[ActualQuantity] = ISNULL((SELECT SUM(STLINE.AMOUNT) FROM LG_003_01_STLINE AS STLINE WITH(NOLOCK) WHERE STLINE.SOURCEPOLNREF = WorkOrder.LOGICALREF AND STLINE.STOCKREF = Product.LOGICALREF AND STLINE.TRCODE = 13 ),0)
	
	FROM
    LG_00{FirmNumber}_DISPLINE AS WorkOrder WITH(NOLOCK) 
	LEFT JOIN LG_00{FirmNumber}_ITEMS AS Product WITH(NOLOCK) ON WorkOrder.ITEMREF = Product.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_OPERTION As Operation WITH(NOLOCK) ON WorkOrder.OPERATIONREF = Operation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETF As Unitset WITH(NOLOCK) ON Product.UNITSETREF = Unitset.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SubUnitset WITH(NOLOCK) ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
	LEFT JOIN LG_00{FirmNumber}_WORKSTAT AS Workstation WITH(NOLOCK) ON WorkOrder.WSREF = Workstation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_PRODORD AS ProductionOrder WITH(NOLOCK) ON WorkOrder.PRODORDREF = ProductionOrder.LOGICALREF
    LEFT JOIN LG_001_CLCARD AS Supplier WITH(NOLOCK) ON ProductionOrder.CLIENTREF = Supplier.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4 WHERE ProductionOrder.FICHETYPE=1
	AND Workstation.CODE = {code}";
        #endregion

        #region Product Filter

        public string GetOutsourceByProductId(int id) =>
    @$"SELECT
   [ReferenceId] = WorkOrder.LOGICALREF,
    [Status] = WorkOrder.LINESTATUS,
    [StatusName] = 
        CASE WorkOrder.LINESTATUS
            WHEN 0 THEN 'Başlamadı'
            WHEN 1 THEN 'Devam Ediyor'
            WHEN 2 THEN 'Durduruldu'
            WHEN 3 THEN 'Tamamlandı'
            WHEN 4 THEN 'Kapandı'
            ELSE 'Diğer'
        END,
		[Code] = WorkOrder.LINENO_,
	[OperationBeginDate] = WorkOrder.OPBEGDATE,
	[OperationDueDate] = WorkOrder.OPDUEDATE,
	[OperationActualBeginDate] = WorkOrder.ACTBEGDATE,
	[OperationActualDueDate] = WorkOrder.ACTDUEDATE,
	[OperationBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPBEGTIME),
	[OperationDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPDUETIME),
	[OperationActualBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTBEGTIME),
	[OperationActualDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTDUETIME),
	[OperationReferenceId] = WorkOrder.OPERATIONREF,
	[OperationCode] = Operation.CODE,
	[OperationName] = Operation.NAME,
	[WorkstationReferenceId] = WorkOrder.WSREF,
	[WorkstationCode] = Workstation.CODE,
	[WorkstationName] = Workstation.NAME,
	[ProductReferenceId] = WorkOrder.ITEMREF,
	[ProductCode] = Product.CODE,
	[ProductName] = Product.NAME,
	[UnitsetReferenceId] = Unitset.LOGICALREF,
	[UnitsetCode] = Unitset.CODE,
	[BrandReferenceId] = Brand.LOGICALREF,
	[BrandCode] = Brand.CODE,
	[BrandName] = Brand.DESCR,
	[ProductionReferenceId] = WorkOrder.PRODORDREF,
	[ProductionCode] = ProductionOrder.FICHENO,
	[SubUnitsetReferenceId] = SubUnitset.LOGICALREF,
	[SubUnitsetCode] = SubUnitset.CODE ,
    [SupplierReferenceId]=Supplier.LOGICALREF,
	[SupplierCode]=Supplier.CODE,
	[SupplierName]=Supplier.DEFINITION_,
	[PlanningQuantity] = ISNULL(Poline.AMOUNT,0),
	[ActualQuantity] = ISNULL((SELECT SUM(STLINE.AMOUNT) FROM LG_003_01_STLINE AS STLINE WITH(NOLOCK) WHERE STLINE.SOURCEPOLNREF = WorkOrder.LOGICALREF AND STLINE.STOCKREF = Product.LOGICALREF AND STLINE.TRCODE = 13 ),0)
	
	FROM
    LG_00{FirmNumber}_DISPLINE AS WorkOrder WITH(NOLOCK) 
	LEFT JOIN LG_00{FirmNumber}_ITEMS AS Product WITH(NOLOCK) ON WorkOrder.ITEMREF = Product.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_OPERTION As Operation WITH(NOLOCK) ON WorkOrder.OPERATIONREF = Operation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETF As Unitset WITH(NOLOCK) ON Product.UNITSETREF = Unitset.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SubUnitset WITH(NOLOCK) ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
	LEFT JOIN LG_00{FirmNumber}_WORKSTAT AS Workstation WITH(NOLOCK) ON WorkOrder.WSREF = Workstation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_PRODORD AS ProductionOrder WITH(NOLOCK) ON WorkOrder.PRODORDREF = ProductionOrder.LOGICALREF
    LEFT JOIN LG_001_CLCARD AS Supplier WITH(NOLOCK) ON ProductionOrder.CLIENTREF = Supplier.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4 WHERE ProductionOrder.FICHETYPE=1
	AND Product.LOGICALREF = {id}";

        #endregion

        #region ProductionOrder Filter
        public string GetOutsourceByProductionOrderId(int id) =>
    @$"SELECT
   [ReferenceId] = WorkOrder.LOGICALREF,
    [Status] = WorkOrder.LINESTATUS,
    [StatusName] = 
        CASE WorkOrder.LINESTATUS
            WHEN 0 THEN 'Başlamadı'
            WHEN 1 THEN 'Devam Ediyor'
            WHEN 2 THEN 'Durduruldu'
            WHEN 3 THEN 'Tamamlandı'
            WHEN 4 THEN 'Kapandı'
            ELSE 'Diğer'
        END,
		[Code] = WorkOrder.LINENO_,
	[OperationBeginDate] = WorkOrder.OPBEGDATE,
	[OperationDueDate] = WorkOrder.OPDUEDATE,
	[OperationActualBeginDate] = WorkOrder.ACTBEGDATE,
	[OperationActualDueDate] = WorkOrder.ACTDUEDATE,
	[OperationBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPBEGTIME),
	[OperationDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPDUETIME),
	[OperationActualBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTBEGTIME),
	[OperationActualDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTDUETIME),
	[OperationReferenceId] = WorkOrder.OPERATIONREF,
	[OperationCode] = Operation.CODE,
	[OperationName] = Operation.NAME,
	[WorkstationReferenceId] = WorkOrder.WSREF,
	[WorkstationCode] = Workstation.CODE,
	[WorkstationName] = Workstation.NAME,
	[ProductReferenceId] = WorkOrder.ITEMREF,
	[ProductCode] = Product.CODE,
	[ProductName] = Product.NAME,
	[UnitsetReferenceId] = Unitset.LOGICALREF,
	[UnitsetCode] = Unitset.CODE,
	[BrandReferenceId] = Brand.LOGICALREF,
	[BrandCode] = Brand.CODE,
	[BrandName] = Brand.DESCR,
	[ProductionReferenceId] = WorkOrder.PRODORDREF,
	[ProductionCode] = ProductionOrder.FICHENO,
	[SubUnitsetReferenceId] = SubUnitset.LOGICALREF,
	[SubUnitsetCode] = SubUnitset.CODE ,
    [SupplierReferenceId]=Supplier.LOGICALREF,
	[SupplierCode]=Supplier.CODE,
	[SupplierName]=Supplier.DEFINITION_,
	[PlanningQuantity] = ISNULL(Poline.AMOUNT,0),
	[ActualQuantity] = ISNULL((SELECT SUM(STLINE.AMOUNT) FROM LG_003_01_STLINE AS STLINE WITH(NOLOCK) WHERE STLINE.SOURCEPOLNREF = WorkOrder.LOGICALREF AND STLINE.STOCKREF = Product.LOGICALREF AND STLINE.TRCODE = 13 ),0)
	
	FROM
    LG_00{FirmNumber}_DISPLINE AS WorkOrder WITH(NOLOCK) 
	LEFT JOIN LG_00{FirmNumber}_ITEMS AS Product WITH(NOLOCK) ON WorkOrder.ITEMREF = Product.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_OPERTION As Operation WITH(NOLOCK) ON WorkOrder.OPERATIONREF = Operation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETF As Unitset WITH(NOLOCK) ON Product.UNITSETREF = Unitset.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SubUnitset WITH(NOLOCK) ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
	LEFT JOIN LG_00{FirmNumber}_WORKSTAT AS Workstation WITH(NOLOCK) ON WorkOrder.WSREF = Workstation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_PRODORD AS ProductionOrder WITH(NOLOCK) ON WorkOrder.PRODORDREF = ProductionOrder.LOGICALREF
    LEFT JOIN LG_001_CLCARD AS Supplier WITH(NOLOCK) ON ProductionOrder.CLIENTREF = Supplier.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4 WHERE ProductionOrder.FICHETYPE=1
	AND WorkOrder.PRODORDREF = {id}";
        public string GetOutsourceByProductionOrderCode(string code) =>
    @$"SELECT
   [ReferenceId] = WorkOrder.LOGICALREF,
    [Status] = WorkOrder.LINESTATUS,
    [StatusName] = 
        CASE WorkOrder.LINESTATUS
            WHEN 0 THEN 'Başlamadı'
            WHEN 1 THEN 'Devam Ediyor'
            WHEN 2 THEN 'Durduruldu'
            WHEN 3 THEN 'Tamamlandı'
            WHEN 4 THEN 'Kapandı'
            ELSE 'Diğer'
        END,
		[Code] = WorkOrder.LINENO_,
	[OperationBeginDate] = WorkOrder.OPBEGDATE,
	[OperationDueDate] = WorkOrder.OPDUEDATE,
	[OperationActualBeginDate] = WorkOrder.ACTBEGDATE,
	[OperationActualDueDate] = WorkOrder.ACTDUEDATE,
	[OperationBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPBEGTIME),
	[OperationDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.OPDUETIME),
	[OperationActualBeginTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTBEGTIME),
	[OperationActualDueTime] = [dbo].[LG_INTTOTIME](WorkOrder.ACTDUETIME),
	[OperationReferenceId] = WorkOrder.OPERATIONREF,
	[OperationCode] = Operation.CODE,
	[OperationName] = Operation.NAME,
	[WorkstationReferenceId] = WorkOrder.WSREF,
	[WorkstationCode] = Workstation.CODE,
	[WorkstationName] = Workstation.NAME,
	[ProductReferenceId] = WorkOrder.ITEMREF,
	[ProductCode] = Product.CODE,
	[ProductName] = Product.NAME,
	[UnitsetReferenceId] = Unitset.LOGICALREF,
	[UnitsetCode] = Unitset.CODE,
	[BrandReferenceId] = Brand.LOGICALREF,
	[BrandCode] = Brand.CODE,
	[BrandName] = Brand.DESCR,
	[ProductionReferenceId] = WorkOrder.PRODORDREF,
	[ProductionCode] = ProductionOrder.FICHENO,
	[SubUnitsetReferenceId] = SubUnitset.LOGICALREF,
	[SubUnitsetCode] = SubUnitset.CODE ,
    [SupplierReferenceId]=Supplier.LOGICALREF,
	[SupplierCode]=Supplier.CODE,
	[SupplierName]=Supplier.DEFINITION_,
	[PlanningQuantity] = ISNULL(Poline.AMOUNT,0),
	[ActualQuantity] = ISNULL((SELECT SUM(STLINE.AMOUNT) FROM LG_003_01_STLINE AS STLINE WITH(NOLOCK) WHERE STLINE.SOURCEPOLNREF = WorkOrder.LOGICALREF AND STLINE.STOCKREF = Product.LOGICALREF AND STLINE.TRCODE = 13 ),0)
	
	FROM
    LG_00{FirmNumber}_DISPLINE AS WorkOrder WITH(NOLOCK) 
	LEFT JOIN LG_00{FirmNumber}_ITEMS AS Product WITH(NOLOCK) ON WorkOrder.ITEMREF = Product.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_OPERTION As Operation WITH(NOLOCK) ON WorkOrder.OPERATIONREF = Operation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETF As Unitset WITH(NOLOCK) ON Product.UNITSETREF = Unitset.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SubUnitset WITH(NOLOCK) ON Unitset.LOGICALREF = SubUnitset.UNITSETREF AND SubUnitset.MAINUNIT = 1
	LEFT JOIN LG_00{FirmNumber}_WORKSTAT AS Workstation WITH(NOLOCK) ON WorkOrder.WSREF = Workstation.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_PRODORD AS ProductionOrder WITH(NOLOCK) ON WorkOrder.PRODORDREF = ProductionOrder.LOGICALREF
    LEFT JOIN LG_001_CLCARD AS Supplier WITH(NOLOCK) ON ProductionOrder.CLIENTREF = Supplier.LOGICALREF
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4 WHERE ProductionOrder.FICHETYPE=1  AND ProductionOrder.FICHENO = {code}";
        #endregion

    }
}
