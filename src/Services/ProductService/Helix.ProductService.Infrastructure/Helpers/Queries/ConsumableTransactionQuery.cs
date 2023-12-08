using Microsoft.Extensions.Configuration;


namespace Helix.ProductService.Infrastructure.Helpers.Queries;

public class ConsumableTransactionQuery : BaseQuery
	{
		public ConsumableTransactionQuery(IConfiguration configuration) : base(configuration)
		{
		}
		public string GetTransactionList() =>
@$"SELECT
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
            STFICHE.TRCODE = 12
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";
		public string GetTransactionById(int id) =>
		 @$"SELECT
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
            STFICHE.LOGICALREF = {id} AND STFICHE.TRCODE = 12
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";
		public string GetTransactionByCode(string code) =>
		 @$"SELECT
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
            STFICHE.FICHENO = '{code}' AND STFICHE.TRCODE = 12
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";
		public string GetTransactionByCurrentId(int id) =>
		 @$"SELECT
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
            CLCARD.LOGICALREF = {id} AND STFICHE.TRCODE = 12
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";
		public string GetTransactionByCurrentCode(string code) =>
		 @$"SELECT
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
            CLCARD.CODE = '{code}' AND STFICHE.TRCODE = 12
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";
	}
