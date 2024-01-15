using Microsoft.Extensions.Configuration;

namespace Helix.PurchaseService.Infrastructure.Helper.Queries
{
	public class PurchaseDispatchTransactionLineQuery : BaseQuery
	{
		public PurchaseDispatchTransactionLineQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetTransactionList(string search, string orderBy, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[FicheReferenceId] = STFICHE.LOGICALREF,
        [FicheCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitset] = SUBUNITSET.CODE,
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
        [DocumentNumber] = STFICHE.DOCODE,
		[DocumentTrackingNumber] = STFICHE.DOCTRACKINGNR,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.TRCODE = 1 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%' )
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;

		}

		public string GetTransactionById(int id) =>
		@$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[FicheReferenceId] = STFICHE.LOGICALREF,
        [FicheCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitset] = SUBUNITSET.CODE,
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
        [DocumentNumber] = STFICHE.DOCODE,
		[DocumentTrackingNumber] = STFICHE.DOCTRACKINGNR,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.TRCODE = 1 AND STLINE.LOGICALREF = {id}";
		public string GetTransactionByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
        {
			int currentIndex = pageSize * page;

			string query = @$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[FicheReferenceId] = STFICHE.LOGICALREF,
        [FicheCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitset] = SUBUNITSET.CODE,
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
        [DocumentNumber] = STFICHE.DOCODE,
		[DocumentTrackingNumber] = STFICHE.DOCTRACKINGNR,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.TRCODE = 1 AND CLCARD.CODE = '{code}' AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%' )
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
		}

		public string GetTransactionByCurrentId(string search, string orderBy, int id, int page, int pageSize)
        {
			int currentIndex = pageSize * page;

			string query = @$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[FicheReferenceId] = STFICHE.LOGICALREF,
        [FicheCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitset] = SUBUNITSET.CODE,
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
        [DocumentNumber] = STFICHE.DOCODE,
		[DocumentTrackingNumber] = STFICHE.DOCTRACKINGNR,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.TRCODE = 1 AND CLCARD.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%' )
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
		}
					
		public string GetTransactionByProductCode(string search, string orderBy, string code, int page, int pageSize )
        {
			int currentIndex = pageSize * page;

			string query = @$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[FicheReferenceId] = STFICHE.LOGICALREF,
        [FicheCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitset] = SUBUNITSET.CODE,
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
        [DocumentNumber] = STFICHE.DOCODE,
		[DocumentTrackingNumber] = STFICHE.DOCTRACKINGNR,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.TRCODE = 1 AND ITEMS.CODE = '{code}' AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%' )
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
		}
					
		public string GetTransactionByProductId(string search, string orderBy, int id, int page, int pageSize)
        {
			int currentIndex = pageSize * page;

			string query = @$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[FicheReferenceId] = STFICHE.LOGICALREF,
        [FicheCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitset] = SUBUNITSET.CODE,
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
        [DocumentNumber] = STFICHE.DOCODE,
		[DocumentTrackingNumber] = STFICHE.DOCTRACKINGNR,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.TRCODE = 1 AND ITEMS.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%' )
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
		}
				
		public string GetTransactionByFicheCode(string search, string orderBy, string code, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[FicheReferenceId] = STFICHE.LOGICALREF,
        [FicheCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitset] = SUBUNITSET.CODE,
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
        [DocumentNumber] = STFICHE.DOCODE,
		[DocumentTrackingNumber] = STFICHE.DOCTRACKINGNR,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.TRCODE = 1 AND STFICHE.FICHENO = '{code}' AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%' )
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
		}
		
		public string GetTransactionByFicheId(string search, string orderBy, int id, int page, int pageSize)
        {
			int currentIndex = pageSize * page;

			string query = @$"SELECT
        [ReferenceId] = STLINE.LOGICALREF,
        [TransactionDate] = STLINE.DATE_,
        [TransactionTime] = dbo.LG_INTTOTIME(STFICHE.FTIME),
		[FicheReferenceId] = STFICHE.LOGICALREF,
        [FicheCode] = STFICHE.FICHENO,
        [TransactionType] = STLINE.TRCODE,
        [ProductReferenceId] = STLINE.STOCKREF,
        [ProductCode] = ITEMS.CODE,
        [ProductName] = ITEMS.NAME,
        [SubUnitset] = SUBUNITSET.CODE,
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
        [DocumentNumber] = STFICHE.DOCODE,
		[DocumentTrackingNumber] = STFICHE.DOCTRACKINGNR,
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.TRCODE = 1 AND STFICHE.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR STFICHE.FICHENO LIKE '%{search}%' )
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            return query;
		}

		public class PurchaseDispatchTransactionLineOrderBy
		{
			public const string DateAsc = "ORDER BY STLINE.DATE_ ASC";
			public const string DateDesc = "ORDER BY STLINE.DATE_ DESC";
			public const string FicheCodeAsc = "ORDER BY STLINE.FICHENO ASC";
			public const string FicheCodeDesc = "ORDER BY STLINE.FICHENO DESC";
			public const string ProductCodeAsc = "ORDER BY ITEMS.CODE ASC";
			public const string ProductCodeDesc = "ORDER BY ITEMS.CODE DESC";
			public const string ProductNameAsc = "ORDER BY ITEMS.NAME ASC";
			public const string ProductNameDesc = "ORDER BY ITEMS.NAME DESC";
		}
	}
}
