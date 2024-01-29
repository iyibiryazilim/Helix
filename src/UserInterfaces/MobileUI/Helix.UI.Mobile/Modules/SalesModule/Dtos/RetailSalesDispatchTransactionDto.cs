using Helix.UI.Mobile.Modules.SalesModule.Dtos.BaseDtos;

namespace Helix.UI.Mobile.Modules.SalesModule.Dtos
{
    public class RetailSalesDispatchTransactionDto : BaseSalesDispatchTransactionDto
    {
        public RetailSalesDispatchTransactionDto()
        {
            Lines = new List<RetailSalesDispatchTransactionLineDto>();
        }
        public IList<RetailSalesDispatchTransactionLineDto> Lines { get; set; }
    }
}
