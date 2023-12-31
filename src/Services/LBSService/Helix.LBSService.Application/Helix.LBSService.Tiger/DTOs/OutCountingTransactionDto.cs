﻿namespace Helix.LBSService.Tiger.DTOs
{

	public class OutCountingTransactionDto : ProductTransactionDto
	{
		public IList<OutCountingTransactionLineDto> Lines { get; set; }

		public OutCountingTransactionDto()
		{
			base.TransactionType = 51;
			base.TransactionTypeName = "Sayım Eksiği Fişi";
			Lines = new List<OutCountingTransactionLineDto>();
		}
	}
	public class OutCountingTransactionLineDto : ProductTransactionLineDto
	{
		public IList<SeriLotTransactionDto> SeriLotTransactions { get; set; }

		public OutCountingTransactionLineDto()
		{
			base.TransactionType = (short)51;
			base.TransactionTypeName = "Sayım Eksiği Fişi";
			SeriLotTransactions = new List<SeriLotTransactionDto>();
		}
	}
}
