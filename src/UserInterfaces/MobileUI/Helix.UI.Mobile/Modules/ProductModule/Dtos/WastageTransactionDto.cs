using Helix.UI.Mobile.Modules.ProductModule.Dtos.BaseDto;

namespace Helix.UI.Mobile.Modules.ProductModule.Dtos
{
    public class WastageTransactionDto : BaseProductTransactionDto
    {
        public WastageTransactionDto()
        {
            Lines = new List<WastageTransactionLineDto>();
        }
        public IList<WastageTransactionLineDto> Lines { get; set; }
    }
}
