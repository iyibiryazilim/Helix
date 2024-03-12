using Microsoft.Extensions.Configuration;

namespace Helix.Queries;

public class SupplierQuery : BaseQuery
{
	public SupplierQuery(IConfiguration configuration) : base(configuration)
	{
	}
	public string GetSupplierList() =>
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
        WHERE CLCARD.CODE LIKE '32%' AND CLCARD.CARDTYPE<> 4";

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
        [ReferenceCount]=ISNULL((SELECT COUNT(DISTINCT STOCKREF) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND (AMOUNT-SHIPPEDAMOUNT) > 0 AND CLOSED = 0  AND LINETYPE = 0 AND TRCODE = 1 ),0),
		[NetTotal] = ISNULL((SELECT SUM(LINENET) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND(AMOUNT - SHIPPEDAMOUNT) > 0 AND CLOSED = 0 AND LINETYPE = 0 AND TRCODE = 1),0),
		[LastTransactionDate] = (SELECT TOP 1 DATE_ FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC),
        [LastTransactionTime] = (SELECT TOP 1 dbo.LG_INTTOTIME(FTIME) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_01_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = CLCARD.LOGICALREF AND FIRMDOC.INFOTYP = 21
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
        [ReferenceCount]=ISNULL((SELECT COUNT(DISTINCT STOCKREF) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND (AMOUNT-SHIPPEDAMOUNT) > 0 AND CLOSED = 0  AND LINETYPE = 0 AND TRCODE = 1 ),0),
		[NetTotal] = ISNULL((SELECT SUM(LINENET) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE WHERE CLIENTREF = CLCARD.LOGICALREF AND(AMOUNT - SHIPPEDAMOUNT) > 0 AND CLOSED = 0 AND LINETYPE = 0 AND TRCODE = 1),0),
		[LastTransactionDate] = (SELECT TOP 1 DATE_ FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC),
        [LastTransactionTime] = (SELECT TOP 1 dbo.LG_INTTOTIME(FTIME) FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_01_STLINE WHERE CLIENTREF = CLCARD.LOGICALREF ORDER BY DATE_ DESC)
        FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD
		LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_FIRMDOC AS FIRMDOC ON FIRMDOC.INFOREF = CLCARD.LOGICALREF AND FIRMDOC.INFOTYP = 21
        WHERE CLCARD.LOGICALREF='{id}' AND CLCARD.CARDTYPE<> 4";
}
