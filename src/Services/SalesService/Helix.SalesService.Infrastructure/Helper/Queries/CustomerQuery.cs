using Microsoft.Extensions.Configuration;

namespace Helix.SalesService.Infrastructure.Helper.Queries;

public class CustomerQuery : BaseQuery
{
	public CustomerQuery(IConfiguration configuration) : base(configuration)
	{
	}

	public string GetCustomerList(string search, string orderBy, int currentPage = 0, int pageSize = 20)
	{
        int currentIndex = pageSize * currentPage;

		string query = @$"SELECT
		[ReferenceId] = CLCARD.LOGICALREF,
        [Code] = CLCARD.CODE,
        [Name] = CLCARD.DEFINITION_,
        [Telephone] = CLCARD.TELNRS1,
        [OtherTelephone] = CLCARD.TELNRS2,
        [TaxOffice] = CLCARD.TAXOFFICE,
        [TaxNumber] = CLCARD.TAXNR,
        [Email] = CLCARD.EMAILADDR,
        [Image] = FIRMDOC.LDATA,
        [Country] = CLCARD.COUNTRY,
        [City] = CLCARD.CITY,
        [County] = CLCARD.TOWN,
        [Address] = CLCARD.ADDR1,
        [ReferenceCount]=ISNULL((SELECT COUNT(DISTINCT STOCKREF) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND (AMOUNT-SHIPPEDAMOUNT) > 0 AND CLOSED = 0  AND LINETYPE = 0 AND TRCODE = 1 ),0),
		[NetTotal] = ISNULL((SELECT SUM(LINENET) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND(AMOUNT - SHIPPEDAMOUNT) > 0 AND CLOSED = 0 AND LINETYPE = 0 AND TRCODE = 1),0),
		[LastTransactionDate] = (SELECT TOP 1 DATE_ FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC),
        [LastTransactionTime] = (SELECT TOP 1 dbo.LG_INTTOTIME(FTIME) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = CLCARD.LOGICALREF AND FIRMDOC.INFOTYP = 21
        WHERE CLCARD.CODE LIKE '12%' AND CLCARD.CARDTYPE<> 4 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' )
		{orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
		return query;
	}


	public string GetCustomerByCode(string code) =>
		@$"SELECT
		[ReferenceId] = CLCARD.LOGICALREF,
        [Code] = CLCARD.CODE,
         [Name] = CLCARD.DEFINITION_,
        [Email] = CLCARD.EMAILADDR,
        [Telephone] = CLCARD.TELNRS1,
        [OtherTelephone] = CLCARD.TELNRS2,
        [TaxOffice] = CLCARD.TAXOFFICE,
        [TaxNumber] = CLCARD.TAXNR,
        [Email] = CLCARD.EMAILADDR,
        [Image] = FIRMDOC.LDATA,
        [Country] = CLCARD.COUNTRY,
        [City] = CLCARD.CITY,
        [County] = CLCARD.TOWN,
        [Address] = CLCARD.ADDR1,
        [ReferenceCount]=ISNULL((SELECT COUNT(DISTINCT STOCKREF) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND (AMOUNT-SHIPPEDAMOUNT) > 0 AND CLOSED = 0  AND LINETYPE = 0 AND TRCODE = 1 ),0),
		[NetTotal] = ISNULL((SELECT SUM(LINENET) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND(AMOUNT - SHIPPEDAMOUNT) > 0 AND CLOSED = 0 AND LINETYPE = 0 AND TRCODE = 1),0),
		[LastTransactionDate] = (SELECT TOP 1 DATE_ FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC),
        [LastTransactionTime] = (SELECT TOP 1 dbo.LG_INTTOTIME(FTIME) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_01_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = CLCARD.LOGICALREF AND FIRMDOC.INFOTYP = 21
        WHERE CLCARD.CODE='{code}' AND CLCARD.CARDTYPE<> 4";

	public string GetCustomerById(int id) =>
		@$"SELECT
		[ReferenceId] = CLCARD.LOGICALREF,
        [Code] = CLCARD.CODE,
         [Name] = CLCARD.DEFINITION_,
        [Email] = CLCARD.EMAILADDR,
        [Telephone] = CLCARD.TELNRS1,
        [OtherTelephone] = CLCARD.TELNRS2,
        [TaxOffice] = CLCARD.TAXOFFICE,
        [TaxNumber] = CLCARD.TAXNR,
        [Image] = FIRMDOC.LDATA,
        [Country] = CLCARD.COUNTRY,
        [City] = CLCARD.CITY,
        [County] = CLCARD.TOWN,
        [Address] = CLCARD.ADDR1,
        [ReferenceCount]=ISNULL((SELECT COUNT(DISTINCT STOCKREF) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND (AMOUNT-SHIPPEDAMOUNT) > 0 AND CLOSED = 0  AND LINETYPE = 0 AND TRCODE = 1 ),0),
		[NetTotal] = ISNULL((SELECT SUM(LINENET) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND(AMOUNT - SHIPPEDAMOUNT) > 0 AND CLOSED = 0 AND LINETYPE = 0 AND TRCODE = 1),0),
		[LastTransactionDate] = (SELECT TOP 1 DATE_ FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC),
        [LastTransactionTime] = (SELECT TOP 1 dbo.LG_INTTOTIME(FTIME) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_01_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = CLCARD.LOGICALREF AND FIRMDOC.INFOTYP = 21
        WHERE CLCARD.LOGICALREF='{id}' AND CLCARD.CARDTYPE<> 4";

	public class CustomerOrderBy
	{
		public const string CustomerCodeAsc = "ORDER BY CLCARD.CODE ASC";
		public const string CustomerCodeDesc = "ORDER BY CLCARD.CODE DESC";
		public const string CustomerNameAsc = "ORDER BY CLCARD.DEFINITION_ ASC";
		public const string CustomerNameDesc = "ORDER BY CLCARD.DEFINITION_ DESC";
	}
}
