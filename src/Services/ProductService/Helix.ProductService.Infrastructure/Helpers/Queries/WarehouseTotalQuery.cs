using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Helix.ProductService.Infrastructure.Helpers.Queries
{
	public class WarehouseTotalQuery : BaseQuery
	{
		public WarehouseTotalQuery(IConfiguration configuration) : base(configuration)
		{
		}
		public string GetTransactionsByWarehouseNumber(int number, short CardType,string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"Select 
            [ProductReferenceId] = STINVTOT.STOCKREF,
            [ProductCode] = ITEMS.CODE,
            [ProductName] = ITEMS.NAME,
            [SubUnitsetCode] = UNITSET.CODE,
            [SubUnitsetReferenceId] = UNITSET.LOGICALREF,
            [UnitsetCode] = BASEUNITSET.CODE,
            [UnitsetReferenceId] = BASEUNITSET.LOGICALREF,
            [OnHand] = ISNULL(SUM(STINVTOT.ONHAND),0),
            from LV_00{FirmNumber}_0{PeriodNumber}_STINVTOT AS STINVTOT 
            LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STINVTOT.STOCKREF = ITEMS.LOGICALREF
             LEFT JOIN LG_00{FirmNumber}_UNITSETF AS BASEUNITSET ON ITEMS.UNITSETREF = BASEUNITSET.LOGICALREF
            LEFT JOIN LG_00{FirmNumber}_UNITSETL AS UNITSET ON UNITSET.UNITSETREF = BASEUNITSET.LOGICALREF AND MAINUNIT = 1
            
            WHERE  (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ITEMS.CARDTYPE LIKE %{search}%)
            GROUP BY STINVTOT.STOCKREF,STINVTOT.INVENNO,ITEMS.CODE,ITEMS.NAME,UNITSET.CODE,UNITSET.LOGICALREF,UNITSET.CODE,
			BASEUNITSET.CODE,BASEUNITSET.LOGICALREF
            HAVING STINVTOT.INVENNO = 
            {number} AND ITEMS.CODE <> 'ÿ'
{orderBy}
OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
		public string GetInputTransactionByWarehouseNumber(int number, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[BaseTransactionReferenceId] = STFICHE.LOGICALREF,
        [BaseTransactionCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitsetCode] = SUBUNITSET.CODE,
        [SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
        [UnitsetCode] = UNITSET.CODE,
        [UnitsetReferenceId] = UNITSET.LOGICALREF,
        [Quantity] = STLINE.AMOUNT,
        [Description] = STLINE.LINEEXP,
        [IOType] = STLINE.IOCODE,
		[UnitPrice] = STLINE.PRICE,
        [WarehouseNumber] = CAPIWHOUSE.NR,
        [WarehouseName] = CAPIWHOUSE.NAME,
		[CurrentReferenceId] = CLCARD.LOGICALREF,
		[CurrentCode] = CLCARD.CODE,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_0000{FirmNumber}_00{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_0000{FirmNumber}_00{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_0000{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_0000{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_0000{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_0000{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = 00{FirmNumber}
		WHERE STLINE.IOCODE IN (1,2) AND CAPIWHOUSE.NR = {number} AND (ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%' OR CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%')
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
		public string GetInputTransactionByWarehouseReferenceId(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[BaseTransactionReferenceId] = STFICHE.LOGICALREF,
        [BaseTransactionCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitsetCode] = SUBUNITSET.CODE,
        [SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
        [UnitsetCode] = UNITSET.CODE,
        [UnitsetReferenceId] = UNITSET.LOGICALREF,
        [Quantity] = STLINE.AMOUNT,
        [Description] = STLINE.LINEEXP,
        [IOType] = STLINE.IOCODE,
		[UnitPrice] = STLINE.PRICE,
        [WarehouseNumber] = CAPIWHOUSE.NR,
        [WarehouseName] = CAPIWHOUSE.NAME,
		[CurrentReferenceId] = CLCARD.LOGICALREF,
		[CurrentCode] = CLCARD.CODE,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_0000{FirmNumber}_00{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_0000{FirmNumber}_00{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_0000{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_0000{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_0000{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_0000{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = 00{FirmNumber}
		WHERE STLINE.IOCODE IN (1,2) AND CAPIWHOUSE.LOGICALREF = {id} AND (ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%' OR CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%')
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}

		public string GetOutputTransactionByWarehouseNumber(int number, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[BaseTransactionReferenceId] = STFICHE.LOGICALREF,
        [BaseTransactionCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitsetCode] = SUBUNITSET.CODE,
        [SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
        [UnitsetCode] = UNITSET.CODE,
        [UnitsetReferenceId] = UNITSET.LOGICALREF,
        [Quantity] = STLINE.AMOUNT,
        [Description] = STLINE.LINEEXP,
        [IOType] = STLINE.IOCODE,
		[UnitPrice] = STLINE.PRICE,
        [WarehouseNumber] = CAPIWHOUSE.NR,
        [WarehouseName] = CAPIWHOUSE.NAME,
		[CurrentReferenceId] = CLCARD.LOGICALREF,
		[CurrentCode] = CLCARD.CODE,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_0000{FirmNumber}_00{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_0000{FirmNumber}_00{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_0000{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_0000{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_0000{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_0000{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = 00{FirmNumber}
		WHERE STLINE.IOCODE IN (3,4) AND CAPIWHOUSE.NR = {number} AND (ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%' OR CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%')
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}

		public string GetOutputTransactionByWarehouseReferenceId(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[BaseTransactionReferenceId] = STFICHE.LOGICALREF,
        [BaseTransactionCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitsetCode] = SUBUNITSET.CODE,
        [SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
        [UnitsetCode] = UNITSET.CODE,
        [UnitsetReferenceId] = UNITSET.LOGICALREF,
        [Quantity] = STLINE.AMOUNT,
        [Description] = STLINE.LINEEXP,
        [IOType] = STLINE.IOCODE,
		[UnitPrice] = STLINE.PRICE,
        [WarehouseNumber] = CAPIWHOUSE.NR,
        [WarehouseName] = CAPIWHOUSE.NAME,
		[CurrentReferenceId] = CLCARD.LOGICALREF,
		[CurrentCode] = CLCARD.CODE,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_0000{FirmNumber}_00{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_0000{FirmNumber}_00{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_0000{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_0000{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_0000{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_0000{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = 00{FirmNumber}
		WHERE STLINE.IOCODE IN (3,4) AND CAPIWHOUSE.LOGICALREF = {id} AND (ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%' OR CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%')
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}

		public class WarehouseTransactionOrderBy
		{
			public const string QuantityAsc = "ORDER BY STLINE.AMOUNT ASC";
			public const string QuantityDesc = "ORDER BY STLINE.AMOUNT DESC";
			public const string DateAsc = "ORDER BY STLINE.DATE_ ASC";
			public const string DateDesc = "ORDER BY STLINE.DATE_ DESC";
		}
	}
}
