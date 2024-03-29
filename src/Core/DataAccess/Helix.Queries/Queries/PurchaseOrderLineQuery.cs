﻿using Microsoft.Extensions.Configuration;

namespace Helix.Queries
{
	public class PurchaseOrderLineQuery : BaseQuery
	{
		public PurchaseOrderLineQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetPurchaseOrderLine() =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2";

		public string GetWaitingPurchaseOrderLine() =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0";

		public string GetPurchaseOrderLineByCode(string code) =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ORFICHE.FICHENO = '{code}' ";
		public string GetPurchaseOrderLineById(int id) =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ORFICHE.LOGICALREF = {id} ";

		#region Current Filter
		public string GetPurchaseOrderLineByCurrentId(int id) =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND CLCARD.LOGICALREF = {id} ";
		public string GetWaitingPurchaseOrderLineByCurrentId(int id) =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND CLCARD.LOGICALREF = {id} AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 ";

		public string GetPurchaseOrderLineByCurrentCode(string code) =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND CLCARD.CODE = '{code}' ";
		public string GetWaitingPurchaseOrderLineByCurrentCode(string code) =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND CLCARD.CODE = '{code}' AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 ";
		#endregion

		#region Product Filter
		public string GetPurchaseOrderLineByProductId(int id) =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ITEMS.LOGICALREF = {id} ";
		public string GetWaitingPurchaseOrderLineByProductId(int id) =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ITEMS.LOGICALREF = {id} AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 ";
		public string GetPurchaseOrderLineByProductCode(string code) =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ITEMS.CODE = '{code}' ";
		public string GetWaitingPurchaseOrderLineByProductCode(string code) =>
			@$"SELECT
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
			
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFLINE AS ORFLINE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE ON ORFLINE.ORDFICHEREF = ORFICHE.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_ITEMS AS ITEMS ON ORFLINE.STOCKREF = ITEMS.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETL AS SUBUNITSET ON ORFLINE.UOMREF = SUBUNITSET.LOGICALREF AND MAINUNIT = 1
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_UNITSETF AS UNITSET ON ORFLINE.USREF = UNITSET.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFLINE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFLINE.TRCODE = 2 AND ITEMS.CODE = '{code}' AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 ";
		#endregion

	}
}
