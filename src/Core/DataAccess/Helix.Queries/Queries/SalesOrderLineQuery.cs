﻿using Microsoft.Extensions.Configuration;

namespace Helix.Queries
{
	public class SalesOrderLineQuery : BaseQuery
	{
		public SalesOrderLineQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetSalesOrderLineQuery() =>
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
			WHERE ORFLINE.TRCODE = 1";

		public string GetWaitingSalesOrderLineQuery() =>
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
			WHERE ORFLINE.TRCODE = 1 AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0";

		public string GetSalesOrderLineByCodeQuery(string code) =>
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
			WHERE ORFLINE.TRCODE = 1 AND ORFICHE.FICHENO = '{code}' ";
		public string GetSalesOrderLineByIdQuery(int id) =>
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
			WHERE ORFLINE.TRCODE = 1 AND ORFICHE.LOGICALREF = {id} ";

		#region Current Filter
		public string GetSalesOrderLineByCurrentIdQuery(int id) =>
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
			WHERE ORFLINE.TRCODE = 1 AND CLCARD.LOGICALREF = {id} ";
		public string GetWaitingSalesOrderLineByCurrentIdQuery(int id) =>
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
			WHERE ORFLINE.TRCODE = 1 AND CLCARD.LOGICALREF = {id} AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 ";

		public string GetSalesOrderLineByCurrentCodeQuery(string code) =>
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
			WHERE ORFLINE.TRCODE = 1 AND CLCARD.CODE = '{code}' ";
		public string GetWaitingSalesOrderLineByCurrentCodeQuery(string code) =>
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
			WHERE ORFLINE.TRCODE = 1 AND CLCARD.CODE = '{code}' AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 ";
		#endregion

		#region Product Filter
		public string GetSalesOrderLineByProductIdQuery(int id) =>
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
			WHERE ORFLINE.TRCODE = 1 AND ITEMS.LOGICALREF = {id} ";
		public string GetWaitingSalesOrderLineByProductIdQuery(int id) =>
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
			WHERE ORFLINE.TRCODE = 1 AND ITEMS.LOGICALREF = {id} AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 ";
		public string GetSalesOrderLineByProductCodeQuery(string code) =>
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
			WHERE ORFLINE.TRCODE = 1 AND ITEMS.CODE = '{code}' ";
		public string GetWaitingSalesOrderLineByProductCodeQuery(string code) =>
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
			WHERE ORFLINE.TRCODE = 1 AND ITEMS.CODE = '{code}' AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 ";
		#endregion
	}
}
