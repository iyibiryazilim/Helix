using Microsoft.Extensions.Configuration;

namespace Helix.SalesService.Infrastructure.Helper.Queries
{
	public class SalesOrderLineQuery : BaseQuery
	{
		public SalesOrderLineQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetSalesOrderLineQuery(string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
			

		public string GetWaitingSalesOrderLineQuery(string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
			

		public string GetSalesOrderLineByFicheCodeQuery(string code, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND ORFICHE.FICHENO = '{code}' AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
		public string GetWaitingSalesOrderLineByFicheCodeQuery(string code, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND ORFICHE.FICHENO = '{code}' AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}



		public string GetSalesOrderLineByFicheIdQuery(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND ORFICHE.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
		public string GetWaitingSalesOrderLineByFicheIdQuery(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND ORFICHE.LOGICALREF = {id} AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}


		#region Current Filter
		public string GetSalesOrderLineByCurrentIdQuery(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20){

			int currentIndex = pageSize * currentPage;

			string query = $@"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND CLCARD.LOGICALREF = {id} AND (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
		public string GetWaitingSalesOrderLineByCurrentIdQuery(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND CLCARD.LOGICALREF = {id} AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 AND (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}

        public string GetWaitingSalesOrderLineByCurrentIdAndWarehouseNumberQuery(int id,int warehouseNumber, string search, string orderBy, int currentPage = 0, int pageSize = 20)
        {
            int currentIndex = pageSize * currentPage;

            string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND CLCARD.LOGICALREF = {id} AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 
			AND (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%') AND WHOUSE.NR = {warehouseNumber}
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

            return query;
        }
        public string GetWaitingSalesOrderLineByCurrentIdAndWarehouseNumberAndShipInfoQuery(int id, int warehouseNumber,int shipInfoReferenceId, string search, string orderBy, int currentPage = 0, int pageSize = 20)
        {
            int currentIndex = pageSize * currentPage;

            string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber} 
			WHERE ORFLINE.TRCODE = 1 AND CLCARD.LOGICALREF = {id} AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 
			AND (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%') 
			AND WHOUSE.NR = {warehouseNumber} AND ORFICHE.SHIPINFOREF = {shipInfoReferenceId}
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

            return query;
        }
        
		public string GetSalesOrderLineByCurrentCodeQuery(string code, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND CLCARD.CODE = '{code}' AND (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
			
		public string GetWaitingSalesOrderLineByCurrentCodeQuery(string code, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = $@"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND CLCARD.CODE = '{code}' AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 AND (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
		#endregion

		#region Product Filter
		public string GetSalesOrderLineByProductIdQuery(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND ITEMS.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
			
		public string GetWaitingSalesOrderLineByProductIdQuery(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = $@"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND ITEMS.LOGICALREF = {id} AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
		public string GetSalesOrderLineByProductCodeQuery(string code, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = $@"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND ITEMS.CODE = '{code}' AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
		public string GetWaitingSalesOrderLineByProductCodeQuery(string code, string search, string orderBy, int currentPage = 0, int pageSize = 20){

			int currentIndex = pageSize * currentPage;

			string query = $@"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[OrderCode] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFLINE.LINEEXP,
			[UnitPrice] = ORFLINE.PRICE,
			[VatRate] = ORFLINE.VAT,
			[ProductReferenceId] = ORFLINE.STOCKREF,
			[ProductCode] = ITEMS.CODE,
			[ProductName] = ITEMS.NAME,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[SubUnitsetCode] = SUBUNITSET.CODE,
			[SubUnitsetReferenceId] = SUBUNITSET.LOGICALREF,
			[UnitsetCode] = UNITSET.CODE,
			[UnitsetReferenceId] = UNITSET.LOGICALREF,
			[Quantity] = ORFLINE.AMOUNT,
			[ShippedQuantity] = ORFLINE.SHIPPEDAMOUNT,
			[WaitingQuantity] = (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT),
			[DueDate] = ORFLINE.DUEDATE,
			[NetTotal] = ORFLINE.LINENET,
			[VatRate] = ORFLINE.VAT
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 1 AND ITEMS.CODE = '{code}' AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
		#endregion
	}

	public class SalesOrderLineOrderBy
	{
		public const string CustomerCodeAsc = "ORDER BY CLCARD.CODE ASC";
		public const string CustomerCodeDesc = "ORDER BY CLCARD.CODE DESC";
		public const string CustomerNameAsc = "ORDER BY CLCARD.DEFINITION_ ASC";
		public const string CustomerNameDesc = "ORDER BY CLCARD.DEFINITION_ DESC";
		public const string ProductCodeAsc = "ORDER BY ITEMS.CODE ASC";
		public const string ProductCodeDesc = "ORDER BY ITEMS.CODE DESC";
		public const string ProductNameAsc = "ORDER BY ITEMS.NAME ASC";
		public const string ProductNameDesc = "ORDER BY ITEMS.NAME DESC";
		public const string DueDateDesc = "ORDER BY ORFLINE.DUEDATE DESC";
		public const string DueDateAsc = "ORDER BY ORFLINE.DUEDATE ASC";

	}
}
