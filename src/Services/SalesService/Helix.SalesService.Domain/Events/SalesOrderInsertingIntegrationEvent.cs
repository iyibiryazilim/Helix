using Helix.EventBus.Base.Events;

namespace Helix.SalesService.Domain.Events;

public class SalesOrderInsertingIntegrationEvent : IntegrationEvent
{

	public int ReferenceId { get; private set; }
    public string Code { get; private set; }
    public DateTime OrderDate { get; private set; }

	public SalesOrderInsertingIntegrationEvent(int referenceId, string code, DateTime orderDate)
	{
		ReferenceId = referenceId;
		Code = code;
		OrderDate = orderDate;
	}

	public SalesOrderInsertingIntegrationEvent()
	{
	}
}
