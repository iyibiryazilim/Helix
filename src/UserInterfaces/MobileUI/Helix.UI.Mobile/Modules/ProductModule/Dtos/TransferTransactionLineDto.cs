﻿using Helix.UI.Mobile.Modules.ProductModule.Dtos.BaseDto;

namespace Helix.UI.Mobile.Modules.ProductModule.Dtos
{
    public class TransferTransactionLineDto : BaseProductTransactionLineDto
    {
        public int? DestinationWarehouseNumber { get; set; }

    }
}
