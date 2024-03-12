using Microsoft.Extensions.Configuration;

namespace Helix.Queries
{
	public class BankAccountQuery : BaseQuery
	{
		public BankAccountQuery(IConfiguration configuration) : base(configuration)
		{
		}
		public string GetBankAccountList() =>
		@$"SELECT 
		[ReferenceId] = BANKACC.LOGICALREF,
		[CardType] = BANKACC.CARDTYPE,
		[Definition] = BANKACC.DEFINITION_,
		[AccountNo] = BANKACC.ACCOUNTNO,
		[BankReferenceId] = BANK.LOGICALREF,
		[BankDefinition] = BANK.DEFINITION_,
		[BankCode]  = BANK.CODE
		FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_BANKACC AS BANKACC
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_BNCARD AS BANK ON BANK.LOGICALREF = BANKACC.BANKREF";
		public string GetBankAccountById(int id) =>
		@$"SELECT 
		[ReferenceId] = BANKACC.LOGICALREF,
		[CardType] = BANKACC.CARDTYPE,
		[Definition] = BANKACC.DEFINITION_,
		[AccountNo] = BANKACC.ACCOUNTNO,
		[BankReferenceId] = BANK.LOGICALREF,
		[BankDefinition] = BANK.DEFINITION_,
		[BankCode]  = BANK.CODE
		FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_BANKACC AS BANKACC
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_BNCARD AS BANK ON BANK.LOGICALREF = BANKACC.BANKREF
		WHERE BANKACC.LOGICALREF = {id}";
		

		public string GetBankAccountByBankId(int id) =>
		@$"SELECT 
		[ReferenceId] = BANKACC.LOGICALREF,
		[CardType] = BANKACC.CARDTYPE,
		[Definition] = BANKACC.DEFINITION_,
		[AccountNo] = BANKACC.ACCOUNTNO,
		[BankReferenceId] = BANK.LOGICALREF,
		[BankDefinition] = BANK.DEFINITION_,
		[BankCode]  = BANK.CODE
		FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_BANKACC AS BANKACC
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_BNCARD AS BANK ON BANK.LOGICALREF = BANKACC.BANKREF
		WHERE BANK.LOGICALREF = {id}";

		public string GetBankAccountByBankCode(string code) =>
		@$"SELECT 
		[ReferenceId] = BANKACC.LOGICALREF,
		[CardType] = BANKACC.CARDTYPE,
		[Definition] = BANKACC.DEFINITION_,
		[AccountNo] = BANKACC.ACCOUNTNO,
		[BankReferenceId] = BANK.LOGICALREF,
		[BankDefinition] = BANK.DEFINITION_,
		[BankCode]  = BANK.CODE
		FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_BANKACC AS BANKACC
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_BNCARD AS BANK ON BANK.LOGICALREF = BANKACC.BANKREF
		WHERE BANK.CODE = '{code}'";
	}
}
