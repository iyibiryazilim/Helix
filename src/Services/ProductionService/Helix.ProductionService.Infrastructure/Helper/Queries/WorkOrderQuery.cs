using Microsoft.Extensions.Configuration;

namespace Helix.ProductionService.Infrastructure.Helper.Queries;

public class WorkOrderQuery : BaseQuery
{
	public WorkOrderQuery(IConfiguration configuration) : base(configuration)
	{
	}

	public string GetWorkOrderList() =>
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
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4
";
	public string GetWorkOrderByStatus(int[] status)
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
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4
	WHERE WorkOrder.LINESTATUS IN ({statusString})";
		return query;
	}
	public string GetWorkOrderById(int id)
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
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4
	WHERE WorkOrder.LOGICALREF = {id}";

		return query;
    }
		

	#region Workstation Filter
	public string GetWorkOrderByWorkstationId(int id) =>
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
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4
	WHERE Workstation.LOGICALREF = {id}";
	public string GetWorkOrderByWorkstationCode(string code) =>
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
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4
	WHERE Workstation.CODE = {code}";
    #endregion

    #region Product Filter

    public string GetWorkOrderByProductId(int id) =>
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
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4
	WHERE Product.LOGICALREF = {id}";



    #endregion

    #region ProductionOrder Filter
    public string GetWorkOrderByProductionOrderId(int id) =>
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
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4
	WHERE WorkOrder.PRODORDREF = {id}";
	public string GetWorkOrderByProductionOrderCode(string code) =>
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
	LEFT JOIN LG_00{FirmNumber}_MARK AS Brand WITH(NOLOCK) ON Product.MARKREF = Brand.LOGICALREF
	LEFT JOIN LG_003_POLINE AS Poline WITH(NOLOCK) ON WorkOrder.LOGICALREF = Poline.DISPLINEREF  AND Poline.ITEMREF = Product.LOGICALREF AND Poline.LINETYPE = 4
	WHERE ProductionOrder.FICHENO = {code}";
	#endregion
}
