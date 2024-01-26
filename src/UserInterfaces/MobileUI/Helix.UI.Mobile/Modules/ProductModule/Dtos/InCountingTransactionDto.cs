using Helix.UI.Mobile.Modules.ProductModule.Dtos.BaseDto;

namespace Helix.UI.Mobile.Modules.ProductModule.Dtos
{
    public class InCountingTransactionDto : BaseProductTransactionDto
    {
        public InCountingTransactionDto()
        {
            Lines = new List<InCountingTransactionLineDto>();
        }
        public IList<InCountingTransactionLineDto> Lines { get; set; }
    }
}
