using Helix.UI.Mobile.Modules.PurchaseModule.Dtos.BaseDto;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Dtos
{
    public class PurchaseDispatchTransactionDto : BasePurchaseDispatchTransactionDto
    {
        public PurchaseDispatchTransactionDto()
        {
            Lines = new List<PurchaseDispatchTransactionLineDto>();
        }
        public IList<PurchaseDispatchTransactionLineDto> Lines { get; set; }
    }
}
