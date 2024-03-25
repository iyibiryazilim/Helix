using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.Tiger.Models
{
	public class LG_TransferTransactionLine : LG_ProductTransactionLine
	{
		public LG_TransferTransactionLine()
		{
			SLTRANS = new List<LG_SeriLotTransaction>();
		}

		public short DESTINDEX { get; set; } = default;
		public short DESTCOSTGRP { get; set; } = default;
		public IList<LG_SeriLotTransaction> SLTRANS { get; set; }
	}
}