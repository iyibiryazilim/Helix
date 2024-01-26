using Helix.UI.Mobile.Modules.ProductModule.Dtos.BaseDto;

namespace Helix.UI.Mobile.Modules.ProductModule.Dtos
{
    public class OutCountingTransactionDto : BaseProductTransactionDto
    {
        public OutCountingTransactionDto()
        {
            Lines = new List<OutCountingTransactionLineDto>();
        }
        public IList<OutCountingTransactionLineDto> Lines { get; set; }
    }
}
