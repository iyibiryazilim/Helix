using Microsoft.Extensions.Configuration;

namespace Helix.SalesService.Infrastructure.Helper.Queries;

public class CustomerQuery : BaseQuery
{
	public CustomerQuery(IConfiguration configuration) : base(configuration)
	{
	}

	public string GetCustomerList() =>
			@$"SELECT
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
        [ReferenceCount]=ISNULL((SELECT COUNT(DISTINCT STOCKREF) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND (AMOUNT-SHIPPEDAMOUNT) > 0 AND CLOSED = 0  AND LINETYPE = 0 AND TRCODE = 1 ),0),
		[NetTotal] = ISNULL((SELECT SUM(LINENET) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND(AMOUNT - SHIPPEDAMOUNT) > 0 AND CLOSED = 0 AND LINETYPE = 0 AND TRCODE = 1),0),
		[LastTransactionDate] = (SELECT TOP 1 DATE_ FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC),
        [LastTransactionTime] = (SELECT TOP 1 dbo.LG_INTTOTIME(FTIME) FROM LG_00{FirmNumber}_01_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_00{FirmNumber}_CLCARD AS CLCARD
		LEFT JOIN LG_00{FirmNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = CLCARD.LOGICALREF AND FIRMDOC.INFOTYP = 21
        WHERE CLCARD.CODE LIKE '12%' AND CLCARD.CARDTYPE<> 4";

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
        [ReferenceCount]=ISNULL((SELECT COUNT(DISTINCT STOCKREF) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND (AMOUNT-SHIPPEDAMOUNT) > 0 AND CLOSED = 0  AND LINETYPE = 0 AND TRCODE = 1 ),0),
		[NetTotal] = ISNULL((SELECT SUM(LINENET) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND(AMOUNT - SHIPPEDAMOUNT) > 0 AND CLOSED = 0 AND LINETYPE = 0 AND TRCODE = 1),0),
		[LastTransactionDate] = (SELECT TOP 1 DATE_ FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC),
        [LastTransactionTime] = (SELECT TOP 1 dbo.LG_INTTOTIME(FTIME) FROM LG_00{FirmNumber}_01_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_00{FirmNumber}_CLCARD AS CLCARD
		LEFT JOIN LG_00{FirmNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = CLCARD.LOGICALREF AND FIRMDOC.INFOTYP = 21
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
        [ReferenceCount]=ISNULL((SELECT COUNT(DISTINCT STOCKREF) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND (AMOUNT-SHIPPEDAMOUNT) > 0 AND CLOSED = 0  AND LINETYPE = 0 AND TRCODE = 1 ),0),
		[NetTotal] = ISNULL((SELECT SUM(LINENET) FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND(AMOUNT - SHIPPEDAMOUNT) > 0 AND CLOSED = 0 AND LINETYPE = 0 AND TRCODE = 1),0),
		[LastTransactionDate] = (SELECT TOP 1 DATE_ FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC),
        [LastTransactionTime] = (SELECT TOP 1 dbo.LG_INTTOTIME(FTIME) FROM LG_00{FirmNumber}_01_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_00{FirmNumber}_CLCARD AS CLCARD
		LEFT JOIN LG_00{FirmNumber}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = CLCARD.LOGICALREF AND FIRMDOC.INFOTYP = 21
        WHERE CLCARD.LOGICALREF='{id}' AND CLCARD.CARDTYPE<> 4";
	
}
