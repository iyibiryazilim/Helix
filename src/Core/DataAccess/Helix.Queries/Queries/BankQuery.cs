using Microsoft.Extensions.Configuration;

namespace Helix.Queries
{
	public class BankQuery : BaseQuery
	{
		public BankQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetBankList() =>
		@$"SELECT 
		[ReferenceId] = BANK.LOGICALREF,
		[Code] = BANK.CODE,
		[Definition] = BANK.DEFINITION_,
		[Branch] = BANK.BRANCH,
		[BranchNo] = BANK.BRANCHNO,
		[Address] = BANK.ADDR1,
		[City] = BANK.CITY,
		[Country] = BANK.COUNTRY,
		[District] = BANK.TOWN
		FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_BNCARD AS BANK";
		public string GetBankById(int id) =>
		@$"SELECT 
		[ReferenceId] = BANK.LOGICALREF,
		[Code] = BANK.CODE,
		[Definition] = BANK.DEFINITION_,
		[Branch] = BANK.BRANCH,
		[BranchNo] = BANK.BRANCHNO,
		[Address] = BANK.ADDR1,
		[City] = BANK.CITY,
		[Country] = BANK.COUNTRY,
		[District] = BANK.TOWN
		FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_BNCARD AS BANK
		WHERE BANK.LOGICALREF = {id}";
		public string GetBankByCode(string code) =>
		@$"SELECT 
		[ReferenceId] = BANK.LOGICALREF,
		[Code] = BANK.CODE,
		[Definition] = BANK.DEFINITION_,
		[Branch] = BANK.BRANCH,
		[BranchNo] = BANK.BRANCHNO,
		[Address] = BANK.ADDR1,
		[City] = BANK.CITY,
		[Country] = BANK.COUNTRY,
		[District] = BANK.TOWN
		FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_BNCARD AS BANK
		WHERE BANK.CODE = '{code}'";
	}
}
