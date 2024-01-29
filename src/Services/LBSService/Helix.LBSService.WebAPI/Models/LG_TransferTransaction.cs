﻿using Helix.LBSService.WebAPI.Models.BaseModel;

namespace Helix.LBSService.WebAPI.Models
{
	public class LG_TransferTransaction : LG_ProductTransaction
	{
		public LG_TransferTransaction()
		{
			TRANSACTIONS = new List<LG_TransferTransactionLine>();
		}
		public IList<LG_TransferTransactionLine> TRANSACTIONS { get; set; }

		public short DEST_COST_GRP { get; set; } = default;
		public short DEST_WH { get; set; } = default;
	}
}