using Helix.UI.Mobile.Modules.ReturnModule.Dtos.BaseDtos;

namespace Helix.UI.Mobile.Modules.ReturnModule.Dtos;

public class RetailSalesReturnDispatchTransactionInsertDto : BaseSalesReturnDispatchTransactionDto
{
    public RetailSalesReturnDispatchTransactionInsertDto()
    {
        Lines = new List<RetailSalesReturnDispatchTransactionLineDto>();
    }
    public IList<RetailSalesReturnDispatchTransactionLineDto> Lines { get; set; }
}
