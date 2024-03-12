using Microsoft.Extensions.Configuration;

namespace Helix.Queries
{
	public class BankAccountTransactionQuery : BaseQuery
	{
		public BankAccountTransactionQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetBankAccountTransactionList() =>
		@$"SELECT 
		[ReferenceId] = BNFICHE.LOGICALREF,
		[TransactionType] = BNFICHE.TRCODE,
		[Code] = BNFICHE.FICHENO,
		[Date] = BNFICHE.DATE_,
		[Time] = dbo.LG_INTTOTIME(BNFICHE.FTIME),
		[Description] = BNFICHE.GENEXP1,
		[SpeCode] = BNFICHE.SPECODE
		FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_BNFICHE AS BNFICHE";
		public string GetBankAccountTransactionById(int id) =>
		@$"SELECT 
		[ReferenceId] = BNFICHE.LOGICALREF,
		[TransactionType] = BNFICHE.TRCODE,
		[Code] = BNFICHE.FICHENO,
		[Date] = BNFICHE.DATE_,
		[Time] = dbo.LG_INTTOTIME(BNFICHE.FTIME),
		[Description] = BNFICHE.GENEXP1,
		[SpeCode] = BNFICHE.SPECODE
		FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_BNFICHE AS BNFICHE
		WHERE BNFICHE.LOGICALREF = {id}";
		public string GetBankAccountTransactionByCode(string code) =>
		@$"SELECT 
		[ReferenceId] = BNFICHE.LOGICALREF,
		[TransactionType] = BNFICHE.TRCODE,
		[Code] = BNFICHE.FICHENO,
		[Date] = BNFICHE.DATE_,
		[Time] = dbo.LG_INTTOTIME(BNFICHE.FTIME),
		[Description] = BNFICHE.GENEXP1,
		[SpeCode] = BNFICHE.SPECODE
		FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_BNFICHE AS BNFICHE
		WHERE BNFICHE.FICHENO = {code}";
	}
}
