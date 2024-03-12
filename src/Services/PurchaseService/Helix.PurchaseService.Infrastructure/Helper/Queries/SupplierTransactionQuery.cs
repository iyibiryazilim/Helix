using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.PurchaseService.Infrastructure.Helper.Queries
{
    public class SupplierTransactionQuery : BaseQuery
    {
        public SupplierTransactionQuery(IConfiguration configuration) : base(configuration)
        {
        }
        public string GetTransactionByTransactionTypeAsync(string search, string orderBy, string currentCode, string TransactionType, int page, int pageSize)
        {
            int currentIndex = pageSize * page;
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
            LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE AS STLINE
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            STFICHE.TRCODE IN ({TransactionType}) AND CLCARD.CODE = '{currentCode}' AND STFICHE.FICHENO LIKE '%{search}%'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
        {orderBy}
        OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY
        ";
            return query;
        }


        public string GetTransactionByTransactionTypeAsync(string search, string orderBy, int currentId, string TransactionType, int page, int pageSize)
        {
            int currentIndex = pageSize * page;
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
            LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE AS STLINE
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            STFICHE.TRCODE IN ({TransactionType}) AND CLCARD.LOGICALREF = {currentId} AND STFICHE.FICHENO LIKE '%{search}%'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
        {orderBy}
        OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY
        ";
            return query;
        }

        public string GetTransactionByTransactionTypeAndWarehouseAsync(string search, string orderBy, int currentId, int warehouseNumber,string TransactionType, int page, int pageSize)
        {
            int currentIndex = pageSize * page;
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
            LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE AS STLINE
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            STFICHE.TRCODE IN ({TransactionType}) AND CLCARD.LOGICALREF = {currentId} AND STFICHE.FICHENO LIKE '%{search}%' AND CAPIWHOUSE.NR = {warehouseNumber}
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
        {orderBy}
        OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY
        ";
            return query;
        }

        public string GetTransactionByTransactionTypeAndWarehouseAndShipInfoAsync(string search, string orderBy, int currentId, int warehouseNumber,int shipInfoReferenceId, string TransactionType, int page, int pageSize)
        {
            int currentIndex = pageSize * page;
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
            LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE AS STLINE
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            STFICHE.TRCODE IN ({TransactionType}) AND CLCARD.LOGICALREF = {currentId} AND STFICHE.FICHENO LIKE '%{search}%' AND CAPIWHOUSE.NR = {warehouseNumber} AND STFICHE.SHIPINFOREF = {shipInfoReferenceId}
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
        {orderBy}
        OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY
        ";
            return query;
        }

        public string GetInputTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
        {
            int currentIndex = pageSize * page;

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
            LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE AS STLINE
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            STFICHE.IOCODE IN (1,2) AND CLCARD.CODE ='{code}'AND STFICHE.FICHENO LIKE '%{search}%'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
        {orderBy}
        OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
        }

        public string GetInputTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize)
        {
            int currentIndex = pageSize * page;

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
            LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE AS STLINE
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            STFICHE.IOCODE IN (1,2) AND CLCARD.LOGICALREF ={id} AND STFICHE.FICHENO LIKE '%{search}%'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
        {orderBy}
        OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
        }
        public string GetOutputTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
        {
            int currentIndex = pageSize * page;

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
            LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE AS STLINE
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            STFICHE.IOCODE IN (3,4) AND CLCARD.CODE ='{code}'AND STFICHE.FICHENO LIKE '%{search}%'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
        {orderBy}
        OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
        }
        public string GetOutputTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize)
        {
            int currentIndex = pageSize * page;

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
            LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE AS STLINE
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            STFICHE.IOCODE IN (3,4) AND CLCARD.LOGICALREF ={id} AND STFICHE.FICHENO LIKE '%{search}%'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
        {orderBy}
        OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
        }

        public string GetTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
        {
            int currentIndex = pageSize * page;

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
            LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE AS STLINE
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
            CLCARD.CODE ='{code}'AND STFICHE.FICHENO LIKE '%{search}%'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
        {orderBy}
        OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
        }

        public string GetTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize)
        {
            int currentIndex = pageSize * page;

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
            LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STLINE AS STLINE
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
            LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
            LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        WHERE
             CLCARD.LOGICALREF ={id} AND STFICHE.FICHENO LIKE '%{search}%'
        GROUP BY
            STFICHE.LOGICALREF, STFICHE.FICHENO, STFICHE.DATE_, dbo.LG_INTTOTIME(STFICHE.FTIME), STFICHE.TRCODE, STFICHE.GENEXP1,
            STFICHE.IOCODE, CAPIWHOUSE.NR, CAPIWHOUSE.NAME, CLCARD.LOGICALREF, CLCARD.CODE, CLCARD.DEFINITION_
        {orderBy}
        OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
        }
    }
    public class SupplierTransactionOrderBy
    {
        public const string DateAsc = "ORDER BY STFICHE.DATE_ ASC";
        public const string DateDesc = "ORDER BY STFICHE.DATE_ DESC";
        public const string CodeAsc = "ORDER BY STFICHE.FICHENO ASC";
        public const string CodeDesc = "ORDER BY STFICHE.FICHENO DESC";
    }
}

