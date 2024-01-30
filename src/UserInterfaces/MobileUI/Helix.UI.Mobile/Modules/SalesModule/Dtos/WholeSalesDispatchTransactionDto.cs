using Helix.UI.Mobile.Modules.SalesModule.Dtos.BaseDtos;

namespace Helix.UI.Mobile.Modules.SalesModule.Dtos
{
    public class WholeSalesDispatchTransactionDto : BaseSalesDispatchTransactionDto
    {
        public WholeSalesDispatchTransactionDto()
        {
            Lines = new List<WholeSalesDispatchTransactionLineDto>();
        }
        public IList<WholeSalesDispatchTransactionLineDto> Lines { get; set; }
    }
}
