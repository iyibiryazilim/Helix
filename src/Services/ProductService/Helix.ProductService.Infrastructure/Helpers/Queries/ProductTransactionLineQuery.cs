using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;

namespace Helix.ProductService.Infrastructure.Helpers.Queries
{
	public class ProductTransactionLineQuery : BaseQuery
	{
		public ProductTransactionLineQuery(IConfiguration configuration) : base(configuration)
		{
		}
		public string GetTransactionLinesByProductCodeAsync(string ProductCode, string search, string orderBy, int currentPage = 0, int pageSize = 20)
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
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
	    WHERE ITEMS.CODE= '{ProductCode}' AND (CLCARD.CODE LIKE '%{search}%' 
        OR CLCARD.DEFINITION_ LIKE '%{search}%' 
        OR STFICHE.FICHENO LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%' OR CAPIWHOUSE.NAME LIKE '%{search}%')
		{orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
		public string GetTransactionLinesByProductIdAsync(int ProductId, string search, string orderBy, int currentPage = 0, int pageSize = 20)
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
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
	    WHERE ITEMS.LOGICALREF= {ProductId} AND (CLCARD.CODE LIKE '%{search}%' 
        OR CLCARD.DEFINITION_ LIKE '%{search}%' 
        OR STFICHE.FICHENO LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%' OR CAPIWHOUSE.NAME LIKE '%{search}%')
		{orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}

		public string GetTransactionLineByTransactionTypeAsync(string ProductCode, string TransactionType, string search, string orderBy, int currentPage = 0, int pageSize = 20)
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
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
	    WHERE  STLINE.TRCODE IN ({TransactionType}) AND ITEMS.CODE= '{ProductCode}' AND (CLCARD.CODE LIKE '%{search}%' 
        OR CLCARD.DEFINITION_ LIKE '%{search}%' 
        OR STFICHE.FICHENO LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%' OR CAPIWHOUSE.NAME LIKE '%{search}%')
		{orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

		return query;
        }

        
		public string GetTransactionLineByTransactionTypeAsync(int ProductId, string TransactionType, string search, string orderBy, int currentPage = 0, int pageSize = 20)
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
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.TRCODE IN ({TransactionType}) AND ITEMS.LOGICALREF= {ProductId} AND (CLCARD.CODE LIKE '%{search}%' 
        OR CLCARD.DEFINITION_ LIKE '%{search}%' 
        OR STFICHE.FICHENO LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%' OR CAPIWHOUSE.NAME LIKE '%{search}%')
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

            return query;
		}
		
		public string GetInputTransactionLineByProductId(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
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
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.IOCODE IN (1,2) AND ITEMS.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' 
        OR CLCARD.DEFINITION_ LIKE '%{search}%' 
        OR STFICHE.FICHENO LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%' OR CAPIWHOUSE.NAME LIKE '%{search}%')
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
					
		public string GetInputTransactionLineByProductCode(string code, string search, string orderBy, int currentPage = 0, int pageSize = 20)
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
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.IOCODE IN (1,2) AND ITEMS.CODE = '{code}' AND (CLCARD.CODE LIKE '%{search}%' 
        OR CLCARD.DEFINITION_ LIKE '%{search}%' 
        OR STFICHE.FICHENO LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%' OR CAPIWHOUSE.NAME LIKE '%{search}%')
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
					
		public string GetOutputTransactionLineByProductId(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
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
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.IOCODE IN (3,4) AND ITEMS.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' 
        OR CLCARD.DEFINITION_ LIKE '%{search}%' 
        OR STFICHE.FICHENO LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%' OR CAPIWHOUSE.NAME LIKE '%{search}%')
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
				
		public string GetOutputTransactionLineByProductCode(string code, string search, string orderBy, int currentPage = 0, int pageSize = 20)
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
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STLINE.IOCODE IN (3,4) AND ITEMS.CODE = '{code}' AND (CLCARD.CODE LIKE '%{search}%' 
        OR CLCARD.DEFINITION_ LIKE '%{search}%' 
        OR STFICHE.FICHENO LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%' OR CAPIWHOUSE.NAME LIKE '%{search}%')
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}

		public string GetTransactionLineByFicheId(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
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
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STFICHE.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' 
        OR CLCARD.DEFINITION_ LIKE '%{search}%' 
        OR STFICHE.FICHENO LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%' OR CAPIWHOUSE.NAME LIKE '%{search}%')
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
			
		public string GetTransactionLineByFicheCode(string code, string search, string orderBy, int currentPage = 0, int pageSize = 20)
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
		[CurrentName] = CLCARD.DEFINITION_
        
        FROM LG_00{FirmNumber}_0{PeriodNumber}_STLINE AS STLINE
        LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_STFICHE AS STFICHE ON STLINE.STFICHEREF = STFICHE.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON STLINE.STOCKREF = ITEMS.LOGICALREF
		LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON STLINE.CLIENTREF = CLCARD.LOGICALREF
        LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON STLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
        LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON STLINE.USREF = UNITSET.LOGICALREF
		LEFT JOIN L_CAPIWHOUSE AS CAPIWHOUSE ON STLINE.SOURCEINDEX = CAPIWHOUSE.NR AND CAPIWHOUSE.FIRMNR = {FirmNumber}
		WHERE STFICHE.CODE = '{code}' AND (CLCARD.CODE LIKE '%{search}%' 
        OR CLCARD.DEFINITION_ LIKE '%{search}%' 
        OR STFICHE.FICHENO LIKE '%{search}%' OR STLINE.DATE_ LIKE '%{search}%' OR CAPIWHOUSE.NAME LIKE '%{search}%')
        {orderBy}
		OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
					
	}
	public class ProductTransactionLineOrderBy
	{
		public const string QuantityAsc = "ORDER BY STLINE.AMOUNT ASC";
		public const string QuantityDesc = "ORDER BY STLINE.AMOUNT DESC";
		public const string DateAsc = "ORDER BY STLINE.DATE_ ASC";
		public const string DateDesc = "ORDER BY STLINE.DATE_ DESC";
	}

}
