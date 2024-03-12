using Microsoft.Extensions.Configuration;

namespace Helix.Queries
{
	public class SalesOrderQuery : BaseQuery
	{
		public SalesOrderQuery(IConfiguration configuration) : base(configuration)
		{
		}
		public string GetSalesOrderQuery() =>
			$@"SELECT
			[ReferenceId] = ORFICHE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFICHE.GENEXP1,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[TotalVat] = ORFICHE.TOTALVAT,
			[NetTotal] = ORFICHE.NETTOTAL,
			[Total] = ORFICHE.GROSSTOTAL
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFICHE.TRCODE = 1";
		public string GetSalesOrderByCodeQuery(string code) =>
			$@"SELECT
			[ReferenceId] = ORFICHE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFICHE.GENEXP1,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[TotalVat] = ORFICHE.TOTALVAT,
			[NetTotal] = ORFICHE.NETTOTAL,
			[Total] = ORFICHE.GROSSTOTAL
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFICHE.TRCODE = 1 AND ORFICHE.FICHENO = '{code}' ";
		public string GetSalesOrderByIdQuery(int id) =>
			$@"SELECT
			[ReferenceId] = ORFICHE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFICHE.GENEXP1,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[TotalVat] = ORFICHE.TOTALVAT,
			[NetTotal] = ORFICHE.NETTOTAL,
			[Total] = ORFICHE.GROSSTOTAL
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFICHE.TRCODE = 1 AND ORFICHE.LOGICALREF = {id} ";


		#region Current Filter
		public string GetSalesOrderByCurrentIdQuery(int id) =>
			$@"SELECT
			[ReferenceId] = ORFICHE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFICHE.GENEXP1,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[TotalVat] = ORFICHE.TOTALVAT,
			[NetTotal] = ORFICHE.NETTOTAL,
			[Total] = ORFICHE.GROSSTOTAL
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFICHE.TRCODE = 1 AND CLCARD.LOGICALREF = {id} ";
		public string GetSalesOrderByCurrentCodeQuery(string code) =>
		$@"SELECT
			[ReferenceId] = ORFICHE.LOGICALREF,
			[Date] = ORFICHE.DATE_,
			[Time] = dbo.LG_INTTOTIME(ORFICHE.TIME_),
			[Code] = ORFICHE.FICHENO,
			[TransactionType] = ORFICHE.TRCODE,
			[Description] = ORFICHE.GENEXP1,
			[WarehouseNumber] = WHOUSE.NR,
			[WarehouseName] = WHOUSE.NAME,
			[CurrentReferenceId] = CLCARD.LOGICALREF,
			[CurrentCode] = CLCARD.CODE,
			[CurrentName] = CLCARD.DEFINITION_,
			[TotalVat] = ORFICHE.TOTALVAT,
			[NetTotal] = ORFICHE.NETTOTAL,
			[Total] = ORFICHE.GROSSTOTAL
			FROM LG_{FirmNumber.ToString().PadLeft(3, '0')}_{PeriodNumber.ToString().PadLeft(2, '0')}_ORFICHE AS ORFICHE
			LEFT JOIN LG_{FirmNumber.ToString().PadLeft(3, '0')}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFICHE.TRCODE = 1 AND CLCARD.CODE = '{code}' ";
		#endregion
	}
}
