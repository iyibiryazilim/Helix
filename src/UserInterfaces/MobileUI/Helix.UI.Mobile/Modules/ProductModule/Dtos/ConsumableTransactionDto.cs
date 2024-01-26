using Helix.UI.Mobile.Modules.ProductModule.Dtos.BaseDto;

namespace Helix.UI.Mobile.Modules.ProductModule.Dtos
{
    public class ConsumableTransactionDto : BaseProductTransactionDto
    {
        public ConsumableTransactionDto()
        {
            Lines = new List<ConsumableTransactionLineDto>();
        }
        public IList<ConsumableTransactionLineDto> Lines { get; set; }
    }
}
