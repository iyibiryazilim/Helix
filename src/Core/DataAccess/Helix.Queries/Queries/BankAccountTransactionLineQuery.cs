using Microsoft.Extensions.Configuration;

namespace Helix.Queries
{
	public class BankAccountTransactionLineQuery : BaseQuery
	{
		public BankAccountTransactionLineQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetBankAccountTransactionLineList() =>
		@$"SELECT 
		[ReferenceId] = BNFLINE.LOGICALREF,
		[TransactionType] = BNFLINE.TRANSTYPE,
		[TransactionTypeCode] = BNFLINE.TRCODE,
		[Date] = BNFLINE.DATE_,
		[Time] = dbo.LG_INTTOTIME(BNFLINE.TIME_),
		[Total] = BNFLINE.AMOUNT,
		[Branch] = BNFLINE.BRANCH,
		[Description]  = BNFLINE.LINEEXP,
		[CurrentReferenceId] = CLCARD.LOGICALREF,
		[CurrentCode] = CLCARD.CODE,
		[CurrentName] = CLCARD.DEFINITION_,
		[BankReferenceId] = BNCARD.LOGICALREF,
		[BankCode] = BNCARD.CODE,
		[BankDefinition] = BNCARD.DEFINITION_,
		[BankAccountReferenceId] = BANKACC.LOGICALREF,
		[BankAccountCode] = BANKACC.CODE,
		[BankAccountDefinition] = BANKACC.DEFINITION_,
		[BankAccountTransactionReferenceId] = BNFICHE.LOGICALREF,
		[BankAccountTransactionCode] = BNFICHE.FICHENO,
		[CurrencyReferenceId] = CURRENCY.LOGICALREF,
		[CurrencyCode] = CURRENCY.CURCODE,
		[CurrencyType] = CURRENCY.CURTYPE,
		[CurrencyName] = CURRENCY.CURNAME
		FROM LG_00{FirmNumber}_0{PeriodNumber}_BNFLINE AS BNFLINE
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON CLCARD.LOGICALREF = BNFLINE.CLIENTREF
		LEFT JOIN LG_00{FirmNumber}_BNCARD AS BNCARD ON BNCARD.LOGICALREF = BNFLINE.BANKREF
		LEFT JOIN LG_00{FirmNumber}_BANKACC AS BANKACC ON BANKACC.LOGICALREF = BNFLINE.BNACCREF
		LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_BNFICHE AS BNFICHE ON BNFICHE.LOGICALREF = BNFLINE.SOURCEFREF
		LEFT JOIN L_CURRENCYLIST AS CURRENCY ON BANKACC.CURRENCY = CURRENCY.CURTYPE AND CURRENCY.FIRMNR = {FirmNumber}";
		public string GetBankAccountTransactionLineById(int id) =>
		@$"SELECT 
		[ReferenceId] = BNFLINE.LOGICALREF,
		[TransactionType] = BNFLINE.TRANSTYPE,
		[TransactionTypeCode] = BNFLINE.TRCODE,
		[Date] = BNFLINE.DATE_,
		[Time] = dbo.LG_INTTOTIME(BNFLINE.TIME_),
		[Total] = BNFLINE.AMOUNT,
		[Branch] = BNFLINE.BRANCH,
		[Description]  = BNFLINE.LINEEXP,
		[CurrentReferenceId] = CLCARD.LOGICALREF,
		[CurrentCode] = CLCARD.CODE,
		[CurrentName] = CLCARD.DEFINITION_,
		[BankReferenceId] = BNCARD.LOGICALREF,
		[BankCode] = BNCARD.CODE,
		[BankDefinition] = BNCARD.DEFINITION_,
		[BankAccountReferenceId] = BANKACC.LOGICALREF,
		[BankAccountCode] = BANKACC.CODE,
		[BankAccountDefinition] = BANKACC.DEFINITION_,
		[BankAccountTransactionReferenceId] = BNFICHE.LOGICALREF,
		[BankAccountTransactionCode] = BNFICHE.FICHENO,
		[CurrencyReferenceId] = CURRENCY.LOGICALREF,
		[CurrencyCode] = CURRENCY.CURCODE,
		[CurrencyType] = CURRENCY.CURTYPE,
		[CurrencyName] = CURRENCY.CURNAME
		FROM LG_00{FirmNumber}_0{PeriodNumber}_BNFLINE AS BNFLINE
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON CLCARD.LOGICALREF = BNFLINE.CLIENTREF
		LEFT JOIN LG_00{FirmNumber}_BNCARD AS BNCARD ON BNCARD.LOGICALREF = BNFLINE.BANKREF
		LEFT JOIN LG_00{FirmNumber}_BANKACC AS BANKACC ON BANKACC.LOGICALREF = BNFLINE.BNACCREF
		LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_BNFICHE AS BNFICHE ON BNFICHE.LOGICALREF = BNFLINE.SOURCEFREF
		LEFT JOIN L_CURRENCYLIST AS CURRENCY ON BANKACC.CURRENCY = CURRENCY.CURTYPE AND CURRENCY.FIRMNR = {FirmNumber}
		WHERE BNFLINE.LOGICALREF = {id}";
		public string GetBankAccountTransactionLineByBankId(int id) =>
		@$"SELECT 
		[ReferenceId] = BNFLINE.LOGICALREF,
		[TransactionType] = BNFLINE.TRANSTYPE,
		[TransactionTypeCode] = BNFLINE.TRCODE,
		[Date] = BNFLINE.DATE_,
		[Time] = dbo.LG_INTTOTIME(BNFLINE.TIME_),
		[Total] = BNFLINE.AMOUNT,
		[Branch] = BNFLINE.BRANCH,
		[Description]  = BNFLINE.LINEEXP,
		[CurrentReferenceId] = CLCARD.LOGICALREF,
		[CurrentCode] = CLCARD.CODE,
		[CurrentName] = CLCARD.DEFINITION_,
		[BankReferenceId] = BNCARD.LOGICALREF,
		[BankCode] = BNCARD.CODE,
		[BankDefinition] = BNCARD.DEFINITION_,
		[BankAccountReferenceId] = BANKACC.LOGICALREF,
		[BankAccountCode] = BANKACC.CODE,
		[BankAccountDefinition] = BANKACC.DEFINITION_,
		[BankAccountTransactionReferenceId] = BNFICHE.LOGICALREF,
		[BankAccountTransactionCode] = BNFICHE.FICHENO,
		[CurrencyReferenceId] = CURRENCY.LOGICALREF,
		[CurrencyCode] = CURRENCY.CURCODE,
		[CurrencyType] = CURRENCY.CURTYPE,
		[CurrencyName] = CURRENCY.CURNAME
		FROM LG_00{FirmNumber}_0{PeriodNumber}_BNFLINE AS BNFLINE
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON CLCARD.LOGICALREF = BNFLINE.CLIENTREF
		LEFT JOIN LG_00{FirmNumber}_BNCARD AS BNCARD ON BNCARD.LOGICALREF = BNFLINE.BANKREF
		LEFT JOIN LG_00{FirmNumber}_BANKACC AS BANKACC ON BANKACC.LOGICALREF = BNFLINE.BNACCREF
		LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_BNFICHE AS BNFICHE ON BNFICHE.LOGICALREF = BNFLINE.SOURCEFREF
		LEFT JOIN L_CURRENCYLIST AS CURRENCY ON BANKACC.CURRENCY = CURRENCY.CURTYPE AND CURRENCY.FIRMNR = {FirmNumber}
		WHERE BNCARD.LOGICALREF = {id}";
		public string GetBankAccountTransactionLineByBankCode(string code) =>
		@$"SELECT 
		[ReferenceId] = BNFLINE.LOGICALREF,
		[TransactionType] = BNFLINE.TRANSTYPE,
		[TransactionTypeCode] = BNFLINE.TRCODE,
		[Date] = BNFLINE.DATE_,
		[Time] = dbo.LG_INTTOTIME(BNFLINE.TIME_),
		[Total] = BNFLINE.AMOUNT,
		[Branch] = BNFLINE.BRANCH,
		[Description]  = BNFLINE.LINEEXP,
		[CurrentReferenceId] = CLCARD.LOGICALREF,
		[CurrentCode] = CLCARD.CODE,
		[CurrentName] = CLCARD.DEFINITION_,
		[BankReferenceId] = BNCARD.LOGICALREF,
		[BankCode] = BNCARD.CODE,
		[BankDefinition] = BNCARD.DEFINITION_,
		[BankAccountReferenceId] = BANKACC.LOGICALREF,
		[BankAccountCode] = BANKACC.CODE,
		[BankAccountDefinition] = BANKACC.DEFINITION_,
		[BankAccountTransactionReferenceId] = BNFICHE.LOGICALREF,
		[BankAccountTransactionCode] = BNFICHE.FICHENO,
		[CurrencyReferenceId] = CURRENCY.LOGICALREF,
		[CurrencyCode] = CURRENCY.CURCODE,
		[CurrencyType] = CURRENCY.CURTYPE,
		[CurrencyName] = CURRENCY.CURNAME
		FROM LG_00{FirmNumber}_0{PeriodNumber}_BNFLINE AS BNFLINE
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON CLCARD.LOGICALREF = BNFLINE.CLIENTREF
		LEFT JOIN LG_00{FirmNumber}_BNCARD AS BNCARD ON BNCARD.LOGICALREF = BNFLINE.BANKREF
		LEFT JOIN LG_00{FirmNumber}_BANKACC AS BANKACC ON BANKACC.LOGICALREF = BNFLINE.BNACCREF
		LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_BNFICHE AS BNFICHE ON BNFICHE.LOGICALREF = BNFLINE.SOURCEFREF
		LEFT JOIN L_CURRENCYLIST AS CURRENCY ON BANKACC.CURRENCY = CURRENCY.CURTYPE AND CURRENCY.FIRMNR = {FirmNumber}
		WHERE BNCARD.CODE = '{code}'";
		public string GetBankAccountTransactionLineByBankAccountId(int id) =>
		@$"SELECT 
		[ReferenceId] = BNFLINE.LOGICALREF,
		[TransactionType] = BNFLINE.TRANSTYPE,
		[TransactionTypeCode] = BNFLINE.TRCODE,
		[Date] = BNFLINE.DATE_,
		[Time] = dbo.LG_INTTOTIME(BNFLINE.TIME_),
		[Total] = BNFLINE.AMOUNT,
		[Branch] = BNFLINE.BRANCH,
		[Description]  = BNFLINE.LINEEXP,
		[CurrentReferenceId] = CLCARD.LOGICALREF,
		[CurrentCode] = CLCARD.CODE,
		[CurrentName] = CLCARD.DEFINITION_,
		[BankReferenceId] = BNCARD.LOGICALREF,
		[BankCode] = BNCARD.CODE,
		[BankDefinition] = BNCARD.DEFINITION_,
		[BankAccountReferenceId] = BANKACC.LOGICALREF,
		[BankAccountCode] = BANKACC.CODE,
		[BankAccountDefinition] = BANKACC.DEFINITION_,
		[BankAccountTransactionReferenceId] = BNFICHE.LOGICALREF,
		[BankAccountTransactionCode] = BNFICHE.FICHENO,
		[CurrencyReferenceId] = CURRENCY.LOGICALREF,
		[CurrencyCode] = CURRENCY.CURCODE,
		[CurrencyType] = CURRENCY.CURTYPE,
		[CurrencyName] = CURRENCY.CURNAME
		FROM LG_00{FirmNumber}_0{PeriodNumber}_BNFLINE AS BNFLINE
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON CLCARD.LOGICALREF = BNFLINE.CLIENTREF
		LEFT JOIN LG_00{FirmNumber}_BNCARD AS BNCARD ON BNCARD.LOGICALREF = BNFLINE.BANKREF
		LEFT JOIN LG_00{FirmNumber}_BANKACC AS BANKACC ON BANKACC.LOGICALREF = BNFLINE.BNACCREF		
		LEFT JOIN L_CURRENCYLIST AS CURRENCY ON BANKACC.CURRENCY = CURRENCY.CURTYPE AND CURRENCY.FIRMNR = {FirmNumber}
		LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_BNFICHE AS BNFICHE ON BNFICHE.LOGICALREF = BNFLINE.SOURCEFREF
		WHERE BANKACC.LOGICALREF = {id}";
		public string GetBankAccountTransactionLineByBankAccountIdAndBankId(int accountId,int bankId) =>
		@$"SELECT 
		[ReferenceId] = BNFLINE.LOGICALREF,
		[TransactionType] = BNFLINE.TRANSTYPE,
		[TransactionTypeCode] = BNFLINE.TRCODE,
		[Date] = BNFLINE.DATE_,
		[Time] = dbo.LG_INTTOTIME(BNFLINE.TIME_),
		[Total] = BNFLINE.AMOUNT,
		[Branch] = BNFLINE.BRANCH,
		[Description]  = BNFLINE.LINEEXP,
		[CurrentReferenceId] = CLCARD.LOGICALREF,
		[CurrentCode] = CLCARD.CODE,
		[CurrentName] = CLCARD.DEFINITION_,
		[BankReferenceId] = BNCARD.LOGICALREF,
		[BankCode] = BNCARD.CODE,
		[BankDefinition] = BNCARD.DEFINITION_,
		[BankAccountReferenceId] = BANKACC.LOGICALREF,
		[BankAccountCode] = BANKACC.CODE,
		[BankAccountDefinition] = BANKACC.DEFINITION_,
		[BankAccountTransactionReferenceId] = BNFICHE.LOGICALREF,
		[BankAccountTransactionCode] = BNFICHE.FICHENO,
		[CurrencyReferenceId] = CURRENCY.LOGICALREF,
		[CurrencyCode] = CURRENCY.CURCODE,
		[CurrencyType] = CURRENCY.CURTYPE,
		[CurrencyName] = CURRENCY.CURNAME
		FROM LG_00{FirmNumber}_0{PeriodNumber}_BNFLINE AS BNFLINE
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON CLCARD.LOGICALREF = BNFLINE.CLIENTREF
		LEFT JOIN LG_00{FirmNumber}_BNCARD AS BNCARD ON BNCARD.LOGICALREF = BNFLINE.BANKREF
		LEFT JOIN LG_00{FirmNumber}_BANKACC AS BANKACC ON BANKACC.LOGICALREF = BNFLINE.BNACCREF
		LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_BNFICHE AS BNFICHE ON BNFICHE.LOGICALREF = BNFLINE.SOURCEFREF
		LEFT JOIN L_CURRENCYLIST AS CURRENCY ON BANKACC.CURRENCY = CURRENCY.CURTYPE AND CURRENCY.FIRMNR = {FirmNumber}
		WHERE BANKACC.LOGICALREF = {accountId} AND BNCARD.LOGICALREF = {bankId}";
		public string GetBankAccountTransactionLineByBankIdAndCurrencyId(int bankId,int currencyId) =>
		@$"SELECT 
		[ReferenceId] = BNFLINE.LOGICALREF,
		[TransactionType] = BNFLINE.TRANSTYPE,
		[TransactionTypeCode] = BNFLINE.TRCODE,
		[Date] = BNFLINE.DATE_,
		[Time] = dbo.LG_INTTOTIME(BNFLINE.TIME_),
		[Total] = BNFLINE.AMOUNT,
		[Branch] = BNFLINE.BRANCH,
		[Description]  = BNFLINE.LINEEXP,
		[CurrentReferenceId] = CLCARD.LOGICALREF,
		[CurrentCode] = CLCARD.CODE,
		[CurrentName] = CLCARD.DEFINITION_,
		[BankReferenceId] = BNCARD.LOGICALREF,
		[BankCode] = BNCARD.CODE,
		[BankDefinition] = BNCARD.DEFINITION_,
		[BankAccountReferenceId] = BANKACC.LOGICALREF,
		[BankAccountCode] = BANKACC.CODE,
		[BankAccountDefinition] = BANKACC.DEFINITION_,
		[BankAccountTransactionReferenceId] = BNFICHE.LOGICALREF,
		[BankAccountTransactionCode] = BNFICHE.FICHENO,
		[CurrencyReferenceId] = CURRENCY.LOGICALREF,
		[CurrencyCode] = CURRENCY.CURCODE,
		[CurrencyType] = CURRENCY.CURTYPE,
		[CurrencyName] = CURRENCY.CURNAME
		FROM LG_00{FirmNumber}_0{PeriodNumber}_BNFLINE AS BNFLINE
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON CLCARD.LOGICALREF = BNFLINE.CLIENTREF
		LEFT JOIN LG_00{FirmNumber}_BNCARD AS BNCARD ON BNCARD.LOGICALREF = BNFLINE.BANKREF
		LEFT JOIN LG_00{FirmNumber}_BANKACC AS BANKACC ON BANKACC.LOGICALREF = BNFLINE.BNACCREF
		LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_BNFICHE AS BNFICHE ON BNFICHE.LOGICALREF = BNFLINE.SOURCEFREF
		LEFT JOIN L_CURRENCYLIST AS CURRENCY ON BANKACC.CURRENCY = CURRENCY.CURTYPE AND CURRENCY.FIRMNR = {FirmNumber}
		WHERE CURRENCY.LOGICALREF = {currencyId} AND BNCARD.LOGICALREF = {bankId}";
	}
}
