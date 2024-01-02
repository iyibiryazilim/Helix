using Microsoft.Extensions.Configuration;

namespace Helix.PurchaseService.Infrastructure.Helper.Queries
{
	public class PurchaseOrderLineQuery : BaseQuery
	{
		public PurchaseOrderLineQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetPurchaseOrderLine(string search, string orderBy, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}

		public string GetWaitingPurchaseOrderLine(string search, string orderBy, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}


		public string GetPurchaseOrderLineByFicheCode(string search, string orderBy, string code, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ORFICHE.FICHENO = '{code}' AND ORFLINE.CLOSED = 0 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY ";

			return query;
		}


		public string GetPurchaseOrderLineByFicheId(string search, string orderBy, int id, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ORFICHE.LOGICALREF = {id} AND ORFLINE.CLOSED = 0 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}

		#region Current Filter
		public string GetPurchaseOrderLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND CLCARD.LOGICALREF = {id}  AND (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}

		public string GetWaitingPurchaseOrderLineByCurrentId(string search, string orderBy, int id, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND CLCARD.LOGICALREF = {id} AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0  AND (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}


		public string GetPurchaseOrderLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND CLCARD.CODE = '{code}' AND (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY ";
			return query;
		}

		public string GetWaitingPurchaseOrderLineByCurrentCode(string search, string orderBy, string code, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND CLCARD.CODE = '{code}' AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0  AND (ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY ";
			return query;
		}

		#endregion

		#region Product Filter
		public string GetPurchaseOrderLineByProductId(string search, string orderBy, int id, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ITEMS.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY ";
			return query;
		}

		public string GetWaitingPurchaseOrderLineByProductId(string search, string orderBy, int id, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ITEMS.LOGICALREF = {id} AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0  AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
			
		public string GetPurchaseOrderLineByProductCode(string search, string orderBy, string code, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ITEMS.CODE = '{code}' AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}

		public string GetWaitingPurchaseOrderLineByProductCode(string search, string orderBy, string code, int page, int pageSize)
		{
			int currentIndex = pageSize * page;

			string query = @$"SELECT
			[ReferenceId] = ORFLINE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
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
			[NetTotal] = ORFLINE.LINENET
			
			
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_00{FirmNumber}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ITEMS.CODE = '{code}' AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ITEMS.NAME LIKE '%{search}%' OR ITEMS.CODE LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY ";

			return query;
		}
		#endregion


	}
	public class PurchaseOrderLineOrderBy
	{
		public const string DateAsc = "ORDER BY ORFLINE.DUEDATE ASC";
		public const string DateDesc = "ORDER BY ORFLINE.DUEDATE DESC";
		public const string CodeAsc = "ORDER BY ORFICHE.FICHENO ASC";
		public const string CodeDesc = "ORDER BY ORFICHE.FICHENO DESC";
		public const string ProductCodeAsc = "ORDER BY ITEMS.CODE ASC";
		public const string ProductCodeDesc = "ORDER BY ITEMS.CODE DESC";
		public const string ProductNameAsc = "ORDER BY ITEMS.NAME ASC";
		public const string ProductNameDesc = "ORDER BY ITEMS.NAME DESC";
		public const string CurrentCodeAsc = "ORDER BY CLCARD.CODE ASC";
		public const string CurrentCodeDesc = "ORDER BY CLCARD.CODE DESC";
		public const string CurrentNameAsc = "ORDER BY CLCARD.DEFINITION_ ASC";
		public const string CurrentNameDesc = "ORDER BY CLCARD.DEFINITION_ DESC";
	}
}
