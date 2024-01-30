using Helix.UI.Mobile.Modules.ReturnModule.Dtos.BaseDtos;

namespace Helix.UI.Mobile.Modules.ReturnModule.Dtos;

public class PurchaseReturnDispatchTransactionInsertDto : BasePurchaseReturnDispatchTransactionDto
{
    public PurchaseReturnDispatchTransactionInsertDto()
    {
        Lines = new List<PurchaseReturnDispatchTransactionLineDto>();
    }
    public IList<PurchaseReturnDispatchTransactionLineDto> Lines{ get; set; }
}
