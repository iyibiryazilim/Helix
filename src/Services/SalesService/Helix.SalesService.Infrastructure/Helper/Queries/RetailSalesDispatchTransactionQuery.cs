using Microsoft.Extensions.Configuration;

namespace Helix.SalesService.Infrastructure.Helper.Queries;

public class RetailSalesDispatchTransactionQuery : BaseQuery
{
	public RetailSalesDispatchTransactionQuery(IConfiguration configuration) : base(configuration)
	{
	}
	public string GetTransactionList(string search, string orderBy, int currentPage = 0, int pageSize = 20)
	{
		int currentIndex = pageSize * currentPage;

		string query = @$"SELECT
            [ReferenceId] = STFICHE.LOGICALREF,
            [TransactionDate] = STFICHE.DATE_,
            [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
            [Code] = STFICHE.FICHENO,
            [IOType] = STFICHE.IOCODE,
            [TransactionType] = STFICHE.TRCODE,
            [WarehouseNumber] = CAPIWHOUSE.NR,
            [WarehouseName] = CAPIWHOUSE.NAME,
            [Description] = STFICHE.GENEXP1,
            [CurrentReferenceId] = CLCARD.LOGICALREF,
            [CurrentCode] = CLCARD.CODE,
            [CurrentName] = CLCARD.DEFINITION_,
            ISNULL(SUM(STLINE.LINENET), 0) AS [NetTotal],
            COUNT(DISTINCT STLINE.STOCKREF) AS [ReferenceCount]
        FROM
            LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
            LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            STFICHE.TRCODE = 7 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%')
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_ 
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";


		return query;
	}

	public string GetTransactionById(int id)
	{
		string query = @$"SELECT
            [ReferenceId] = STFICHE.LOGICALREF,
            [TransactionDate] = STFICHE.DATE_,
            [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
            [Code] = STFICHE.FICHENO,
            [IOType] = STFICHE.IOCODE,
            [TransactionType] = STFICHE.TRCODE,
            [WarehouseNumber] = CAPIWHOUSE.NR,
            [WarehouseName] = CAPIWHOUSE.NAME,
            [Description] = STFICHE.GENEXP1,
            [CurrentReferenceId] = CLCARD.LOGICALREF,
            [CurrentCode] = CLCARD.CODE,
            [CurrentName] = CLCARD.DEFINITION_,
            ISNULL(SUM(STLINE.LINENET), 0) AS [NetTotal],
            COUNT(DISTINCT STLINE.STOCKREF) AS [ReferenceCount]
        FROM
            LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
            LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            STFICHE.LOGICALREF = {id} AND STFICHE.TRCODE = 7
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";

		return query;
	}

	public string GetTransactionByCode(string code)
	{

		string query = @$"SELECT
            [ReferenceId] = STFICHE.LOGICALREF,
            [TransactionDate] = STFICHE.DATE_,
            [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
            [Code] = STFICHE.FICHENO,
            [IOType] = STFICHE.IOCODE,
            [TransactionType] = STFICHE.TRCODE,
            [WarehouseNumber] = CAPIWHOUSE.NR,
            [WarehouseName] = CAPIWHOUSE.NAME,
            [Description] = STFICHE.GENEXP1,
            [CurrentReferenceId] = CLCARD.LOGICALREF,
            [CurrentCode] = CLCARD.CODE,
            [CurrentName] = CLCARD.DEFINITION_,
            ISNULL(SUM(STLINE.LINENET), 0) AS [NetTotal],
            COUNT(DISTINCT STLINE.STOCKREF) AS [ReferenceCount]
        FROM
            LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
            LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            STFICHE.FICHENO = '{code}' AND STFICHE.TRCODE = 7
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_";

		return query;
	}

	public string GetTransactionByCurrentId(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
	{
		int currentIndex = pageSize * currentPage;

		string query = @$"SELECT
            [ReferenceId] = STFICHE.LOGICALREF,
            [TransactionDate] = STFICHE.DATE_,
            [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
            [Code] = STFICHE.FICHENO,
            [IOType] = STFICHE.IOCODE,
            [TransactionType] = STFICHE.TRCODE,
            [WarehouseNumber] = CAPIWHOUSE.NR,
            [WarehouseName] = CAPIWHOUSE.NAME,
            [Description] = STFICHE.GENEXP1,
            [CurrentReferenceId] = CLCARD.LOGICALREF,
            [CurrentCode] = CLCARD.CODE,
            [CurrentName] = CLCARD.DEFINITION_,
            ISNULL(SUM(STLINE.LINENET), 0) AS [NetTotal],
            COUNT(DISTINCT STLINE.STOCKREF) AS [ReferenceCount]
        FROM
            LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
            LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            CLCARD.LOGICALREF = {id} AND STFICHE.TRCODE = 7 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%')
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

		return query;
	}

	public string GetTransactionByCurrentCode(string code, string search, string orderBy, int currentPage = 0, int pageSize = 20)
	{
		int currentIndex = pageSize * currentPage;

		string query = @$"SELECT
            [ReferenceId] = STFICHE.LOGICALREF,
            [TransactionDate] = STFICHE.DATE_,
            [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
            [Code] = STFICHE.FICHENO,
            [IOType] = STFICHE.IOCODE,
            [TransactionType] = STFICHE.TRCODE,
            [WarehouseNumber] = CAPIWHOUSE.NR,
            [WarehouseName] = CAPIWHOUSE.NAME,
            [Description] = STFICHE.GENEXP1,
            [CurrentReferenceId] = CLCARD.LOGICALREF,
            [CurrentCode] = CLCARD.CODE,
            [CurrentName] = CLCARD.DEFINITION_,
            ISNULL(SUM(STLINE.LINENET), 0) AS [NetTotal],
            COUNT(DISTINCT STLINE.STOCKREF) AS [ReferenceCount]
        FROM
            LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
            LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            CLCARD.CODE = '{code}' AND STFICHE.TRCODE = 7 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%')
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

		return query;
	}

}
public class RetailSalesDispatchOrderBy
{
	public const string CustomerCodeAsc = "ORDER BY CLCARD.CODE ASC";
	public const string CustomerCodeDesc = "ORDER BY CLCARD.CODE DESC";
	public const string CustomerNameAsc = "ORDER BY CLCARD.DEFINITION_ ASC";
	public const string CustomerNameDesc = "ORDER BY CLCARD.DEFINITION_ DESC";
	public const string NetTotalAsc = "ORDER BY [NetTotal] ASC";
	public const string NetTotalDesc = "ORDER BY [NetTotal] DESC";
	public const string DateAsc = "ORDER BY STFICHE.DATE_ ASC";
	public const string DateDesc = "ORDER BY STFICHE.DATE_ DESC";

}

