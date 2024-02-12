using Helix.UI.Mobile.Modules.BaseModule.Models;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Models;

public class WaitingOrderLineGroupByModel : List<WaitingOrderLine>
{
    public string Name { get; set; }

    public WaitingOrderLineGroupByModel(string name, List<WaitingOrderLine> waitingOrderLines) : base(waitingOrderLines)
    {
        Name = name;
	}
}
