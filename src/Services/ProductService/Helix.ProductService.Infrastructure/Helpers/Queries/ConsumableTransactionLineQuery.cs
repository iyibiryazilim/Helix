using Microsoft.Extensions.Configuration;


namespace Helix.ProductService.Infrastructure.Helpers.Queries;

public class ConsumableTransactionLineQuery : BaseQuery
{
	public ConsumableTransactionLineQuery(IConfiguration configuration) : base(configuration)
	{
	}
	public string GetTransactionList() =>
	@$"SELECT
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
		WHERE STLINE.TRCODE = 12";
	public string GetTransactionById(int id) =>
	@$"SELECT
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
		WHERE STLINE.TRCODE = 12 AND STLINE.LOGICALREF = {id}";
	public string GetTransactionByCurrentCode(string code) =>
		@$"SELECT
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
		WHERE STLINE.TRCODE = 12 AND CLCARD.CODE = {code}";
	public string GetTransactionByCurrentId(int id) =>
				@$"SELECT
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
		WHERE STLINE.TRCODE = 12 AND CLCARD.LOGICALREF = {id}";
	public string GetTransactionByProductCode(string code) =>
					@$"SELECT
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
		WHERE STLINE.TRCODE = 12 AND ITEMS.CODE = {code}";
	public string GetTransactionByProductId(int id) =>
			@$"SELECT
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
		WHERE STLINE.TRCODE = 12 AND ITEMS.LOGICALREF = {id}";
	public string GetTransactionByFicheCode(string code) =>
	@$"SELECT
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
		WHERE STLINE.TRCODE = 12 AND STFICHE.FICHENO = {code}";
	public string GetTransactionByFicheId(int id) =>
	@$"SELECT
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
		WHERE STLINE.TRCODE = 12 AND STFICHE.LOGICALREF = {id}";
}
