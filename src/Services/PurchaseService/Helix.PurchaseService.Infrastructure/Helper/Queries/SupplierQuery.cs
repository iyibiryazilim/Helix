using Microsoft.Extensions.Configuration;

namespace Helix.PurchaseService.Infrastructure.Helper.Queries;

public class SupplierQuery : BaseQuery
{
	public SupplierQuery(IConfiguration configuration) : base(configuration)
	{
	}
	public string GetSupplierList(string search, string orderBy, int currentPage = 0, int pageSize = 20)
    {
		int currentIndex = pageSize * currentPage;
        string query = @$"SELECT
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
        [ReferenceCount]=ISNULL((SELECT COUNT(DISTINCT STOCKREF) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND (AMOUNT-SHIPPEDAMOUNT) > 0 AND CLOSED = 0  AND LINETYPE = 0 AND TRCODE = 1 ),0),
		[NetTotal] = ISNULL((SELECT SUM(LINENET) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND(AMOUNT - SHIPPEDAMOUNT) > 0 AND CLOSED = 0 AND LINETYPE = 0 AND TRCODE = 1),0),
		[LastTransactionDate] = (SELECT TOP 1 DATE_ FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC),
        [LastTransactionTime] = (SELECT TOP 1 dbo.LG_INTTOTIME(FTIME) FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_00{FirmNumber}_CLCARD AS CLCARD
		LEFT JOIN LG_00{FirmNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = CLCARD.LOGICALREF AND FIRMDOC.INFOTYP = 21
        WHERE CLCARD.CODE LIKE '32%' AND CLCARD.CARDTYPE<> 4 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' )
		{orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
        return query;
	}
		

	public string GetSupplierByCode(string code) =>
		@$"SELECT
		[ReferenceId] = CLCARD.LOGICALREF,
        [Code] = CLCARD.CODE,
      [Name] = CLCARD.DEFINITION_,
        [Telephone] = CLCARD.TELNRS1,
        [Email] = CLCARD.EMAILADDR,
        [OtherTelephone] = CLCARD.TELNRS2,
        [TaxOffice] = CLCARD.TAXOFFICE,
        [TaxNumber] = CLCARD.TAXNR,
        [Image] = FIRMDOC.LDATA,
        [Country] = CLCARD.COUNTRY,
        [City] = CLCARD.CITY,
        [County] = CLCARD.TOWN,
        [Address] = CLCARD.ADDR1,
        [ReferenceCount]=ISNULL((SELECT COUNT(DISTINCT STOCKREF) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND (AMOUNT-SHIPPEDAMOUNT) > 0 AND CLOSED = 0  AND LINETYPE = 0 AND TRCODE = 1 ),0),
		[NetTotal] = ISNULL((SELECT SUM(LINENET) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND(AMOUNT - SHIPPEDAMOUNT) > 0 AND CLOSED = 0 AND LINETYPE = 0 AND TRCODE = 1),0),
		[LastTransactionDate] = (SELECT TOP 1 DATE_ FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC),
        [LastTransactionTime] = (SELECT TOP 1 dbo.LG_INTTOTIME(FTIME) FROM LG_00{FirmNumber}_01_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_00{FirmNumber}_CLCARD AS CLCARD
		LEFT JOIN LG_00{FirmNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = CLCARD.LOGICALREF AND FIRMDOC.INFOTYP = 21
        WHERE CLCARD.CODE='{code}' AND CLCARD.CARDTYPE<> 4";

	public string GetSupplierById(int id) =>
		@$"SELECT
		[ReferenceId] = CLCARD.LOGICALREF,
        [Code] = CLCARD.CODE,
        [Name] = CLCARD.DEFINITION_,
        [Telephone] = CLCARD.TELNRS1,
        [OtherTelephone] = CLCARD.TELNRS2,
        [Email] = CLCARD.EMAILADDR,
        [TaxOffice] = CLCARD.TAXOFFICE,
        [TaxNumber] = CLCARD.TAXNR,
        [Image] = FIRMDOC.LDATA,
        [Country] = CLCARD.COUNTRY,
        [City] = CLCARD.CITY,
        [County] = CLCARD.TOWN,
        [Address] = CLCARD.ADDR1,
        [ReferenceCount]=ISNULL((SELECT COUNT(DISTINCT STOCKREF) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND (AMOUNT-SHIPPEDAMOUNT) > 0 AND CLOSED = 0  AND LINETYPE = 0 AND TRCODE = 1 ),0),
		[NetTotal] = ISNULL((SELECT SUM(LINENET) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND(AMOUNT - SHIPPEDAMOUNT) > 0 AND CLOSED = 0 AND LINETYPE = 0 AND TRCODE = 1),0),
		[LastTransactionDate] = (SELECT TOP 1 DATE_ FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC),
        [LastTransactionTime] = (SELECT TOP 1 dbo.LG_INTTOTIME(FTIME) FROM LG_00{FirmNumber}_01_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_00{FirmNumber}_CLCARD AS CLCARD
		LEFT JOIN LG_00{FirmNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = CLCARD.LOGICALREF AND FIRMDOC.INFOTYP = 21
        WHERE CLCARD.LOGICALREF='{id}' AND CLCARD.CARDTYPE<> 4";

	public class SupplierOrderBy
	{
		public const string SupplierCodeAsc = "ORDER BY CLCARD.CODE ASC";
		public const string SupplierCodeDesc = "ORDER BY CLCARD.CODE DESC";
		public const string SupplierNameAsc = "ORDER BY CLCARD.DEFINITION_ ASC";
		public const string SupplierNameDesc = "ORDER BY CLCARD.DEFINITION_ DESC";
	}
}
