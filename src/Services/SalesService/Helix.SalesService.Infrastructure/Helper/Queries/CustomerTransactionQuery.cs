using Microsoft.Extensions.Configuration;

namespace Helix.SalesService.Infrastructure.Helper.Queries
{
	public class CustomerTransactionQuery : BaseQuery
	{
		public CustomerTransactionQuery(IConfiguration configuration) : base(configuration)
		{
		}
		public string GetTransactionByTransactionTypeAsync(string currentCode, string TransactionType) =>
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
            STFICHE.TRCODE IN ({TransactionType}) AND CLCARD.CODE = '{currentCode}'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";

		public string GetTransactionByTransactionTypeAsync(int currentId, string TransactionType) =>
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
            STFICHE.TRCODE IN ({TransactionType}) AND CLCARD.LOGICALREF = '{currentId}'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";

		public string GetInputTransactionByCurrentCode(string code) =>
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
            STFICHE.IOCODE IN (1,2) AND CLCARD.CODE ='{code}'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";
		public string GetInputTransactionByCurrentId(int id) =>
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
            STFICHE.IOCODE IN (1,2) AND CLCARD.CODE ='{id}'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";
		public string GetOutputTransactionByCurrentCode(string code) =>
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
            STFICHE.IOCODE IN (3,4) AND CLCARD.CODE ='{code}'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";
		public string GetOutputTransactionByCurrentId(int id) =>
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
            STFICHE.IOCODE IN (3,4) AND CLCARD.CODE ='{id}'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_;";
	}
}
