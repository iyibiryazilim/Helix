using Helix.UI.Mobile.Modules.ReturnModule.Dtos.BaseDtos;

namespace Helix.UI.Mobile.Modules.ReturnModule.Dtos;
public class WholeSalesReturnTransactionInsertDto : BaseSalesReturnDispatchTransactionDto
{
    public WholeSalesReturnTransactionInsertDto()
    {
        Lines = new List<WholeSalesReturnTransactionLineDto>();
    }
    public IList<WholeSalesReturnTransactionLineDto> Lines { get; set; }
}
