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
			[ShipCustomerName] = ISNULL(CL.DEFINITION_,''),
			[ShipCustomerCode] = ISNULL(CL.CODE,''),
			[ShipCustomerReferenceId] = ISNULL(CL.LOGICALREF,0),
			[ShipInfoCode]=ISNULL(SHIPINFO.CODE,''),
			[ShipInfoName]=ISNULL(SHIPINFO.NAME,''),
			[ShipInfoReferenceId] =ISNULL(SHIPINFO.LOGICALREF,0),
			[TotalVat] = ORFICHE.TOTALVAT,
			[NetTotal] = ORFICHE.NETTOTAL,
			[Total] = ORFICHE.GROSSTOTAL
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CL ON ORFICHE.RECVREF = CL.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_SHIPINFO AS SHIPINFO ON ORFICHE.SHIPINFOREF = SHIPINFO.LOGICALREF
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
			[ShipCustomerName] = ISNULL(CL.DEFINITION_,''),
			[ShipCustomerCode] = ISNULL(CL.CODE,''),
			[ShipCustomerReferenceId] = ISNULL(CL.LOGICALREF,0),
			[ShipInfoCode]=ISNULL(SHIPINFO.CODE,''),
			[ShipInfoName]=ISNULL(SHIPINFO.NAME,''),
			[ShipInfoReferenceId] =ISNULL(SHIPINFO.LOGICALREF,0),
			[TotalVat] = ORFICHE.TOTALVAT,
			[NetTotal] = ORFICHE.NETTOTAL,
			[Total] = ORFICHE.GROSSTOTAL
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CL ON ORFICHE.RECVREF = CL.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_SHIPINFO AS SHIPINFO ON ORFICHE.SHIPINFOREF = SHIPINFO.LOGICALREF
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
			[ShipCustomerName] = ISNULL(CL.DEFINITION_,''),
			[ShipCustomerCode] = ISNULL(CL.CODE,''),
			[ShipCustomerReferenceId] = ISNULL(CL.LOGICALREF,0),
			[ShipInfoCode]=ISNULL(SHIPINFO.CODE,''),
			[ShipInfoName]=ISNULL(SHIPINFO.NAME,''),
			[ShipInfoReferenceId] =ISNULL(SHIPINFO.LOGICALREF,0),
			[TotalVat] = ORFICHE.TOTALVAT,
			[NetTotal] = ORFICHE.NETTOTAL,
			[Total] = ORFICHE.GROSSTOTAL
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CL ON ORFICHE.RECVREF = CL.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_SHIPINFO AS SHIPINFO ON ORFICHE.SHIPINFOREF = SHIPINFO.LOGICALREF
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
			[ShipCustomerName] = ISNULL(CL.DEFINITION_,''),
			[ShipCustomerCode] = ISNULL(CL.CODE,''),
			[ShipCustomerReferenceId] = ISNULL(CL.LOGICALREF,0),
			[ShipInfoCode]=ISNULL(SHIPINFO.CODE,''),
			[ShipInfoName]=ISNULL(SHIPINFO.NAME,''),
			[ShipInfoReferenceId] =ISNULL(SHIPINFO.LOGICALREF,0),
			[TotalVat] = ORFICHE.TOTALVAT,
			[NetTotal] = ORFICHE.NETTOTAL,
			[Total] = ORFICHE.GROSSTOTAL
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFICHE.LOGICALREF = ORFLINE.ORDFICHEREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CL ON ORFICHE.RECVREF = CL.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_SHIPINFO AS SHIPINFO ON ORFICHE.SHIPINFOREF = SHIPINFO.LOGICALREF
			WHERE ORFICHE.TRCODE = 1 AND CLCARD.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 
			GROUP BY ORFICHE.LOGICALREF,ORFICHE.DATE_,dbo.LG_INTTOTIME(ORFICHE.TIME_),ORFICHE.FICHENO,ORFICHE.TRCODE,ORFICHE.GENEXP1,
			WHOUSE.NR,WHOUSE.NAME,CLCARD.LOGICALREF,CLCARD.CODE,CLCARD.DEFINITION_,CL.DEFINITION_,
			CL.CODE,CL.LOGICALREF,SHIPINFO.CODE,SHIPINFO.LOGICALREF,SHIPINFO.NAME,ORFICHE.TOTALVAT,ORFICHE.NETTOTAL,ORFICHE.GROSSTOTAL
			{orderBy}
			OFFSET {currentIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY";
			return query;
		}

        public string GetSalesOrderByCurrentIdAndWarehouseNumberQuery(int id,int number, string search, string orderBy, int currentPage = 0, int pageSize = 20)
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
			[ShipCustomerName] = ISNULL(CL.DEFINITION_,''),
			[ShipCustomerCode] = ISNULL(CL.CODE,''),
			[ShipCustomerReferenceId] = ISNULL(CL.LOGICALREF,0),
			[ShipInfoCode]=ISNULL(SHIPINFO.CODE,''),
			[ShipInfoName]=ISNULL(SHIPINFO.NAME,''),
			[ShipInfoReferenceId] =ISNULL(SHIPINFO.LOGICALREF,0),
			[TotalVat] = ORFICHE.TOTALVAT,
			[NetTotal] = ORFICHE.NETTOTAL,
			[Total] = ORFICHE.GROSSTOTAL
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFLINE AS ORFLINE
			LEFT JOIN LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE ON ORFICHE.LOGICALREF = ORFLINE.ORDFICHEREF
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CL ON ORFICHE.RECVREF = CL.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_SHIPINFO AS SHIPINFO ON ORFICHE.SHIPINFOREF = SHIPINFO.LOGICALREF
			WHERE ORFICHE.TRCODE = 1 AND CLCARD.LOGICALREF = {id} AND (CLCARD.CODE LIKE '%{search}%' OR CLCARD.DEFINITION_ LIKE '%{search}%' OR ORFICHE.FICHENO LIKE '%{search}%')
			AND (ORFLINE.AMOUNT - ORFLINE.SHIPPEDAMOUNT) > 0 AND ORFLINE.CLOSED = 0 AND WHOUSE.NR = {number}
			GROUP BY ORFICHE.LOGICALREF,ORFICHE.DATE_,dbo.LG_INTTOTIME(ORFICHE.TIME_),ORFICHE.FICHENO,ORFICHE.TRCODE,ORFICHE.GENEXP1,
			WHOUSE.NR,WHOUSE.NAME,CLCARD.LOGICALREF,CLCARD.CODE,CLCARD.DEFINITION_,CL.DEFINITION_,
			CL.CODE,CL.LOGICALREF,SHIPINFO.CODE,SHIPINFO.LOGICALREF,SHIPINFO.NAME,ORFICHE.TOTALVAT,ORFICHE.NETTOTAL,ORFICHE.GROSSTOTAL
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
			[ShipCustomerName] = ISNULL(CL.DEFINITION_,''),
			[ShipCustomerCode] = ISNULL(CL.CODE,''),
			[ShipCustomerReferenceId] = ISNULL(CL.LOGICALREF,0),
			[ShipInfoCode]=ISNULL(SHIPINFO.CODE,''),
			[ShipInfoName]=ISNULL(SHIPINFO.NAME,''),
			[ShipInfoReferenceId] =ISNULL(SHIPINFO.LOGICALREF,0),
			[TotalVat] = ORFICHE.TOTALVAT,
			[NetTotal] = ORFICHE.NETTOTAL,
			[Total] = ORFICHE.GROSSTOTAL
			FROM LG_00{FirmNumber}_0{PeriodNumber}_ORFICHE AS ORFICHE
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CLCARD ON ORFICHE.CLIENTREF = CLCARD.LOGICALREF
			LEFT JOIN L_CAPIWHOUSE AS WHOUSE ON ORFICHE.SOURCEINDEX = WHOUSE.NR AND WHOUSE.FIRMNR = {FirmNumber}
			LEFT JOIN LG_00{FirmNumber}_CLCARD AS CL ON ORFICHE.RECVREF = CL.LOGICALREF
			LEFT JOIN LG_00{FirmNumber}_SHIPINFO AS SHIPINFO ON ORFICHE.SHIPINFOREF = SHIPINFO.LOGICALREF
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
