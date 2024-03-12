using Microsoft.Extensions.Configuration;

namespace Helix.ProductionService.Infrastructure.Helper.Queries;

public class StopTransactionQuery : BaseQuery
{
	public StopTransactionQuery(IConfiguration configuration) : base(configuration)
	{
	}

	public string GetStopTransactionList() =>
		$@"SELECT
[RefereceId] = StopTransaction.LOGICALREF,
[WorkOrderReferenceId] = StopTransaction.DISPLINEREF,
[WorkOrderStatus] = WorkOrder.LINESTATUS,
[ProductionReferenceId] = ProductionOrder.LOGICALREF,
[ProductionCode] = ProductionOrder.FICHENO,
[OperationReferenceId] = Operation.LOGICALREF,
[OperationCode] = Operation.CODE,
[WorkstationReferenceId] = Workstation.LOGICALREF,
[WorkstationSpeCode] = Workstation.SPECODE,
[WorkstationPermissionCode] = Workstation.CYPHCODE,
[StopCauseReferenceId] = StopCause.LOGICALREF,
[StopCauseCode] = StopCause.CODE,
[Description] =StopTransaction.TRANSEXP,
[StopDate] = StopTransaction.STOPDATE,
[StartDate] = StopTransaction.STARTDATE,
[StopTime] =  [dbo].[LG_INTTOTIME](StopTransaction.STOPTIME),
[StarTime] =  [dbo].[LG_INTTOTIME](StopTransaction.STARTTIME),
[StopDuration] =StopTransaction.STOPDURATION

FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_STOPTRANS AS StopTransaction
LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_DISPLINE AS WorkOrder ON StopTransaction.DISPLINEREF = WorkOrder.LOGICALREF
LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_PRODORD AS ProductionOrder ON WorkOrder.PRODORDREF = ProductionOrder.LOGICALREF
LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_OPERTION AS Operation ON StopTransaction.OPREF = Operation.LOGICALREF
LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_WORKSTAT AS Workstation ON StopTransaction.WSREF = Workstation.LOGICALREF
LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_STOPCAUSE AS StopCause ON StopTransaction.CAUSEREF = StopCause.LOGICALREF";
}
