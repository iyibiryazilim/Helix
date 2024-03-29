﻿using Helix.UI.Mobile.Modules.ProductModule.Dtos.BaseDto;

namespace Helix.UI.Mobile.Modules.ProductModule.Dtos
{
    public class TransferTransactionDto : BaseProductTransactionDto
    {
        public TransferTransactionDto()
        {
            Lines = new List<TransferTransactionLineDto>();
        }
        public int? DestinationWarehouseNumber { get; set; }
        public IList<TransferTransactionLineDto> Lines { get; set; }
    }
}
