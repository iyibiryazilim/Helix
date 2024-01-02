using Microsoft.Extensions.Configuration;

namespace Helix.SalesService.Infrastructure.Helper.Queries
{
	public class SalesOrderQuery : BaseQuery
	{
		public SalesOrderQuery(IConfiguration configuration) : base(configuration)
		{
		}
		public string GetSalesOrderQuery(string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = $@"SELECT
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
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFICHE.TRCODE = 1 AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";

			return query;
		}
			
		public string GetSalesOrderByCodeQuery(string code)
		{
			string query= $@"SELECT
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
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFICHE.TRCODE = 1 AND ORFICHE.FICHENO = '{code}' ";

			return query;
		}
			
		public string GetSalesOrderByIdQuery(int id){
			string query = $@"SELECT
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
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFICHE.TRCODE = 1 AND ORFICHE.LOGICALREF = {id} ";
			return query;
		}


		#region Current Filter
		public string GetSalesOrderByCurrentIdQuery(int id, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = $@"SELECT
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
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFICHE.TRCODE = 1 AND CLCARD.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
		public string GetSalesOrderByCurrentCodeQuery(string code, string search, string orderBy, int currentPage = 0, int pageSize = 20)
		{
			int currentIndex = pageSize * currentPage;

			string query = $@"SELECT
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
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			WHERE ORFICHE.TRCODE = 1 AND CLCARD.CODE = '{code}' AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}
		#endregion
	}

	public class SalesOrdersOrderBy
	{
		public const string CustomerCodeAsc = "ORDER BY CLCARD.CODE ASC";
		public const string CustomerCodeDesc = "ORDER BY CLCARD.CODE DESC";
		public const string CustomerNameAsc = "ORDER BY CLCARD.DEFINITION_ ASC";
		public const string CustomerNameDesc = "ORDER BY CLCARD.DEFINITION_ DESC";
		public const string NetTotalAsc = "ORDER BY ORFICHE.NETTOTAL ASC";
		public const string NetTotalDesc = "ORDER BY ORFICHE.NETTOTAL DESC";
		public const string DateAsc = "ORDER BY ORFICHE.DATE_ ASC";
		public const string DateDesc = "ORDER BY ORFICHE.DATE_ DESC";

	}
}
