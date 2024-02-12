using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Models;
using Helix.LBSService.Go.Services;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Numerics;
using System.Transactions;

namespace Helix.LBSService.Go.DataStores
{
	public class LG_STFICHE_Context : ILG_STFICHE_Context
	{

		readonly int _defaultFirmNumber = LBSParameter.FirmNumber;
		readonly int _defaultPeriodNumber = LBSParameter.Period;
		readonly string _connectionString = LBSParameter.Connection; 
       
		public async Task<int> UpdateObject(string lastAsgnd, string effsdate, string effedate, int TRCODE)
		{
			string query = $@"UPDATE L_LDOCNUM SET LASTASGND = '{lastAsgnd}'
        WHERE EFFSDATE<='{effsdate}' AND EFFEDATE>='{effedate}' AND FIRMID={_defaultFirmNumber} AND DOCIDEN ={TRCODE} ";
			await using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				await connection.OpenAsync();
				await using (SqlCommand command = new SqlCommand(query, connection))
				{
					return await command.ExecuteNonQueryAsync();
				}
			}
		}
		public async ValueTask<string> GetLastAsgn(string effsdate, string effedate, int TRCODE)
		{
			var lastNumber = string.Empty;
			string query = $"SELECT TOP 1 LASTASGND as lastNumber FROM L_LDOCNUM WHERE EFFSDATE<='{effsdate}' AND EFFEDATE>='{effedate}' AND FIRMID={_defaultFirmNumber} AND DOCIDEN = {TRCODE}";
			await using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				await connection.OpenAsync();
				await using (SqlCommand command = new SqlCommand(query, connection))
				{
					SqlDataReader dr = await command.ExecuteReaderAsync();
					if (dr.HasRows)
					{
						await dr.ReadAsync(); // Veri okuma işlemine başla
						lastNumber = dr["lastNumber"].ToString();

					}
				}
			}
			return lastNumber;
		}

		public async Task<DataResult<LG_STFICHE>> InsertObject(LG_STFICHE item)
		{
			int ReferenceId;
			string query = $"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_STFICHE( GRPCODE ,DOCDATE ,TRCODE ,IOCODE ,FICHENO ,DATE_ ,FTIME ,DOCODE ,INVNO ,SPECODE ,CYPHCODE ,INVOICEREF ,CLIENTREF ,RECVREF ,ACCOUNTREF ,CENTERREF ,PRODORDERREF ,PORDERFICHENO ,SOURCETYPE ,SOURCEINDEX ,SOURCEWSREF ,SOURCEPOLNREF ,SOURCECOSTGRP ,DESTTYPE ,DESTINDEX ,DESTWSREF ,DESTPOLNREF ,DESTCOSTGRP ,FACTORYNR ,BRANCH ,DEPARTMENT ,COMPBRANCH ,COMPDEPARTMENT ,COMPFACTORY ,PRODSTAT ,DEVIR ,CANCELLED ,BILLED ,ACCOUNTED ,UPDCURR ,INUSE ,INVKIND ,ADDDISCOUNTS ,TOTALDISCOUNTS ,TOTALDISCOUNTED ,ADDEXPENSES ,TOTALEXPENSES ,TOTALDEPOZITO ,TOTALPROMOTIONS ,TOTALVAT ,GROSSTOTAL ,NETTOTAL ,GENEXP1 ,GENEXP2 ,GENEXP3 ,GENEXP4 ,GENEXP5 ,GENEXP6 ,REPORTRATE ,REPORTNET ,EXTENREF ,PAYDEFREF ,PRINTCNT ,FICHECNT ,ACCFICHEREF ,CAPIBLOCK_CREATEDBY ,CAPIBLOCK_CREADEDDATE ,CAPIBLOCK_CREATEDHOUR ,CAPIBLOCK_CREATEDMIN ,CAPIBLOCK_CREATEDSEC ,SALESMANREF ,CANCELLEDACC ,SHPTYPCOD ,SHPAGNCOD ,TRACKNR ,GENEXCTYP ,LINEEXCTYP ,TRADINGGRP ,TEXTINC ,SITEID ,RECSTATUS ,ORGLOGICREF ,WFSTATUS ,SHIPINFOREF ,DISTORDERREF ,SENDCNT ,DLVCLIENT ,DOCTRACKINGNR ,ADDTAXCALC ,TOTALADDTAX ,UGIRTRACKINGNO ,QPRODFCREF ,VAACCREF ,VACENTERREF ,ORGLOGOID ,FROMEXIM ,FRGTYPCOD ,TRCURR ,TRRATE ,TRNET ,EXIMWHFCREF ,EXIMFCTYPE ,MAINSTFCREF ,FROMORDWITHPAY ,PROJECTREF ,WFLOWCRDREF ,STATUS ,UPDTRCURR ,TOTALEXADDTAX ,AFFECTCOLLATRL ,DEDUCTIONPART1 ,DEDUCTIONPART2 ,GRPFIRMTRANS ,AFFECTRISK ,DISPSTATUS ,APPROVE ,CANTCREDEDUCT ,SHIPTIME ,ENTRUSTDEVIR ,RELTRANSFCREF ,FROMTRANSFER ,GUID ,GLOBALID ,COMPSTFCREF ,COMPINVREF ,TOTALSERVICES ,CAMPAIGNCODE ,OFFERREF ,EINVOICETYP ,EINVOICE ,NOCALCULATE ,PRODORDERTYP ,QPRODFCTYP ,PRDORDSLPLNRESERVE ,CONTROLINFO ,EDESPATCH ,DOCTIME ,EDESPSTATUS ,PROFILEID ,DELIVERYCODE ,DESTSTATUS ,CANCELEXP ,UNDOEXP) VALUES ( @GRPCODE ,@DOCDATE ,@TRCODE ,@IOCODE ,@FICHENO ,@DATE_ ,(SELECT [dbo].[LG_TIMETOINT](@FHOUR,@FMINUTE,@FSECOND)),@DOCODE ,@INVNO ,@SPECODE ,@CYPHCODE ,@INVOICEREF ,@CLIENTREF ,@RECVREF ,@ACCOUNTREF ,@CENTERREF ,@PRODORDERREF ,@PORDERFICHENO ,@SOURCETYPE ,@SOURCEINDEX ,@SOURCEWSREF ,@SOURCEPOLNREF ,@SOURCECOSTGRP ,@DESTTYPE ,@DESTINDEX ,@DESTWSREF ,@DESTPOLNREF ,@DESTCOSTGRP ,@FACTORYNR ,@BRANCH ,@DEPARTMENT ,@COMPBRANCH ,@COMPDEPARTMENT ,@COMPFACTORY ,@PRODSTAT ,@DEVIR ,@CANCELLED ,@BILLED ,@ACCOUNTED ,@UPDCURR ,@INUSE ,@INVKIND ,@ADDDISCOUNTS ,@TOTALDISCOUNTS ,@TOTALDISCOUNTED ,@ADDEXPENSES ,@TOTALEXPENSES ,@TOTALDEPOZITO ,@TOTALPROMOTIONS ,@TOTALVAT ,@GROSSTOTAL ,@NETTOTAL ,@GENEXP1 ,@GENEXP2 ,@GENEXP3 ,@GENEXP4 ,@GENEXP5 ,@GENEXP6 ,@REPORTRATE ,@REPORTNET ,@EXTENREF ,@PAYDEFREF ,@PRINTCNT ,@FICHECNT ,@ACCFICHEREF ,@CAPIBLOCK_CREATEDBY ,@CAPIBLOCK_CREADEDDATE ,@CAPIBLOCK_CREATEDHOUR ,@CAPIBLOCK_CREATEDMIN ,@CAPIBLOCK_CREATEDSEC ,@SALESMANREF ,@CANCELLEDACC ,@SHPTYPCOD ,@SHPAGNCOD ,@TRACKNR ,@GENEXCTYP ,@LINEEXCTYP ,@TRADINGGRP ,@TEXTINC ,@SITEID ,@RECSTATUS ,@ORGLOGICREF ,@WFSTATUS ,@SHIPINFOREF ,@DISTORDERREF ,@SENDCNT ,@DLVCLIENT ,@DOCTRACKINGNR ,@ADDTAXCALC ,@TOTALADDTAX ,@UGIRTRACKINGNO ,@QPRODFCREF ,@VAACCREF ,@VACENTERREF ,@ORGLOGOID ,@FROMEXIM ,@FRGTYPCOD ,@TRCURR ,@TRRATE ,@TRNET ,@EXIMWHFCREF ,@EXIMFCTYPE ,@MAINSTFCREF ,@FROMORDWITHPAY ,@PROJECTREF ,@WFLOWCRDREF ,@STATUS ,@UPDTRCURR ,@TOTALEXADDTAX ,@AFFECTCOLLATRL ,@DEDUCTIONPART1 ,@DEDUCTIONPART2 ,@GRPFIRMTRANS ,@AFFECTRISK ,@DISPSTATUS ,@APPROVE ,@CANTCREDEDUCT ,@SHIPTIME ,@ENTRUSTDEVIR ,@RELTRANSFCREF ,@FROMTRANSFER ,@GUID ,@GLOBALID ,@COMPSTFCREF ,@COMPINVREF ,@TOTALSERVICES ,@CAMPAIGNCODE ,@OFFERREF ,@EINVOICETYP ,@EINVOICE ,@NOCALCULATE ,@PRODORDERTYP ,@QPRODFCTYP ,@PRDORDSLPLNRESERVE ,@CONTROLINFO ,@EDESPATCH ,@DOCTIME ,@EDESPSTATUS ,@PROFILEID ,@DELIVERYCODE ,@DESTSTATUS ,@CANCELEXP ,@UNDOEXP); SELECT SCOPE_IDENTITY();";
			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				try
				{
					var lastNumber = await GetLastAsgn(item.DATE_.ToString("s"), item.DATE_.ToString("s"), item.TRCODE);
					BigInteger number = BigInteger.Parse(lastNumber);
					number++; // 1 ekleyin
					var last = number.ToString("D16");
					int hour = item.DATE_.Hour;
					int minute = item.DATE_.Minute;
					int second = item.DATE_.Second;

					// Construct the time string in the format expected by the LG_TIMETOINT function
					string timeString = $"{hour},{minute},{second}";
					#region Fiche Insert
					await using (SqlConnection connection = new SqlConnection(_connectionString))
					{
						await connection.OpenAsync();
						await using (SqlCommand command = new SqlCommand(query, connection))
						{
							command.Parameters.AddWithValue("GRPCODE", item.GRPCODE);
							command.Parameters.AddWithValue("DOCDATE", item.DOCDATE);
							command.Parameters.AddWithValue("TRCODE", item.TRCODE);
							command.Parameters.AddWithValue("IOCODE", item.IOCODE);
							command.Parameters.AddWithValue("FICHENO", last);
							command.Parameters.AddWithValue("DATE_", item.DATE_);
							command.Parameters.AddWithValue("FHOUR", item.DATE_.Hour);
							command.Parameters.AddWithValue("FMINUTE", item.DATE_.Minute);
							command.Parameters.AddWithValue("FSECOND", item.DATE_.Second);
							command.Parameters.AddWithValue("DOCODE", item.DOCODE);
							command.Parameters.AddWithValue("INVNO", item.INVNO);
							command.Parameters.AddWithValue("SPECODE", item.SPECODE);
							command.Parameters.AddWithValue("CYPHCODE", item.CYPHCODE);
							command.Parameters.AddWithValue("INVOICEREF", item.INVOICEREF);
							command.Parameters.AddWithValue("CLIENTREF", item.CLIENTREF);
							command.Parameters.AddWithValue("RECVREF", item.RECVREF);
							command.Parameters.AddWithValue("ACCOUNTREF", item.ACCOUNTREF);
							command.Parameters.AddWithValue("CENTERREF", item.CENTERREF);
							command.Parameters.AddWithValue("PRODORDERREF", item.PRODORDERREF);
							command.Parameters.AddWithValue("PORDERFICHENO", item.PORDERFICHENO);
							command.Parameters.AddWithValue("SOURCETYPE", item.SOURCETYPE);
							command.Parameters.AddWithValue("SOURCEINDEX", item.SOURCEINDEX);
							command.Parameters.AddWithValue("SOURCEWSREF", item.SOURCEWSREF);
							command.Parameters.AddWithValue("SOURCEPOLNREF", item.SOURCEPOLNREF);
							command.Parameters.AddWithValue("SOURCECOSTGRP", item.SOURCECOSTGRP);
							command.Parameters.AddWithValue("DESTTYPE", item.DESTTYPE);
							command.Parameters.AddWithValue("DESTINDEX", item.DESTINDEX);
							command.Parameters.AddWithValue("DESTWSREF", item.DESTWSREF);
							command.Parameters.AddWithValue("DESTPOLNREF", item.DESTPOLNREF);
							command.Parameters.AddWithValue("DESTCOSTGRP", item.DESTCOSTGRP);
							command.Parameters.AddWithValue("FACTORYNR", item.FACTORYNR);
							command.Parameters.AddWithValue("BRANCH", item.BRANCH);
							command.Parameters.AddWithValue("DEPARTMENT", item.DEPARTMENT);
							command.Parameters.AddWithValue("COMPBRANCH", item.COMPBRANCH);
							command.Parameters.AddWithValue("COMPDEPARTMENT", item.COMPDEPARTMENT);
							command.Parameters.AddWithValue("COMPFACTORY", item.COMPFACTORY);
							command.Parameters.AddWithValue("PRODSTAT", item.PRODSTAT);
							command.Parameters.AddWithValue("DEVIR", item.DEVIR);
							command.Parameters.AddWithValue("CANCELLED", item.CANCELLED);
							command.Parameters.AddWithValue("BILLED", item.BILLED);
							command.Parameters.AddWithValue("ACCOUNTED", item.ACCOUNTED);
							command.Parameters.AddWithValue("UPDCURR", item.UPDCURR);
							command.Parameters.AddWithValue("INUSE", item.INUSE);
							command.Parameters.AddWithValue("INVKIND", item.INVKIND);
							command.Parameters.AddWithValue("ADDDISCOUNTS", item.ADDDISCOUNTS);
							command.Parameters.AddWithValue("TOTALDISCOUNTS", item.TOTALDISCOUNTS);
							command.Parameters.AddWithValue("TOTALDISCOUNTED", item.TOTALDISCOUNTED);
							command.Parameters.AddWithValue("ADDEXPENSES", item.ADDEXPENSES);
							command.Parameters.AddWithValue("TOTALEXPENSES", item.TOTALEXPENSES);
							command.Parameters.AddWithValue("TOTALDEPOZITO", item.TOTALDEPOZITO);
							command.Parameters.AddWithValue("TOTALPROMOTIONS", item.TOTALPROMOTIONS);
							command.Parameters.AddWithValue("TOTALVAT", item.TOTALVAT);
							command.Parameters.AddWithValue("GROSSTOTAL", item.GROSSTOTAL);
							command.Parameters.AddWithValue("NETTOTAL", item.NETTOTAL);
							command.Parameters.AddWithValue("GENEXP1", item.GENEXP1);
							command.Parameters.AddWithValue("GENEXP2", item.GENEXP2);
							command.Parameters.AddWithValue("GENEXP3", item.GENEXP3);
							command.Parameters.AddWithValue("GENEXP4", item.GENEXP4);
							command.Parameters.AddWithValue("GENEXP5", item.GENEXP5);
							command.Parameters.AddWithValue("GENEXP6", item.GENEXP6);
							command.Parameters.AddWithValue("REPORTRATE", item.REPORTRATE);
							command.Parameters.AddWithValue("REPORTNET", item.REPORTNET);
							command.Parameters.AddWithValue("EXTENREF", item.EXTENREF);
							command.Parameters.AddWithValue("PAYDEFREF", item.PAYDEFREF);
							command.Parameters.AddWithValue("PRINTCNT", item.PRINTCNT);
							command.Parameters.AddWithValue("FICHECNT", item.FICHECNT);
							command.Parameters.AddWithValue("ACCFICHEREF", item.ACCFICHEREF);
							command.Parameters.AddWithValue("CAPIBLOCK_CREATEDBY", item.CAPIBLOCK_CREATEDBY);
							command.Parameters.AddWithValue("CAPIBLOCK_CREADEDDATE", item.CAPIBLOCK_CREADEDDATE);
							command.Parameters.AddWithValue("CAPIBLOCK_CREATEDHOUR", item.CAPIBLOCK_CREATEDHOUR);
							command.Parameters.AddWithValue("CAPIBLOCK_CREATEDMIN", item.CAPIBLOCK_CREATEDMIN);
							command.Parameters.AddWithValue("CAPIBLOCK_CREATEDSEC", item.CAPIBLOCK_CREATEDSEC);
							command.Parameters.AddWithValue("SALESMANREF", item.SALESMANREF);
							command.Parameters.AddWithValue("CANCELLEDACC", item.CANCELLEDACC);
							command.Parameters.AddWithValue("SHPTYPCOD", item.SHPTYPCOD);
							command.Parameters.AddWithValue("SHPAGNCOD", item.SHPAGNCOD);
							command.Parameters.AddWithValue("TRACKNR", item.TRACKNR);
							command.Parameters.AddWithValue("GENEXCTYP", item.GENEXCTYP);
							command.Parameters.AddWithValue("LINEEXCTYP", item.LINEEXCTYP);
							command.Parameters.AddWithValue("TRADINGGRP", item.TRADINGGRP);
							command.Parameters.AddWithValue("TEXTINC", item.TEXTINC);
							command.Parameters.AddWithValue("SITEID", item.SITEID);
							command.Parameters.AddWithValue("RECSTATUS", item.RECSTATUS);
							command.Parameters.AddWithValue("ORGLOGICREF", item.ORGLOGICREF);
							command.Parameters.AddWithValue("WFSTATUS", item.WFSTATUS);
							command.Parameters.AddWithValue("SHIPINFOREF", item.SHIPINFOREF);
							command.Parameters.AddWithValue("DISTORDERREF", item.DISTORDERREF);
							command.Parameters.AddWithValue("SENDCNT", item.SENDCNT);
							command.Parameters.AddWithValue("DLVCLIENT", item.DLVCLIENT);
							command.Parameters.AddWithValue("DOCTRACKINGNR", item.DOCTRACKINGNR);
							command.Parameters.AddWithValue("ADDTAXCALC", item.ADDTAXCALC);
							command.Parameters.AddWithValue("TOTALADDTAX", item.TOTALADDTAX);
							command.Parameters.AddWithValue("UGIRTRACKINGNO", item.UGIRTRACKINGNO);
							command.Parameters.AddWithValue("QPRODFCREF", item.QPRODFCREF);
							command.Parameters.AddWithValue("VAACCREF", item.VAACCREF);
							command.Parameters.AddWithValue("VACENTERREF", item.VACENTERREF);
							command.Parameters.AddWithValue("ORGLOGOID", item.ORGLOGOID);
							command.Parameters.AddWithValue("FROMEXIM", item.FROMEXIM);
							command.Parameters.AddWithValue("FRGTYPCOD", item.FRGTYPCOD);
							command.Parameters.AddWithValue("TRCURR", item.TRCURR);
							command.Parameters.AddWithValue("TRRATE", item.TRRATE);
							command.Parameters.AddWithValue("TRNET", item.TRNET);
							command.Parameters.AddWithValue("EXIMWHFCREF", item.EXIMWHFCREF);
							command.Parameters.AddWithValue("EXIMFCTYPE", item.EXIMFCTYPE);
							command.Parameters.AddWithValue("MAINSTFCREF", item.MAINSTFCREF);
							command.Parameters.AddWithValue("FROMORDWITHPAY", item.FROMORDWITHPAY);
							command.Parameters.AddWithValue("PROJECTREF", item.PROJECTREF);
							command.Parameters.AddWithValue("WFLOWCRDREF", item.WFLOWCRDREF);
							command.Parameters.AddWithValue("STATUS", item.STATUS);
							command.Parameters.AddWithValue("UPDTRCURR", item.UPDTRCURR);
							command.Parameters.AddWithValue("TOTALEXADDTAX", item.TOTALEXADDTAX);
							command.Parameters.AddWithValue("AFFECTCOLLATRL", item.AFFECTCOLLATRL);
							command.Parameters.AddWithValue("DEDUCTIONPART1", item.DEDUCTIONPART1);
							command.Parameters.AddWithValue("DEDUCTIONPART2", item.DEDUCTIONPART2);
							command.Parameters.AddWithValue("GRPFIRMTRANS", item.GRPFIRMTRANS);
							command.Parameters.AddWithValue("AFFECTRISK", item.AFFECTRISK);
							command.Parameters.AddWithValue("DISPSTATUS", item.DISPSTATUS);
							command.Parameters.AddWithValue("APPROVE", item.APPROVE);
							command.Parameters.AddWithValue("CANTCREDEDUCT", item.CANTCREDEDUCT);
							command.Parameters.AddWithValue("SHIPTIME", item.SHIPTIME);
							command.Parameters.AddWithValue("ENTRUSTDEVIR", item.ENTRUSTDEVIR);
							command.Parameters.AddWithValue("RELTRANSFCREF", item.RELTRANSFCREF);
							command.Parameters.AddWithValue("FROMTRANSFER", item.FROMTRANSFER);
							command.Parameters.AddWithValue("GUID", item.GUID);
							command.Parameters.AddWithValue("GLOBALID", item.GLOBALID);
							command.Parameters.AddWithValue("COMPSTFCREF", item.COMPSTFCREF);
							command.Parameters.AddWithValue("COMPINVREF", item.COMPINVREF);
							command.Parameters.AddWithValue("TOTALSERVICES", item.TOTALSERVICES);
							command.Parameters.AddWithValue("CAMPAIGNCODE", item.CAMPAIGNCODE);
							command.Parameters.AddWithValue("OFFERREF", item.OFFERREF);
							command.Parameters.AddWithValue("EINVOICETYP", item.EINVOICETYP);
							command.Parameters.AddWithValue("EINVOICE", item.EINVOICE);
							command.Parameters.AddWithValue("NOCALCULATE", item.NOCALCULATE);
							command.Parameters.AddWithValue("PRODORDERTYP", item.PRODORDERTYP);
							command.Parameters.AddWithValue("QPRODFCTYP", item.QPRODFCTYP);
							command.Parameters.AddWithValue("PRDORDSLPLNRESERVE", item.PRDORDSLPLNRESERVE);
							command.Parameters.AddWithValue("CONTROLINFO", item.CONTROLINFO);
							command.Parameters.AddWithValue("EDESPATCH", item.EDESPATCH);
							command.Parameters.AddWithValue("DOCTIME", item.DOCTIME);
							command.Parameters.AddWithValue("EDESPSTATUS", item.EDESPSTATUS);
							command.Parameters.AddWithValue("PROFILEID", item.PROFILEID);
							command.Parameters.AddWithValue("DELIVERYCODE", item.DELIVERYCODE);
							command.Parameters.AddWithValue("DESTSTATUS", item.DESTSTATUS);
							command.Parameters.AddWithValue("CANCELEXP", item.CANCELEXP);
							command.Parameters.AddWithValue("UNDOEXP", item.UNDOEXP);

							var id = await command.ExecuteScalarAsync();
							await connection.CloseAsync();
							ReferenceId = Convert.ToInt32(id);
						}
					}
					#endregion


					if (item.TRCODE == 2 || item.TRCODE == 3 || item.TRCODE == 7 || item.TRCODE == 8)
					{
						#region Driver Insert

						string driverQuery = string.Format(@$"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_EINVOICEDET
            ([INVOICEREF]
           ,[STFREF]
           ,[EINVOICETYP]
           ,[PROFILEID]
           ,[ESTATUS]
           ,[EDESCRIPTION]
           ,[EDURATION]
           ,[EDURATIONTYPE]
           ,[TAXTYPE]
           ,[TUNAME]
           ,[TUSURNAME]
           ,[TUPASSPORTNO]
           ,[TUNATIONALITY]
           ,[TUNATIONALITYNAME]
           ,[TUBANKNAME]
           ,[TUBNACCOUNTNO]
           ,[TUBNBRANCH]
           ,[TUPAYMENTNOTE]
           ,[TUBNCURR]
           ,[ADDR1]
           ,[ADDR2]
           ,[CITYCODE]
           ,[CITY]
           ,[COUNTRYCODE]
           ,[COUNTRY]
           ,[DISTRICTCODE]
           ,[DISTRICT]
           ,[TOWNCODE]
           ,[TOWN]
           ,[EXITTOWN]
           ,[EXITGATECODE]
           ,[EXITGATE]
           ,[AGENCYCODE]
           ,[AGENCY]
           ,[EXITCOUNTRYCODE]
           ,[EXITCOUNTRY]
           ,[TRANSPORTTYP]
           ,[TRANSPORTTYPCODE]
           ,[TRANSPORTTYPNAME]
           ,[FLIGHTNUMBER]
           ,[GUIDE]
           ,[TURETPRICE]
           ,[SENDEINVCUSTOM]
           ,[EINVOICETYPSGK]
           ,[TAXPAYERCODE]
           ,[TAXPAYERNAME]
           ,[DOCUMENTNOSGK]
           ,[DRIVERNAME1]
           ,[DRIVERNAME2]
           ,[DRIVERNAME3]
           ,[DRIVERSURNAME1]
           ,[DRIVERSURNAME2]
           ,[DRIVERSURNAME3]
           ,[DRIVERTCKNO1]
           ,[DRIVERTCKNO2]
           ,[DRIVERTCKNO3]
           ,[PLATENUM1]
           ,[PLATENUM2]
           ,[PLATENUM3]
           ,[CHASSISNUM1]
           ,[CHASSISNUM2]
           ,[CHASSISNUM3]
           ,[RESPONSECODE]
           ,[RESPONSESTATUS]
           ,[STATUSDESC]
           ,[RESPONSECODEDESP]
           ,[RESPONSESTATUSDESP]
           ,[STATUSDESCDESP]
           ,[ORDFCREF]
           ,[CHAINDELIVERY]
           ,[SELLERCLIENTREF]
           ,[TAXNRTOPAY]) 
            VALUES(
            @INVOICEREF,@STFREF,@EINVOICETYP,@PROFILEID,@ESTATUS,@EDESCRIPTION,@EDURATION,@EDURATIONTYPE,@TAXTYPE,@TUNAME
           ,@TUSURNAME,@TUPASSPORTNO,@TUNATIONALITY,@TUNATIONALITYNAME,@TUBANKNAME,@TUBNACCOUNTNO,@TUBNBRANCH
           ,@TUPAYMENTNOTE,@TUBNCURR,@ADDR1,@ADDR2,@CITYCODE,@CITY,@COUNTRYCODE,@COUNTRY
           ,@DISTRICTCODE,@DISTRICT,@TOWNCODE,@TOWN,@EXITTOWN,@EXITGATECODE,@EXITGATE,@AGENCYCODE,@AGENCY,@EXITCOUNTRYCODE,@EXITCOUNTRY
           ,@TRANSPORTTYP,@TRANSPORTTYPCODE,@TRANSPORTTYPNAME,@FLIGHTNUMBER,@GUIDE,@TURETPRICE,@SENDEINVCUSTOM
           ,@EINVOICETYPSGK,@TAXPAYERCODE,@TAXPAYERNAME,@DOCUMENTNOSGK,@DRIVERNAME1,@DRIVERNAME2,@DRIVERNAME3,@DRIVERSURNAME1
           ,@DRIVERSURNAME2,@DRIVERSURNAME3,@DRIVERTCKNO1,@DRIVERTCKNO2,@DRIVERTCKNO3,@PLATENUM1,@PLATENUM2,@PLATENUM3,@CHASSISNUM1
           ,@CHASSISNUM2,@CHASSISNUM3,@RESPONSECODE,@RESPONSESTATUS,@STATUSDESC,@RESPONSECODEDESP,@RESPONSESTATUSDESP,@STATUSDESCDESP,@ORDFCREF,@CHAINDELIVERY
           ,@SELLERCLIENTREF,@TAXNRTOPAY); SELECT SCOPE_IDENTITY();");

						await using (SqlConnection connection = new SqlConnection(_connectionString))
						{
							await connection.OpenAsync();
							await using (SqlCommand command = new SqlCommand(driverQuery, connection))
							{
								//command.Parameters.AddWithValue("EENDDATE", item.EENDDATE ?? default(DateTime));
								//command.Parameters.AddWithValue("ESTARTDATE", item.ESTARTDATE ?? default(DateTime));
								//command.Parameters.AddWithValue("EXITDATE", item.EXITDATE ?? default(DateTime));
								//command.Parameters.AddWithValue("TUPASSPORTDATE", item.TUPASSPORTDATE ?? default(DateTime));
								command.Parameters.AddWithValue("INVOICEREF", item.EINVOICEDET.INVOICEREF);
								command.Parameters.AddWithValue("ORDFCREF", item.EINVOICEDET.ORDFCREF);
								command.Parameters.AddWithValue("SELLERCLIENTREF", item.EINVOICEDET.SELLERCLIENTREF);
								command.Parameters.AddWithValue("STFREF", ReferenceId);
								command.Parameters.AddWithValue("CHASSISNUM1", item.EINVOICEDET.CHASSISNUM1);
								command.Parameters.AddWithValue("CHASSISNUM2", item.EINVOICEDET.CHASSISNUM2);
								command.Parameters.AddWithValue("CHASSISNUM3", item.EINVOICEDET.CHASSISNUM3);
								command.Parameters.AddWithValue("FLIGHTNUMBER", item.EINVOICEDET.FLIGHTNUMBER);
								command.Parameters.AddWithValue("PLATENUM1", item.EINVOICEDET.PLATENUM1);
								command.Parameters.AddWithValue("PLATENUM2", item.EINVOICEDET.PLATENUM2);
								command.Parameters.AddWithValue("PLATENUM3", item.EINVOICEDET.PLATENUM3);
								command.Parameters.AddWithValue("DISTRICTCODE", item.EINVOICEDET.DISTRICTCODE);
								command.Parameters.AddWithValue("DRIVERTCKNO1", item.EINVOICEDET.DRIVERTCKNO1);
								command.Parameters.AddWithValue("DRIVERTCKNO2", item.EINVOICEDET.DRIVERTCKNO2);
								command.Parameters.AddWithValue("DRIVERTCKNO3", item.EINVOICEDET.DRIVERTCKNO3);
								command.Parameters.AddWithValue("EXITCOUNTRY", item.EINVOICEDET.EXITCOUNTRY);
								command.Parameters.AddWithValue("EXITCOUNTRYCODE", item.EINVOICEDET.EXITCOUNTRYCODE);
								command.Parameters.AddWithValue("COUNTRYCODE", item.EINVOICEDET.COUNTRYCODE);
								command.Parameters.AddWithValue("COUNTRY", item.EINVOICEDET.COUNTRY);
								command.Parameters.AddWithValue("GUIDE", item.EINVOICEDET.GUIDE);
								command.Parameters.AddWithValue("CITY", item.EINVOICEDET.CITY);
								command.Parameters.AddWithValue("CITYCODE", item.EINVOICEDET.CITYCODE);
								command.Parameters.AddWithValue("AGENCYCODE", item.EINVOICEDET.AGENCYCODE);
								command.Parameters.AddWithValue("TRANSPORTTYPCODE", item.EINVOICEDET.TRANSPORTTYPCODE);
								command.Parameters.AddWithValue("TOWNCODE", item.EINVOICEDET.TOWNCODE);
								command.Parameters.AddWithValue("TOWN", item.EINVOICEDET.TOWN);
								command.Parameters.AddWithValue("TAXPAYERCODE", item.EINVOICEDET.TAXPAYERCODE);
								command.Parameters.AddWithValue("ADDR1", item.EINVOICEDET.ADDR1);
								command.Parameters.AddWithValue("ADDR2", item.EINVOICEDET.ADDR2);
								command.Parameters.AddWithValue("AGENCY", item.EINVOICEDET.AGENCY);
								command.Parameters.AddWithValue("DISTRICT", item.EINVOICEDET.DISTRICT);
								command.Parameters.AddWithValue("DOCUMENTNOSGK", item.EINVOICEDET.DOCUMENTNOSGK);
								command.Parameters.AddWithValue("DRIVERNAME1", item.EINVOICEDET.DRIVERNAME1);
								command.Parameters.AddWithValue("DRIVERNAME2", item.EINVOICEDET.DRIVERNAME2);
								command.Parameters.AddWithValue("DRIVERNAME3", item.EINVOICEDET.DRIVERNAME3);
								command.Parameters.AddWithValue("DRIVERSURNAME1", item.EINVOICEDET.DRIVERSURNAME1);
								command.Parameters.AddWithValue("DRIVERSURNAME2", item.EINVOICEDET.DRIVERSURNAME2);
								command.Parameters.AddWithValue("DRIVERSURNAME3", item.EINVOICEDET.DRIVERSURNAME3);
								command.Parameters.AddWithValue("EDESCRIPTION", item.EINVOICEDET.EDESCRIPTION);
								command.Parameters.AddWithValue("TRANSPORTTYPNAME", item.EINVOICEDET.TRANSPORTTYPNAME);
								command.Parameters.AddWithValue("TUSURNAME", item.EINVOICEDET.TUSURNAME);
								command.Parameters.AddWithValue("TUNAME", item.EINVOICEDET.TUNAME);
								command.Parameters.AddWithValue("TUNATIONALITY", item.EINVOICEDET.TUNATIONALITY);
								command.Parameters.AddWithValue("TUNATIONALITYNAME", item.EINVOICEDET.TUNATIONALITYNAME);
								command.Parameters.AddWithValue("TUBNCURR", item.EINVOICEDET.TUBNCURR);
								command.Parameters.AddWithValue("TUBNBRANCH", item.EINVOICEDET.TUBNBRANCH);
								command.Parameters.AddWithValue("TUBNACCOUNTNO", item.EINVOICEDET.TUBNACCOUNTNO);
								command.Parameters.AddWithValue("TUBANKNAME", item.EINVOICEDET.TUBANKNAME);
								command.Parameters.AddWithValue("STATUSDESC", item.EINVOICEDET.STATUSDESC);
								command.Parameters.AddWithValue("STATUSDESCDESP", item.EINVOICEDET.STATUSDESCDESP);
								command.Parameters.AddWithValue("TUPAYMENTNOTE", item.EINVOICEDET.TUPAYMENTNOTE);
								command.Parameters.AddWithValue("TAXPAYERNAME", item.EINVOICEDET.TAXPAYERNAME);
								command.Parameters.AddWithValue("TAXNRTOPAY", item.EINVOICEDET.TAXNRTOPAY);
								command.Parameters.AddWithValue("TUPASSPORTNO", item.EINVOICEDET.TUPASSPORTNO);
								command.Parameters.AddWithValue("EXITTOWN", item.EINVOICEDET.EXITTOWN);
								command.Parameters.AddWithValue("EXITGATECODE", item.EINVOICEDET.EXITGATECODE);
								command.Parameters.AddWithValue("EXITGATE", item.EINVOICEDET.EXITGATE);
								command.Parameters.AddWithValue("RESPONSECODE", item.EINVOICEDET.RESPONSECODE);
								command.Parameters.AddWithValue("CHAINDELIVERY", item.EINVOICEDET.CHAINDELIVERY);
								command.Parameters.AddWithValue("TURETPRICE", item.EINVOICEDET.TURETPRICE);
								command.Parameters.AddWithValue("SENDEINVCUSTOM", item.EINVOICEDET.SENDEINVCUSTOM);
								command.Parameters.AddWithValue("RESPONSECODEDESP", item.EINVOICEDET.RESPONSECODEDESP);
								command.Parameters.AddWithValue("RESPONSESTATUS", item.EINVOICEDET.RESPONSESTATUS);
								command.Parameters.AddWithValue("RESPONSESTATUSDESP", item.EINVOICEDET.RESPONSESTATUSDESP);
								command.Parameters.AddWithValue("EDURATIONTYPE", item.EINVOICEDET.EDURATIONTYPE);
								command.Parameters.AddWithValue("EINVOICETYP", item.EINVOICEDET.EINVOICETYP);
								command.Parameters.AddWithValue("EINVOICETYPSGK", item.EINVOICEDET.EINVOICETYPSGK);
								command.Parameters.AddWithValue("TAXTYPE", item.EINVOICEDET.TAXTYPE);
								command.Parameters.AddWithValue("TRANSPORTTYP", item.EINVOICEDET.TRANSPORTTYP);
								command.Parameters.AddWithValue("PROFILEID", item.EINVOICEDET.PROFILEID);
								command.Parameters.AddWithValue("ESTATUS", item.EINVOICEDET.ESTATUS);
								command.Parameters.AddWithValue("EDURATION", item.EINVOICEDET.EDURATION);
								var id = await command.ExecuteScalarAsync();
								await connection.CloseAsync();
							}
						}
						#endregion
					}


					#region Line Insert
					foreach (LG_STLINE line in item.TRANSACTIONS)
					{
						string lineQuery = $@"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_STLINE(
            STOCKREF
           ,LINETYPE
           ,PREVLINEREF
           ,PREVLINENO
           ,DETLINE
           ,TRCODE
           ,DATE_
           ,FTIME
           ,GLOBTRANS
           ,CALCTYPE
           ,PRODORDERREF
           ,SOURCETYPE
           ,SOURCEINDEX
           ,SOURCECOSTGRP
           ,SOURCEWSREF
           ,SOURCEPOLNREF
           ,DESTTYPE
           ,DESTINDEX
           ,DESTCOSTGRP
           ,DESTWSREF
           ,DESTPOLNREF
           ,FACTORYNR
           ,IOCODE
           ,STFICHEREF
           ,STFICHELNNO
           ,INVOICEREF
           ,INVOICELNNO
           ,CLIENTREF
           ,ORDTRANSREF
           ,ORDFICHEREF
           ,CENTERREF
           ,ACCOUNTREF
           ,VATACCREF
           ,VATCENTERREF
           ,PRACCREF
           ,PRCENTERREF
           ,PRVATACCREF
           ,PRVATCENREF
           ,PROMREF
           ,PAYDEFREF
           ,SPECODE
           ,DELVRYCODE
           ,AMOUNT
           ,PRICE
           ,TOTAL
           ,PRCURR
           ,PRPRICE
           ,TRCURR
           ,TRRATE
           ,REPORTRATE
           ,DISTCOST
           ,DISTDISC
           ,DISTEXP
           ,DISTPROM
           ,DISCPER
           ,LINEEXP
           ,UOMREF
           ,USREF
           ,UINFO1
           ,UINFO2
           ,UINFO3
           ,UINFO4
           ,UINFO5
           ,UINFO6
           ,UINFO7
           ,UINFO8
           ,PLNAMOUNT
           ,VATINC
           ,VAT
           ,VATAMNT
           ,VATMATRAH
           ,BILLEDITEM
           ,BILLED
           ,CPSTFLAG
           ,RETCOSTTYPE
           ,SOURCELINK
           ,RETCOST
           ,RETCOSTCURR
           ,OUTCOST
           ,OUTCOSTCURR
           ,RETAMOUNT
           ,FAREGREF
           ,FAATTRIB
           ,CANCELLED
           ,LINENET
           ,DISTADDEXP
           ,FADACCREF
           ,FADCENTERREF
           ,FARACCREF
           ,FARCENTERREF
           ,DIFFPRICE
           ,DIFFPRCOST
           ,DECPRDIFF
           ,LPRODSTAT
           ,PRDEXPTOTAL
           ,DIFFREPPRICE
           ,DIFFPRCRCOST
           ,SALESMANREF
           ,FAPLACCREF
           ,FAPLCENTERREF
           ,OUTPUTIDCODE
           ,DREF
           ,COSTRATE
           ,XPRICEUPD
           ,XPRICE
           ,XREPRATE
           ,DISTCOEF
           ,TRANSQCOK
           ,SITEID
           ,RECSTATUS
           ,ORGLOGICREF
           ,WFSTATUS
           ,POLINEREF
           ,PLNSTTRANSREF
           ,NETDISCFLAG
           ,NETDISCPERC
           ,NETDISCAMNT
           ,VATCALCDIFF
           ,CONDITIONREF
           ,DISTORDERREF
           ,DISTORDLINEREF
           ,CAMPAIGNREFS1
           ,CAMPAIGNREFS2
           ,CAMPAIGNREFS3
           ,CAMPAIGNREFS4
           ,CAMPAIGNREFS5
           ,POINTCAMPREF
           ,CAMPPOINT
           ,PROMCLASITEMREF
           ,CMPGLINEREF
           ,PLNSTTRANSPERNR
           ,PORDCLSPLNAMNT
           ,VENDCOMM
           ,PREVIOUSOUTCOST
           ,COSTOFSALEACCREF
           ,PURCHACCREF
           ,COSTOFSALECNTREF
           ,PURCHCENTREF
           ,PREVOUTCOSTCURR
           ,ABVATAMOUNT
           ,ABVATSTATUS
           ,PRRATE
           ,ADDTAXRATE
           ,ADDTAXCONVFACT
           ,ADDTAXAMOUNT
           ,ADDTAXPRCOST
           ,ADDTAXRETCOST
           ,ADDTAXRETCOSTCURR
           ,GROSSUINFO1
           ,GROSSUINFO2
           ,ADDTAXPRCOSTCURR
           ,ADDTAXACCREF
           ,ADDTAXCENTERREF
           ,ADDTAXAMNTISUPD
           ,INFIDX
           ,ADDTAXCOSACCREF
           ,ADDTAXCOSCNTREF
           ,PREVIOUSATAXPRCOST
           ,PREVATAXPRCOSTCURR
           ,PRDORDTOTCOEF
           ,DEMPEGGEDAMNT
           ,STDUNITCOST
           ,STDRPUNITCOST
           ,COSTDIFFACCREF
           ,COSTDIFFCENREF
           ,TEXTINC
           ,ADDTAXDISCAMOUNT
           ,ORGLOGOID
           ,EXIMFICHENO
           ,EXIMFCTYPE
           ,TRANSEXPLINE
           ,INSEXPLINE
           ,EXIMWHFCREF
           ,EXIMWHLNREF
           ,EXIMFILEREF
           ,EXIMPROCNR
           ,EISRVDSTTYP
           ,MAINSTLNREF
           ,MADEOFSHRED
           ,FROMORDWITHPAY
           ,PROJECTREF
           ,STATUS
           ,DORESERVE
           ,POINTCAMPREFS1
           ,POINTCAMPREFS2
           ,POINTCAMPREFS3
           ,POINTCAMPREFS4
           ,CAMPPOINTS1
           ,CAMPPOINTS2
           ,CAMPPOINTS3
           ,CAMPPOINTS4
           ,CMPGLINEREFS1
           ,CMPGLINEREFS2
           ,CMPGLINEREFS3
           ,CMPGLINEREFS4
           ,PRCLISTREF
           ,PORDSYMOUTLN
           ,MONTH_
           ,YEAR_
           ,EXADDTAXRATE
           ,EXADDTAXCONVF
           ,EXADDTAXAREF
           ,EXADDTAXCREF
           ,OTHRADDTAXAREF
           ,OTHRADDTAXCREF
           ,EXADDTAXAMNT
           ,AFFECTCOLLATRL
           ,ALTPROMFLAG
           ,EIDISTFLNNR
           ,EXIMTYPE
           ,VARIANTREF
           ,CANDEDUCT
           ,OUTREMAMNT
           ,OUTREMCOST
           ,OUTREMCOSTCURR
           ,REFLVATACCREF
           ,REFLVATOTHACCREF
           ,PARENTLNREF
           ,AFFECTRISK
           ,INEFFECTIVECOST
           ,ADDTAXVATMATRAH
           ,REFLACCREF
           ,REFLOTHACCREF
           ,CAMPPAYDEFREF
           ,FAREGBINDDATE
           ,RELTRANSLNREF
           ,FROMTRANSFER
           ,COSTDISTPRICE
           ,COSTDISTREPPRICE
           ,DIFFPRICEUFRS
           ,DIFFREPPRICEUFRS
           ,OUTCOSTUFRS
           ,OUTCOSTCURRUFRS
           ,DIFFPRCOSTUFRS
           ,DIFFPRCRCOSTUFRS
           ,RETCOSTUFRS
           ,RETCOSTCURRUFRS
           ,OUTREMCOSTUFRS
           ,OUTREMCOSTCURRUFRS
           ,INFIDXUFRS
           ,ADJPRICEUFRS
           ,ADJREPPRICEUFRS
           ,ADJPRCOSTUFRS
           ,ADJPRCRCOSTUFRS
           ,COSTDISTPRICEUFRS
           ,COSTDISTREPPRICEUFRS
           ,PURCHACCREFUFRS
           ,PURCHCENTREFUFRS
           ,COSACCREFUFRS
           ,COSCNTREFUFRS
           ,PROUTCOSTUFRSDIFF
           ,PROUTCOSTCRUFRSDIFF
           ,UNDERDEDUCTLIMIT
           ,GLOBALID
           ,DEDUCTIONPART1
           ,DEDUCTIONPART2
           ,GUID
           ,SPECODE2
           ,OFFERREF
           ,OFFTRANSREF
           ,VATEXCEPTREASON
           ,PLNDEFSERILOTNO
           ,PLNUNRSRVAMOUNT
           ,PORDCLSPLNUNRSRVAMNT
           ,LPRODRSRVSTAT
           ,FALINKTYPE
           ,DEDUCTCODE
           ,UPDTHISLINE
           ,VATEXCEPTCODE
           ,PORDERFICHENO
           ,QPRODFCREF
           ,RELTRANSFCREF
           ,ATAXEXCEPTREASON
           ,ATAXEXCEPTCODE
           ,PRODORDERTYP
           ,SUBCONTORDERREF
           ,QPRODFCTYP
           ,PRDORDSLPLNRESERVE
           ,INFDATE
           ,DESTSTATUS
           ,REGTYPREF
           ,FAPROFITACCREF
           ,FAPROFITCENTREF
           ,FALOSSACCREF
           ,FALOSSCENTREF
           ,CPACODE
           ,GTIPCODE
           ,PUBLICCOUNTRYREF
           ,QPRODITEMTYPE
           ,FUTMONTHCNT
           ,FUTMONTHBEGDATE

          
          
             )
            VALUES (
            @STOCKREF
           ,@LINETYPE
           ,@PREVLINEREF
           ,@PREVLINENO
           ,@DETLINE
           ,@TRCODE
           ,@DATE_
           ,(SELECT [dbo].[LG_TIMETOINT](@FHOUR,@FMINUTE,@FSECOND))
           ,@GLOBTRANS
           ,@CALCTYPE
           ,@PRODORDERREF
           ,@SOURCETYPE
           ,@SOURCEINDEX
           ,@SOURCECOSTGRP
           ,@SOURCEWSREF
           ,@SOURCEPOLNREF
           ,@DESTTYPE
           ,@DESTINDEX
           ,@DESTCOSTGRP
           ,@DESTWSREF
           ,@DESTPOLNREF
           ,@FACTORYNR
           ,@IOCODE
           ,@STFICHEREF
           ,@STFICHELNNO
           ,@INVOICEREF
           ,@INVOICELNNO
           ,@CLIENTREF
           ,@ORDTRANSREF
           ,@ORDFICHEREF
           ,@CENTERREF
           ,@ACCOUNTREF
           ,@VATACCREF
           ,@VATCENTERREF
           ,@PRACCREF
           ,@PRCENTERREF
           ,@PRVATACCREF
           ,@PRVATCENREF
           ,@PROMREF
           ,@PAYDEFREF
           ,@SPECODE
           ,@DELVRYCODE
           ,@AMOUNT
           ,@PRICE
           ,@TOTAL
           ,@PRCURR
           ,@PRPRICE
           ,@TRCURR
           ,@TRRATE
           ,@REPORTRATE
           ,@DISTCOST
           ,@DISTDISC
           ,@DISTEXP
           ,@DISTPROM
           ,@DISCPER
           ,@LINEEXP
           ,@UOMREF
           ,@USREF
           ,@UINFO1
           ,@UINFO2
           ,@UINFO3
           ,@UINFO4
           ,@UINFO5
           ,@UINFO6
           ,@UINFO7
           ,@UINFO8
           ,@PLNAMOUNT
           ,@VATINC
           ,@VAT
           ,@VATAMNT
           ,@VATMATRAH
           ,@BILLEDITEM
           ,@BILLED
           ,@CPSTFLAG
           ,@RETCOSTTYPE
           ,@SOURCELINK
           ,@RETCOST
           ,@RETCOSTCURR
           ,@OUTCOST
           ,@OUTCOSTCURR
           ,@RETAMOUNT
           ,@FAREGREF
           ,@FAATTRIB
           ,@CANCELLED
           ,@LINENET
           ,@DISTADDEXP
           ,@FADACCREF
           ,@FADCENTERREF
           ,@FARACCREF
           ,@FARCENTERREF
           ,@DIFFPRICE
           ,@DIFFPRCOST
           ,@DECPRDIFF
           ,@LPRODSTAT
           ,@PRDEXPTOTAL
           ,@DIFFREPPRICE
           ,@DIFFPRCRCOST
           ,@SALESMANREF
           ,@FAPLACCREF
           ,@FAPLCENTERREF
           ,@OUTPUTIDCODE
           ,@DREF
           ,@COSTRATE
           ,@XPRICEUPD
           ,@XPRICE
           ,@XREPRATE
           ,@DISTCOEF
           ,@TRANSQCOK
           ,@SITEID
           ,@RECSTATUS
           ,@ORGLOGICREF
           ,@WFSTATUS
           ,@POLINEREF
           ,@PLNSTTRANSREF
           ,@NETDISCFLAG
           ,@NETDISCPERC
           ,@NETDISCAMNT
           ,@VATCALCDIFF
           ,@CONDITIONREF
           ,@DISTORDERREF
           ,@DISTORDLINEREF
           ,@CAMPAIGNREFS1
           ,@CAMPAIGNREFS2
           ,@CAMPAIGNREFS3
           ,@CAMPAIGNREFS4
           ,@CAMPAIGNREFS5
           ,@POINTCAMPREF
           ,@CAMPPOINT
           ,@PROMCLASITEMREF
           ,@CMPGLINEREF
           ,@PLNSTTRANSPERNR
           ,@PORDCLSPLNAMNT
           ,@VENDCOMM
           ,@PREVIOUSOUTCOST
           ,@COSTOFSALEACCREF
           ,@PURCHACCREF
           ,@COSTOFSALECNTREF
           ,@PURCHCENTREF
           ,@PREVOUTCOSTCURR
           ,@ABVATAMOUNT
           ,@ABVATSTATUS
           ,@PRRATE
           ,@ADDTAXRATE
           ,@ADDTAXCONVFACT
           ,@ADDTAXAMOUNT
           ,@ADDTAXPRCOST
           ,@ADDTAXRETCOST
           ,@ADDTAXRETCOSTCURR
           ,@GROSSUINFO1
           ,@GROSSUINFO2
           ,@ADDTAXPRCOSTCURR
           ,@ADDTAXACCREF
           ,@ADDTAXCENTERREF
           ,@ADDTAXAMNTISUPD
           ,@INFIDX
           ,@ADDTAXCOSACCREF
           ,@ADDTAXCOSCNTREF
           ,@PREVIOUSATAXPRCOST
           ,@PREVATAXPRCOSTCURR
           ,@PRDORDTOTCOEF
           ,@DEMPEGGEDAMNT
           ,@STDUNITCOST
           ,@STDRPUNITCOST
           ,@COSTDIFFACCREF
           ,@COSTDIFFCENREF
           ,@TEXTINC
           ,@ADDTAXDISCAMOUNT
           ,@ORGLOGOID
           ,@EXIMFICHENO
           ,@EXIMFCTYPE
           ,@TRANSEXPLINE
           ,@INSEXPLINE
           ,@EXIMWHFCREF
           ,@EXIMWHLNREF
           ,@EXIMFILEREF
           ,@EXIMPROCNR
           ,@EISRVDSTTYP
           ,@MAINSTLNREF
           ,@MADEOFSHRED
           ,@FROMORDWITHPAY
           ,@PROJECTREF
           ,@STATUS
           ,@DORESERVE
           ,@POINTCAMPREFS1
           ,@POINTCAMPREFS2
           ,@POINTCAMPREFS3
           ,@POINTCAMPREFS4
           ,@CAMPPOINTS1
           ,@CAMPPOINTS2
           ,@CAMPPOINTS3
           ,@CAMPPOINTS4
           ,@CMPGLINEREFS1
           ,@CMPGLINEREFS2
           ,@CMPGLINEREFS3
           ,@CMPGLINEREFS4
           ,@PRCLISTREF
           ,@PORDSYMOUTLN
           ,@MONTH_
           ,@YEAR_
           ,@EXADDTAXRATE
           ,@EXADDTAXCONVF
           ,@EXADDTAXAREF
           ,@EXADDTAXCREF
           ,@OTHRADDTAXAREF
           ,@OTHRADDTAXCREF
           ,@EXADDTAXAMNT
           ,@AFFECTCOLLATRL
           ,@ALTPROMFLAG
           ,@EIDISTFLNNR
           ,@EXIMTYPE
           ,@VARIANTREF
           ,@CANDEDUCT
           ,@OUTREMAMNT
           ,@OUTREMCOST
           ,@OUTREMCOSTCURR
           ,@REFLVATACCREF
           ,@REFLVATOTHACCREF
           ,@PARENTLNREF
           ,@AFFECTRISK
           ,@INEFFECTIVECOST
           ,@ADDTAXVATMATRAH
           ,@REFLACCREF
           ,@REFLOTHACCREF
           ,@CAMPPAYDEFREF
           ,@FAREGBINDDATE
           ,@RELTRANSLNREF
           ,@FROMTRANSFER
           ,@COSTDISTPRICE
           ,@COSTDISTREPPRICE
           ,@DIFFPRICEUFRS
           ,@DIFFREPPRICEUFRS
           ,@OUTCOSTUFRS
           ,@OUTCOSTCURRUFRS
           ,@DIFFPRCOSTUFRS
           ,@DIFFPRCRCOSTUFRS
           ,@RETCOSTUFRS
           ,@RETCOSTCURRUFRS
           ,@OUTREMCOSTUFRS
           ,@OUTREMCOSTCURRUFRS
           ,@INFIDXUFRS
           ,@ADJPRICEUFRS
           ,@ADJREPPRICEUFRS
           ,@ADJPRCOSTUFRS
           ,@ADJPRCRCOSTUFRS
           ,@COSTDISTPRICEUFRS
           ,@COSTDISTREPPRICEUFRS
           ,@PURCHACCREFUFRS
           ,@PURCHCENTREFUFRS
           ,@COSACCREFUFRS
           ,@COSCNTREFUFRS
           ,@PROUTCOSTUFRSDIFF
           ,@PROUTCOSTCRUFRSDIFF
           ,@UNDERDEDUCTLIMIT
           ,@GLOBALID
           ,@DEDUCTIONPART1
           ,@DEDUCTIONPART2
           ,@GUID
           ,@SPECODE2
           ,@OFFERREF
           ,@OFFTRANSREF
           ,@VATEXCEPTREASON
           ,@PLNDEFSERILOTNO
           ,@PLNUNRSRVAMOUNT
           ,@PORDCLSPLNUNRSRVAMNT
           ,@LPRODRSRVSTAT
           ,@FALINKTYPE
           ,@DEDUCTCODE
           ,@UPDTHISLINE
           ,@VATEXCEPTCODE
           ,@PORDERFICHENO
           ,@QPRODFCREF
           ,@RELTRANSFCREF
           ,@ATAXEXCEPTREASON
           ,@ATAXEXCEPTCODE
           ,@PRODORDERTYP
           ,@SUBCONTORDERREF
           ,@QPRODFCTYP
           ,@PRDORDSLPLNRESERVE
           ,@INFDATE
           ,@DESTSTATUS
           ,@REGTYPREF
           ,@FAPROFITACCREF
           ,@FAPROFITCENTREF
           ,@FALOSSACCREF
           ,@FALOSSCENTREF
           ,@CPACODE
           ,@GTIPCODE
           ,@PUBLICCOUNTRYREF
           ,@QPRODITEMTYPE
           ,@FUTMONTHCNT
           ,@FUTMONTHBEGDATE
           
           
           ); SELECT SCOPE_IDENTITY();";
						await using (SqlConnection connection = new SqlConnection(_connectionString))
						{
							await connection.OpenAsync();

							try
							{
								await using (SqlCommand command = new SqlCommand(lineQuery, connection))
								{
									command.Parameters.AddWithValue("STOCKREF", line.STOCKREF);
									command.Parameters.AddWithValue("LINETYPE", line.LINETYPE);
									command.Parameters.AddWithValue("PREVLINEREF", line.PREVLINEREF);
									command.Parameters.AddWithValue("PREVLINENO", line.PREVLINENO);
									command.Parameters.AddWithValue("DETLINE", line.DETLINE);
									command.Parameters.AddWithValue("TRCODE", line.TRCODE);
									command.Parameters.AddWithValue("DATE_", line.DATE_);
									command.Parameters.AddWithValue("FHOUR", item.DATE_.Hour);
									command.Parameters.AddWithValue("FMINUTE", item.DATE_.Minute);
									command.Parameters.AddWithValue("FSECOND", item.DATE_.Second);
									command.Parameters.AddWithValue("GLOBTRANS", line.GLOBTRANS);
									command.Parameters.AddWithValue("CALCTYPE", line.CALCTYPE);
									command.Parameters.AddWithValue("PRODORDERREF", line.PRODORDERREF);
									command.Parameters.AddWithValue("SOURCETYPE", line.SOURCETYPE);
									command.Parameters.AddWithValue("SOURCEINDEX", line.SOURCEINDEX);
									command.Parameters.AddWithValue("SOURCECOSTGRP", line.SOURCECOSTGRP);
									command.Parameters.AddWithValue("SOURCEWSREF", line.SOURCEWSREF);
									command.Parameters.AddWithValue("SOURCEPOLNREF", line.SOURCEPOLNREF);
									command.Parameters.AddWithValue("DESTTYPE", line.DESTTYPE);
									command.Parameters.AddWithValue("DESTINDEX", line.DESTINDEX);
									command.Parameters.AddWithValue("DESTCOSTGRP", line.DESTCOSTGRP);
									command.Parameters.AddWithValue("DESTWSREF", line.DESTWSREF);
									command.Parameters.AddWithValue("DESTPOLNREF", line.DESTPOLNREF);
									command.Parameters.AddWithValue("FACTORYNR", line.FACTORYNR);
									command.Parameters.AddWithValue("IOCODE", line.IOCODE);
									command.Parameters.AddWithValue("STFICHEREF", ReferenceId);
									command.Parameters.AddWithValue("STFICHELNNO", line.STFICHELNNO);
									command.Parameters.AddWithValue("INVOICEREF", line.INVOICEREF);
									command.Parameters.AddWithValue("INVOICELNNO", line.INVOICELNNO);
									command.Parameters.AddWithValue("CLIENTREF", line.CLIENTREF);
									command.Parameters.AddWithValue("ORDTRANSREF", line.ORDTRANSREF);
									command.Parameters.AddWithValue("ORDFICHEREF", line.ORDFICHEREF);
									command.Parameters.AddWithValue("CENTERREF", line.CENTERREF);
									command.Parameters.AddWithValue("ACCOUNTREF", line.ACCOUNTREF);
									command.Parameters.AddWithValue("VATACCREF", line.VATACCREF);
									command.Parameters.AddWithValue("VATCENTERREF", line.VATCENTERREF);
									command.Parameters.AddWithValue("PRACCREF", line.PRACCREF);
									command.Parameters.AddWithValue("PRCENTERREF", line.PRCENTERREF);
									command.Parameters.AddWithValue("PRVATACCREF", line.PRVATACCREF);
									command.Parameters.AddWithValue("PRVATCENREF", line.PRVATCENREF);
									command.Parameters.AddWithValue("PROMREF", line.PROMREF);
									command.Parameters.AddWithValue("PAYDEFREF", line.PAYDEFREF);
									command.Parameters.AddWithValue("SPECODE", line.SPECODE);
									command.Parameters.AddWithValue("DELVRYCODE", line.DELVRYCODE);
									command.Parameters.AddWithValue("AMOUNT", line.AMOUNT);
									command.Parameters.AddWithValue("PRICE", line.PRICE);
									command.Parameters.AddWithValue("TOTAL", line.TOTAL);
									command.Parameters.AddWithValue("PRCURR", line.PRCURR);
									command.Parameters.AddWithValue("PRPRICE", line.PRPRICE);
									command.Parameters.AddWithValue("TRCURR", line.TRCURR);
									command.Parameters.AddWithValue("TRRATE", line.TRRATE);
									command.Parameters.AddWithValue("REPORTRATE", line.REPORTRATE);
									command.Parameters.AddWithValue("DISTCOST", line.DISTCOST);
									command.Parameters.AddWithValue("DISTDISC", line.DISTDISC);
									command.Parameters.AddWithValue("DISTEXP", line.DISTEXP);
									command.Parameters.AddWithValue("DISTPROM", line.DISTPROM);
									command.Parameters.AddWithValue("DISCPER", line.DISCPER);
									command.Parameters.AddWithValue("LINEEXP", line.LINEEXP);
									command.Parameters.AddWithValue("UOMREF", line.UOMREF);
									command.Parameters.AddWithValue("USREF", line.USREF);
									command.Parameters.AddWithValue("UINFO1", line.UINFO1);
									command.Parameters.AddWithValue("UINFO2", line.UINFO2);
									command.Parameters.AddWithValue("UINFO3", line.UINFO3);
									command.Parameters.AddWithValue("UINFO4", line.UINFO4);
									command.Parameters.AddWithValue("UINFO5", line.UINFO5);
									command.Parameters.AddWithValue("UINFO6", line.UINFO6);
									command.Parameters.AddWithValue("UINFO7", line.UINFO7);
									command.Parameters.AddWithValue("UINFO8", line.UINFO8);
									command.Parameters.AddWithValue("PLNAMOUNT", line.PLNAMOUNT);
									command.Parameters.AddWithValue("VATINC", line.VATINC);
									command.Parameters.AddWithValue("VAT", line.VAT);
									command.Parameters.AddWithValue("VATAMNT", line.VATAMNT);
									command.Parameters.AddWithValue("VATMATRAH", line.VATMATRAH);
									command.Parameters.AddWithValue("BILLEDITEM", line.BILLEDITEM);
									command.Parameters.AddWithValue("BILLED", line.BILLED);
									command.Parameters.AddWithValue("CPSTFLAG", line.CPSTFLAG);
									command.Parameters.AddWithValue("RETCOSTTYPE", line.RETCOSTTYPE);
									command.Parameters.AddWithValue("SOURCELINK", line.SOURCELINK);
									command.Parameters.AddWithValue("RETCOST", line.RETCOST);
									command.Parameters.AddWithValue("RETCOSTCURR", line.RETCOSTCURR);
									command.Parameters.AddWithValue("OUTCOST", line.OUTCOST);
									command.Parameters.AddWithValue("OUTCOSTCURR", line.OUTCOSTCURR);
									command.Parameters.AddWithValue("RETAMOUNT", line.RETAMOUNT);
									command.Parameters.AddWithValue("FAREGREF", line.FAREGREF);
									command.Parameters.AddWithValue("FAATTRIB", line.FAATTRIB);
									command.Parameters.AddWithValue("CANCELLED", line.CANCELLED);
									command.Parameters.AddWithValue("LINENET", line.LINENET);
									command.Parameters.AddWithValue("DISTADDEXP", line.DISTADDEXP);
									command.Parameters.AddWithValue("FADACCREF", line.FADACCREF);
									command.Parameters.AddWithValue("FADCENTERREF", line.FADCENTERREF);
									command.Parameters.AddWithValue("FARACCREF", line.FARACCREF);
									command.Parameters.AddWithValue("FARCENTERREF", line.FARCENTERREF);
									command.Parameters.AddWithValue("DIFFPRICE", line.DIFFPRICE);
									command.Parameters.AddWithValue("DIFFPRCOST", line.DIFFPRCOST);
									command.Parameters.AddWithValue("DECPRDIFF", line.DECPRDIFF);
									command.Parameters.AddWithValue("LPRODSTAT", line.LPRODSTAT);
									command.Parameters.AddWithValue("PRDEXPTOTAL", line.PRDEXPTOTAL);
									command.Parameters.AddWithValue("DIFFREPPRICE", line.DIFFREPPRICE);
									command.Parameters.AddWithValue("DIFFPRCRCOST", line.DIFFPRCRCOST);
									command.Parameters.AddWithValue("SALESMANREF", line.SALESMANREF);
									command.Parameters.AddWithValue("FAPLACCREF", line.FAPLACCREF);
									command.Parameters.AddWithValue("FAPLCENTERREF", line.FAPLCENTERREF);
									command.Parameters.AddWithValue("OUTPUTIDCODE", line.OUTPUTIDCODE);
									command.Parameters.AddWithValue("DREF", line.DREF);
									command.Parameters.AddWithValue("COSTRATE", line.COSTRATE);
									command.Parameters.AddWithValue("XPRICEUPD", line.XPRICEUPD);
									command.Parameters.AddWithValue("XPRICE", line.XPRICE);
									command.Parameters.AddWithValue("XREPRATE", line.XREPRATE);
									command.Parameters.AddWithValue("DISTCOEF", line.DISTCOEF);
									command.Parameters.AddWithValue("TRANSQCOK", line.TRANSQCOK);
									command.Parameters.AddWithValue("SITEID", line.SITEID);
									command.Parameters.AddWithValue("RECSTATUS", line.RECSTATUS);
									command.Parameters.AddWithValue("ORGLOGICREF", line.ORGLOGICREF);
									command.Parameters.AddWithValue("WFSTATUS", line.WFSTATUS);
									command.Parameters.AddWithValue("POLINEREF", line.POLINEREF);
									command.Parameters.AddWithValue("PLNSTTRANSREF", line.PLNSTTRANSREF);
									command.Parameters.AddWithValue("NETDISCFLAG", line.NETDISCFLAG);
									command.Parameters.AddWithValue("NETDISCPERC", line.NETDISCPERC);
									command.Parameters.AddWithValue("NETDISCAMNT", line.NETDISCAMNT);
									command.Parameters.AddWithValue("VATCALCDIFF", line.VATCALCDIFF);
									command.Parameters.AddWithValue("CONDITIONREF", line.CONDITIONREF);
									command.Parameters.AddWithValue("DISTORDERREF", line.DISTORDERREF);
									command.Parameters.AddWithValue("DISTORDLINEREF", line.DISTORDLINEREF);
									command.Parameters.AddWithValue("CAMPAIGNREFS1", line.CAMPAIGNREFS1);
									command.Parameters.AddWithValue("CAMPAIGNREFS2", line.CAMPAIGNREFS2);
									command.Parameters.AddWithValue("CAMPAIGNREFS3", line.CAMPAIGNREFS3);
									command.Parameters.AddWithValue("CAMPAIGNREFS4", line.CAMPAIGNREFS4);
									command.Parameters.AddWithValue("CAMPAIGNREFS5", line.CAMPAIGNREFS5);
									command.Parameters.AddWithValue("POINTCAMPREF", line.POINTCAMPREF);
									command.Parameters.AddWithValue("CAMPPOINT", line.CAMPPOINT);
									command.Parameters.AddWithValue("PROMCLASITEMREF", line.PROMCLASITEMREF);
									command.Parameters.AddWithValue("CMPGLINEREF", line.CMPGLINEREF);
									command.Parameters.AddWithValue("PLNSTTRANSPERNR", line.PLNSTTRANSPERNR);
									command.Parameters.AddWithValue("PORDCLSPLNAMNT", line.PORDCLSPLNAMNT);
									command.Parameters.AddWithValue("VENDCOMM", line.VENDCOMM);
									command.Parameters.AddWithValue("PREVIOUSOUTCOST", line.PREVIOUSOUTCOST);
									command.Parameters.AddWithValue("COSTOFSALEACCREF", line.COSTOFSALEACCREF);
									command.Parameters.AddWithValue("PURCHACCREF", line.PURCHACCREF);
									command.Parameters.AddWithValue("COSTOFSALECNTREF", line.COSTOFSALECNTREF);
									command.Parameters.AddWithValue("PURCHCENTREF", line.PURCHCENTREF);
									command.Parameters.AddWithValue("PREVOUTCOSTCURR", line.PREVOUTCOSTCURR);
									command.Parameters.AddWithValue("ABVATAMOUNT", line.ABVATAMOUNT);
									command.Parameters.AddWithValue("ABVATSTATUS", line.ABVATSTATUS);
									command.Parameters.AddWithValue("PRRATE", line.PRRATE);
									command.Parameters.AddWithValue("ADDTAXRATE", line.ADDTAXRATE);
									command.Parameters.AddWithValue("ADDTAXCONVFACT", line.ADDTAXCONVFACT);
									command.Parameters.AddWithValue("ADDTAXAMOUNT", line.ADDTAXAMOUNT);
									command.Parameters.AddWithValue("ADDTAXPRCOST", line.ADDTAXPRCOST);
									command.Parameters.AddWithValue("ADDTAXRETCOST", line.ADDTAXRETCOST);
									command.Parameters.AddWithValue("ADDTAXRETCOSTCURR", line.ADDTAXRETCOSTCURR);
									command.Parameters.AddWithValue("GROSSUINFO1", line.GROSSUINFO1);
									command.Parameters.AddWithValue("GROSSUINFO2", line.GROSSUINFO2);
									command.Parameters.AddWithValue("ADDTAXPRCOSTCURR", line.ADDTAXPRCOSTCURR);
									command.Parameters.AddWithValue("ADDTAXACCREF", line.ADDTAXACCREF);
									command.Parameters.AddWithValue("ADDTAXCENTERREF", line.ADDTAXCENTERREF);
									command.Parameters.AddWithValue("ADDTAXAMNTISUPD", line.ADDTAXAMNTISUPD);
									command.Parameters.AddWithValue("INFIDX", line.INFIDX);
									command.Parameters.AddWithValue("ADDTAXCOSACCREF", line.ADDTAXCOSACCREF);
									command.Parameters.AddWithValue("ADDTAXCOSCNTREF", line.ADDTAXCOSCNTREF);
									command.Parameters.AddWithValue("PREVIOUSATAXPRCOST", line.PREVIOUSATAXPRCOST);
									command.Parameters.AddWithValue("PREVATAXPRCOSTCURR", line.PREVATAXPRCOSTCURR);
									command.Parameters.AddWithValue("PRDORDTOTCOEF", line.PRDORDTOTCOEF);
									command.Parameters.AddWithValue("DEMPEGGEDAMNT", line.DEMPEGGEDAMNT);
									command.Parameters.AddWithValue("STDUNITCOST", line.STDUNITCOST);
									command.Parameters.AddWithValue("STDRPUNITCOST", line.STDRPUNITCOST);
									command.Parameters.AddWithValue("COSTDIFFACCREF", line.COSTDIFFACCREF);
									command.Parameters.AddWithValue("COSTDIFFCENREF", line.COSTDIFFCENREF);
									command.Parameters.AddWithValue("TEXTINC", line.TEXTINC);
									command.Parameters.AddWithValue("ADDTAXDISCAMOUNT", line.ADDTAXDISCAMOUNT);
									command.Parameters.AddWithValue("ORGLOGOID", line.ORGLOGOID);
									command.Parameters.AddWithValue("EXIMFICHENO", line.EXIMFICHENO);
									command.Parameters.AddWithValue("EXIMFCTYPE", line.EXIMFCTYPE);
									command.Parameters.AddWithValue("TRANSEXPLINE", line.TRANSEXPLINE);
									command.Parameters.AddWithValue("INSEXPLINE", line.INSEXPLINE);
									command.Parameters.AddWithValue("EXIMWHFCREF", line.EXIMWHFCREF);
									command.Parameters.AddWithValue("EXIMWHLNREF", line.EXIMWHLNREF);
									command.Parameters.AddWithValue("EXIMFILEREF", line.EXIMFILEREF);
									command.Parameters.AddWithValue("EXIMPROCNR", line.EXIMPROCNR);
									command.Parameters.AddWithValue("EISRVDSTTYP", line.EISRVDSTTYP);
									command.Parameters.AddWithValue("MAINSTLNREF", line.MAINSTLNREF);
									command.Parameters.AddWithValue("MADEOFSHRED", line.MADEOFSHRED);
									command.Parameters.AddWithValue("FROMORDWITHPAY", line.FROMORDWITHPAY);
									command.Parameters.AddWithValue("PROJECTREF", line.PROJECTREF);
									command.Parameters.AddWithValue("STATUS", line.STATUS);
									command.Parameters.AddWithValue("DORESERVE", line.DORESERVE);
									command.Parameters.AddWithValue("POINTCAMPREFS1", line.POINTCAMPREFS1);
									command.Parameters.AddWithValue("POINTCAMPREFS2", line.POINTCAMPREFS2);
									command.Parameters.AddWithValue("POINTCAMPREFS3", line.POINTCAMPREFS3);
									command.Parameters.AddWithValue("POINTCAMPREFS4", line.POINTCAMPREFS4);
									command.Parameters.AddWithValue("CAMPPOINTS1", line.CAMPPOINTS1);
									command.Parameters.AddWithValue("CAMPPOINTS2", line.CAMPPOINTS2);
									command.Parameters.AddWithValue("CAMPPOINTS3", line.CAMPPOINTS3);
									command.Parameters.AddWithValue("CAMPPOINTS4", line.CAMPPOINTS4);
									command.Parameters.AddWithValue("CMPGLINEREFS1", line.CMPGLINEREFS1);
									command.Parameters.AddWithValue("CMPGLINEREFS2", line.CMPGLINEREFS2);
									command.Parameters.AddWithValue("CMPGLINEREFS3", line.CMPGLINEREFS3);
									command.Parameters.AddWithValue("CMPGLINEREFS4", line.CMPGLINEREFS4);
									command.Parameters.AddWithValue("PRCLISTREF", line.PRCLISTREF);
									command.Parameters.AddWithValue("PORDSYMOUTLN", line.PORDSYMOUTLN);
									command.Parameters.AddWithValue("MONTH_", line.MONTH_);
									command.Parameters.AddWithValue("YEAR_", line.YEAR_);
									command.Parameters.AddWithValue("EXADDTAXRATE", line.EXADDTAXRATE);
									command.Parameters.AddWithValue("EXADDTAXCONVF", line.EXADDTAXCONVF);
									command.Parameters.AddWithValue("EXADDTAXAREF", line.EXADDTAXAREF);
									command.Parameters.AddWithValue("EXADDTAXCREF", line.EXADDTAXCREF);
									command.Parameters.AddWithValue("OTHRADDTAXAREF", line.OTHRADDTAXAREF);
									command.Parameters.AddWithValue("OTHRADDTAXCREF", line.OTHRADDTAXCREF);
									command.Parameters.AddWithValue("EXADDTAXAMNT", line.EXADDTAXAMNT);
									command.Parameters.AddWithValue("AFFECTCOLLATRL", line.AFFECTCOLLATRL);
									command.Parameters.AddWithValue("ALTPROMFLAG", line.ALTPROMFLAG);
									command.Parameters.AddWithValue("EIDISTFLNNR", line.EIDISTFLNNR);
									command.Parameters.AddWithValue("EXIMTYPE", line.EXIMTYPE);
									command.Parameters.AddWithValue("VARIANTREF", line.VARIANTREF);
									command.Parameters.AddWithValue("CANDEDUCT", line.CANDEDUCT);
									command.Parameters.AddWithValue("OUTREMAMNT", line.OUTREMAMNT);
									command.Parameters.AddWithValue("OUTREMCOST", line.OUTREMCOST);
									command.Parameters.AddWithValue("OUTREMCOSTCURR", line.OUTREMCOSTCURR);
									command.Parameters.AddWithValue("REFLVATACCREF", line.REFLVATACCREF);
									command.Parameters.AddWithValue("REFLVATOTHACCREF", line.REFLVATOTHACCREF);
									command.Parameters.AddWithValue("PARENTLNREF", line.PARENTLNREF);
									command.Parameters.AddWithValue("AFFECTRISK", line.AFFECTRISK);
									command.Parameters.AddWithValue("INEFFECTIVECOST", line.INEFFECTIVECOST);
									command.Parameters.AddWithValue("ADDTAXVATMATRAH", line.ADDTAXVATMATRAH);
									command.Parameters.AddWithValue("REFLACCREF", line.REFLACCREF);
									command.Parameters.AddWithValue("REFLOTHACCREF", line.REFLOTHACCREF);
									command.Parameters.AddWithValue("CAMPPAYDEFREF", line.CAMPPAYDEFREF);


									if (line.FAREGBINDDATE == null)
										command.Parameters.AddWithValue("FAREGBINDDATE", DBNull.Value);
									else
										command.Parameters.AddWithValue("FAREGBINDDATE", line.FAREGBINDDATE);

									command.Parameters.AddWithValue("RELTRANSLNREF", line.RELTRANSLNREF);
									command.Parameters.AddWithValue("FROMTRANSFER", line.FROMTRANSFER);
									command.Parameters.AddWithValue("COSTDISTPRICE", line.COSTDISTPRICE);
									command.Parameters.AddWithValue("COSTDISTREPPRICE", line.COSTDISTREPPRICE);
									command.Parameters.AddWithValue("DIFFPRICEUFRS", line.DIFFPRICEUFRS);
									command.Parameters.AddWithValue("DIFFREPPRICEUFRS", line.DIFFREPPRICEUFRS);
									command.Parameters.AddWithValue("OUTCOSTUFRS", line.OUTCOSTUFRS);
									command.Parameters.AddWithValue("OUTCOSTCURRUFRS", line.OUTCOSTCURRUFRS);
									command.Parameters.AddWithValue("DIFFPRCOSTUFRS", line.DIFFPRCOSTUFRS);
									command.Parameters.AddWithValue("DIFFPRCRCOSTUFRS", line.DIFFPRCRCOSTUFRS);
									command.Parameters.AddWithValue("RETCOSTUFRS", line.RETCOSTUFRS);
									command.Parameters.AddWithValue("RETCOSTCURRUFRS", line.RETCOSTCURRUFRS);
									command.Parameters.AddWithValue("OUTREMCOSTUFRS", line.OUTREMCOSTUFRS);
									command.Parameters.AddWithValue("OUTREMCOSTCURRUFRS", line.OUTREMCOSTCURRUFRS);
									command.Parameters.AddWithValue("INFIDXUFRS", line.INFIDXUFRS);
									command.Parameters.AddWithValue("ADJPRICEUFRS", line.ADJPRICEUFRS);
									command.Parameters.AddWithValue("ADJREPPRICEUFRS", line.ADJREPPRICEUFRS);
									command.Parameters.AddWithValue("ADJPRCOSTUFRS", line.ADJPRCOSTUFRS);
									command.Parameters.AddWithValue("ADJPRCRCOSTUFRS", line.ADJPRCRCOSTUFRS);
									command.Parameters.AddWithValue("COSTDISTPRICEUFRS", line.COSTDISTPRICEUFRS);
									command.Parameters.AddWithValue("COSTDISTREPPRICEUFRS", line.COSTDISTREPPRICEUFRS);
									command.Parameters.AddWithValue("PURCHACCREFUFRS", line.PURCHACCREFUFRS);
									command.Parameters.AddWithValue("PURCHCENTREFUFRS", line.PURCHCENTREFUFRS);
									command.Parameters.AddWithValue("COSACCREFUFRS", line.COSACCREFUFRS);
									command.Parameters.AddWithValue("COSCNTREFUFRS", line.COSCNTREFUFRS);
									command.Parameters.AddWithValue("PROUTCOSTUFRSDIFF", line.PROUTCOSTUFRSDIFF);
									command.Parameters.AddWithValue("PROUTCOSTCRUFRSDIFF", line.PROUTCOSTCRUFRSDIFF);
									command.Parameters.AddWithValue("UNDERDEDUCTLIMIT", line.UNDERDEDUCTLIMIT);
									command.Parameters.AddWithValue("GLOBALID", line.GLOBALID);
									command.Parameters.AddWithValue("DEDUCTIONPART1", line.DEDUCTIONPART1);
									command.Parameters.AddWithValue("DEDUCTIONPART2", line.DEDUCTIONPART2);
									command.Parameters.AddWithValue("GUID", line.GUID);
									command.Parameters.AddWithValue("SPECODE2", line.SPECODE2);
									command.Parameters.AddWithValue("OFFERREF", line.OFFERREF);
									command.Parameters.AddWithValue("OFFTRANSREF", line.OFFTRANSREF);
									command.Parameters.AddWithValue("VATEXCEPTREASON", line.VATEXCEPTREASON);
									command.Parameters.AddWithValue("PLNDEFSERILOTNO", line.PLNDEFSERILOTNO);
									command.Parameters.AddWithValue("PLNUNRSRVAMOUNT", line.PLNUNRSRVAMOUNT);
									command.Parameters.AddWithValue("PORDCLSPLNUNRSRVAMNT", line.PORDCLSPLNUNRSRVAMNT);
									command.Parameters.AddWithValue("LPRODRSRVSTAT", line.LPRODRSRVSTAT);
									command.Parameters.AddWithValue("FALINKTYPE", line.FALINKTYPE);
									command.Parameters.AddWithValue("DEDUCTCODE", line.DEDUCTCODE);
									command.Parameters.AddWithValue("UPDTHISLINE", line.UPDTHISLINE);
									command.Parameters.AddWithValue("VATEXCEPTCODE", line.VATEXCEPTCODE);
									command.Parameters.AddWithValue("PORDERFICHENO", line.PORDERFICHENO);
									command.Parameters.AddWithValue("QPRODFCREF", line.QPRODFCREF);
									command.Parameters.AddWithValue("RELTRANSFCREF", line.RELTRANSFCREF);
									command.Parameters.AddWithValue("ATAXEXCEPTREASON", line.ATAXEXCEPTREASON);
									command.Parameters.AddWithValue("ATAXEXCEPTCODE", line.ATAXEXCEPTCODE);
									command.Parameters.AddWithValue("PRODORDERTYP", line.PRODORDERTYP);
									command.Parameters.AddWithValue("SUBCONTORDERREF", line.SUBCONTORDERREF);
									command.Parameters.AddWithValue("QPRODFCTYP", line.QPRODFCTYP);
									command.Parameters.AddWithValue("PRDORDSLPLNRESERVE", line.PRDORDSLPLNRESERVE);

									if (line.INFDATE == null)
										command.Parameters.AddWithValue("INFDATE", DBNull.Value);
									else
										command.Parameters.AddWithValue("INFDATE", line.INFDATE);

									command.Parameters.AddWithValue("DESTSTATUS", line.DESTSTATUS);
									command.Parameters.AddWithValue("REGTYPREF", line.REGTYPREF);
									command.Parameters.AddWithValue("FAPROFITACCREF", line.FAPROFITACCREF);
									command.Parameters.AddWithValue("FAPROFITCENTREF", line.FAPROFITCENTREF);
									command.Parameters.AddWithValue("FALOSSACCREF", line.FALOSSACCREF);
									command.Parameters.AddWithValue("FALOSSCENTREF", line.FALOSSCENTREF);
									command.Parameters.AddWithValue("FUTMONTHCNT", line.FUTMONTHCNT);
									command.Parameters.AddWithValue("FUTMONTHBEGDATE", line.FUTMONTHBEGDATE);
									command.Parameters.AddWithValue("GTIPCODE", line.GTIPCODE);
									command.Parameters.AddWithValue("CPACODE", line.CPACODE);
									command.Parameters.AddWithValue("QPRODITEMTYPE", line.QPRODITEMTYPE);
									command.Parameters.AddWithValue("PUBLICCOUNTRYREF", line.PUBLICCOUNTRYREF);
									var id = await command.ExecuteScalarAsync();
									await connection.CloseAsync();
								}
							}
							catch (Exception e)
							{
								Debug.WriteLine(e.Message);
								throw;
							}
						}


						if (line.SERILOTTRANSACTIONS != null)
						{
							foreach (var serilot in line.SERILOTTRANSACTIONS)
							{
								string seriLotQuery = $@"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_SLTRANS(
            STFICHEREF
           ,DATE_
           ,STTRANSREF
           ,INTRANSREF
           ,INSLTRANSREF
           ,INSLAMOUNT
           ,LINENR
           ,ITEMREF
           ,IOCODE
           ,INVENNO
           ,FICHETYPE
           ,SLTYPE
           ,SLREF
           ,LOCREF
           ,MAINAMOUNT
           ,UOMREF
           ,AMOUNT
           ,REMAMOUNT
           ,REMLNUNITAMNT
           ,UINFO1
           ,UINFO2
           ,UINFO3
           ,UINFO4
           ,UINFO5
           ,UINFO6
           ,UINFO7
           ,UINFO8
           ,RATESCORE
           ,CANCELLED
           ,OUTCOST
           ,OUTCOSTCURR
           ,DIFFPRCOST
           ,DIFFPRCOSTCURR
           ,SERIQCOK
           ,LPRODSTAT
           ,SOURCETYPE
           ,SOURCEWSREF
           ,SITEID
           ,RECSTATUS
           ,ORGLOGICREF
           ,WFSTATUS
           ,DISTORDREF
           ,DISTORDLNREF
           ,INDORDSLTRNREF
           ,GROSSUINFO1
           ,GROSSUINFO2
           ,ATAXPRCOST
           ,ATAXPRCOSTCURR
           ,INFIDX
           ,ORGLOGOID
           ,LINEEXP
           ,EXIMFCTYPE
           ,EXIMFILEREF
           ,EXIMPROCNR
           ,MAINSLLNREF
           ,MADEOFSHRED
           ,STATUS
           ,VARIANTREF
           ,GRPBEGCODE
           ,GRPENDCODE
           ,OUTCOSTUFRS
           ,OUTCOSTCURRUFRS
           ,DIFFPRCOSTUFRS
           ,DIFFPRCOSTCURRUFRS
           ,INFIDXUFRS
           ,ADJPRCOSTUFRS
           ,ADJPRCOSTCURRUFRS
           ,GUID
           ,PRDORDREF
           ,PRDORDSLPLNRESERVE
           ,INPLNSLTRANSREF
           ,NOTSHIPPED
            ,EXPDATE)  
         VALUES(
            @STFICHEREF
           ,@DATE_
           ,@STTRANSREF
           ,@INTRANSREF
           ,@INSLTRANSREF
           ,@INSLAMOUNT
           ,@LINENR
           ,@ITEMREF
           ,@IOCODE
           ,@INVENNO
           ,@FICHETYPE
           ,@SLTYPE
           ,@SLREF
           ,@LOCREF
           ,@MAINAMOUNT
           ,@UOMREF
           ,@AMOUNT
           ,@REMAMOUNT
           ,@REMLNUNITAMNT
           ,@UINFO1
           ,@UINFO2
           ,@UINFO3
           ,@UINFO4
           ,@UINFO5
           ,@UINFO6
           ,@UINFO7
           ,@UINFO8
           ,@RATESCORE
           ,@CANCELLED
           ,@OUTCOST
           ,@OUTCOSTCURR
           ,@DIFFPRCOST
           ,@DIFFPRCOSTCURR
           ,@SERIQCOK
           ,@LPRODSTAT
           ,@SOURCETYPE
           ,@SOURCEWSREF
           ,@SITEID
           ,@RECSTATUS
           ,@ORGLOGICREF
           ,@WFSTATUS
           ,@DISTORDREF
           ,@DISTORDLNREF
           ,@INDORDSLTRNREF
           ,@GROSSUINFO1
           ,@GROSSUINFO2
           ,@ATAXPRCOST
           ,@ATAXPRCOSTCURR
           ,@INFIDX
           ,@ORGLOGOID
           ,@LINEEXP
           ,@EXIMFCTYPE
           ,@EXIMFILEREF
           ,@EXIMPROCNR
           ,@MAINSLLNREF
           ,@MADEOFSHRED
           ,@STATUS
           ,@VARIANTREF
           ,@GRPBEGCODE
           ,@GRPENDCODE
           ,@OUTCOSTUFRS
           ,@OUTCOSTCURRUFRS
           ,@DIFFPRCOSTUFRS
           ,@DIFFPRCOSTCURRUFRS
           ,@INFIDXUFRS
           ,@ADJPRCOSTUFRS
           ,@ADJPRCOSTCURRUFRS
           ,@GUID
           ,@PRDORDREF
           ,@PRDORDSLPLNRESERVE
           ,@INPLNSLTRANSREF
           ,@NOTSHIPPED
           ,@EXPDATE
         	); SELECT SCOPE_IDENTITY();";

								await using (SqlConnection connection = new SqlConnection(_connectionString))
								{
									await connection.OpenAsync();
									await using (SqlCommand command = new SqlCommand(seriLotQuery, connection))
									{
										command.Parameters.AddWithValue("STFICHEREF", ReferenceId);
										command.Parameters.AddWithValue("STTRANSREF", serilot.STTRANSREF);
										command.Parameters.AddWithValue("INTRANSREF", serilot.INTRANSREF);
										command.Parameters.AddWithValue("INSLTRANSREF", serilot.INSLTRANSREF);
										command.Parameters.AddWithValue("INSLAMOUNT", serilot.INSLAMOUNT);
										command.Parameters.AddWithValue("LINENR", serilot.LINENR);
										//command.Parameters.AddWithValue("serilotREF", serilot.serilotREF);
										command.Parameters.AddWithValue("DATE_", serilot.DATE_);
										command.Parameters.AddWithValue("IOCODE", serilot.IOCODE);
										command.Parameters.AddWithValue("INVENNO", serilot.INVENNO);
										command.Parameters.AddWithValue("FICHETYPE", serilot.FICHETYPE);
										command.Parameters.AddWithValue("SLTYPE", serilot.SLTYPE);
										command.Parameters.AddWithValue("SLREF", serilot.SLREF);
										command.Parameters.AddWithValue("LOCREF", serilot.LOCREF);
										command.Parameters.AddWithValue("MAINAMOUNT", serilot.MAINAMOUNT);
										command.Parameters.AddWithValue("UOMREF", serilot.UOMREF);
										command.Parameters.AddWithValue("AMOUNT", serilot.AMOUNT);
										command.Parameters.AddWithValue("REMAMOUNT", serilot.REMAMOUNT);
										command.Parameters.AddWithValue("REMLNUNITAMNT", serilot.REMLNUNITAMNT);
										command.Parameters.AddWithValue("UINFO1", serilot.UINFO1);
										command.Parameters.AddWithValue("UINFO2", serilot.UINFO2);
										command.Parameters.AddWithValue("UINFO3", serilot.UINFO3);
										command.Parameters.AddWithValue("UINFO4", serilot.UINFO4);
										command.Parameters.AddWithValue("UINFO5", serilot.UINFO5);
										command.Parameters.AddWithValue("UINFO6", serilot.UINFO6);
										command.Parameters.AddWithValue("UINFO7", serilot.UINFO7);
										command.Parameters.AddWithValue("UINFO8", serilot.UINFO8);
										command.Parameters.AddWithValue("EXPDATE", serilot.EXPDATE);
										command.Parameters.AddWithValue("RATESCORE", serilot.RATESCORE);
										command.Parameters.AddWithValue("CANCELLED", serilot.CANCELLED);
										command.Parameters.AddWithValue("OUTCOST", serilot.OUTCOST);
										command.Parameters.AddWithValue("OUTCOSTCURR", serilot.OUTCOSTCURR);
										command.Parameters.AddWithValue("DIFFPRCOST", serilot.DIFFPRCOST);
										command.Parameters.AddWithValue("DIFFPRCOSTCURR", serilot.DIFFPRCOSTCURR);
										command.Parameters.AddWithValue("SERIQCOK", serilot.SERIQCOK);
										command.Parameters.AddWithValue("LPRODSTAT", serilot.LPRODSTAT);
										command.Parameters.AddWithValue("SOURCETYPE", serilot.SOURCETYPE);
										command.Parameters.AddWithValue("SOURCEWSREF", serilot.SOURCEWSREF);
										command.Parameters.AddWithValue("SITEID", serilot.SITEID);
										command.Parameters.AddWithValue("RECSTATUS", serilot.RECSTATUS);
										command.Parameters.AddWithValue("ORGLOGICREF", serilot.ORGLOGICREF);
										command.Parameters.AddWithValue("WFSTATUS", serilot.WFSTATUS);
										command.Parameters.AddWithValue("DISTORDREF", serilot.DISTORDREF);
										command.Parameters.AddWithValue("DISTORDLNREF", serilot.DISTORDLNREF);
										command.Parameters.AddWithValue("INDORDSLTRNREF", serilot.INDORDSLTRNREF);
										command.Parameters.AddWithValue("GROSSUINFO1", serilot.GROSSUINFO1);
										command.Parameters.AddWithValue("GROSSUINFO2", serilot.GROSSUINFO2);
										command.Parameters.AddWithValue("ATAXPRCOST", serilot.ATAXPRCOST);
										command.Parameters.AddWithValue("ATAXPRCOSTCURR", serilot.ATAXPRCOSTCURR);
										command.Parameters.AddWithValue("INFIDX", serilot.INFIDX);
										command.Parameters.AddWithValue("ORGLOGOID", serilot.ORGLOGOID);
										command.Parameters.AddWithValue("LINEEXP", serilot.LINEEXP);
										command.Parameters.AddWithValue("EXIMFCTYPE", serilot.EXIMFCTYPE);
										command.Parameters.AddWithValue("EXIMFILEREF", serilot.EXIMFILEREF);
										command.Parameters.AddWithValue("EXIMPROCNR", serilot.EXIMPROCNR);
										command.Parameters.AddWithValue("MAINSLLNREF", serilot.MAINSLLNREF);
										command.Parameters.AddWithValue("MADEOFSHRED", serilot.MADEOFSHRED);
										command.Parameters.AddWithValue("STATUS", serilot.STATUS);
										command.Parameters.AddWithValue("VARIANTREF", serilot.VARIANTREF);
										command.Parameters.AddWithValue("GRPBEGCODE", serilot.GRPBEGCODE);
										command.Parameters.AddWithValue("GRPENDCODE", serilot.GRPENDCODE);
										command.Parameters.AddWithValue("OUTCOSTUFRS", serilot.OUTCOSTUFRS);
										command.Parameters.AddWithValue("OUTCOSTCURRUFRS", serilot.OUTCOSTCURRUFRS);
										command.Parameters.AddWithValue("DIFFPRCOSTUFRS", serilot.DIFFPRCOSTUFRS);
										command.Parameters.AddWithValue("DIFFPRCOSTCURRUFRS", serilot.DIFFPRCOSTCURRUFRS);
										command.Parameters.AddWithValue("INFIDXUFRS", serilot.INFIDXUFRS);
										command.Parameters.AddWithValue("ADJPRCOSTUFRS", serilot.ADJPRCOSTUFRS);
										command.Parameters.AddWithValue("ADJPRCOSTCURRUFRS", serilot.ADJPRCOSTCURRUFRS);
										command.Parameters.AddWithValue("GUID", serilot.GUID);
										command.Parameters.AddWithValue("PRDORDREF", serilot.PRDORDREF);
										command.Parameters.AddWithValue("PRDORDSLPLNRESERVE", serilot.PRDORDSLPLNRESERVE);
										command.Parameters.AddWithValue("INPLNSLTRANSREF", serilot.INPLNSLTRANSREF);
										command.Parameters.AddWithValue("NOTSHIPPED", serilot.NOTSHIPPED);

										var id = await command.ExecuteScalarAsync();
										await connection.CloseAsync();
										ReferenceId = Convert.ToInt32(id);
									}
								}
							}


						}
					}
					#endregion
					await UpdateObject(last, item.DATE_.ToString("s"), item.DATE_.ToString("s"), item.TRCODE);
					transaction.Complete();

					return new DataResult<LG_STFICHE>()
					{
						Data = null,
						IsSuccess = true,
						Message = "Succes"
					};
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);

					return new DataResult<LG_STFICHE>()
					{
						Data = null,
						IsSuccess = false,
						Message = e.Message
					};

				}
			}
		}


		public async Task<DataResult<LG_STFICHE>> InsertTransferTransaction(LG_STFICHE item)
		{
			int ReferenceId;
			string query = $"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_STFICHE( GRPCODE ,DOCDATE ,TRCODE ,IOCODE ,FICHENO ,DATE_ ,FTIME ,DOCODE ,INVNO ,SPECODE ,CYPHCODE ,INVOICEREF ,CLIENTREF ,RECVREF ,ACCOUNTREF ,CENTERREF ,PRODORDERREF ,PORDERFICHENO ,SOURCETYPE ,SOURCEINDEX ,SOURCEWSREF ,SOURCEPOLNREF ,SOURCECOSTGRP ,DESTTYPE ,DESTINDEX ,DESTWSREF ,DESTPOLNREF ,DESTCOSTGRP ,FACTORYNR ,BRANCH ,DEPARTMENT ,COMPBRANCH ,COMPDEPARTMENT ,COMPFACTORY ,PRODSTAT ,DEVIR ,CANCELLED ,BILLED ,ACCOUNTED ,UPDCURR ,INUSE ,INVKIND ,ADDDISCOUNTS ,TOTALDISCOUNTS ,TOTALDISCOUNTED ,ADDEXPENSES ,TOTALEXPENSES ,TOTALDEPOZITO ,TOTALPROMOTIONS ,TOTALVAT ,GROSSTOTAL ,NETTOTAL ,GENEXP1 ,GENEXP2 ,GENEXP3 ,GENEXP4 ,GENEXP5 ,GENEXP6 ,REPORTRATE ,REPORTNET ,EXTENREF ,PAYDEFREF ,PRINTCNT ,FICHECNT ,ACCFICHEREF ,CAPIBLOCK_CREATEDBY ,CAPIBLOCK_CREADEDDATE ,CAPIBLOCK_CREATEDHOUR ,CAPIBLOCK_CREATEDMIN ,CAPIBLOCK_CREATEDSEC ,SALESMANREF ,CANCELLEDACC ,SHPTYPCOD ,SHPAGNCOD ,TRACKNR ,GENEXCTYP ,LINEEXCTYP ,TRADINGGRP ,TEXTINC ,SITEID ,RECSTATUS ,ORGLOGICREF ,WFSTATUS ,SHIPINFOREF ,DISTORDERREF ,SENDCNT ,DLVCLIENT ,DOCTRACKINGNR ,ADDTAXCALC ,TOTALADDTAX ,UGIRTRACKINGNO ,QPRODFCREF ,VAACCREF ,VACENTERREF ,ORGLOGOID ,FROMEXIM ,FRGTYPCOD ,TRCURR ,TRRATE ,TRNET ,EXIMWHFCREF ,EXIMFCTYPE ,MAINSTFCREF ,FROMORDWITHPAY ,PROJECTREF ,WFLOWCRDREF ,STATUS ,UPDTRCURR ,TOTALEXADDTAX ,AFFECTCOLLATRL ,DEDUCTIONPART1 ,DEDUCTIONPART2 ,GRPFIRMTRANS ,AFFECTRISK ,DISPSTATUS ,APPROVE ,CANTCREDEDUCT ,SHIPTIME ,ENTRUSTDEVIR ,RELTRANSFCREF ,FROMTRANSFER ,GUID ,GLOBALID ,COMPSTFCREF ,COMPINVREF ,TOTALSERVICES ,CAMPAIGNCODE ,OFFERREF ,EINVOICETYP ,EINVOICE ,NOCALCULATE ,PRODORDERTYP ,QPRODFCTYP ,PRDORDSLPLNRESERVE ,CONTROLINFO ,EDESPATCH ,DOCTIME ,EDESPSTATUS ,PROFILEID ,DELIVERYCODE ,DESTSTATUS ,CANCELEXP ,UNDOEXP) VALUES ( @GRPCODE ,@DOCDATE ,@TRCODE ,@IOCODE ,@FICHENO ,@DATE_ ,(SELECT [dbo].[LG_TIMETOINT](@FHOUR,@FMINUTE,@FSECOND)),@DOCODE ,@INVNO ,@SPECODE ,@CYPHCODE ,@INVOICEREF ,@CLIENTREF ,@RECVREF ,@ACCOUNTREF ,@CENTERREF ,@PRODORDERREF ,@PORDERFICHENO ,@SOURCETYPE ,@SOURCEINDEX ,@SOURCEWSREF ,@SOURCEPOLNREF ,@SOURCECOSTGRP ,@DESTTYPE ,@DESTINDEX ,@DESTWSREF ,@DESTPOLNREF ,@DESTCOSTGRP ,@FACTORYNR ,@BRANCH ,@DEPARTMENT ,@COMPBRANCH ,@COMPDEPARTMENT ,@COMPFACTORY ,@PRODSTAT ,@DEVIR ,@CANCELLED ,@BILLED ,@ACCOUNTED ,@UPDCURR ,@INUSE ,@INVKIND ,@ADDDISCOUNTS ,@TOTALDISCOUNTS ,@TOTALDISCOUNTED ,@ADDEXPENSES ,@TOTALEXPENSES ,@TOTALDEPOZITO ,@TOTALPROMOTIONS ,@TOTALVAT ,@GROSSTOTAL ,@NETTOTAL ,@GENEXP1 ,@GENEXP2 ,@GENEXP3 ,@GENEXP4 ,@GENEXP5 ,@GENEXP6 ,@REPORTRATE ,@REPORTNET ,@EXTENREF ,@PAYDEFREF ,@PRINTCNT ,@FICHECNT ,@ACCFICHEREF ,@CAPIBLOCK_CREATEDBY ,@CAPIBLOCK_CREADEDDATE ,@CAPIBLOCK_CREATEDHOUR ,@CAPIBLOCK_CREATEDMIN ,@CAPIBLOCK_CREATEDSEC ,@SALESMANREF ,@CANCELLEDACC ,@SHPTYPCOD ,@SHPAGNCOD ,@TRACKNR ,@GENEXCTYP ,@LINEEXCTYP ,@TRADINGGRP ,@TEXTINC ,@SITEID ,@RECSTATUS ,@ORGLOGICREF ,@WFSTATUS ,@SHIPINFOREF ,@DISTORDERREF ,@SENDCNT ,@DLVCLIENT ,@DOCTRACKINGNR ,@ADDTAXCALC ,@TOTALADDTAX ,@UGIRTRACKINGNO ,@QPRODFCREF ,@VAACCREF ,@VACENTERREF ,@ORGLOGOID ,@FROMEXIM ,@FRGTYPCOD ,@TRCURR ,@TRRATE ,@TRNET ,@EXIMWHFCREF ,@EXIMFCTYPE ,@MAINSTFCREF ,@FROMORDWITHPAY ,@PROJECTREF ,@WFLOWCRDREF ,@STATUS ,@UPDTRCURR ,@TOTALEXADDTAX ,@AFFECTCOLLATRL ,@DEDUCTIONPART1 ,@DEDUCTIONPART2 ,@GRPFIRMTRANS ,@AFFECTRISK ,@DISPSTATUS ,@APPROVE ,@CANTCREDEDUCT ,@SHIPTIME ,@ENTRUSTDEVIR ,@RELTRANSFCREF ,@FROMTRANSFER ,@GUID ,@GLOBALID ,@COMPSTFCREF ,@COMPINVREF ,@TOTALSERVICES ,@CAMPAIGNCODE ,@OFFERREF ,@EINVOICETYP ,@EINVOICE ,@NOCALCULATE ,@PRODORDERTYP ,@QPRODFCTYP ,@PRDORDSLPLNRESERVE ,@CONTROLINFO ,@EDESPATCH ,@DOCTIME ,@EDESPSTATUS ,@PROFILEID ,@DELIVERYCODE ,@DESTSTATUS ,@CANCELEXP ,@UNDOEXP); SELECT SCOPE_IDENTITY();";
			using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				try
				{
					var lastNumber = await GetLastAsgn(item.DATE_.ToString("s"), item.DATE_.ToString("s"), item.TRCODE);
					BigInteger number = BigInteger.Parse(lastNumber);
					number++; // 1 ekleyin
					var last = number.ToString("D16");
					int hour = item.DATE_.Hour;
					int minute = item.DATE_.Minute;
					int second = item.DATE_.Second;

					// Construct the time string in the format expected by the LG_TIMETOINT function
					string timeString = $"{hour},{minute},{second}";
					#region Fiche Insert
					await using (SqlConnection connection = new SqlConnection(_connectionString))
					{
						await connection.OpenAsync();
						await using (SqlCommand command = new SqlCommand(query, connection))
						{
							command.Parameters.AddWithValue("GRPCODE", item.GRPCODE);
							command.Parameters.AddWithValue("DOCDATE", item.DOCDATE);
							command.Parameters.AddWithValue("TRCODE", item.TRCODE);
							command.Parameters.AddWithValue("IOCODE", item.IOCODE);
							command.Parameters.AddWithValue("FICHENO", last);
							command.Parameters.AddWithValue("DATE_", item.DATE_);
							command.Parameters.AddWithValue("FHOUR", item.DATE_.Hour);
							command.Parameters.AddWithValue("FMINUTE", item.DATE_.Minute);
							command.Parameters.AddWithValue("FSECOND", item.DATE_.Second);
							command.Parameters.AddWithValue("DOCODE", item.DOCODE);
							command.Parameters.AddWithValue("INVNO", item.INVNO);
							command.Parameters.AddWithValue("SPECODE", item.SPECODE);
							command.Parameters.AddWithValue("CYPHCODE", item.CYPHCODE);
							command.Parameters.AddWithValue("INVOICEREF", item.INVOICEREF);
							command.Parameters.AddWithValue("CLIENTREF", item.CLIENTREF);
							command.Parameters.AddWithValue("RECVREF", item.RECVREF);
							command.Parameters.AddWithValue("ACCOUNTREF", item.ACCOUNTREF);
							command.Parameters.AddWithValue("CENTERREF", item.CENTERREF);
							command.Parameters.AddWithValue("PRODORDERREF", item.PRODORDERREF);
							command.Parameters.AddWithValue("PORDERFICHENO", item.PORDERFICHENO);
							command.Parameters.AddWithValue("SOURCETYPE", item.SOURCETYPE);
							command.Parameters.AddWithValue("SOURCEINDEX", item.SOURCEINDEX);
							command.Parameters.AddWithValue("SOURCEWSREF", item.SOURCEWSREF);
							command.Parameters.AddWithValue("SOURCEPOLNREF", item.SOURCEPOLNREF);
							command.Parameters.AddWithValue("SOURCECOSTGRP", item.SOURCECOSTGRP);
							command.Parameters.AddWithValue("DESTTYPE", item.DESTTYPE);
							command.Parameters.AddWithValue("DESTINDEX", item.DESTINDEX);
							command.Parameters.AddWithValue("DESTWSREF", item.DESTWSREF);
							command.Parameters.AddWithValue("DESTPOLNREF", item.DESTPOLNREF);
							command.Parameters.AddWithValue("DESTCOSTGRP", item.DESTCOSTGRP);
							command.Parameters.AddWithValue("FACTORYNR", item.FACTORYNR);
							command.Parameters.AddWithValue("BRANCH", item.BRANCH);
							command.Parameters.AddWithValue("DEPARTMENT", item.DEPARTMENT);
							command.Parameters.AddWithValue("COMPBRANCH", item.COMPBRANCH);
							command.Parameters.AddWithValue("COMPDEPARTMENT", item.COMPDEPARTMENT);
							command.Parameters.AddWithValue("COMPFACTORY", item.COMPFACTORY);
							command.Parameters.AddWithValue("PRODSTAT", item.PRODSTAT);
							command.Parameters.AddWithValue("DEVIR", item.DEVIR);
							command.Parameters.AddWithValue("CANCELLED", item.CANCELLED);
							command.Parameters.AddWithValue("BILLED", item.BILLED);
							command.Parameters.AddWithValue("ACCOUNTED", item.ACCOUNTED);
							command.Parameters.AddWithValue("UPDCURR", item.UPDCURR);
							command.Parameters.AddWithValue("INUSE", item.INUSE);
							command.Parameters.AddWithValue("INVKIND", item.INVKIND);
							command.Parameters.AddWithValue("ADDDISCOUNTS", item.ADDDISCOUNTS);
							command.Parameters.AddWithValue("TOTALDISCOUNTS", item.TOTALDISCOUNTS);
							command.Parameters.AddWithValue("TOTALDISCOUNTED", item.TOTALDISCOUNTED);
							command.Parameters.AddWithValue("ADDEXPENSES", item.ADDEXPENSES);
							command.Parameters.AddWithValue("TOTALEXPENSES", item.TOTALEXPENSES);
							command.Parameters.AddWithValue("TOTALDEPOZITO", item.TOTALDEPOZITO);
							command.Parameters.AddWithValue("TOTALPROMOTIONS", item.TOTALPROMOTIONS);
							command.Parameters.AddWithValue("TOTALVAT", item.TOTALVAT);
							command.Parameters.AddWithValue("GROSSTOTAL", item.GROSSTOTAL);
							command.Parameters.AddWithValue("NETTOTAL", item.NETTOTAL);
							command.Parameters.AddWithValue("GENEXP1", item.GENEXP1);
							command.Parameters.AddWithValue("GENEXP2", item.GENEXP2);
							command.Parameters.AddWithValue("GENEXP3", item.GENEXP3);
							command.Parameters.AddWithValue("GENEXP4", item.GENEXP4);
							command.Parameters.AddWithValue("GENEXP5", item.GENEXP5);
							command.Parameters.AddWithValue("GENEXP6", item.GENEXP6);
							command.Parameters.AddWithValue("REPORTRATE", item.REPORTRATE);
							command.Parameters.AddWithValue("REPORTNET", item.REPORTNET);
							command.Parameters.AddWithValue("EXTENREF", item.EXTENREF);
							command.Parameters.AddWithValue("PAYDEFREF", item.PAYDEFREF);
							command.Parameters.AddWithValue("PRINTCNT", item.PRINTCNT);
							command.Parameters.AddWithValue("FICHECNT", item.FICHECNT);
							command.Parameters.AddWithValue("ACCFICHEREF", item.ACCFICHEREF);
							command.Parameters.AddWithValue("CAPIBLOCK_CREATEDBY", item.CAPIBLOCK_CREATEDBY);
							command.Parameters.AddWithValue("CAPIBLOCK_CREADEDDATE", item.CAPIBLOCK_CREADEDDATE);
							command.Parameters.AddWithValue("CAPIBLOCK_CREATEDHOUR", item.CAPIBLOCK_CREATEDHOUR);
							command.Parameters.AddWithValue("CAPIBLOCK_CREATEDMIN", item.CAPIBLOCK_CREATEDMIN);
							command.Parameters.AddWithValue("CAPIBLOCK_CREATEDSEC", item.CAPIBLOCK_CREATEDSEC);
							command.Parameters.AddWithValue("SALESMANREF", item.SALESMANREF);
							command.Parameters.AddWithValue("CANCELLEDACC", item.CANCELLEDACC);
							command.Parameters.AddWithValue("SHPTYPCOD", item.SHPTYPCOD);
							command.Parameters.AddWithValue("SHPAGNCOD", item.SHPAGNCOD);
							command.Parameters.AddWithValue("TRACKNR", item.TRACKNR);
							command.Parameters.AddWithValue("GENEXCTYP", item.GENEXCTYP);
							command.Parameters.AddWithValue("LINEEXCTYP", item.LINEEXCTYP);
							command.Parameters.AddWithValue("TRADINGGRP", item.TRADINGGRP);
							command.Parameters.AddWithValue("TEXTINC", item.TEXTINC);
							command.Parameters.AddWithValue("SITEID", item.SITEID);
							command.Parameters.AddWithValue("RECSTATUS", item.RECSTATUS);
							command.Parameters.AddWithValue("ORGLOGICREF", item.ORGLOGICREF);
							command.Parameters.AddWithValue("WFSTATUS", item.WFSTATUS);
							command.Parameters.AddWithValue("SHIPINFOREF", item.SHIPINFOREF);
							command.Parameters.AddWithValue("DISTORDERREF", item.DISTORDERREF);
							command.Parameters.AddWithValue("SENDCNT", item.SENDCNT);
							command.Parameters.AddWithValue("DLVCLIENT", item.DLVCLIENT);
							command.Parameters.AddWithValue("DOCTRACKINGNR", item.DOCTRACKINGNR);
							command.Parameters.AddWithValue("ADDTAXCALC", item.ADDTAXCALC);
							command.Parameters.AddWithValue("TOTALADDTAX", item.TOTALADDTAX);
							command.Parameters.AddWithValue("UGIRTRACKINGNO", item.UGIRTRACKINGNO);
							command.Parameters.AddWithValue("QPRODFCREF", item.QPRODFCREF);
							command.Parameters.AddWithValue("VAACCREF", item.VAACCREF);
							command.Parameters.AddWithValue("VACENTERREF", item.VACENTERREF);
							command.Parameters.AddWithValue("ORGLOGOID", item.ORGLOGOID);
							command.Parameters.AddWithValue("FROMEXIM", item.FROMEXIM);
							command.Parameters.AddWithValue("FRGTYPCOD", item.FRGTYPCOD);
							command.Parameters.AddWithValue("TRCURR", item.TRCURR);
							command.Parameters.AddWithValue("TRRATE", item.TRRATE);
							command.Parameters.AddWithValue("TRNET", item.TRNET);
							command.Parameters.AddWithValue("EXIMWHFCREF", item.EXIMWHFCREF);
							command.Parameters.AddWithValue("EXIMFCTYPE", item.EXIMFCTYPE);
							command.Parameters.AddWithValue("MAINSTFCREF", item.MAINSTFCREF);
							command.Parameters.AddWithValue("FROMORDWITHPAY", item.FROMORDWITHPAY);
							command.Parameters.AddWithValue("PROJECTREF", item.PROJECTREF);
							command.Parameters.AddWithValue("WFLOWCRDREF", item.WFLOWCRDREF);
							command.Parameters.AddWithValue("STATUS", item.STATUS);
							command.Parameters.AddWithValue("UPDTRCURR", item.UPDTRCURR);
							command.Parameters.AddWithValue("TOTALEXADDTAX", item.TOTALEXADDTAX);
							command.Parameters.AddWithValue("AFFECTCOLLATRL", item.AFFECTCOLLATRL);
							command.Parameters.AddWithValue("DEDUCTIONPART1", item.DEDUCTIONPART1);
							command.Parameters.AddWithValue("DEDUCTIONPART2", item.DEDUCTIONPART2);
							command.Parameters.AddWithValue("GRPFIRMTRANS", item.GRPFIRMTRANS);
							command.Parameters.AddWithValue("AFFECTRISK", item.AFFECTRISK);
							command.Parameters.AddWithValue("DISPSTATUS", item.DISPSTATUS);
							command.Parameters.AddWithValue("APPROVE", item.APPROVE);
							command.Parameters.AddWithValue("CANTCREDEDUCT", item.CANTCREDEDUCT);
							command.Parameters.AddWithValue("SHIPTIME", item.SHIPTIME);
							command.Parameters.AddWithValue("ENTRUSTDEVIR", item.ENTRUSTDEVIR);
							command.Parameters.AddWithValue("RELTRANSFCREF", item.RELTRANSFCREF);
							command.Parameters.AddWithValue("FROMTRANSFER", item.FROMTRANSFER);
							command.Parameters.AddWithValue("GUID", item.GUID);
							command.Parameters.AddWithValue("GLOBALID", item.GLOBALID);
							command.Parameters.AddWithValue("COMPSTFCREF", item.COMPSTFCREF);
							command.Parameters.AddWithValue("COMPINVREF", item.COMPINVREF);
							command.Parameters.AddWithValue("TOTALSERVICES", item.TOTALSERVICES);
							command.Parameters.AddWithValue("CAMPAIGNCODE", item.CAMPAIGNCODE);
							command.Parameters.AddWithValue("OFFERREF", item.OFFERREF);
							command.Parameters.AddWithValue("EINVOICETYP", item.EINVOICETYP);
							command.Parameters.AddWithValue("EINVOICE", item.EINVOICE);
							command.Parameters.AddWithValue("NOCALCULATE", item.NOCALCULATE);
							command.Parameters.AddWithValue("PRODORDERTYP", item.PRODORDERTYP);
							command.Parameters.AddWithValue("QPRODFCTYP", item.QPRODFCTYP);
							command.Parameters.AddWithValue("PRDORDSLPLNRESERVE", item.PRDORDSLPLNRESERVE);
							command.Parameters.AddWithValue("CONTROLINFO", item.CONTROLINFO);
							command.Parameters.AddWithValue("EDESPATCH", item.EDESPATCH);
							command.Parameters.AddWithValue("DOCTIME", item.DOCTIME);
							command.Parameters.AddWithValue("EDESPSTATUS", item.EDESPSTATUS);
							command.Parameters.AddWithValue("PROFILEID", item.PROFILEID);
							command.Parameters.AddWithValue("DELIVERYCODE", item.DELIVERYCODE);
							command.Parameters.AddWithValue("DESTSTATUS", item.DESTSTATUS);
							command.Parameters.AddWithValue("CANCELEXP", item.CANCELEXP);
							command.Parameters.AddWithValue("UNDOEXP", item.UNDOEXP);

							var id = await command.ExecuteScalarAsync();
							await connection.CloseAsync();
							ReferenceId = Convert.ToInt32(id);
						}
					}
					#endregion


					if (item.TRCODE == 2 || item.TRCODE == 3 || item.TRCODE == 7 || item.TRCODE == 8)
					{
						#region Driver Insert

						string driverQuery = string.Format(@$"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_EINVOICEDET
            ([INVOICEREF]
           ,[STFREF]
           ,[EINVOICETYP]
           ,[PROFILEID]
           ,[ESTATUS]
           ,[EDESCRIPTION]
           ,[EDURATION]
           ,[EDURATIONTYPE]
           ,[TAXTYPE]
           ,[TUNAME]
           ,[TUSURNAME]
           ,[TUPASSPORTNO]
           ,[TUNATIONALITY]
           ,[TUNATIONALITYNAME]
           ,[TUBANKNAME]
           ,[TUBNACCOUNTNO]
           ,[TUBNBRANCH]
           ,[TUPAYMENTNOTE]
           ,[TUBNCURR]
           ,[ADDR1]
           ,[ADDR2]
           ,[CITYCODE]
           ,[CITY]
           ,[COUNTRYCODE]
           ,[COUNTRY]
           ,[DISTRICTCODE]
           ,[DISTRICT]
           ,[TOWNCODE]
           ,[TOWN]
           ,[EXITTOWN]
           ,[EXITGATECODE]
           ,[EXITGATE]
           ,[AGENCYCODE]
           ,[AGENCY]
           ,[EXITCOUNTRYCODE]
           ,[EXITCOUNTRY]
           ,[TRANSPORTTYP]
           ,[TRANSPORTTYPCODE]
           ,[TRANSPORTTYPNAME]
           ,[FLIGHTNUMBER]
           ,[GUIDE]
           ,[TURETPRICE]
           ,[SENDEINVCUSTOM]
           ,[EINVOICETYPSGK]
           ,[TAXPAYERCODE]
           ,[TAXPAYERNAME]
           ,[DOCUMENTNOSGK]
           ,[DRIVERNAME1]
           ,[DRIVERNAME2]
           ,[DRIVERNAME3]
           ,[DRIVERSURNAME1]
           ,[DRIVERSURNAME2]
           ,[DRIVERSURNAME3]
           ,[DRIVERTCKNO1]
           ,[DRIVERTCKNO2]
           ,[DRIVERTCKNO3]
           ,[PLATENUM1]
           ,[PLATENUM2]
           ,[PLATENUM3]
           ,[CHASSISNUM1]
           ,[CHASSISNUM2]
           ,[CHASSISNUM3]
           ,[RESPONSECODE]
           ,[RESPONSESTATUS]
           ,[STATUSDESC]
           ,[RESPONSECODEDESP]
           ,[RESPONSESTATUSDESP]
           ,[STATUSDESCDESP]
           ,[ORDFCREF]
           ,[CHAINDELIVERY]
           ,[SELLERCLIENTREF]
           ,[TAXNRTOPAY]) 
            VALUES(
            @INVOICEREF,@STFREF,@EINVOICETYP,@PROFILEID,@ESTATUS,@EDESCRIPTION,@EDURATION,@EDURATIONTYPE,@TAXTYPE,@TUNAME
           ,@TUSURNAME,@TUPASSPORTNO,@TUNATIONALITY,@TUNATIONALITYNAME,@TUBANKNAME,@TUBNACCOUNTNO,@TUBNBRANCH
           ,@TUPAYMENTNOTE,@TUBNCURR,@ADDR1,@ADDR2,@CITYCODE,@CITY,@COUNTRYCODE,@COUNTRY
           ,@DISTRICTCODE,@DISTRICT,@TOWNCODE,@TOWN,@EXITTOWN,@EXITGATECODE,@EXITGATE,@AGENCYCODE,@AGENCY,@EXITCOUNTRYCODE,@EXITCOUNTRY
           ,@TRANSPORTTYP,@TRANSPORTTYPCODE,@TRANSPORTTYPNAME,@FLIGHTNUMBER,@GUIDE,@TURETPRICE,@SENDEINVCUSTOM
           ,@EINVOICETYPSGK,@TAXPAYERCODE,@TAXPAYERNAME,@DOCUMENTNOSGK,@DRIVERNAME1,@DRIVERNAME2,@DRIVERNAME3,@DRIVERSURNAME1
           ,@DRIVERSURNAME2,@DRIVERSURNAME3,@DRIVERTCKNO1,@DRIVERTCKNO2,@DRIVERTCKNO3,@PLATENUM1,@PLATENUM2,@PLATENUM3,@CHASSISNUM1
           ,@CHASSISNUM2,@CHASSISNUM3,@RESPONSECODE,@RESPONSESTATUS,@STATUSDESC,@RESPONSECODEDESP,@RESPONSESTATUSDESP,@STATUSDESCDESP,@ORDFCREF,@CHAINDELIVERY
           ,@SELLERCLIENTREF,@TAXNRTOPAY); SELECT SCOPE_IDENTITY();");

						await using (SqlConnection connection = new SqlConnection(_connectionString))
						{
							await connection.OpenAsync();
							await using (SqlCommand command = new SqlCommand(driverQuery, connection))
							{
								//command.Parameters.AddWithValue("EENDDATE", item.EENDDATE ?? default(DateTime));
								//command.Parameters.AddWithValue("ESTARTDATE", item.ESTARTDATE ?? default(DateTime));
								//command.Parameters.AddWithValue("EXITDATE", item.EXITDATE ?? default(DateTime));
								//command.Parameters.AddWithValue("TUPASSPORTDATE", item.TUPASSPORTDATE ?? default(DateTime));
								command.Parameters.AddWithValue("INVOICEREF", item.EINVOICEDET.INVOICEREF);
								command.Parameters.AddWithValue("ORDFCREF", item.EINVOICEDET.ORDFCREF);
								command.Parameters.AddWithValue("SELLERCLIENTREF", item.EINVOICEDET.SELLERCLIENTREF);
								command.Parameters.AddWithValue("STFREF", ReferenceId);
								command.Parameters.AddWithValue("CHASSISNUM1", item.EINVOICEDET.CHASSISNUM1);
								command.Parameters.AddWithValue("CHASSISNUM2", item.EINVOICEDET.CHASSISNUM2);
								command.Parameters.AddWithValue("CHASSISNUM3", item.EINVOICEDET.CHASSISNUM3);
								command.Parameters.AddWithValue("FLIGHTNUMBER", item.EINVOICEDET.FLIGHTNUMBER);
								command.Parameters.AddWithValue("PLATENUM1", item.EINVOICEDET.PLATENUM1);
								command.Parameters.AddWithValue("PLATENUM2", item.EINVOICEDET.PLATENUM2);
								command.Parameters.AddWithValue("PLATENUM3", item.EINVOICEDET.PLATENUM3);
								command.Parameters.AddWithValue("DISTRICTCODE", item.EINVOICEDET.DISTRICTCODE);
								command.Parameters.AddWithValue("DRIVERTCKNO1", item.EINVOICEDET.DRIVERTCKNO1);
								command.Parameters.AddWithValue("DRIVERTCKNO2", item.EINVOICEDET.DRIVERTCKNO2);
								command.Parameters.AddWithValue("DRIVERTCKNO3", item.EINVOICEDET.DRIVERTCKNO3);
								command.Parameters.AddWithValue("EXITCOUNTRY", item.EINVOICEDET.EXITCOUNTRY);
								command.Parameters.AddWithValue("EXITCOUNTRYCODE", item.EINVOICEDET.EXITCOUNTRYCODE);
								command.Parameters.AddWithValue("COUNTRYCODE", item.EINVOICEDET.COUNTRYCODE);
								command.Parameters.AddWithValue("COUNTRY", item.EINVOICEDET.COUNTRY);
								command.Parameters.AddWithValue("GUIDE", item.EINVOICEDET.GUIDE);
								command.Parameters.AddWithValue("CITY", item.EINVOICEDET.CITY);
								command.Parameters.AddWithValue("CITYCODE", item.EINVOICEDET.CITYCODE);
								command.Parameters.AddWithValue("AGENCYCODE", item.EINVOICEDET.AGENCYCODE);
								command.Parameters.AddWithValue("TRANSPORTTYPCODE", item.EINVOICEDET.TRANSPORTTYPCODE);
								command.Parameters.AddWithValue("TOWNCODE", item.EINVOICEDET.TOWNCODE);
								command.Parameters.AddWithValue("TOWN", item.EINVOICEDET.TOWN);
								command.Parameters.AddWithValue("TAXPAYERCODE", item.EINVOICEDET.TAXPAYERCODE);
								command.Parameters.AddWithValue("ADDR1", item.EINVOICEDET.ADDR1);
								command.Parameters.AddWithValue("ADDR2", item.EINVOICEDET.ADDR2);
								command.Parameters.AddWithValue("AGENCY", item.EINVOICEDET.AGENCY);
								command.Parameters.AddWithValue("DISTRICT", item.EINVOICEDET.DISTRICT);
								command.Parameters.AddWithValue("DOCUMENTNOSGK", item.EINVOICEDET.DOCUMENTNOSGK);
								command.Parameters.AddWithValue("DRIVERNAME1", item.EINVOICEDET.DRIVERNAME1);
								command.Parameters.AddWithValue("DRIVERNAME2", item.EINVOICEDET.DRIVERNAME2);
								command.Parameters.AddWithValue("DRIVERNAME3", item.EINVOICEDET.DRIVERNAME3);
								command.Parameters.AddWithValue("DRIVERSURNAME1", item.EINVOICEDET.DRIVERSURNAME1);
								command.Parameters.AddWithValue("DRIVERSURNAME2", item.EINVOICEDET.DRIVERSURNAME2);
								command.Parameters.AddWithValue("DRIVERSURNAME3", item.EINVOICEDET.DRIVERSURNAME3);
								command.Parameters.AddWithValue("EDESCRIPTION", item.EINVOICEDET.EDESCRIPTION);
								command.Parameters.AddWithValue("TRANSPORTTYPNAME", item.EINVOICEDET.TRANSPORTTYPNAME);
								command.Parameters.AddWithValue("TUSURNAME", item.EINVOICEDET.TUSURNAME);
								command.Parameters.AddWithValue("TUNAME", item.EINVOICEDET.TUNAME);
								command.Parameters.AddWithValue("TUNATIONALITY", item.EINVOICEDET.TUNATIONALITY);
								command.Parameters.AddWithValue("TUNATIONALITYNAME", item.EINVOICEDET.TUNATIONALITYNAME);
								command.Parameters.AddWithValue("TUBNCURR", item.EINVOICEDET.TUBNCURR);
								command.Parameters.AddWithValue("TUBNBRANCH", item.EINVOICEDET.TUBNBRANCH);
								command.Parameters.AddWithValue("TUBNACCOUNTNO", item.EINVOICEDET.TUBNACCOUNTNO);
								command.Parameters.AddWithValue("TUBANKNAME", item.EINVOICEDET.TUBANKNAME);
								command.Parameters.AddWithValue("STATUSDESC", item.EINVOICEDET.STATUSDESC);
								command.Parameters.AddWithValue("STATUSDESCDESP", item.EINVOICEDET.STATUSDESCDESP);
								command.Parameters.AddWithValue("TUPAYMENTNOTE", item.EINVOICEDET.TUPAYMENTNOTE);
								command.Parameters.AddWithValue("TAXPAYERNAME", item.EINVOICEDET.TAXPAYERNAME);
								command.Parameters.AddWithValue("TAXNRTOPAY", item.EINVOICEDET.TAXNRTOPAY);
								command.Parameters.AddWithValue("TUPASSPORTNO", item.EINVOICEDET.TUPASSPORTNO);
								command.Parameters.AddWithValue("EXITTOWN", item.EINVOICEDET.EXITTOWN);
								command.Parameters.AddWithValue("EXITGATECODE", item.EINVOICEDET.EXITGATECODE);
								command.Parameters.AddWithValue("EXITGATE", item.EINVOICEDET.EXITGATE);
								command.Parameters.AddWithValue("RESPONSECODE", item.EINVOICEDET.RESPONSECODE);
								command.Parameters.AddWithValue("CHAINDELIVERY", item.EINVOICEDET.CHAINDELIVERY);
								command.Parameters.AddWithValue("TURETPRICE", item.EINVOICEDET.TURETPRICE);
								command.Parameters.AddWithValue("SENDEINVCUSTOM", item.EINVOICEDET.SENDEINVCUSTOM);
								command.Parameters.AddWithValue("RESPONSECODEDESP", item.EINVOICEDET.RESPONSECODEDESP);
								command.Parameters.AddWithValue("RESPONSESTATUS", item.EINVOICEDET.RESPONSESTATUS);
								command.Parameters.AddWithValue("RESPONSESTATUSDESP", item.EINVOICEDET.RESPONSESTATUSDESP);
								command.Parameters.AddWithValue("EDURATIONTYPE", item.EINVOICEDET.EDURATIONTYPE);
								command.Parameters.AddWithValue("EINVOICETYP", item.EINVOICEDET.EINVOICETYP);
								command.Parameters.AddWithValue("EINVOICETYPSGK", item.EINVOICEDET.EINVOICETYPSGK);
								command.Parameters.AddWithValue("TAXTYPE", item.EINVOICEDET.TAXTYPE);
								command.Parameters.AddWithValue("TRANSPORTTYP", item.EINVOICEDET.TRANSPORTTYP);
								command.Parameters.AddWithValue("PROFILEID", item.EINVOICEDET.PROFILEID);
								command.Parameters.AddWithValue("ESTATUS", item.EINVOICEDET.ESTATUS);
								command.Parameters.AddWithValue("EDURATION", item.EINVOICEDET.EDURATION);
								var id = await command.ExecuteScalarAsync();
								await connection.CloseAsync();
							}
						}
						#endregion
					}


					#region OutCounting Line Insert
					foreach (LG_STLINE line in item.TRANSACTIONS)
					{
						string lineQuery = $@"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_STLINE(
            STOCKREF
           ,LINETYPE
           ,PREVLINEREF
           ,PREVLINENO
           ,DETLINE
           ,TRCODE
           ,DATE_
           ,FTIME
           ,GLOBTRANS
           ,CALCTYPE
           ,PRODORDERREF
           ,SOURCETYPE
           ,SOURCEINDEX
           ,SOURCECOSTGRP
           ,SOURCEWSREF
           ,SOURCEPOLNREF
           ,DESTTYPE
           ,DESTINDEX
           ,DESTCOSTGRP
           ,DESTWSREF
           ,DESTPOLNREF
           ,FACTORYNR
           ,IOCODE
           ,STFICHEREF
           ,STFICHELNNO
           ,INVOICEREF
           ,INVOICELNNO
           ,CLIENTREF
           ,ORDTRANSREF
           ,ORDFICHEREF
           ,CENTERREF
           ,ACCOUNTREF
           ,VATACCREF
           ,VATCENTERREF
           ,PRACCREF
           ,PRCENTERREF
           ,PRVATACCREF
           ,PRVATCENREF
           ,PROMREF
           ,PAYDEFREF
           ,SPECODE
           ,DELVRYCODE
           ,AMOUNT
           ,PRICE
           ,TOTAL
           ,PRCURR
           ,PRPRICE
           ,TRCURR
           ,TRRATE
           ,REPORTRATE
           ,DISTCOST
           ,DISTDISC
           ,DISTEXP
           ,DISTPROM
           ,DISCPER
           ,LINEEXP
           ,UOMREF
           ,USREF
           ,UINFO1
           ,UINFO2
           ,UINFO3
           ,UINFO4
           ,UINFO5
           ,UINFO6
           ,UINFO7
           ,UINFO8
           ,PLNAMOUNT
           ,VATINC
           ,VAT
           ,VATAMNT
           ,VATMATRAH
           ,BILLEDITEM
           ,BILLED
           ,CPSTFLAG
           ,RETCOSTTYPE
           ,SOURCELINK
           ,RETCOST
           ,RETCOSTCURR
           ,OUTCOST
           ,OUTCOSTCURR
           ,RETAMOUNT
           ,FAREGREF
           ,FAATTRIB
           ,CANCELLED
           ,LINENET
           ,DISTADDEXP
           ,FADACCREF
           ,FADCENTERREF
           ,FARACCREF
           ,FARCENTERREF
           ,DIFFPRICE
           ,DIFFPRCOST
           ,DECPRDIFF
           ,LPRODSTAT
           ,PRDEXPTOTAL
           ,DIFFREPPRICE
           ,DIFFPRCRCOST
           ,SALESMANREF
           ,FAPLACCREF
           ,FAPLCENTERREF
           ,OUTPUTIDCODE
           ,DREF
           ,COSTRATE
           ,XPRICEUPD
           ,XPRICE
           ,XREPRATE
           ,DISTCOEF
           ,TRANSQCOK
           ,SITEID
           ,RECSTATUS
           ,ORGLOGICREF
           ,WFSTATUS
           ,POLINEREF
           ,PLNSTTRANSREF
           ,NETDISCFLAG
           ,NETDISCPERC
           ,NETDISCAMNT
           ,VATCALCDIFF
           ,CONDITIONREF
           ,DISTORDERREF
           ,DISTORDLINEREF
           ,CAMPAIGNREFS1
           ,CAMPAIGNREFS2
           ,CAMPAIGNREFS3
           ,CAMPAIGNREFS4
           ,CAMPAIGNREFS5
           ,POINTCAMPREF
           ,CAMPPOINT
           ,PROMCLASITEMREF
           ,CMPGLINEREF
           ,PLNSTTRANSPERNR
           ,PORDCLSPLNAMNT
           ,VENDCOMM
           ,PREVIOUSOUTCOST
           ,COSTOFSALEACCREF
           ,PURCHACCREF
           ,COSTOFSALECNTREF
           ,PURCHCENTREF
           ,PREVOUTCOSTCURR
           ,ABVATAMOUNT
           ,ABVATSTATUS
           ,PRRATE
           ,ADDTAXRATE
           ,ADDTAXCONVFACT
           ,ADDTAXAMOUNT
           ,ADDTAXPRCOST
           ,ADDTAXRETCOST
           ,ADDTAXRETCOSTCURR
           ,GROSSUINFO1
           ,GROSSUINFO2
           ,ADDTAXPRCOSTCURR
           ,ADDTAXACCREF
           ,ADDTAXCENTERREF
           ,ADDTAXAMNTISUPD
           ,INFIDX
           ,ADDTAXCOSACCREF
           ,ADDTAXCOSCNTREF
           ,PREVIOUSATAXPRCOST
           ,PREVATAXPRCOSTCURR
           ,PRDORDTOTCOEF
           ,DEMPEGGEDAMNT
           ,STDUNITCOST
           ,STDRPUNITCOST
           ,COSTDIFFACCREF
           ,COSTDIFFCENREF
           ,TEXTINC
           ,ADDTAXDISCAMOUNT
           ,ORGLOGOID
           ,EXIMFICHENO
           ,EXIMFCTYPE
           ,TRANSEXPLINE
           ,INSEXPLINE
           ,EXIMWHFCREF
           ,EXIMWHLNREF
           ,EXIMFILEREF
           ,EXIMPROCNR
           ,EISRVDSTTYP
           ,MAINSTLNREF
           ,MADEOFSHRED
           ,FROMORDWITHPAY
           ,PROJECTREF
           ,STATUS
           ,DORESERVE
           ,POINTCAMPREFS1
           ,POINTCAMPREFS2
           ,POINTCAMPREFS3
           ,POINTCAMPREFS4
           ,CAMPPOINTS1
           ,CAMPPOINTS2
           ,CAMPPOINTS3
           ,CAMPPOINTS4
           ,CMPGLINEREFS1
           ,CMPGLINEREFS2
           ,CMPGLINEREFS3
           ,CMPGLINEREFS4
           ,PRCLISTREF
           ,PORDSYMOUTLN
           ,MONTH_
           ,YEAR_
           ,EXADDTAXRATE
           ,EXADDTAXCONVF
           ,EXADDTAXAREF
           ,EXADDTAXCREF
           ,OTHRADDTAXAREF
           ,OTHRADDTAXCREF
           ,EXADDTAXAMNT
           ,AFFECTCOLLATRL
           ,ALTPROMFLAG
           ,EIDISTFLNNR
           ,EXIMTYPE
           ,VARIANTREF
           ,CANDEDUCT
           ,OUTREMAMNT
           ,OUTREMCOST
           ,OUTREMCOSTCURR
           ,REFLVATACCREF
           ,REFLVATOTHACCREF
           ,PARENTLNREF
           ,AFFECTRISK
           ,INEFFECTIVECOST
           ,ADDTAXVATMATRAH
           ,REFLACCREF
           ,REFLOTHACCREF
           ,CAMPPAYDEFREF
           ,FAREGBINDDATE
           ,RELTRANSLNREF
           ,FROMTRANSFER
           ,COSTDISTPRICE
           ,COSTDISTREPPRICE
           ,DIFFPRICEUFRS
           ,DIFFREPPRICEUFRS
           ,OUTCOSTUFRS
           ,OUTCOSTCURRUFRS
           ,DIFFPRCOSTUFRS
           ,DIFFPRCRCOSTUFRS
           ,RETCOSTUFRS
           ,RETCOSTCURRUFRS
           ,OUTREMCOSTUFRS
           ,OUTREMCOSTCURRUFRS
           ,INFIDXUFRS
           ,ADJPRICEUFRS
           ,ADJREPPRICEUFRS
           ,ADJPRCOSTUFRS
           ,ADJPRCRCOSTUFRS
           ,COSTDISTPRICEUFRS
           ,COSTDISTREPPRICEUFRS
           ,PURCHACCREFUFRS
           ,PURCHCENTREFUFRS
           ,COSACCREFUFRS
           ,COSCNTREFUFRS
           ,PROUTCOSTUFRSDIFF
           ,PROUTCOSTCRUFRSDIFF
           ,UNDERDEDUCTLIMIT
           ,GLOBALID
           ,DEDUCTIONPART1
           ,DEDUCTIONPART2
           ,GUID
           ,SPECODE2
           ,OFFERREF
           ,OFFTRANSREF
           ,VATEXCEPTREASON
           ,PLNDEFSERILOTNO
           ,PLNUNRSRVAMOUNT
           ,PORDCLSPLNUNRSRVAMNT
           ,LPRODRSRVSTAT
           ,FALINKTYPE
           ,DEDUCTCODE
           ,UPDTHISLINE
           ,VATEXCEPTCODE
           ,PORDERFICHENO
           ,QPRODFCREF
           ,RELTRANSFCREF
           ,ATAXEXCEPTREASON
           ,ATAXEXCEPTCODE
           ,PRODORDERTYP
           ,SUBCONTORDERREF
           ,QPRODFCTYP
           ,PRDORDSLPLNRESERVE
           ,INFDATE
           ,DESTSTATUS
           ,REGTYPREF
           ,FAPROFITACCREF
           ,FAPROFITCENTREF
           ,FALOSSACCREF
           ,FALOSSCENTREF
           ,CPACODE
           ,GTIPCODE
           ,PUBLICCOUNTRYREF
           ,QPRODITEMTYPE
           ,FUTMONTHCNT
           ,FUTMONTHBEGDATE

          
          
             )
            VALUES (
            @STOCKREF
           ,@LINETYPE
           ,@PREVLINEREF
           ,@PREVLINENO
           ,@DETLINE
           ,@TRCODE
           ,@DATE_
           ,(SELECT [dbo].[LG_TIMETOINT](@FHOUR,@FMINUTE,@FSECOND))
           ,@GLOBTRANS
           ,@CALCTYPE
           ,@PRODORDERREF
           ,@SOURCETYPE
           ,@SOURCEINDEX
           ,@SOURCECOSTGRP
           ,@SOURCEWSREF
           ,@SOURCEPOLNREF
           ,@DESTTYPE
           ,@DESTINDEX
           ,@DESTCOSTGRP
           ,@DESTWSREF
           ,@DESTPOLNREF
           ,@FACTORYNR
           ,@IOCODE
           ,@STFICHEREF
           ,@STFICHELNNO
           ,@INVOICEREF
           ,@INVOICELNNO
           ,@CLIENTREF
           ,@ORDTRANSREF
           ,@ORDFICHEREF
           ,@CENTERREF
           ,@ACCOUNTREF
           ,@VATACCREF
           ,@VATCENTERREF
           ,@PRACCREF
           ,@PRCENTERREF
           ,@PRVATACCREF
           ,@PRVATCENREF
           ,@PROMREF
           ,@PAYDEFREF
           ,@SPECODE
           ,@DELVRYCODE
           ,@AMOUNT
           ,@PRICE
           ,@TOTAL
           ,@PRCURR
           ,@PRPRICE
           ,@TRCURR
           ,@TRRATE
           ,@REPORTRATE
           ,@DISTCOST
           ,@DISTDISC
           ,@DISTEXP
           ,@DISTPROM
           ,@DISCPER
           ,@LINEEXP
           ,@UOMREF
           ,@USREF
           ,@UINFO1
           ,@UINFO2
           ,@UINFO3
           ,@UINFO4
           ,@UINFO5
           ,@UINFO6
           ,@UINFO7
           ,@UINFO8
           ,@PLNAMOUNT
           ,@VATINC
           ,@VAT
           ,@VATAMNT
           ,@VATMATRAH
           ,@BILLEDITEM
           ,@BILLED
           ,@CPSTFLAG
           ,@RETCOSTTYPE
           ,@SOURCELINK
           ,@RETCOST
           ,@RETCOSTCURR
           ,@OUTCOST
           ,@OUTCOSTCURR
           ,@RETAMOUNT
           ,@FAREGREF
           ,@FAATTRIB
           ,@CANCELLED
           ,@LINENET
           ,@DISTADDEXP
           ,@FADACCREF
           ,@FADCENTERREF
           ,@FARACCREF
           ,@FARCENTERREF
           ,@DIFFPRICE
           ,@DIFFPRCOST
           ,@DECPRDIFF
           ,@LPRODSTAT
           ,@PRDEXPTOTAL
           ,@DIFFREPPRICE
           ,@DIFFPRCRCOST
           ,@SALESMANREF
           ,@FAPLACCREF
           ,@FAPLCENTERREF
           ,@OUTPUTIDCODE
           ,@DREF
           ,@COSTRATE
           ,@XPRICEUPD
           ,@XPRICE
           ,@XREPRATE
           ,@DISTCOEF
           ,@TRANSQCOK
           ,@SITEID
           ,@RECSTATUS
           ,@ORGLOGICREF
           ,@WFSTATUS
           ,@POLINEREF
           ,@PLNSTTRANSREF
           ,@NETDISCFLAG
           ,@NETDISCPERC
           ,@NETDISCAMNT
           ,@VATCALCDIFF
           ,@CONDITIONREF
           ,@DISTORDERREF
           ,@DISTORDLINEREF
           ,@CAMPAIGNREFS1
           ,@CAMPAIGNREFS2
           ,@CAMPAIGNREFS3
           ,@CAMPAIGNREFS4
           ,@CAMPAIGNREFS5
           ,@POINTCAMPREF
           ,@CAMPPOINT
           ,@PROMCLASITEMREF
           ,@CMPGLINEREF
           ,@PLNSTTRANSPERNR
           ,@PORDCLSPLNAMNT
           ,@VENDCOMM
           ,@PREVIOUSOUTCOST
           ,@COSTOFSALEACCREF
           ,@PURCHACCREF
           ,@COSTOFSALECNTREF
           ,@PURCHCENTREF
           ,@PREVOUTCOSTCURR
           ,@ABVATAMOUNT
           ,@ABVATSTATUS
           ,@PRRATE
           ,@ADDTAXRATE
           ,@ADDTAXCONVFACT
           ,@ADDTAXAMOUNT
           ,@ADDTAXPRCOST
           ,@ADDTAXRETCOST
           ,@ADDTAXRETCOSTCURR
           ,@GROSSUINFO1
           ,@GROSSUINFO2
           ,@ADDTAXPRCOSTCURR
           ,@ADDTAXACCREF
           ,@ADDTAXCENTERREF
           ,@ADDTAXAMNTISUPD
           ,@INFIDX
           ,@ADDTAXCOSACCREF
           ,@ADDTAXCOSCNTREF
           ,@PREVIOUSATAXPRCOST
           ,@PREVATAXPRCOSTCURR
           ,@PRDORDTOTCOEF
           ,@DEMPEGGEDAMNT
           ,@STDUNITCOST
           ,@STDRPUNITCOST
           ,@COSTDIFFACCREF
           ,@COSTDIFFCENREF
           ,@TEXTINC
           ,@ADDTAXDISCAMOUNT
           ,@ORGLOGOID
           ,@EXIMFICHENO
           ,@EXIMFCTYPE
           ,@TRANSEXPLINE
           ,@INSEXPLINE
           ,@EXIMWHFCREF
           ,@EXIMWHLNREF
           ,@EXIMFILEREF
           ,@EXIMPROCNR
           ,@EISRVDSTTYP
           ,@MAINSTLNREF
           ,@MADEOFSHRED
           ,@FROMORDWITHPAY
           ,@PROJECTREF
           ,@STATUS
           ,@DORESERVE
           ,@POINTCAMPREFS1
           ,@POINTCAMPREFS2
           ,@POINTCAMPREFS3
           ,@POINTCAMPREFS4
           ,@CAMPPOINTS1
           ,@CAMPPOINTS2
           ,@CAMPPOINTS3
           ,@CAMPPOINTS4
           ,@CMPGLINEREFS1
           ,@CMPGLINEREFS2
           ,@CMPGLINEREFS3
           ,@CMPGLINEREFS4
           ,@PRCLISTREF
           ,@PORDSYMOUTLN
           ,@MONTH_
           ,@YEAR_
           ,@EXADDTAXRATE
           ,@EXADDTAXCONVF
           ,@EXADDTAXAREF
           ,@EXADDTAXCREF
           ,@OTHRADDTAXAREF
           ,@OTHRADDTAXCREF
           ,@EXADDTAXAMNT
           ,@AFFECTCOLLATRL
           ,@ALTPROMFLAG
           ,@EIDISTFLNNR
           ,@EXIMTYPE
           ,@VARIANTREF
           ,@CANDEDUCT
           ,@OUTREMAMNT
           ,@OUTREMCOST
           ,@OUTREMCOSTCURR
           ,@REFLVATACCREF
           ,@REFLVATOTHACCREF
           ,@PARENTLNREF
           ,@AFFECTRISK
           ,@INEFFECTIVECOST
           ,@ADDTAXVATMATRAH
           ,@REFLACCREF
           ,@REFLOTHACCREF
           ,@CAMPPAYDEFREF
           ,@FAREGBINDDATE
           ,@RELTRANSLNREF
           ,@FROMTRANSFER
           ,@COSTDISTPRICE
           ,@COSTDISTREPPRICE
           ,@DIFFPRICEUFRS
           ,@DIFFREPPRICEUFRS
           ,@OUTCOSTUFRS
           ,@OUTCOSTCURRUFRS
           ,@DIFFPRCOSTUFRS
           ,@DIFFPRCRCOSTUFRS
           ,@RETCOSTUFRS
           ,@RETCOSTCURRUFRS
           ,@OUTREMCOSTUFRS
           ,@OUTREMCOSTCURRUFRS
           ,@INFIDXUFRS
           ,@ADJPRICEUFRS
           ,@ADJREPPRICEUFRS
           ,@ADJPRCOSTUFRS
           ,@ADJPRCRCOSTUFRS
           ,@COSTDISTPRICEUFRS
           ,@COSTDISTREPPRICEUFRS
           ,@PURCHACCREFUFRS
           ,@PURCHCENTREFUFRS
           ,@COSACCREFUFRS
           ,@COSCNTREFUFRS
           ,@PROUTCOSTUFRSDIFF
           ,@PROUTCOSTCRUFRSDIFF
           ,@UNDERDEDUCTLIMIT
           ,@GLOBALID
           ,@DEDUCTIONPART1
           ,@DEDUCTIONPART2
           ,@GUID
           ,@SPECODE2
           ,@OFFERREF
           ,@OFFTRANSREF
           ,@VATEXCEPTREASON
           ,@PLNDEFSERILOTNO
           ,@PLNUNRSRVAMOUNT
           ,@PORDCLSPLNUNRSRVAMNT
           ,@LPRODRSRVSTAT
           ,@FALINKTYPE
           ,@DEDUCTCODE
           ,@UPDTHISLINE
           ,@VATEXCEPTCODE
           ,@PORDERFICHENO
           ,@QPRODFCREF
           ,@RELTRANSFCREF
           ,@ATAXEXCEPTREASON
           ,@ATAXEXCEPTCODE
           ,@PRODORDERTYP
           ,@SUBCONTORDERREF
           ,@QPRODFCTYP
           ,@PRDORDSLPLNRESERVE
           ,@INFDATE
           ,@DESTSTATUS
           ,@REGTYPREF
           ,@FAPROFITACCREF
           ,@FAPROFITCENTREF
           ,@FALOSSACCREF
           ,@FALOSSCENTREF
           ,@CPACODE
           ,@GTIPCODE
           ,@PUBLICCOUNTRYREF
           ,@QPRODITEMTYPE
           ,@FUTMONTHCNT
           ,@FUTMONTHBEGDATE
           
           
           ); SELECT SCOPE_IDENTITY();";
						await using (SqlConnection connection = new SqlConnection(_connectionString))
						{
							await connection.OpenAsync();

							try
							{
								await using (SqlCommand command = new SqlCommand(lineQuery, connection))
								{
									command.Parameters.AddWithValue("STOCKREF", line.STOCKREF);
									command.Parameters.AddWithValue("LINETYPE", line.LINETYPE);
									command.Parameters.AddWithValue("PREVLINEREF", line.PREVLINEREF);
									command.Parameters.AddWithValue("PREVLINENO", line.PREVLINENO);
									command.Parameters.AddWithValue("DETLINE", line.DETLINE);
									command.Parameters.AddWithValue("TRCODE", 51);
									command.Parameters.AddWithValue("DATE_", line.DATE_);
									command.Parameters.AddWithValue("FHOUR", item.DATE_.Hour);
									command.Parameters.AddWithValue("FMINUTE", item.DATE_.Minute);
									command.Parameters.AddWithValue("FSECOND", item.DATE_.Second);
									command.Parameters.AddWithValue("GLOBTRANS", line.GLOBTRANS);
									command.Parameters.AddWithValue("CALCTYPE", line.CALCTYPE);
									command.Parameters.AddWithValue("PRODORDERREF", line.PRODORDERREF);
									command.Parameters.AddWithValue("SOURCETYPE", line.SOURCETYPE);
									command.Parameters.AddWithValue("SOURCEINDEX", line.SOURCEINDEX);
									command.Parameters.AddWithValue("SOURCECOSTGRP", line.SOURCECOSTGRP);
									command.Parameters.AddWithValue("SOURCEWSREF", line.SOURCEWSREF);
									command.Parameters.AddWithValue("SOURCEPOLNREF", line.SOURCEPOLNREF);
									command.Parameters.AddWithValue("DESTTYPE", line.DESTTYPE);
									command.Parameters.AddWithValue("DESTINDEX", line.DESTINDEX);
									command.Parameters.AddWithValue("DESTCOSTGRP", line.DESTCOSTGRP);
									command.Parameters.AddWithValue("DESTWSREF", line.DESTWSREF);
									command.Parameters.AddWithValue("DESTPOLNREF", line.DESTPOLNREF);
									command.Parameters.AddWithValue("FACTORYNR", line.FACTORYNR);
									command.Parameters.AddWithValue("IOCODE", 4);
									command.Parameters.AddWithValue("STFICHEREF", ReferenceId);
									command.Parameters.AddWithValue("STFICHELNNO", line.STFICHELNNO);
									command.Parameters.AddWithValue("INVOICEREF", line.INVOICEREF);
									command.Parameters.AddWithValue("INVOICELNNO", line.INVOICELNNO);
									command.Parameters.AddWithValue("CLIENTREF", line.CLIENTREF);
									command.Parameters.AddWithValue("ORDTRANSREF", line.ORDTRANSREF);
									command.Parameters.AddWithValue("ORDFICHEREF", line.ORDFICHEREF);
									command.Parameters.AddWithValue("CENTERREF", line.CENTERREF);
									command.Parameters.AddWithValue("ACCOUNTREF", line.ACCOUNTREF);
									command.Parameters.AddWithValue("VATACCREF", line.VATACCREF);
									command.Parameters.AddWithValue("VATCENTERREF", line.VATCENTERREF);
									command.Parameters.AddWithValue("PRACCREF", line.PRACCREF);
									command.Parameters.AddWithValue("PRCENTERREF", line.PRCENTERREF);
									command.Parameters.AddWithValue("PRVATACCREF", line.PRVATACCREF);
									command.Parameters.AddWithValue("PRVATCENREF", line.PRVATCENREF);
									command.Parameters.AddWithValue("PROMREF", line.PROMREF);
									command.Parameters.AddWithValue("PAYDEFREF", line.PAYDEFREF);
									command.Parameters.AddWithValue("SPECODE", line.SPECODE);
									command.Parameters.AddWithValue("DELVRYCODE", line.DELVRYCODE);
									command.Parameters.AddWithValue("AMOUNT", line.AMOUNT);
									command.Parameters.AddWithValue("PRICE", line.PRICE);
									command.Parameters.AddWithValue("TOTAL", line.TOTAL);
									command.Parameters.AddWithValue("PRCURR", line.PRCURR);
									command.Parameters.AddWithValue("PRPRICE", line.PRPRICE);
									command.Parameters.AddWithValue("TRCURR", line.TRCURR);
									command.Parameters.AddWithValue("TRRATE", line.TRRATE);
									command.Parameters.AddWithValue("REPORTRATE", line.REPORTRATE);
									command.Parameters.AddWithValue("DISTCOST", line.DISTCOST);
									command.Parameters.AddWithValue("DISTDISC", line.DISTDISC);
									command.Parameters.AddWithValue("DISTEXP", line.DISTEXP);
									command.Parameters.AddWithValue("DISTPROM", line.DISTPROM);
									command.Parameters.AddWithValue("DISCPER", line.DISCPER);
									command.Parameters.AddWithValue("LINEEXP", line.LINEEXP);
									command.Parameters.AddWithValue("UOMREF", line.UOMREF);
									command.Parameters.AddWithValue("USREF", line.USREF);
									command.Parameters.AddWithValue("UINFO1", line.UINFO1);
									command.Parameters.AddWithValue("UINFO2", line.UINFO2);
									command.Parameters.AddWithValue("UINFO3", line.UINFO3);
									command.Parameters.AddWithValue("UINFO4", line.UINFO4);
									command.Parameters.AddWithValue("UINFO5", line.UINFO5);
									command.Parameters.AddWithValue("UINFO6", line.UINFO6);
									command.Parameters.AddWithValue("UINFO7", line.UINFO7);
									command.Parameters.AddWithValue("UINFO8", line.UINFO8);
									command.Parameters.AddWithValue("PLNAMOUNT", line.PLNAMOUNT);
									command.Parameters.AddWithValue("VATINC", line.VATINC);
									command.Parameters.AddWithValue("VAT", line.VAT);
									command.Parameters.AddWithValue("VATAMNT", line.VATAMNT);
									command.Parameters.AddWithValue("VATMATRAH", line.VATMATRAH);
									command.Parameters.AddWithValue("BILLEDITEM", line.BILLEDITEM);
									command.Parameters.AddWithValue("BILLED", line.BILLED);
									command.Parameters.AddWithValue("CPSTFLAG", line.CPSTFLAG);
									command.Parameters.AddWithValue("RETCOSTTYPE", line.RETCOSTTYPE);
									command.Parameters.AddWithValue("SOURCELINK", line.SOURCELINK);
									command.Parameters.AddWithValue("RETCOST", line.RETCOST);
									command.Parameters.AddWithValue("RETCOSTCURR", line.RETCOSTCURR);
									command.Parameters.AddWithValue("OUTCOST", line.OUTCOST);
									command.Parameters.AddWithValue("OUTCOSTCURR", line.OUTCOSTCURR);
									command.Parameters.AddWithValue("RETAMOUNT", line.RETAMOUNT);
									command.Parameters.AddWithValue("FAREGREF", line.FAREGREF);
									command.Parameters.AddWithValue("FAATTRIB", line.FAATTRIB);
									command.Parameters.AddWithValue("CANCELLED", line.CANCELLED);
									command.Parameters.AddWithValue("LINENET", line.LINENET);
									command.Parameters.AddWithValue("DISTADDEXP", line.DISTADDEXP);
									command.Parameters.AddWithValue("FADACCREF", line.FADACCREF);
									command.Parameters.AddWithValue("FADCENTERREF", line.FADCENTERREF);
									command.Parameters.AddWithValue("FARACCREF", line.FARACCREF);
									command.Parameters.AddWithValue("FARCENTERREF", line.FARCENTERREF);
									command.Parameters.AddWithValue("DIFFPRICE", line.DIFFPRICE);
									command.Parameters.AddWithValue("DIFFPRCOST", line.DIFFPRCOST);
									command.Parameters.AddWithValue("DECPRDIFF", line.DECPRDIFF);
									command.Parameters.AddWithValue("LPRODSTAT", line.LPRODSTAT);
									command.Parameters.AddWithValue("PRDEXPTOTAL", line.PRDEXPTOTAL);
									command.Parameters.AddWithValue("DIFFREPPRICE", line.DIFFREPPRICE);
									command.Parameters.AddWithValue("DIFFPRCRCOST", line.DIFFPRCRCOST);
									command.Parameters.AddWithValue("SALESMANREF", line.SALESMANREF);
									command.Parameters.AddWithValue("FAPLACCREF", line.FAPLACCREF);
									command.Parameters.AddWithValue("FAPLCENTERREF", line.FAPLCENTERREF);
									command.Parameters.AddWithValue("OUTPUTIDCODE", line.OUTPUTIDCODE);
									command.Parameters.AddWithValue("DREF", line.DREF);
									command.Parameters.AddWithValue("COSTRATE", line.COSTRATE);
									command.Parameters.AddWithValue("XPRICEUPD", line.XPRICEUPD);
									command.Parameters.AddWithValue("XPRICE", line.XPRICE);
									command.Parameters.AddWithValue("XREPRATE", line.XREPRATE);
									command.Parameters.AddWithValue("DISTCOEF", line.DISTCOEF);
									command.Parameters.AddWithValue("TRANSQCOK", line.TRANSQCOK);
									command.Parameters.AddWithValue("SITEID", line.SITEID);
									command.Parameters.AddWithValue("RECSTATUS", line.RECSTATUS);
									command.Parameters.AddWithValue("ORGLOGICREF", line.ORGLOGICREF);
									command.Parameters.AddWithValue("WFSTATUS", line.WFSTATUS);
									command.Parameters.AddWithValue("POLINEREF", line.POLINEREF);
									command.Parameters.AddWithValue("PLNSTTRANSREF", line.PLNSTTRANSREF);
									command.Parameters.AddWithValue("NETDISCFLAG", line.NETDISCFLAG);
									command.Parameters.AddWithValue("NETDISCPERC", line.NETDISCPERC);
									command.Parameters.AddWithValue("NETDISCAMNT", line.NETDISCAMNT);
									command.Parameters.AddWithValue("VATCALCDIFF", line.VATCALCDIFF);
									command.Parameters.AddWithValue("CONDITIONREF", line.CONDITIONREF);
									command.Parameters.AddWithValue("DISTORDERREF", line.DISTORDERREF);
									command.Parameters.AddWithValue("DISTORDLINEREF", line.DISTORDLINEREF);
									command.Parameters.AddWithValue("CAMPAIGNREFS1", line.CAMPAIGNREFS1);
									command.Parameters.AddWithValue("CAMPAIGNREFS2", line.CAMPAIGNREFS2);
									command.Parameters.AddWithValue("CAMPAIGNREFS3", line.CAMPAIGNREFS3);
									command.Parameters.AddWithValue("CAMPAIGNREFS4", line.CAMPAIGNREFS4);
									command.Parameters.AddWithValue("CAMPAIGNREFS5", line.CAMPAIGNREFS5);
									command.Parameters.AddWithValue("POINTCAMPREF", line.POINTCAMPREF);
									command.Parameters.AddWithValue("CAMPPOINT", line.CAMPPOINT);
									command.Parameters.AddWithValue("PROMCLASITEMREF", line.PROMCLASITEMREF);
									command.Parameters.AddWithValue("CMPGLINEREF", line.CMPGLINEREF);
									command.Parameters.AddWithValue("PLNSTTRANSPERNR", line.PLNSTTRANSPERNR);
									command.Parameters.AddWithValue("PORDCLSPLNAMNT", line.PORDCLSPLNAMNT);
									command.Parameters.AddWithValue("VENDCOMM", line.VENDCOMM);
									command.Parameters.AddWithValue("PREVIOUSOUTCOST", line.PREVIOUSOUTCOST);
									command.Parameters.AddWithValue("COSTOFSALEACCREF", line.COSTOFSALEACCREF);
									command.Parameters.AddWithValue("PURCHACCREF", line.PURCHACCREF);
									command.Parameters.AddWithValue("COSTOFSALECNTREF", line.COSTOFSALECNTREF);
									command.Parameters.AddWithValue("PURCHCENTREF", line.PURCHCENTREF);
									command.Parameters.AddWithValue("PREVOUTCOSTCURR", line.PREVOUTCOSTCURR);
									command.Parameters.AddWithValue("ABVATAMOUNT", line.ABVATAMOUNT);
									command.Parameters.AddWithValue("ABVATSTATUS", line.ABVATSTATUS);
									command.Parameters.AddWithValue("PRRATE", line.PRRATE);
									command.Parameters.AddWithValue("ADDTAXRATE", line.ADDTAXRATE);
									command.Parameters.AddWithValue("ADDTAXCONVFACT", line.ADDTAXCONVFACT);
									command.Parameters.AddWithValue("ADDTAXAMOUNT", line.ADDTAXAMOUNT);
									command.Parameters.AddWithValue("ADDTAXPRCOST", line.ADDTAXPRCOST);
									command.Parameters.AddWithValue("ADDTAXRETCOST", line.ADDTAXRETCOST);
									command.Parameters.AddWithValue("ADDTAXRETCOSTCURR", line.ADDTAXRETCOSTCURR);
									command.Parameters.AddWithValue("GROSSUINFO1", line.GROSSUINFO1);
									command.Parameters.AddWithValue("GROSSUINFO2", line.GROSSUINFO2);
									command.Parameters.AddWithValue("ADDTAXPRCOSTCURR", line.ADDTAXPRCOSTCURR);
									command.Parameters.AddWithValue("ADDTAXACCREF", line.ADDTAXACCREF);
									command.Parameters.AddWithValue("ADDTAXCENTERREF", line.ADDTAXCENTERREF);
									command.Parameters.AddWithValue("ADDTAXAMNTISUPD", line.ADDTAXAMNTISUPD);
									command.Parameters.AddWithValue("INFIDX", line.INFIDX);
									command.Parameters.AddWithValue("ADDTAXCOSACCREF", line.ADDTAXCOSACCREF);
									command.Parameters.AddWithValue("ADDTAXCOSCNTREF", line.ADDTAXCOSCNTREF);
									command.Parameters.AddWithValue("PREVIOUSATAXPRCOST", line.PREVIOUSATAXPRCOST);
									command.Parameters.AddWithValue("PREVATAXPRCOSTCURR", line.PREVATAXPRCOSTCURR);
									command.Parameters.AddWithValue("PRDORDTOTCOEF", line.PRDORDTOTCOEF);
									command.Parameters.AddWithValue("DEMPEGGEDAMNT", line.DEMPEGGEDAMNT);
									command.Parameters.AddWithValue("STDUNITCOST", line.STDUNITCOST);
									command.Parameters.AddWithValue("STDRPUNITCOST", line.STDRPUNITCOST);
									command.Parameters.AddWithValue("COSTDIFFACCREF", line.COSTDIFFACCREF);
									command.Parameters.AddWithValue("COSTDIFFCENREF", line.COSTDIFFCENREF);
									command.Parameters.AddWithValue("TEXTINC", line.TEXTINC);
									command.Parameters.AddWithValue("ADDTAXDISCAMOUNT", line.ADDTAXDISCAMOUNT);
									command.Parameters.AddWithValue("ORGLOGOID", line.ORGLOGOID);
									command.Parameters.AddWithValue("EXIMFICHENO", line.EXIMFICHENO);
									command.Parameters.AddWithValue("EXIMFCTYPE", line.EXIMFCTYPE);
									command.Parameters.AddWithValue("TRANSEXPLINE", line.TRANSEXPLINE);
									command.Parameters.AddWithValue("INSEXPLINE", line.INSEXPLINE);
									command.Parameters.AddWithValue("EXIMWHFCREF", line.EXIMWHFCREF);
									command.Parameters.AddWithValue("EXIMWHLNREF", line.EXIMWHLNREF);
									command.Parameters.AddWithValue("EXIMFILEREF", line.EXIMFILEREF);
									command.Parameters.AddWithValue("EXIMPROCNR", line.EXIMPROCNR);
									command.Parameters.AddWithValue("EISRVDSTTYP", line.EISRVDSTTYP);
									command.Parameters.AddWithValue("MAINSTLNREF", line.MAINSTLNREF);
									command.Parameters.AddWithValue("MADEOFSHRED", line.MADEOFSHRED);
									command.Parameters.AddWithValue("FROMORDWITHPAY", line.FROMORDWITHPAY);
									command.Parameters.AddWithValue("PROJECTREF", line.PROJECTREF);
									command.Parameters.AddWithValue("STATUS", line.STATUS);
									command.Parameters.AddWithValue("DORESERVE", line.DORESERVE);
									command.Parameters.AddWithValue("POINTCAMPREFS1", line.POINTCAMPREFS1);
									command.Parameters.AddWithValue("POINTCAMPREFS2", line.POINTCAMPREFS2);
									command.Parameters.AddWithValue("POINTCAMPREFS3", line.POINTCAMPREFS3);
									command.Parameters.AddWithValue("POINTCAMPREFS4", line.POINTCAMPREFS4);
									command.Parameters.AddWithValue("CAMPPOINTS1", line.CAMPPOINTS1);
									command.Parameters.AddWithValue("CAMPPOINTS2", line.CAMPPOINTS2);
									command.Parameters.AddWithValue("CAMPPOINTS3", line.CAMPPOINTS3);
									command.Parameters.AddWithValue("CAMPPOINTS4", line.CAMPPOINTS4);
									command.Parameters.AddWithValue("CMPGLINEREFS1", line.CMPGLINEREFS1);
									command.Parameters.AddWithValue("CMPGLINEREFS2", line.CMPGLINEREFS2);
									command.Parameters.AddWithValue("CMPGLINEREFS3", line.CMPGLINEREFS3);
									command.Parameters.AddWithValue("CMPGLINEREFS4", line.CMPGLINEREFS4);
									command.Parameters.AddWithValue("PRCLISTREF", line.PRCLISTREF);
									command.Parameters.AddWithValue("PORDSYMOUTLN", line.PORDSYMOUTLN);
									command.Parameters.AddWithValue("MONTH_", line.MONTH_);
									command.Parameters.AddWithValue("YEAR_", line.YEAR_);
									command.Parameters.AddWithValue("EXADDTAXRATE", line.EXADDTAXRATE);
									command.Parameters.AddWithValue("EXADDTAXCONVF", line.EXADDTAXCONVF);
									command.Parameters.AddWithValue("EXADDTAXAREF", line.EXADDTAXAREF);
									command.Parameters.AddWithValue("EXADDTAXCREF", line.EXADDTAXCREF);
									command.Parameters.AddWithValue("OTHRADDTAXAREF", line.OTHRADDTAXAREF);
									command.Parameters.AddWithValue("OTHRADDTAXCREF", line.OTHRADDTAXCREF);
									command.Parameters.AddWithValue("EXADDTAXAMNT", line.EXADDTAXAMNT);
									command.Parameters.AddWithValue("AFFECTCOLLATRL", line.AFFECTCOLLATRL);
									command.Parameters.AddWithValue("ALTPROMFLAG", line.ALTPROMFLAG);
									command.Parameters.AddWithValue("EIDISTFLNNR", line.EIDISTFLNNR);
									command.Parameters.AddWithValue("EXIMTYPE", line.EXIMTYPE);
									command.Parameters.AddWithValue("VARIANTREF", line.VARIANTREF);
									command.Parameters.AddWithValue("CANDEDUCT", line.CANDEDUCT);
									command.Parameters.AddWithValue("OUTREMAMNT", line.OUTREMAMNT);
									command.Parameters.AddWithValue("OUTREMCOST", line.OUTREMCOST);
									command.Parameters.AddWithValue("OUTREMCOSTCURR", line.OUTREMCOSTCURR);
									command.Parameters.AddWithValue("REFLVATACCREF", line.REFLVATACCREF);
									command.Parameters.AddWithValue("REFLVATOTHACCREF", line.REFLVATOTHACCREF);
									command.Parameters.AddWithValue("PARENTLNREF", line.PARENTLNREF);
									command.Parameters.AddWithValue("AFFECTRISK", line.AFFECTRISK);
									command.Parameters.AddWithValue("INEFFECTIVECOST", line.INEFFECTIVECOST);
									command.Parameters.AddWithValue("ADDTAXVATMATRAH", line.ADDTAXVATMATRAH);
									command.Parameters.AddWithValue("REFLACCREF", line.REFLACCREF);
									command.Parameters.AddWithValue("REFLOTHACCREF", line.REFLOTHACCREF);
									command.Parameters.AddWithValue("CAMPPAYDEFREF", line.CAMPPAYDEFREF);


									if (line.FAREGBINDDATE == null)
										command.Parameters.AddWithValue("FAREGBINDDATE", DBNull.Value);
									else
										command.Parameters.AddWithValue("FAREGBINDDATE", line.FAREGBINDDATE);

									command.Parameters.AddWithValue("RELTRANSLNREF", line.RELTRANSLNREF);
									command.Parameters.AddWithValue("FROMTRANSFER", line.FROMTRANSFER);
									command.Parameters.AddWithValue("COSTDISTPRICE", line.COSTDISTPRICE);
									command.Parameters.AddWithValue("COSTDISTREPPRICE", line.COSTDISTREPPRICE);
									command.Parameters.AddWithValue("DIFFPRICEUFRS", line.DIFFPRICEUFRS);
									command.Parameters.AddWithValue("DIFFREPPRICEUFRS", line.DIFFREPPRICEUFRS);
									command.Parameters.AddWithValue("OUTCOSTUFRS", line.OUTCOSTUFRS);
									command.Parameters.AddWithValue("OUTCOSTCURRUFRS", line.OUTCOSTCURRUFRS);
									command.Parameters.AddWithValue("DIFFPRCOSTUFRS", line.DIFFPRCOSTUFRS);
									command.Parameters.AddWithValue("DIFFPRCRCOSTUFRS", line.DIFFPRCRCOSTUFRS);
									command.Parameters.AddWithValue("RETCOSTUFRS", line.RETCOSTUFRS);
									command.Parameters.AddWithValue("RETCOSTCURRUFRS", line.RETCOSTCURRUFRS);
									command.Parameters.AddWithValue("OUTREMCOSTUFRS", line.OUTREMCOSTUFRS);
									command.Parameters.AddWithValue("OUTREMCOSTCURRUFRS", line.OUTREMCOSTCURRUFRS);
									command.Parameters.AddWithValue("INFIDXUFRS", line.INFIDXUFRS);
									command.Parameters.AddWithValue("ADJPRICEUFRS", line.ADJPRICEUFRS);
									command.Parameters.AddWithValue("ADJREPPRICEUFRS", line.ADJREPPRICEUFRS);
									command.Parameters.AddWithValue("ADJPRCOSTUFRS", line.ADJPRCOSTUFRS);
									command.Parameters.AddWithValue("ADJPRCRCOSTUFRS", line.ADJPRCRCOSTUFRS);
									command.Parameters.AddWithValue("COSTDISTPRICEUFRS", line.COSTDISTPRICEUFRS);
									command.Parameters.AddWithValue("COSTDISTREPPRICEUFRS", line.COSTDISTREPPRICEUFRS);
									command.Parameters.AddWithValue("PURCHACCREFUFRS", line.PURCHACCREFUFRS);
									command.Parameters.AddWithValue("PURCHCENTREFUFRS", line.PURCHCENTREFUFRS);
									command.Parameters.AddWithValue("COSACCREFUFRS", line.COSACCREFUFRS);
									command.Parameters.AddWithValue("COSCNTREFUFRS", line.COSCNTREFUFRS);
									command.Parameters.AddWithValue("PROUTCOSTUFRSDIFF", line.PROUTCOSTUFRSDIFF);
									command.Parameters.AddWithValue("PROUTCOSTCRUFRSDIFF", line.PROUTCOSTCRUFRSDIFF);
									command.Parameters.AddWithValue("UNDERDEDUCTLIMIT", line.UNDERDEDUCTLIMIT);
									command.Parameters.AddWithValue("GLOBALID", line.GLOBALID);
									command.Parameters.AddWithValue("DEDUCTIONPART1", line.DEDUCTIONPART1);
									command.Parameters.AddWithValue("DEDUCTIONPART2", line.DEDUCTIONPART2);
									command.Parameters.AddWithValue("GUID", line.GUID);
									command.Parameters.AddWithValue("SPECODE2", line.SPECODE2);
									command.Parameters.AddWithValue("OFFERREF", line.OFFERREF);
									command.Parameters.AddWithValue("OFFTRANSREF", line.OFFTRANSREF);
									command.Parameters.AddWithValue("VATEXCEPTREASON", line.VATEXCEPTREASON);
									command.Parameters.AddWithValue("PLNDEFSERILOTNO", line.PLNDEFSERILOTNO);
									command.Parameters.AddWithValue("PLNUNRSRVAMOUNT", line.PLNUNRSRVAMOUNT);
									command.Parameters.AddWithValue("PORDCLSPLNUNRSRVAMNT", line.PORDCLSPLNUNRSRVAMNT);
									command.Parameters.AddWithValue("LPRODRSRVSTAT", line.LPRODRSRVSTAT);
									command.Parameters.AddWithValue("FALINKTYPE", line.FALINKTYPE);
									command.Parameters.AddWithValue("DEDUCTCODE", line.DEDUCTCODE);
									command.Parameters.AddWithValue("UPDTHISLINE", line.UPDTHISLINE);
									command.Parameters.AddWithValue("VATEXCEPTCODE", line.VATEXCEPTCODE);
									command.Parameters.AddWithValue("PORDERFICHENO", line.PORDERFICHENO);
									command.Parameters.AddWithValue("QPRODFCREF", line.QPRODFCREF);
									command.Parameters.AddWithValue("RELTRANSFCREF", line.RELTRANSFCREF);
									command.Parameters.AddWithValue("ATAXEXCEPTREASON", line.ATAXEXCEPTREASON);
									command.Parameters.AddWithValue("ATAXEXCEPTCODE", line.ATAXEXCEPTCODE);
									command.Parameters.AddWithValue("PRODORDERTYP", line.PRODORDERTYP);
									command.Parameters.AddWithValue("SUBCONTORDERREF", line.SUBCONTORDERREF);
									command.Parameters.AddWithValue("QPRODFCTYP", line.QPRODFCTYP);
									command.Parameters.AddWithValue("PRDORDSLPLNRESERVE", line.PRDORDSLPLNRESERVE);

									if (line.INFDATE == null)
										command.Parameters.AddWithValue("INFDATE", DBNull.Value);
									else
										command.Parameters.AddWithValue("INFDATE", line.INFDATE);

									command.Parameters.AddWithValue("DESTSTATUS", line.DESTSTATUS);
									command.Parameters.AddWithValue("REGTYPREF", line.REGTYPREF);
									command.Parameters.AddWithValue("FAPROFITACCREF", line.FAPROFITACCREF);
									command.Parameters.AddWithValue("FAPROFITCENTREF", line.FAPROFITCENTREF);
									command.Parameters.AddWithValue("FALOSSACCREF", line.FALOSSACCREF);
									command.Parameters.AddWithValue("FALOSSCENTREF", line.FALOSSCENTREF);
									command.Parameters.AddWithValue("FUTMONTHCNT", line.FUTMONTHCNT);
									command.Parameters.AddWithValue("FUTMONTHBEGDATE", line.FUTMONTHBEGDATE);
									command.Parameters.AddWithValue("GTIPCODE", line.GTIPCODE);
									command.Parameters.AddWithValue("CPACODE", line.CPACODE);
									command.Parameters.AddWithValue("QPRODITEMTYPE", line.QPRODITEMTYPE);
									command.Parameters.AddWithValue("PUBLICCOUNTRYREF", line.PUBLICCOUNTRYREF);
									var id = await command.ExecuteScalarAsync();
									await connection.CloseAsync();
								}
							}
							catch (Exception e)
							{
								Debug.WriteLine(e.Message);
								throw;
							}
						}


						if (line.SERILOTTRANSACTIONS != null)
						{
							foreach (var serilot in line.SERILOTTRANSACTIONS)
							{
								string seriLotQuery = $@"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_SLTRANS(
            STFICHEREF
           ,DATE_
           ,STTRANSREF
           ,INTRANSREF
           ,INSLTRANSREF
           ,INSLAMOUNT
           ,LINENR
           ,ITEMREF
           ,IOCODE
           ,INVENNO
           ,FICHETYPE
           ,SLTYPE
           ,SLREF
           ,LOCREF
           ,MAINAMOUNT
           ,UOMREF
           ,AMOUNT
           ,REMAMOUNT
           ,REMLNUNITAMNT
           ,UINFO1
           ,UINFO2
           ,UINFO3
           ,UINFO4
           ,UINFO5
           ,UINFO6
           ,UINFO7
           ,UINFO8
           ,RATESCORE
           ,CANCELLED
           ,OUTCOST
           ,OUTCOSTCURR
           ,DIFFPRCOST
           ,DIFFPRCOSTCURR
           ,SERIQCOK
           ,LPRODSTAT
           ,SOURCETYPE
           ,SOURCEWSREF
           ,SITEID
           ,RECSTATUS
           ,ORGLOGICREF
           ,WFSTATUS
           ,DISTORDREF
           ,DISTORDLNREF
           ,INDORDSLTRNREF
           ,GROSSUINFO1
           ,GROSSUINFO2
           ,ATAXPRCOST
           ,ATAXPRCOSTCURR
           ,INFIDX
           ,ORGLOGOID
           ,LINEEXP
           ,EXIMFCTYPE
           ,EXIMFILEREF
           ,EXIMPROCNR
           ,MAINSLLNREF
           ,MADEOFSHRED
           ,STATUS
           ,VARIANTREF
           ,GRPBEGCODE
           ,GRPENDCODE
           ,OUTCOSTUFRS
           ,OUTCOSTCURRUFRS
           ,DIFFPRCOSTUFRS
           ,DIFFPRCOSTCURRUFRS
           ,INFIDXUFRS
           ,ADJPRCOSTUFRS
           ,ADJPRCOSTCURRUFRS
           ,GUID
           ,PRDORDREF
           ,PRDORDSLPLNRESERVE
           ,INPLNSLTRANSREF
           ,NOTSHIPPED
            ,EXPDATE)  
         VALUES(
            @STFICHEREF
           ,@DATE_
           ,@STTRANSREF
           ,@INTRANSREF
           ,@INSLTRANSREF
           ,@INSLAMOUNT
           ,@LINENR
           ,@ITEMREF
           ,@IOCODE
           ,@INVENNO
           ,@FICHETYPE
           ,@SLTYPE
           ,@SLREF
           ,@LOCREF
           ,@MAINAMOUNT
           ,@UOMREF
           ,@AMOUNT
           ,@REMAMOUNT
           ,@REMLNUNITAMNT
           ,@UINFO1
           ,@UINFO2
           ,@UINFO3
           ,@UINFO4
           ,@UINFO5
           ,@UINFO6
           ,@UINFO7
           ,@UINFO8
           ,@RATESCORE
           ,@CANCELLED
           ,@OUTCOST
           ,@OUTCOSTCURR
           ,@DIFFPRCOST
           ,@DIFFPRCOSTCURR
           ,@SERIQCOK
           ,@LPRODSTAT
           ,@SOURCETYPE
           ,@SOURCEWSREF
           ,@SITEID
           ,@RECSTATUS
           ,@ORGLOGICREF
           ,@WFSTATUS
           ,@DISTORDREF
           ,@DISTORDLNREF
           ,@INDORDSLTRNREF
           ,@GROSSUINFO1
           ,@GROSSUINFO2
           ,@ATAXPRCOST
           ,@ATAXPRCOSTCURR
           ,@INFIDX
           ,@ORGLOGOID
           ,@LINEEXP
           ,@EXIMFCTYPE
           ,@EXIMFILEREF
           ,@EXIMPROCNR
           ,@MAINSLLNREF
           ,@MADEOFSHRED
           ,@STATUS
           ,@VARIANTREF
           ,@GRPBEGCODE
           ,@GRPENDCODE
           ,@OUTCOSTUFRS
           ,@OUTCOSTCURRUFRS
           ,@DIFFPRCOSTUFRS
           ,@DIFFPRCOSTCURRUFRS
           ,@INFIDXUFRS
           ,@ADJPRCOSTUFRS
           ,@ADJPRCOSTCURRUFRS
           ,@GUID
           ,@PRDORDREF
           ,@PRDORDSLPLNRESERVE
           ,@INPLNSLTRANSREF
           ,@NOTSHIPPED
           ,@EXPDATE
         	); SELECT SCOPE_IDENTITY();";

								await using (SqlConnection connection = new SqlConnection(_connectionString))
								{
									await connection.OpenAsync();
									await using (SqlCommand command = new SqlCommand(seriLotQuery, connection))
									{
										command.Parameters.AddWithValue("STFICHEREF", ReferenceId);
										command.Parameters.AddWithValue("STTRANSREF", serilot.STTRANSREF);
										command.Parameters.AddWithValue("INTRANSREF", serilot.INTRANSREF);
										command.Parameters.AddWithValue("INSLTRANSREF", serilot.INSLTRANSREF);
										command.Parameters.AddWithValue("INSLAMOUNT", serilot.INSLAMOUNT);
										command.Parameters.AddWithValue("LINENR", serilot.LINENR);
										//command.Parameters.AddWithValue("serilotREF", serilot.serilotREF);
										command.Parameters.AddWithValue("DATE_", serilot.DATE_);
										command.Parameters.AddWithValue("IOCODE", 4);
										command.Parameters.AddWithValue("INVENNO", serilot.INVENNO);
										command.Parameters.AddWithValue("FICHETYPE", serilot.FICHETYPE);
										command.Parameters.AddWithValue("SLTYPE", serilot.SLTYPE);
										command.Parameters.AddWithValue("SLREF", serilot.SLREF);
										command.Parameters.AddWithValue("LOCREF", serilot.LOCREF);
										command.Parameters.AddWithValue("MAINAMOUNT", serilot.MAINAMOUNT);
										command.Parameters.AddWithValue("UOMREF", serilot.UOMREF);
										command.Parameters.AddWithValue("AMOUNT", serilot.AMOUNT);
										command.Parameters.AddWithValue("REMAMOUNT", serilot.REMAMOUNT);
										command.Parameters.AddWithValue("REMLNUNITAMNT", serilot.REMLNUNITAMNT);
										command.Parameters.AddWithValue("UINFO1", serilot.UINFO1);
										command.Parameters.AddWithValue("UINFO2", serilot.UINFO2);
										command.Parameters.AddWithValue("UINFO3", serilot.UINFO3);
										command.Parameters.AddWithValue("UINFO4", serilot.UINFO4);
										command.Parameters.AddWithValue("UINFO5", serilot.UINFO5);
										command.Parameters.AddWithValue("UINFO6", serilot.UINFO6);
										command.Parameters.AddWithValue("UINFO7", serilot.UINFO7);
										command.Parameters.AddWithValue("UINFO8", serilot.UINFO8);
										command.Parameters.AddWithValue("EXPDATE", serilot.EXPDATE);
										command.Parameters.AddWithValue("RATESCORE", serilot.RATESCORE);
										command.Parameters.AddWithValue("CANCELLED", serilot.CANCELLED);
										command.Parameters.AddWithValue("OUTCOST", serilot.OUTCOST);
										command.Parameters.AddWithValue("OUTCOSTCURR", serilot.OUTCOSTCURR);
										command.Parameters.AddWithValue("DIFFPRCOST", serilot.DIFFPRCOST);
										command.Parameters.AddWithValue("DIFFPRCOSTCURR", serilot.DIFFPRCOSTCURR);
										command.Parameters.AddWithValue("SERIQCOK", serilot.SERIQCOK);
										command.Parameters.AddWithValue("LPRODSTAT", serilot.LPRODSTAT);
										command.Parameters.AddWithValue("SOURCETYPE", serilot.SOURCETYPE);
										command.Parameters.AddWithValue("SOURCEWSREF", serilot.SOURCEWSREF);
										command.Parameters.AddWithValue("SITEID", serilot.SITEID);
										command.Parameters.AddWithValue("RECSTATUS", serilot.RECSTATUS);
										command.Parameters.AddWithValue("ORGLOGICREF", serilot.ORGLOGICREF);
										command.Parameters.AddWithValue("WFSTATUS", serilot.WFSTATUS);
										command.Parameters.AddWithValue("DISTORDREF", serilot.DISTORDREF);
										command.Parameters.AddWithValue("DISTORDLNREF", serilot.DISTORDLNREF);
										command.Parameters.AddWithValue("INDORDSLTRNREF", serilot.INDORDSLTRNREF);
										command.Parameters.AddWithValue("GROSSUINFO1", serilot.GROSSUINFO1);
										command.Parameters.AddWithValue("GROSSUINFO2", serilot.GROSSUINFO2);
										command.Parameters.AddWithValue("ATAXPRCOST", serilot.ATAXPRCOST);
										command.Parameters.AddWithValue("ATAXPRCOSTCURR", serilot.ATAXPRCOSTCURR);
										command.Parameters.AddWithValue("INFIDX", serilot.INFIDX);
										command.Parameters.AddWithValue("ORGLOGOID", serilot.ORGLOGOID);
										command.Parameters.AddWithValue("LINEEXP", serilot.LINEEXP);
										command.Parameters.AddWithValue("EXIMFCTYPE", serilot.EXIMFCTYPE);
										command.Parameters.AddWithValue("EXIMFILEREF", serilot.EXIMFILEREF);
										command.Parameters.AddWithValue("EXIMPROCNR", serilot.EXIMPROCNR);
										command.Parameters.AddWithValue("MAINSLLNREF", serilot.MAINSLLNREF);
										command.Parameters.AddWithValue("MADEOFSHRED", serilot.MADEOFSHRED);
										command.Parameters.AddWithValue("STATUS", serilot.STATUS);
										command.Parameters.AddWithValue("VARIANTREF", serilot.VARIANTREF);
										command.Parameters.AddWithValue("GRPBEGCODE", serilot.GRPBEGCODE);
										command.Parameters.AddWithValue("GRPENDCODE", serilot.GRPENDCODE);
										command.Parameters.AddWithValue("OUTCOSTUFRS", serilot.OUTCOSTUFRS);
										command.Parameters.AddWithValue("OUTCOSTCURRUFRS", serilot.OUTCOSTCURRUFRS);
										command.Parameters.AddWithValue("DIFFPRCOSTUFRS", serilot.DIFFPRCOSTUFRS);
										command.Parameters.AddWithValue("DIFFPRCOSTCURRUFRS", serilot.DIFFPRCOSTCURRUFRS);
										command.Parameters.AddWithValue("INFIDXUFRS", serilot.INFIDXUFRS);
										command.Parameters.AddWithValue("ADJPRCOSTUFRS", serilot.ADJPRCOSTUFRS);
										command.Parameters.AddWithValue("ADJPRCOSTCURRUFRS", serilot.ADJPRCOSTCURRUFRS);
										command.Parameters.AddWithValue("GUID", serilot.GUID);
										command.Parameters.AddWithValue("PRDORDREF", serilot.PRDORDREF);
										command.Parameters.AddWithValue("PRDORDSLPLNRESERVE", serilot.PRDORDSLPLNRESERVE);
										command.Parameters.AddWithValue("INPLNSLTRANSREF", serilot.INPLNSLTRANSREF);
										command.Parameters.AddWithValue("NOTSHIPPED", serilot.NOTSHIPPED);

										var id = await command.ExecuteScalarAsync();
										await connection.CloseAsync();
										ReferenceId = Convert.ToInt32(id);
									}
								}
							}


						}
					}
					#endregion
					#region InCounting Line Insert
					foreach (LG_STLINE line in item.TRANSACTIONS)
					{
						string lineQuery = $@"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_STLINE(
            STOCKREF
           ,LINETYPE
           ,PREVLINEREF
           ,PREVLINENO
           ,DETLINE
           ,TRCODE
           ,DATE_
           ,FTIME
           ,GLOBTRANS
           ,CALCTYPE
           ,PRODORDERREF
           ,SOURCETYPE
           ,SOURCEINDEX
           ,SOURCECOSTGRP
           ,SOURCEWSREF
           ,SOURCEPOLNREF
           ,DESTTYPE
           ,DESTINDEX
           ,DESTCOSTGRP
           ,DESTWSREF
           ,DESTPOLNREF
           ,FACTORYNR
           ,IOCODE
           ,STFICHEREF
           ,STFICHELNNO
           ,INVOICEREF
           ,INVOICELNNO
           ,CLIENTREF
           ,ORDTRANSREF
           ,ORDFICHEREF
           ,CENTERREF
           ,ACCOUNTREF
           ,VATACCREF
           ,VATCENTERREF
           ,PRACCREF
           ,PRCENTERREF
           ,PRVATACCREF
           ,PRVATCENREF
           ,PROMREF
           ,PAYDEFREF
           ,SPECODE
           ,DELVRYCODE
           ,AMOUNT
           ,PRICE
           ,TOTAL
           ,PRCURR
           ,PRPRICE
           ,TRCURR
           ,TRRATE
           ,REPORTRATE
           ,DISTCOST
           ,DISTDISC
           ,DISTEXP
           ,DISTPROM
           ,DISCPER
           ,LINEEXP
           ,UOMREF
           ,USREF
           ,UINFO1
           ,UINFO2
           ,UINFO3
           ,UINFO4
           ,UINFO5
           ,UINFO6
           ,UINFO7
           ,UINFO8
           ,PLNAMOUNT
           ,VATINC
           ,VAT
           ,VATAMNT
           ,VATMATRAH
           ,BILLEDITEM
           ,BILLED
           ,CPSTFLAG
           ,RETCOSTTYPE
           ,SOURCELINK
           ,RETCOST
           ,RETCOSTCURR
           ,OUTCOST
           ,OUTCOSTCURR
           ,RETAMOUNT
           ,FAREGREF
           ,FAATTRIB
           ,CANCELLED
           ,LINENET
           ,DISTADDEXP
           ,FADACCREF
           ,FADCENTERREF
           ,FARACCREF
           ,FARCENTERREF
           ,DIFFPRICE
           ,DIFFPRCOST
           ,DECPRDIFF
           ,LPRODSTAT
           ,PRDEXPTOTAL
           ,DIFFREPPRICE
           ,DIFFPRCRCOST
           ,SALESMANREF
           ,FAPLACCREF
           ,FAPLCENTERREF
           ,OUTPUTIDCODE
           ,DREF
           ,COSTRATE
           ,XPRICEUPD
           ,XPRICE
           ,XREPRATE
           ,DISTCOEF
           ,TRANSQCOK
           ,SITEID
           ,RECSTATUS
           ,ORGLOGICREF
           ,WFSTATUS
           ,POLINEREF
           ,PLNSTTRANSREF
           ,NETDISCFLAG
           ,NETDISCPERC
           ,NETDISCAMNT
           ,VATCALCDIFF
           ,CONDITIONREF
           ,DISTORDERREF
           ,DISTORDLINEREF
           ,CAMPAIGNREFS1
           ,CAMPAIGNREFS2
           ,CAMPAIGNREFS3
           ,CAMPAIGNREFS4
           ,CAMPAIGNREFS5
           ,POINTCAMPREF
           ,CAMPPOINT
           ,PROMCLASITEMREF
           ,CMPGLINEREF
           ,PLNSTTRANSPERNR
           ,PORDCLSPLNAMNT
           ,VENDCOMM
           ,PREVIOUSOUTCOST
           ,COSTOFSALEACCREF
           ,PURCHACCREF
           ,COSTOFSALECNTREF
           ,PURCHCENTREF
           ,PREVOUTCOSTCURR
           ,ABVATAMOUNT
           ,ABVATSTATUS
           ,PRRATE
           ,ADDTAXRATE
           ,ADDTAXCONVFACT
           ,ADDTAXAMOUNT
           ,ADDTAXPRCOST
           ,ADDTAXRETCOST
           ,ADDTAXRETCOSTCURR
           ,GROSSUINFO1
           ,GROSSUINFO2
           ,ADDTAXPRCOSTCURR
           ,ADDTAXACCREF
           ,ADDTAXCENTERREF
           ,ADDTAXAMNTISUPD
           ,INFIDX
           ,ADDTAXCOSACCREF
           ,ADDTAXCOSCNTREF
           ,PREVIOUSATAXPRCOST
           ,PREVATAXPRCOSTCURR
           ,PRDORDTOTCOEF
           ,DEMPEGGEDAMNT
           ,STDUNITCOST
           ,STDRPUNITCOST
           ,COSTDIFFACCREF
           ,COSTDIFFCENREF
           ,TEXTINC
           ,ADDTAXDISCAMOUNT
           ,ORGLOGOID
           ,EXIMFICHENO
           ,EXIMFCTYPE
           ,TRANSEXPLINE
           ,INSEXPLINE
           ,EXIMWHFCREF
           ,EXIMWHLNREF
           ,EXIMFILEREF
           ,EXIMPROCNR
           ,EISRVDSTTYP
           ,MAINSTLNREF
           ,MADEOFSHRED
           ,FROMORDWITHPAY
           ,PROJECTREF
           ,STATUS
           ,DORESERVE
           ,POINTCAMPREFS1
           ,POINTCAMPREFS2
           ,POINTCAMPREFS3
           ,POINTCAMPREFS4
           ,CAMPPOINTS1
           ,CAMPPOINTS2
           ,CAMPPOINTS3
           ,CAMPPOINTS4
           ,CMPGLINEREFS1
           ,CMPGLINEREFS2
           ,CMPGLINEREFS3
           ,CMPGLINEREFS4
           ,PRCLISTREF
           ,PORDSYMOUTLN
           ,MONTH_
           ,YEAR_
           ,EXADDTAXRATE
           ,EXADDTAXCONVF
           ,EXADDTAXAREF
           ,EXADDTAXCREF
           ,OTHRADDTAXAREF
           ,OTHRADDTAXCREF
           ,EXADDTAXAMNT
           ,AFFECTCOLLATRL
           ,ALTPROMFLAG
           ,EIDISTFLNNR
           ,EXIMTYPE
           ,VARIANTREF
           ,CANDEDUCT
           ,OUTREMAMNT
           ,OUTREMCOST
           ,OUTREMCOSTCURR
           ,REFLVATACCREF
           ,REFLVATOTHACCREF
           ,PARENTLNREF
           ,AFFECTRISK
           ,INEFFECTIVECOST
           ,ADDTAXVATMATRAH
           ,REFLACCREF
           ,REFLOTHACCREF
           ,CAMPPAYDEFREF
           ,FAREGBINDDATE
           ,RELTRANSLNREF
           ,FROMTRANSFER
           ,COSTDISTPRICE
           ,COSTDISTREPPRICE
           ,DIFFPRICEUFRS
           ,DIFFREPPRICEUFRS
           ,OUTCOSTUFRS
           ,OUTCOSTCURRUFRS
           ,DIFFPRCOSTUFRS
           ,DIFFPRCRCOSTUFRS
           ,RETCOSTUFRS
           ,RETCOSTCURRUFRS
           ,OUTREMCOSTUFRS
           ,OUTREMCOSTCURRUFRS
           ,INFIDXUFRS
           ,ADJPRICEUFRS
           ,ADJREPPRICEUFRS
           ,ADJPRCOSTUFRS
           ,ADJPRCRCOSTUFRS
           ,COSTDISTPRICEUFRS
           ,COSTDISTREPPRICEUFRS
           ,PURCHACCREFUFRS
           ,PURCHCENTREFUFRS
           ,COSACCREFUFRS
           ,COSCNTREFUFRS
           ,PROUTCOSTUFRSDIFF
           ,PROUTCOSTCRUFRSDIFF
           ,UNDERDEDUCTLIMIT
           ,GLOBALID
           ,DEDUCTIONPART1
           ,DEDUCTIONPART2
           ,GUID
           ,SPECODE2
           ,OFFERREF
           ,OFFTRANSREF
           ,VATEXCEPTREASON
           ,PLNDEFSERILOTNO
           ,PLNUNRSRVAMOUNT
           ,PORDCLSPLNUNRSRVAMNT
           ,LPRODRSRVSTAT
           ,FALINKTYPE
           ,DEDUCTCODE
           ,UPDTHISLINE
           ,VATEXCEPTCODE
           ,PORDERFICHENO
           ,QPRODFCREF
           ,RELTRANSFCREF
           ,ATAXEXCEPTREASON
           ,ATAXEXCEPTCODE
           ,PRODORDERTYP
           ,SUBCONTORDERREF
           ,QPRODFCTYP
           ,PRDORDSLPLNRESERVE
           ,INFDATE
           ,DESTSTATUS
           ,REGTYPREF
           ,FAPROFITACCREF
           ,FAPROFITCENTREF
           ,FALOSSACCREF
           ,FALOSSCENTREF
           ,CPACODE
           ,GTIPCODE
           ,PUBLICCOUNTRYREF
           ,QPRODITEMTYPE
           ,FUTMONTHCNT
           ,FUTMONTHBEGDATE

          
          
             )
            VALUES (
            @STOCKREF
           ,@LINETYPE
           ,@PREVLINEREF
           ,@PREVLINENO
           ,@DETLINE
           ,@TRCODE
           ,@DATE_
           ,(SELECT [dbo].[LG_TIMETOINT](@FHOUR,@FMINUTE,@FSECOND))
           ,@GLOBTRANS
           ,@CALCTYPE
           ,@PRODORDERREF
           ,@SOURCETYPE
           ,@SOURCEINDEX
           ,@SOURCECOSTGRP
           ,@SOURCEWSREF
           ,@SOURCEPOLNREF
           ,@DESTTYPE
           ,@DESTINDEX
           ,@DESTCOSTGRP
           ,@DESTWSREF
           ,@DESTPOLNREF
           ,@FACTORYNR
           ,@IOCODE
           ,@STFICHEREF
           ,@STFICHELNNO
           ,@INVOICEREF
           ,@INVOICELNNO
           ,@CLIENTREF
           ,@ORDTRANSREF
           ,@ORDFICHEREF
           ,@CENTERREF
           ,@ACCOUNTREF
           ,@VATACCREF
           ,@VATCENTERREF
           ,@PRACCREF
           ,@PRCENTERREF
           ,@PRVATACCREF
           ,@PRVATCENREF
           ,@PROMREF
           ,@PAYDEFREF
           ,@SPECODE
           ,@DELVRYCODE
           ,@AMOUNT
           ,@PRICE
           ,@TOTAL
           ,@PRCURR
           ,@PRPRICE
           ,@TRCURR
           ,@TRRATE
           ,@REPORTRATE
           ,@DISTCOST
           ,@DISTDISC
           ,@DISTEXP
           ,@DISTPROM
           ,@DISCPER
           ,@LINEEXP
           ,@UOMREF
           ,@USREF
           ,@UINFO1
           ,@UINFO2
           ,@UINFO3
           ,@UINFO4
           ,@UINFO5
           ,@UINFO6
           ,@UINFO7
           ,@UINFO8
           ,@PLNAMOUNT
           ,@VATINC
           ,@VAT
           ,@VATAMNT
           ,@VATMATRAH
           ,@BILLEDITEM
           ,@BILLED
           ,@CPSTFLAG
           ,@RETCOSTTYPE
           ,@SOURCELINK
           ,@RETCOST
           ,@RETCOSTCURR
           ,@OUTCOST
           ,@OUTCOSTCURR
           ,@RETAMOUNT
           ,@FAREGREF
           ,@FAATTRIB
           ,@CANCELLED
           ,@LINENET
           ,@DISTADDEXP
           ,@FADACCREF
           ,@FADCENTERREF
           ,@FARACCREF
           ,@FARCENTERREF
           ,@DIFFPRICE
           ,@DIFFPRCOST
           ,@DECPRDIFF
           ,@LPRODSTAT
           ,@PRDEXPTOTAL
           ,@DIFFREPPRICE
           ,@DIFFPRCRCOST
           ,@SALESMANREF
           ,@FAPLACCREF
           ,@FAPLCENTERREF
           ,@OUTPUTIDCODE
           ,@DREF
           ,@COSTRATE
           ,@XPRICEUPD
           ,@XPRICE
           ,@XREPRATE
           ,@DISTCOEF
           ,@TRANSQCOK
           ,@SITEID
           ,@RECSTATUS
           ,@ORGLOGICREF
           ,@WFSTATUS
           ,@POLINEREF
           ,@PLNSTTRANSREF
           ,@NETDISCFLAG
           ,@NETDISCPERC
           ,@NETDISCAMNT
           ,@VATCALCDIFF
           ,@CONDITIONREF
           ,@DISTORDERREF
           ,@DISTORDLINEREF
           ,@CAMPAIGNREFS1
           ,@CAMPAIGNREFS2
           ,@CAMPAIGNREFS3
           ,@CAMPAIGNREFS4
           ,@CAMPAIGNREFS5
           ,@POINTCAMPREF
           ,@CAMPPOINT
           ,@PROMCLASITEMREF
           ,@CMPGLINEREF
           ,@PLNSTTRANSPERNR
           ,@PORDCLSPLNAMNT
           ,@VENDCOMM
           ,@PREVIOUSOUTCOST
           ,@COSTOFSALEACCREF
           ,@PURCHACCREF
           ,@COSTOFSALECNTREF
           ,@PURCHCENTREF
           ,@PREVOUTCOSTCURR
           ,@ABVATAMOUNT
           ,@ABVATSTATUS
           ,@PRRATE
           ,@ADDTAXRATE
           ,@ADDTAXCONVFACT
           ,@ADDTAXAMOUNT
           ,@ADDTAXPRCOST
           ,@ADDTAXRETCOST
           ,@ADDTAXRETCOSTCURR
           ,@GROSSUINFO1
           ,@GROSSUINFO2
           ,@ADDTAXPRCOSTCURR
           ,@ADDTAXACCREF
           ,@ADDTAXCENTERREF
           ,@ADDTAXAMNTISUPD
           ,@INFIDX
           ,@ADDTAXCOSACCREF
           ,@ADDTAXCOSCNTREF
           ,@PREVIOUSATAXPRCOST
           ,@PREVATAXPRCOSTCURR
           ,@PRDORDTOTCOEF
           ,@DEMPEGGEDAMNT
           ,@STDUNITCOST
           ,@STDRPUNITCOST
           ,@COSTDIFFACCREF
           ,@COSTDIFFCENREF
           ,@TEXTINC
           ,@ADDTAXDISCAMOUNT
           ,@ORGLOGOID
           ,@EXIMFICHENO
           ,@EXIMFCTYPE
           ,@TRANSEXPLINE
           ,@INSEXPLINE
           ,@EXIMWHFCREF
           ,@EXIMWHLNREF
           ,@EXIMFILEREF
           ,@EXIMPROCNR
           ,@EISRVDSTTYP
           ,@MAINSTLNREF
           ,@MADEOFSHRED
           ,@FROMORDWITHPAY
           ,@PROJECTREF
           ,@STATUS
           ,@DORESERVE
           ,@POINTCAMPREFS1
           ,@POINTCAMPREFS2
           ,@POINTCAMPREFS3
           ,@POINTCAMPREFS4
           ,@CAMPPOINTS1
           ,@CAMPPOINTS2
           ,@CAMPPOINTS3
           ,@CAMPPOINTS4
           ,@CMPGLINEREFS1
           ,@CMPGLINEREFS2
           ,@CMPGLINEREFS3
           ,@CMPGLINEREFS4
           ,@PRCLISTREF
           ,@PORDSYMOUTLN
           ,@MONTH_
           ,@YEAR_
           ,@EXADDTAXRATE
           ,@EXADDTAXCONVF
           ,@EXADDTAXAREF
           ,@EXADDTAXCREF
           ,@OTHRADDTAXAREF
           ,@OTHRADDTAXCREF
           ,@EXADDTAXAMNT
           ,@AFFECTCOLLATRL
           ,@ALTPROMFLAG
           ,@EIDISTFLNNR
           ,@EXIMTYPE
           ,@VARIANTREF
           ,@CANDEDUCT
           ,@OUTREMAMNT
           ,@OUTREMCOST
           ,@OUTREMCOSTCURR
           ,@REFLVATACCREF
           ,@REFLVATOTHACCREF
           ,@PARENTLNREF
           ,@AFFECTRISK
           ,@INEFFECTIVECOST
           ,@ADDTAXVATMATRAH
           ,@REFLACCREF
           ,@REFLOTHACCREF
           ,@CAMPPAYDEFREF
           ,@FAREGBINDDATE
           ,@RELTRANSLNREF
           ,@FROMTRANSFER
           ,@COSTDISTPRICE
           ,@COSTDISTREPPRICE
           ,@DIFFPRICEUFRS
           ,@DIFFREPPRICEUFRS
           ,@OUTCOSTUFRS
           ,@OUTCOSTCURRUFRS
           ,@DIFFPRCOSTUFRS
           ,@DIFFPRCRCOSTUFRS
           ,@RETCOSTUFRS
           ,@RETCOSTCURRUFRS
           ,@OUTREMCOSTUFRS
           ,@OUTREMCOSTCURRUFRS
           ,@INFIDXUFRS
           ,@ADJPRICEUFRS
           ,@ADJREPPRICEUFRS
           ,@ADJPRCOSTUFRS
           ,@ADJPRCRCOSTUFRS
           ,@COSTDISTPRICEUFRS
           ,@COSTDISTREPPRICEUFRS
           ,@PURCHACCREFUFRS
           ,@PURCHCENTREFUFRS
           ,@COSACCREFUFRS
           ,@COSCNTREFUFRS
           ,@PROUTCOSTUFRSDIFF
           ,@PROUTCOSTCRUFRSDIFF
           ,@UNDERDEDUCTLIMIT
           ,@GLOBALID
           ,@DEDUCTIONPART1
           ,@DEDUCTIONPART2
           ,@GUID
           ,@SPECODE2
           ,@OFFERREF
           ,@OFFTRANSREF
           ,@VATEXCEPTREASON
           ,@PLNDEFSERILOTNO
           ,@PLNUNRSRVAMOUNT
           ,@PORDCLSPLNUNRSRVAMNT
           ,@LPRODRSRVSTAT
           ,@FALINKTYPE
           ,@DEDUCTCODE
           ,@UPDTHISLINE
           ,@VATEXCEPTCODE
           ,@PORDERFICHENO
           ,@QPRODFCREF
           ,@RELTRANSFCREF
           ,@ATAXEXCEPTREASON
           ,@ATAXEXCEPTCODE
           ,@PRODORDERTYP
           ,@SUBCONTORDERREF
           ,@QPRODFCTYP
           ,@PRDORDSLPLNRESERVE
           ,@INFDATE
           ,@DESTSTATUS
           ,@REGTYPREF
           ,@FAPROFITACCREF
           ,@FAPROFITCENTREF
           ,@FALOSSACCREF
           ,@FALOSSCENTREF
           ,@CPACODE
           ,@GTIPCODE
           ,@PUBLICCOUNTRYREF
           ,@QPRODITEMTYPE
           ,@FUTMONTHCNT
           ,@FUTMONTHBEGDATE
           
           
           ); SELECT SCOPE_IDENTITY();";
						await using (SqlConnection connection = new SqlConnection(_connectionString))
						{
							await connection.OpenAsync();

							try
							{
								await using (SqlCommand command = new SqlCommand(lineQuery, connection))
								{
									command.Parameters.AddWithValue("STOCKREF", line.STOCKREF);
									command.Parameters.AddWithValue("LINETYPE", line.LINETYPE);
									command.Parameters.AddWithValue("PREVLINEREF", line.PREVLINEREF);
									command.Parameters.AddWithValue("PREVLINENO", line.PREVLINENO);
									command.Parameters.AddWithValue("DETLINE", line.DETLINE);
									command.Parameters.AddWithValue("TRCODE", 50);
									command.Parameters.AddWithValue("DATE_", line.DATE_);
									command.Parameters.AddWithValue("FHOUR", item.DATE_.Hour);
									command.Parameters.AddWithValue("FMINUTE", item.DATE_.Minute);
									command.Parameters.AddWithValue("FSECOND", item.DATE_.Second);
									command.Parameters.AddWithValue("GLOBTRANS", line.GLOBTRANS);
									command.Parameters.AddWithValue("CALCTYPE", line.CALCTYPE);
									command.Parameters.AddWithValue("PRODORDERREF", line.PRODORDERREF);
									command.Parameters.AddWithValue("SOURCETYPE", line.SOURCETYPE);
									command.Parameters.AddWithValue("SOURCEINDEX", line.SOURCEINDEX);
									command.Parameters.AddWithValue("SOURCECOSTGRP", line.SOURCECOSTGRP);
									command.Parameters.AddWithValue("SOURCEWSREF", line.SOURCEWSREF);
									command.Parameters.AddWithValue("SOURCEPOLNREF", line.SOURCEPOLNREF);
									command.Parameters.AddWithValue("DESTTYPE", line.DESTTYPE);
									command.Parameters.AddWithValue("DESTINDEX", line.DESTINDEX);
									command.Parameters.AddWithValue("DESTCOSTGRP", line.DESTCOSTGRP);
									command.Parameters.AddWithValue("DESTWSREF", line.DESTWSREF);
									command.Parameters.AddWithValue("DESTPOLNREF", line.DESTPOLNREF);
									command.Parameters.AddWithValue("FACTORYNR", line.FACTORYNR);
									command.Parameters.AddWithValue("IOCODE", 1);
									command.Parameters.AddWithValue("STFICHEREF", ReferenceId);
									command.Parameters.AddWithValue("STFICHELNNO", line.STFICHELNNO);
									command.Parameters.AddWithValue("INVOICEREF", line.INVOICEREF);
									command.Parameters.AddWithValue("INVOICELNNO", line.INVOICELNNO);
									command.Parameters.AddWithValue("CLIENTREF", line.CLIENTREF);
									command.Parameters.AddWithValue("ORDTRANSREF", line.ORDTRANSREF);
									command.Parameters.AddWithValue("ORDFICHEREF", line.ORDFICHEREF);
									command.Parameters.AddWithValue("CENTERREF", line.CENTERREF);
									command.Parameters.AddWithValue("ACCOUNTREF", line.ACCOUNTREF);
									command.Parameters.AddWithValue("VATACCREF", line.VATACCREF);
									command.Parameters.AddWithValue("VATCENTERREF", line.VATCENTERREF);
									command.Parameters.AddWithValue("PRACCREF", line.PRACCREF);
									command.Parameters.AddWithValue("PRCENTERREF", line.PRCENTERREF);
									command.Parameters.AddWithValue("PRVATACCREF", line.PRVATACCREF);
									command.Parameters.AddWithValue("PRVATCENREF", line.PRVATCENREF);
									command.Parameters.AddWithValue("PROMREF", line.PROMREF);
									command.Parameters.AddWithValue("PAYDEFREF", line.PAYDEFREF);
									command.Parameters.AddWithValue("SPECODE", line.SPECODE);
									command.Parameters.AddWithValue("DELVRYCODE", line.DELVRYCODE);
									command.Parameters.AddWithValue("AMOUNT", line.AMOUNT);
									command.Parameters.AddWithValue("PRICE", line.PRICE);
									command.Parameters.AddWithValue("TOTAL", line.TOTAL);
									command.Parameters.AddWithValue("PRCURR", line.PRCURR);
									command.Parameters.AddWithValue("PRPRICE", line.PRPRICE);
									command.Parameters.AddWithValue("TRCURR", line.TRCURR);
									command.Parameters.AddWithValue("TRRATE", line.TRRATE);
									command.Parameters.AddWithValue("REPORTRATE", line.REPORTRATE);
									command.Parameters.AddWithValue("DISTCOST", line.DISTCOST);
									command.Parameters.AddWithValue("DISTDISC", line.DISTDISC);
									command.Parameters.AddWithValue("DISTEXP", line.DISTEXP);
									command.Parameters.AddWithValue("DISTPROM", line.DISTPROM);
									command.Parameters.AddWithValue("DISCPER", line.DISCPER);
									command.Parameters.AddWithValue("LINEEXP", line.LINEEXP);
									command.Parameters.AddWithValue("UOMREF", line.UOMREF);
									command.Parameters.AddWithValue("USREF", line.USREF);
									command.Parameters.AddWithValue("UINFO1", line.UINFO1);
									command.Parameters.AddWithValue("UINFO2", line.UINFO2);
									command.Parameters.AddWithValue("UINFO3", line.UINFO3);
									command.Parameters.AddWithValue("UINFO4", line.UINFO4);
									command.Parameters.AddWithValue("UINFO5", line.UINFO5);
									command.Parameters.AddWithValue("UINFO6", line.UINFO6);
									command.Parameters.AddWithValue("UINFO7", line.UINFO7);
									command.Parameters.AddWithValue("UINFO8", line.UINFO8);
									command.Parameters.AddWithValue("PLNAMOUNT", line.PLNAMOUNT);
									command.Parameters.AddWithValue("VATINC", line.VATINC);
									command.Parameters.AddWithValue("VAT", line.VAT);
									command.Parameters.AddWithValue("VATAMNT", line.VATAMNT);
									command.Parameters.AddWithValue("VATMATRAH", line.VATMATRAH);
									command.Parameters.AddWithValue("BILLEDITEM", line.BILLEDITEM);
									command.Parameters.AddWithValue("BILLED", line.BILLED);
									command.Parameters.AddWithValue("CPSTFLAG", line.CPSTFLAG);
									command.Parameters.AddWithValue("RETCOSTTYPE", line.RETCOSTTYPE);
									command.Parameters.AddWithValue("SOURCELINK", line.SOURCELINK);
									command.Parameters.AddWithValue("RETCOST", line.RETCOST);
									command.Parameters.AddWithValue("RETCOSTCURR", line.RETCOSTCURR);
									command.Parameters.AddWithValue("OUTCOST", line.OUTCOST);
									command.Parameters.AddWithValue("OUTCOSTCURR", line.OUTCOSTCURR);
									command.Parameters.AddWithValue("RETAMOUNT", line.RETAMOUNT);
									command.Parameters.AddWithValue("FAREGREF", line.FAREGREF);
									command.Parameters.AddWithValue("FAATTRIB", line.FAATTRIB);
									command.Parameters.AddWithValue("CANCELLED", line.CANCELLED);
									command.Parameters.AddWithValue("LINENET", line.LINENET);
									command.Parameters.AddWithValue("DISTADDEXP", line.DISTADDEXP);
									command.Parameters.AddWithValue("FADACCREF", line.FADACCREF);
									command.Parameters.AddWithValue("FADCENTERREF", line.FADCENTERREF);
									command.Parameters.AddWithValue("FARACCREF", line.FARACCREF);
									command.Parameters.AddWithValue("FARCENTERREF", line.FARCENTERREF);
									command.Parameters.AddWithValue("DIFFPRICE", line.DIFFPRICE);
									command.Parameters.AddWithValue("DIFFPRCOST", line.DIFFPRCOST);
									command.Parameters.AddWithValue("DECPRDIFF", line.DECPRDIFF);
									command.Parameters.AddWithValue("LPRODSTAT", line.LPRODSTAT);
									command.Parameters.AddWithValue("PRDEXPTOTAL", line.PRDEXPTOTAL);
									command.Parameters.AddWithValue("DIFFREPPRICE", line.DIFFREPPRICE);
									command.Parameters.AddWithValue("DIFFPRCRCOST", line.DIFFPRCRCOST);
									command.Parameters.AddWithValue("SALESMANREF", line.SALESMANREF);
									command.Parameters.AddWithValue("FAPLACCREF", line.FAPLACCREF);
									command.Parameters.AddWithValue("FAPLCENTERREF", line.FAPLCENTERREF);
									command.Parameters.AddWithValue("OUTPUTIDCODE", line.OUTPUTIDCODE);
									command.Parameters.AddWithValue("DREF", line.DREF);
									command.Parameters.AddWithValue("COSTRATE", line.COSTRATE);
									command.Parameters.AddWithValue("XPRICEUPD", line.XPRICEUPD);
									command.Parameters.AddWithValue("XPRICE", line.XPRICE);
									command.Parameters.AddWithValue("XREPRATE", line.XREPRATE);
									command.Parameters.AddWithValue("DISTCOEF", line.DISTCOEF);
									command.Parameters.AddWithValue("TRANSQCOK", line.TRANSQCOK);
									command.Parameters.AddWithValue("SITEID", line.SITEID);
									command.Parameters.AddWithValue("RECSTATUS", line.RECSTATUS);
									command.Parameters.AddWithValue("ORGLOGICREF", line.ORGLOGICREF);
									command.Parameters.AddWithValue("WFSTATUS", line.WFSTATUS);
									command.Parameters.AddWithValue("POLINEREF", line.POLINEREF);
									command.Parameters.AddWithValue("PLNSTTRANSREF", line.PLNSTTRANSREF);
									command.Parameters.AddWithValue("NETDISCFLAG", line.NETDISCFLAG);
									command.Parameters.AddWithValue("NETDISCPERC", line.NETDISCPERC);
									command.Parameters.AddWithValue("NETDISCAMNT", line.NETDISCAMNT);
									command.Parameters.AddWithValue("VATCALCDIFF", line.VATCALCDIFF);
									command.Parameters.AddWithValue("CONDITIONREF", line.CONDITIONREF);
									command.Parameters.AddWithValue("DISTORDERREF", line.DISTORDERREF);
									command.Parameters.AddWithValue("DISTORDLINEREF", line.DISTORDLINEREF);
									command.Parameters.AddWithValue("CAMPAIGNREFS1", line.CAMPAIGNREFS1);
									command.Parameters.AddWithValue("CAMPAIGNREFS2", line.CAMPAIGNREFS2);
									command.Parameters.AddWithValue("CAMPAIGNREFS3", line.CAMPAIGNREFS3);
									command.Parameters.AddWithValue("CAMPAIGNREFS4", line.CAMPAIGNREFS4);
									command.Parameters.AddWithValue("CAMPAIGNREFS5", line.CAMPAIGNREFS5);
									command.Parameters.AddWithValue("POINTCAMPREF", line.POINTCAMPREF);
									command.Parameters.AddWithValue("CAMPPOINT", line.CAMPPOINT);
									command.Parameters.AddWithValue("PROMCLASITEMREF", line.PROMCLASITEMREF);
									command.Parameters.AddWithValue("CMPGLINEREF", line.CMPGLINEREF);
									command.Parameters.AddWithValue("PLNSTTRANSPERNR", line.PLNSTTRANSPERNR);
									command.Parameters.AddWithValue("PORDCLSPLNAMNT", line.PORDCLSPLNAMNT);
									command.Parameters.AddWithValue("VENDCOMM", line.VENDCOMM);
									command.Parameters.AddWithValue("PREVIOUSOUTCOST", line.PREVIOUSOUTCOST);
									command.Parameters.AddWithValue("COSTOFSALEACCREF", line.COSTOFSALEACCREF);
									command.Parameters.AddWithValue("PURCHACCREF", line.PURCHACCREF);
									command.Parameters.AddWithValue("COSTOFSALECNTREF", line.COSTOFSALECNTREF);
									command.Parameters.AddWithValue("PURCHCENTREF", line.PURCHCENTREF);
									command.Parameters.AddWithValue("PREVOUTCOSTCURR", line.PREVOUTCOSTCURR);
									command.Parameters.AddWithValue("ABVATAMOUNT", line.ABVATAMOUNT);
									command.Parameters.AddWithValue("ABVATSTATUS", line.ABVATSTATUS);
									command.Parameters.AddWithValue("PRRATE", line.PRRATE);
									command.Parameters.AddWithValue("ADDTAXRATE", line.ADDTAXRATE);
									command.Parameters.AddWithValue("ADDTAXCONVFACT", line.ADDTAXCONVFACT);
									command.Parameters.AddWithValue("ADDTAXAMOUNT", line.ADDTAXAMOUNT);
									command.Parameters.AddWithValue("ADDTAXPRCOST", line.ADDTAXPRCOST);
									command.Parameters.AddWithValue("ADDTAXRETCOST", line.ADDTAXRETCOST);
									command.Parameters.AddWithValue("ADDTAXRETCOSTCURR", line.ADDTAXRETCOSTCURR);
									command.Parameters.AddWithValue("GROSSUINFO1", line.GROSSUINFO1);
									command.Parameters.AddWithValue("GROSSUINFO2", line.GROSSUINFO2);
									command.Parameters.AddWithValue("ADDTAXPRCOSTCURR", line.ADDTAXPRCOSTCURR);
									command.Parameters.AddWithValue("ADDTAXACCREF", line.ADDTAXACCREF);
									command.Parameters.AddWithValue("ADDTAXCENTERREF", line.ADDTAXCENTERREF);
									command.Parameters.AddWithValue("ADDTAXAMNTISUPD", line.ADDTAXAMNTISUPD);
									command.Parameters.AddWithValue("INFIDX", line.INFIDX);
									command.Parameters.AddWithValue("ADDTAXCOSACCREF", line.ADDTAXCOSACCREF);
									command.Parameters.AddWithValue("ADDTAXCOSCNTREF", line.ADDTAXCOSCNTREF);
									command.Parameters.AddWithValue("PREVIOUSATAXPRCOST", line.PREVIOUSATAXPRCOST);
									command.Parameters.AddWithValue("PREVATAXPRCOSTCURR", line.PREVATAXPRCOSTCURR);
									command.Parameters.AddWithValue("PRDORDTOTCOEF", line.PRDORDTOTCOEF);
									command.Parameters.AddWithValue("DEMPEGGEDAMNT", line.DEMPEGGEDAMNT);
									command.Parameters.AddWithValue("STDUNITCOST", line.STDUNITCOST);
									command.Parameters.AddWithValue("STDRPUNITCOST", line.STDRPUNITCOST);
									command.Parameters.AddWithValue("COSTDIFFACCREF", line.COSTDIFFACCREF);
									command.Parameters.AddWithValue("COSTDIFFCENREF", line.COSTDIFFCENREF);
									command.Parameters.AddWithValue("TEXTINC", line.TEXTINC);
									command.Parameters.AddWithValue("ADDTAXDISCAMOUNT", line.ADDTAXDISCAMOUNT);
									command.Parameters.AddWithValue("ORGLOGOID", line.ORGLOGOID);
									command.Parameters.AddWithValue("EXIMFICHENO", line.EXIMFICHENO);
									command.Parameters.AddWithValue("EXIMFCTYPE", line.EXIMFCTYPE);
									command.Parameters.AddWithValue("TRANSEXPLINE", line.TRANSEXPLINE);
									command.Parameters.AddWithValue("INSEXPLINE", line.INSEXPLINE);
									command.Parameters.AddWithValue("EXIMWHFCREF", line.EXIMWHFCREF);
									command.Parameters.AddWithValue("EXIMWHLNREF", line.EXIMWHLNREF);
									command.Parameters.AddWithValue("EXIMFILEREF", line.EXIMFILEREF);
									command.Parameters.AddWithValue("EXIMPROCNR", line.EXIMPROCNR);
									command.Parameters.AddWithValue("EISRVDSTTYP", line.EISRVDSTTYP);
									command.Parameters.AddWithValue("MAINSTLNREF", line.MAINSTLNREF);
									command.Parameters.AddWithValue("MADEOFSHRED", line.MADEOFSHRED);
									command.Parameters.AddWithValue("FROMORDWITHPAY", line.FROMORDWITHPAY);
									command.Parameters.AddWithValue("PROJECTREF", line.PROJECTREF);
									command.Parameters.AddWithValue("STATUS", line.STATUS);
									command.Parameters.AddWithValue("DORESERVE", line.DORESERVE);
									command.Parameters.AddWithValue("POINTCAMPREFS1", line.POINTCAMPREFS1);
									command.Parameters.AddWithValue("POINTCAMPREFS2", line.POINTCAMPREFS2);
									command.Parameters.AddWithValue("POINTCAMPREFS3", line.POINTCAMPREFS3);
									command.Parameters.AddWithValue("POINTCAMPREFS4", line.POINTCAMPREFS4);
									command.Parameters.AddWithValue("CAMPPOINTS1", line.CAMPPOINTS1);
									command.Parameters.AddWithValue("CAMPPOINTS2", line.CAMPPOINTS2);
									command.Parameters.AddWithValue("CAMPPOINTS3", line.CAMPPOINTS3);
									command.Parameters.AddWithValue("CAMPPOINTS4", line.CAMPPOINTS4);
									command.Parameters.AddWithValue("CMPGLINEREFS1", line.CMPGLINEREFS1);
									command.Parameters.AddWithValue("CMPGLINEREFS2", line.CMPGLINEREFS2);
									command.Parameters.AddWithValue("CMPGLINEREFS3", line.CMPGLINEREFS3);
									command.Parameters.AddWithValue("CMPGLINEREFS4", line.CMPGLINEREFS4);
									command.Parameters.AddWithValue("PRCLISTREF", line.PRCLISTREF);
									command.Parameters.AddWithValue("PORDSYMOUTLN", line.PORDSYMOUTLN);
									command.Parameters.AddWithValue("MONTH_", line.MONTH_);
									command.Parameters.AddWithValue("YEAR_", line.YEAR_);
									command.Parameters.AddWithValue("EXADDTAXRATE", line.EXADDTAXRATE);
									command.Parameters.AddWithValue("EXADDTAXCONVF", line.EXADDTAXCONVF);
									command.Parameters.AddWithValue("EXADDTAXAREF", line.EXADDTAXAREF);
									command.Parameters.AddWithValue("EXADDTAXCREF", line.EXADDTAXCREF);
									command.Parameters.AddWithValue("OTHRADDTAXAREF", line.OTHRADDTAXAREF);
									command.Parameters.AddWithValue("OTHRADDTAXCREF", line.OTHRADDTAXCREF);
									command.Parameters.AddWithValue("EXADDTAXAMNT", line.EXADDTAXAMNT);
									command.Parameters.AddWithValue("AFFECTCOLLATRL", line.AFFECTCOLLATRL);
									command.Parameters.AddWithValue("ALTPROMFLAG", line.ALTPROMFLAG);
									command.Parameters.AddWithValue("EIDISTFLNNR", line.EIDISTFLNNR);
									command.Parameters.AddWithValue("EXIMTYPE", line.EXIMTYPE);
									command.Parameters.AddWithValue("VARIANTREF", line.VARIANTREF);
									command.Parameters.AddWithValue("CANDEDUCT", line.CANDEDUCT);
									command.Parameters.AddWithValue("OUTREMAMNT", line.OUTREMAMNT);
									command.Parameters.AddWithValue("OUTREMCOST", line.OUTREMCOST);
									command.Parameters.AddWithValue("OUTREMCOSTCURR", line.OUTREMCOSTCURR);
									command.Parameters.AddWithValue("REFLVATACCREF", line.REFLVATACCREF);
									command.Parameters.AddWithValue("REFLVATOTHACCREF", line.REFLVATOTHACCREF);
									command.Parameters.AddWithValue("PARENTLNREF", line.PARENTLNREF);
									command.Parameters.AddWithValue("AFFECTRISK", line.AFFECTRISK);
									command.Parameters.AddWithValue("INEFFECTIVECOST", line.INEFFECTIVECOST);
									command.Parameters.AddWithValue("ADDTAXVATMATRAH", line.ADDTAXVATMATRAH);
									command.Parameters.AddWithValue("REFLACCREF", line.REFLACCREF);
									command.Parameters.AddWithValue("REFLOTHACCREF", line.REFLOTHACCREF);
									command.Parameters.AddWithValue("CAMPPAYDEFREF", line.CAMPPAYDEFREF);


									if (line.FAREGBINDDATE == null)
										command.Parameters.AddWithValue("FAREGBINDDATE", DBNull.Value);
									else
										command.Parameters.AddWithValue("FAREGBINDDATE", line.FAREGBINDDATE);

									command.Parameters.AddWithValue("RELTRANSLNREF", line.RELTRANSLNREF);
									command.Parameters.AddWithValue("FROMTRANSFER", line.FROMTRANSFER);
									command.Parameters.AddWithValue("COSTDISTPRICE", line.COSTDISTPRICE);
									command.Parameters.AddWithValue("COSTDISTREPPRICE", line.COSTDISTREPPRICE);
									command.Parameters.AddWithValue("DIFFPRICEUFRS", line.DIFFPRICEUFRS);
									command.Parameters.AddWithValue("DIFFREPPRICEUFRS", line.DIFFREPPRICEUFRS);
									command.Parameters.AddWithValue("OUTCOSTUFRS", line.OUTCOSTUFRS);
									command.Parameters.AddWithValue("OUTCOSTCURRUFRS", line.OUTCOSTCURRUFRS);
									command.Parameters.AddWithValue("DIFFPRCOSTUFRS", line.DIFFPRCOSTUFRS);
									command.Parameters.AddWithValue("DIFFPRCRCOSTUFRS", line.DIFFPRCRCOSTUFRS);
									command.Parameters.AddWithValue("RETCOSTUFRS", line.RETCOSTUFRS);
									command.Parameters.AddWithValue("RETCOSTCURRUFRS", line.RETCOSTCURRUFRS);
									command.Parameters.AddWithValue("OUTREMCOSTUFRS", line.OUTREMCOSTUFRS);
									command.Parameters.AddWithValue("OUTREMCOSTCURRUFRS", line.OUTREMCOSTCURRUFRS);
									command.Parameters.AddWithValue("INFIDXUFRS", line.INFIDXUFRS);
									command.Parameters.AddWithValue("ADJPRICEUFRS", line.ADJPRICEUFRS);
									command.Parameters.AddWithValue("ADJREPPRICEUFRS", line.ADJREPPRICEUFRS);
									command.Parameters.AddWithValue("ADJPRCOSTUFRS", line.ADJPRCOSTUFRS);
									command.Parameters.AddWithValue("ADJPRCRCOSTUFRS", line.ADJPRCRCOSTUFRS);
									command.Parameters.AddWithValue("COSTDISTPRICEUFRS", line.COSTDISTPRICEUFRS);
									command.Parameters.AddWithValue("COSTDISTREPPRICEUFRS", line.COSTDISTREPPRICEUFRS);
									command.Parameters.AddWithValue("PURCHACCREFUFRS", line.PURCHACCREFUFRS);
									command.Parameters.AddWithValue("PURCHCENTREFUFRS", line.PURCHCENTREFUFRS);
									command.Parameters.AddWithValue("COSACCREFUFRS", line.COSACCREFUFRS);
									command.Parameters.AddWithValue("COSCNTREFUFRS", line.COSCNTREFUFRS);
									command.Parameters.AddWithValue("PROUTCOSTUFRSDIFF", line.PROUTCOSTUFRSDIFF);
									command.Parameters.AddWithValue("PROUTCOSTCRUFRSDIFF", line.PROUTCOSTCRUFRSDIFF);
									command.Parameters.AddWithValue("UNDERDEDUCTLIMIT", line.UNDERDEDUCTLIMIT);
									command.Parameters.AddWithValue("GLOBALID", line.GLOBALID);
									command.Parameters.AddWithValue("DEDUCTIONPART1", line.DEDUCTIONPART1);
									command.Parameters.AddWithValue("DEDUCTIONPART2", line.DEDUCTIONPART2);
									command.Parameters.AddWithValue("GUID", line.GUID);
									command.Parameters.AddWithValue("SPECODE2", line.SPECODE2);
									command.Parameters.AddWithValue("OFFERREF", line.OFFERREF);
									command.Parameters.AddWithValue("OFFTRANSREF", line.OFFTRANSREF);
									command.Parameters.AddWithValue("VATEXCEPTREASON", line.VATEXCEPTREASON);
									command.Parameters.AddWithValue("PLNDEFSERILOTNO", line.PLNDEFSERILOTNO);
									command.Parameters.AddWithValue("PLNUNRSRVAMOUNT", line.PLNUNRSRVAMOUNT);
									command.Parameters.AddWithValue("PORDCLSPLNUNRSRVAMNT", line.PORDCLSPLNUNRSRVAMNT);
									command.Parameters.AddWithValue("LPRODRSRVSTAT", line.LPRODRSRVSTAT);
									command.Parameters.AddWithValue("FALINKTYPE", line.FALINKTYPE);
									command.Parameters.AddWithValue("DEDUCTCODE", line.DEDUCTCODE);
									command.Parameters.AddWithValue("UPDTHISLINE", line.UPDTHISLINE);
									command.Parameters.AddWithValue("VATEXCEPTCODE", line.VATEXCEPTCODE);
									command.Parameters.AddWithValue("PORDERFICHENO", line.PORDERFICHENO);
									command.Parameters.AddWithValue("QPRODFCREF", line.QPRODFCREF);
									command.Parameters.AddWithValue("RELTRANSFCREF", line.RELTRANSFCREF);
									command.Parameters.AddWithValue("ATAXEXCEPTREASON", line.ATAXEXCEPTREASON);
									command.Parameters.AddWithValue("ATAXEXCEPTCODE", line.ATAXEXCEPTCODE);
									command.Parameters.AddWithValue("PRODORDERTYP", line.PRODORDERTYP);
									command.Parameters.AddWithValue("SUBCONTORDERREF", line.SUBCONTORDERREF);
									command.Parameters.AddWithValue("QPRODFCTYP", line.QPRODFCTYP);
									command.Parameters.AddWithValue("PRDORDSLPLNRESERVE", line.PRDORDSLPLNRESERVE);

									if (line.INFDATE == null)
										command.Parameters.AddWithValue("INFDATE", DBNull.Value);
									else
										command.Parameters.AddWithValue("INFDATE", line.INFDATE);

									command.Parameters.AddWithValue("DESTSTATUS", line.DESTSTATUS);
									command.Parameters.AddWithValue("REGTYPREF", line.REGTYPREF);
									command.Parameters.AddWithValue("FAPROFITACCREF", line.FAPROFITACCREF);
									command.Parameters.AddWithValue("FAPROFITCENTREF", line.FAPROFITCENTREF);
									command.Parameters.AddWithValue("FALOSSACCREF", line.FALOSSACCREF);
									command.Parameters.AddWithValue("FALOSSCENTREF", line.FALOSSCENTREF);
									command.Parameters.AddWithValue("FUTMONTHCNT", line.FUTMONTHCNT);
									command.Parameters.AddWithValue("FUTMONTHBEGDATE", line.FUTMONTHBEGDATE);
									command.Parameters.AddWithValue("GTIPCODE", line.GTIPCODE);
									command.Parameters.AddWithValue("CPACODE", line.CPACODE);
									command.Parameters.AddWithValue("QPRODITEMTYPE", line.QPRODITEMTYPE);
									command.Parameters.AddWithValue("PUBLICCOUNTRYREF", line.PUBLICCOUNTRYREF);
									var id = await command.ExecuteScalarAsync();
									await connection.CloseAsync();
								}
							}
							catch (Exception e)
							{
								Debug.WriteLine(e.Message);
								throw;
							}
						}


						if (line.SERILOTTRANSACTIONS != null)
						{
							foreach (var serilot in line.SERILOTTRANSACTIONS)
							{
								string seriLotQuery = $@"INSERT INTO LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_SLTRANS(
            STFICHEREF
           ,DATE_
           ,STTRANSREF
           ,INTRANSREF
           ,INSLTRANSREF
           ,INSLAMOUNT
           ,LINENR
           ,ITEMREF
           ,IOCODE
           ,INVENNO
           ,FICHETYPE
           ,SLTYPE
           ,SLREF
           ,LOCREF
           ,MAINAMOUNT
           ,UOMREF
           ,AMOUNT
           ,REMAMOUNT
           ,REMLNUNITAMNT
           ,UINFO1
           ,UINFO2
           ,UINFO3
           ,UINFO4
           ,UINFO5
           ,UINFO6
           ,UINFO7
           ,UINFO8
           ,RATESCORE
           ,CANCELLED
           ,OUTCOST
           ,OUTCOSTCURR
           ,DIFFPRCOST
           ,DIFFPRCOSTCURR
           ,SERIQCOK
           ,LPRODSTAT
           ,SOURCETYPE
           ,SOURCEWSREF
           ,SITEID
           ,RECSTATUS
           ,ORGLOGICREF
           ,WFSTATUS
           ,DISTORDREF
           ,DISTORDLNREF
           ,INDORDSLTRNREF
           ,GROSSUINFO1
           ,GROSSUINFO2
           ,ATAXPRCOST
           ,ATAXPRCOSTCURR
           ,INFIDX
           ,ORGLOGOID
           ,LINEEXP
           ,EXIMFCTYPE
           ,EXIMFILEREF
           ,EXIMPROCNR
           ,MAINSLLNREF
           ,MADEOFSHRED
           ,STATUS
           ,VARIANTREF
           ,GRPBEGCODE
           ,GRPENDCODE
           ,OUTCOSTUFRS
           ,OUTCOSTCURRUFRS
           ,DIFFPRCOSTUFRS
           ,DIFFPRCOSTCURRUFRS
           ,INFIDXUFRS
           ,ADJPRCOSTUFRS
           ,ADJPRCOSTCURRUFRS
           ,GUID
           ,PRDORDREF
           ,PRDORDSLPLNRESERVE
           ,INPLNSLTRANSREF
           ,NOTSHIPPED
            ,EXPDATE)  
         VALUES(
            @STFICHEREF
           ,@DATE_
           ,@STTRANSREF
           ,@INTRANSREF
           ,@INSLTRANSREF
           ,@INSLAMOUNT
           ,@LINENR
           ,@ITEMREF
           ,@IOCODE
           ,@INVENNO
           ,@FICHETYPE
           ,@SLTYPE
           ,@SLREF
           ,@LOCREF
           ,@MAINAMOUNT
           ,@UOMREF
           ,@AMOUNT
           ,@REMAMOUNT
           ,@REMLNUNITAMNT
           ,@UINFO1
           ,@UINFO2
           ,@UINFO3
           ,@UINFO4
           ,@UINFO5
           ,@UINFO6
           ,@UINFO7
           ,@UINFO8
           ,@RATESCORE
           ,@CANCELLED
           ,@OUTCOST
           ,@OUTCOSTCURR
           ,@DIFFPRCOST
           ,@DIFFPRCOSTCURR
           ,@SERIQCOK
           ,@LPRODSTAT
           ,@SOURCETYPE
           ,@SOURCEWSREF
           ,@SITEID
           ,@RECSTATUS
           ,@ORGLOGICREF
           ,@WFSTATUS
           ,@DISTORDREF
           ,@DISTORDLNREF
           ,@INDORDSLTRNREF
           ,@GROSSUINFO1
           ,@GROSSUINFO2
           ,@ATAXPRCOST
           ,@ATAXPRCOSTCURR
           ,@INFIDX
           ,@ORGLOGOID
           ,@LINEEXP
           ,@EXIMFCTYPE
           ,@EXIMFILEREF
           ,@EXIMPROCNR
           ,@MAINSLLNREF
           ,@MADEOFSHRED
           ,@STATUS
           ,@VARIANTREF
           ,@GRPBEGCODE
           ,@GRPENDCODE
           ,@OUTCOSTUFRS
           ,@OUTCOSTCURRUFRS
           ,@DIFFPRCOSTUFRS
           ,@DIFFPRCOSTCURRUFRS
           ,@INFIDXUFRS
           ,@ADJPRCOSTUFRS
           ,@ADJPRCOSTCURRUFRS
           ,@GUID
           ,@PRDORDREF
           ,@PRDORDSLPLNRESERVE
           ,@INPLNSLTRANSREF
           ,@NOTSHIPPED
           ,@EXPDATE
         	); SELECT SCOPE_IDENTITY();";

								await using (SqlConnection connection = new SqlConnection(_connectionString))
								{
									await connection.OpenAsync();
									await using (SqlCommand command = new SqlCommand(seriLotQuery, connection))
									{
										command.Parameters.AddWithValue("STFICHEREF", ReferenceId);
										command.Parameters.AddWithValue("STTRANSREF", serilot.STTRANSREF);
										command.Parameters.AddWithValue("INTRANSREF", serilot.INTRANSREF);
										command.Parameters.AddWithValue("INSLTRANSREF", serilot.INSLTRANSREF);
										command.Parameters.AddWithValue("INSLAMOUNT", serilot.INSLAMOUNT);
										command.Parameters.AddWithValue("LINENR", serilot.LINENR);
										//command.Parameters.AddWithValue("serilotREF", serilot.serilotREF);
										command.Parameters.AddWithValue("DATE_", serilot.DATE_);
										command.Parameters.AddWithValue("IOCODE", 1);
										command.Parameters.AddWithValue("INVENNO", serilot.INVENNO);
										command.Parameters.AddWithValue("FICHETYPE", serilot.FICHETYPE);
										command.Parameters.AddWithValue("SLTYPE", serilot.SLTYPE);
										command.Parameters.AddWithValue("SLREF", serilot.SLREF);
										command.Parameters.AddWithValue("LOCREF", serilot.LOCREF);
										command.Parameters.AddWithValue("MAINAMOUNT", serilot.MAINAMOUNT);
										command.Parameters.AddWithValue("UOMREF", serilot.UOMREF);
										command.Parameters.AddWithValue("AMOUNT", serilot.AMOUNT);
										command.Parameters.AddWithValue("REMAMOUNT", serilot.REMAMOUNT);
										command.Parameters.AddWithValue("REMLNUNITAMNT", serilot.REMLNUNITAMNT);
										command.Parameters.AddWithValue("UINFO1", serilot.UINFO1);
										command.Parameters.AddWithValue("UINFO2", serilot.UINFO2);
										command.Parameters.AddWithValue("UINFO3", serilot.UINFO3);
										command.Parameters.AddWithValue("UINFO4", serilot.UINFO4);
										command.Parameters.AddWithValue("UINFO5", serilot.UINFO5);
										command.Parameters.AddWithValue("UINFO6", serilot.UINFO6);
										command.Parameters.AddWithValue("UINFO7", serilot.UINFO7);
										command.Parameters.AddWithValue("UINFO8", serilot.UINFO8);
										command.Parameters.AddWithValue("EXPDATE", serilot.EXPDATE);
										command.Parameters.AddWithValue("RATESCORE", serilot.RATESCORE);
										command.Parameters.AddWithValue("CANCELLED", serilot.CANCELLED);
										command.Parameters.AddWithValue("OUTCOST", serilot.OUTCOST);
										command.Parameters.AddWithValue("OUTCOSTCURR", serilot.OUTCOSTCURR);
										command.Parameters.AddWithValue("DIFFPRCOST", serilot.DIFFPRCOST);
										command.Parameters.AddWithValue("DIFFPRCOSTCURR", serilot.DIFFPRCOSTCURR);
										command.Parameters.AddWithValue("SERIQCOK", serilot.SERIQCOK);
										command.Parameters.AddWithValue("LPRODSTAT", serilot.LPRODSTAT);
										command.Parameters.AddWithValue("SOURCETYPE", serilot.SOURCETYPE);
										command.Parameters.AddWithValue("SOURCEWSREF", serilot.SOURCEWSREF);
										command.Parameters.AddWithValue("SITEID", serilot.SITEID);
										command.Parameters.AddWithValue("RECSTATUS", serilot.RECSTATUS);
										command.Parameters.AddWithValue("ORGLOGICREF", serilot.ORGLOGICREF);
										command.Parameters.AddWithValue("WFSTATUS", serilot.WFSTATUS);
										command.Parameters.AddWithValue("DISTORDREF", serilot.DISTORDREF);
										command.Parameters.AddWithValue("DISTORDLNREF", serilot.DISTORDLNREF);
										command.Parameters.AddWithValue("INDORDSLTRNREF", serilot.INDORDSLTRNREF);
										command.Parameters.AddWithValue("GROSSUINFO1", serilot.GROSSUINFO1);
										command.Parameters.AddWithValue("GROSSUINFO2", serilot.GROSSUINFO2);
										command.Parameters.AddWithValue("ATAXPRCOST", serilot.ATAXPRCOST);
										command.Parameters.AddWithValue("ATAXPRCOSTCURR", serilot.ATAXPRCOSTCURR);
										command.Parameters.AddWithValue("INFIDX", serilot.INFIDX);
										command.Parameters.AddWithValue("ORGLOGOID", serilot.ORGLOGOID);
										command.Parameters.AddWithValue("LINEEXP", serilot.LINEEXP);
										command.Parameters.AddWithValue("EXIMFCTYPE", serilot.EXIMFCTYPE);
										command.Parameters.AddWithValue("EXIMFILEREF", serilot.EXIMFILEREF);
										command.Parameters.AddWithValue("EXIMPROCNR", serilot.EXIMPROCNR);
										command.Parameters.AddWithValue("MAINSLLNREF", serilot.MAINSLLNREF);
										command.Parameters.AddWithValue("MADEOFSHRED", serilot.MADEOFSHRED);
										command.Parameters.AddWithValue("STATUS", serilot.STATUS);
										command.Parameters.AddWithValue("VARIANTREF", serilot.VARIANTREF);
										command.Parameters.AddWithValue("GRPBEGCODE", serilot.GRPBEGCODE);
										command.Parameters.AddWithValue("GRPENDCODE", serilot.GRPENDCODE);
										command.Parameters.AddWithValue("OUTCOSTUFRS", serilot.OUTCOSTUFRS);
										command.Parameters.AddWithValue("OUTCOSTCURRUFRS", serilot.OUTCOSTCURRUFRS);
										command.Parameters.AddWithValue("DIFFPRCOSTUFRS", serilot.DIFFPRCOSTUFRS);
										command.Parameters.AddWithValue("DIFFPRCOSTCURRUFRS", serilot.DIFFPRCOSTCURRUFRS);
										command.Parameters.AddWithValue("INFIDXUFRS", serilot.INFIDXUFRS);
										command.Parameters.AddWithValue("ADJPRCOSTUFRS", serilot.ADJPRCOSTUFRS);
										command.Parameters.AddWithValue("ADJPRCOSTCURRUFRS", serilot.ADJPRCOSTCURRUFRS);
										command.Parameters.AddWithValue("GUID", serilot.GUID);
										command.Parameters.AddWithValue("PRDORDREF", serilot.PRDORDREF);
										command.Parameters.AddWithValue("PRDORDSLPLNRESERVE", serilot.PRDORDSLPLNRESERVE);
										command.Parameters.AddWithValue("INPLNSLTRANSREF", serilot.INPLNSLTRANSREF);
										command.Parameters.AddWithValue("NOTSHIPPED", serilot.NOTSHIPPED);

										var id = await command.ExecuteScalarAsync();
										await connection.CloseAsync();
										ReferenceId = Convert.ToInt32(id);
									}
								}
							}


						}
					}
					#endregion
					await UpdateObject(last, item.DATE_.ToString("s"), item.DATE_.ToString("s"), item.TRCODE);
					transaction.Complete();

					return new DataResult<LG_STFICHE>()
					{
						Data = null,
						IsSuccess = true,
						Message = "Succes"
					};
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);

					return new DataResult<LG_STFICHE>()
					{
						Data = null,
						IsSuccess = false,
						Message = e.Message
					};

				}
			}
		}
	}
}
