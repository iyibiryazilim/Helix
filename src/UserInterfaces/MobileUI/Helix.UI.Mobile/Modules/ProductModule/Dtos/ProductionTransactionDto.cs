using Helix.UI.Mobile.Modules.ProductModule.Dtos.BaseDto;

namespace Helix.UI.Mobile.Modules.ProductModule.Dtos
{
    public class ProductionTransactionDto : BaseProductTransactionDto
    {
        public ProductionTransactionDto()
        {
            Lines = new List<ProductionTransactionLineDto>();
        }
        public IList<ProductionTransactionLineDto> Lines { get; set; }
    }
}
