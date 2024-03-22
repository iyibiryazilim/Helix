using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Models;
using Helix.LBSService.Go.Services;
using Microsoft.Data.SqlClient;

namespace Helix.LBSService.Go.DataStores;

public class LG_STLINE_Context : ILG_STLINE_Context, IDisposable
{
	private readonly int _defaultFirmNumber = LBSParameter.FirmNumber;
	private readonly int _defaultPeriodNumber = LBSParameter.Period;
	private readonly string _connectionString = LBSParameter.Connection;

	public LG_STLINE_Context()
	{
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			// Dispose of managed resources
			// Add code here to dispose of managed resources
		}

		// Dispose of unmanaged resources
		// Add code here to dispose of unmanaged resources
	}

	public async Task<DataResult<LG_STLINE>> InsertAsync(LG_STLINE dto)
	{
		DataResult<LG_STLINE> result = new DataResult<LG_STLINE>();
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
           ); SELECT SCOPE_IDENTITY();";
		try
		{
			var referenceId = 0;
			await using SqlConnection connection = new SqlConnection(_connectionString);
			await using (SqlCommand command = new SqlCommand(lineQuery, connection))
			{
				command.CommandTimeout = 600;
				await connection.OpenAsync();

				#region Set Line

				command.Parameters.AddWithValue(nameof(dto.LOGICALREF), dto.LOGICALREF);
				command.Parameters.AddWithValue(nameof(dto.STOCKREF), dto.STOCKREF);
				command.Parameters.AddWithValue(nameof(dto.LINETYPE), dto.LINETYPE);
				command.Parameters.AddWithValue(nameof(dto.PREVLINEREF), dto.PREVLINEREF);
				command.Parameters.AddWithValue(nameof(dto.PREVLINENO), dto.PREVLINENO);
				command.Parameters.AddWithValue(nameof(dto.DETLINE), dto.DETLINE);
				command.Parameters.AddWithValue(nameof(dto.TRCODE), dto.TRCODE);
				command.Parameters.AddWithValue(nameof(dto.DATE_), dto.DATE_);
				command.Parameters.AddWithValue(nameof(dto.FTIME), dto.FTIME);
				command.Parameters.AddWithValue("FHOUR", dto.DATE_.Hour);
				command.Parameters.AddWithValue("FMINUTE", dto.DATE_.Minute);
				command.Parameters.AddWithValue("FSECOND", dto.DATE_.Second);
				command.Parameters.AddWithValue(nameof(dto.GLOBTRANS), dto.GLOBTRANS);
				command.Parameters.AddWithValue(nameof(dto.CALCTYPE), dto.CALCTYPE);
				command.Parameters.AddWithValue(nameof(dto.PRODORDERREF), dto.PRODORDERREF);
				command.Parameters.AddWithValue(nameof(dto.SOURCETYPE), dto.SOURCETYPE);
				command.Parameters.AddWithValue(nameof(dto.SOURCEINDEX), dto.SOURCEINDEX);
				command.Parameters.AddWithValue(nameof(dto.SOURCECOSTGRP), dto.SOURCECOSTGRP);
				command.Parameters.AddWithValue(nameof(dto.SOURCEWSREF), dto.SOURCEWSREF);
				command.Parameters.AddWithValue(nameof(dto.SOURCEPOLNREF), dto.SOURCEPOLNREF);
				command.Parameters.AddWithValue(nameof(dto.DESTTYPE), dto.DESTTYPE);
				command.Parameters.AddWithValue(nameof(dto.DESTINDEX), dto.DESTINDEX);
				command.Parameters.AddWithValue(nameof(dto.DESTCOSTGRP), dto.DESTCOSTGRP);
				command.Parameters.AddWithValue(nameof(dto.DESTWSREF), dto.DESTWSREF);
				command.Parameters.AddWithValue(nameof(dto.DESTPOLNREF), dto.DESTPOLNREF);
				command.Parameters.AddWithValue(nameof(dto.FACTORYNR), dto.FACTORYNR);
				command.Parameters.AddWithValue(nameof(dto.IOCODE), dto.IOCODE);
				command.Parameters.AddWithValue(nameof(dto.STFICHEREF), dto.STFICHEREF);
				command.Parameters.AddWithValue(nameof(dto.STFICHELNNO), dto.STFICHELNNO);
				command.Parameters.AddWithValue(nameof(dto.INVOICEREF), dto.INVOICEREF);
				command.Parameters.AddWithValue(nameof(dto.INVOICELNNO), dto.INVOICELNNO);
				command.Parameters.AddWithValue(nameof(dto.CLIENTREF), dto.CLIENTREF);
				command.Parameters.AddWithValue(nameof(dto.ORDTRANSREF), dto.ORDTRANSREF);
				command.Parameters.AddWithValue(nameof(dto.ORDFICHEREF), dto.ORDFICHEREF);
				command.Parameters.AddWithValue(nameof(dto.CENTERREF), dto.CENTERREF);
				command.Parameters.AddWithValue(nameof(dto.ACCOUNTREF), dto.ACCOUNTREF);
				command.Parameters.AddWithValue(nameof(dto.VATACCREF), dto.VATACCREF);
				command.Parameters.AddWithValue(nameof(dto.VATCENTERREF), dto.VATCENTERREF);
				command.Parameters.AddWithValue(nameof(dto.PRACCREF), dto.PRACCREF);
				command.Parameters.AddWithValue(nameof(dto.PRCENTERREF), dto.PRCENTERREF);
				command.Parameters.AddWithValue(nameof(dto.PRVATACCREF), dto.PRVATACCREF);
				command.Parameters.AddWithValue(nameof(dto.PRVATCENREF), dto.PRVATCENREF);
				command.Parameters.AddWithValue(nameof(dto.PROMREF), dto.PROMREF);
				command.Parameters.AddWithValue(nameof(dto.PAYDEFREF), dto.PAYDEFREF);
				command.Parameters.AddWithValue(nameof(dto.SPECODE), dto.SPECODE);
				command.Parameters.AddWithValue(nameof(dto.DELVRYCODE), dto.DELVRYCODE);
				command.Parameters.AddWithValue(nameof(dto.AMOUNT), dto.AMOUNT);
				command.Parameters.AddWithValue(nameof(dto.PRICE), dto.PRICE);
				command.Parameters.AddWithValue(nameof(dto.TOTAL), dto.TOTAL);
				command.Parameters.AddWithValue(nameof(dto.PRCURR), dto.PRCURR);
				command.Parameters.AddWithValue(nameof(dto.PRPRICE), dto.PRPRICE);
				command.Parameters.AddWithValue(nameof(dto.TRCURR), dto.TRCURR);
				command.Parameters.AddWithValue(nameof(dto.TRRATE), dto.TRRATE);
				command.Parameters.AddWithValue(nameof(dto.REPORTRATE), dto.REPORTRATE);
				command.Parameters.AddWithValue(nameof(dto.DISTCOST), dto.DISTCOST);
				command.Parameters.AddWithValue(nameof(dto.DISTDISC), dto.DISTDISC);
				command.Parameters.AddWithValue(nameof(dto.DISTEXP), dto.DISTEXP);
				command.Parameters.AddWithValue(nameof(dto.DISTPROM), dto.DISTPROM);
				command.Parameters.AddWithValue(nameof(dto.DISCPER), dto.DISCPER);
				command.Parameters.AddWithValue(nameof(dto.LINEEXP), dto.LINEEXP);
				command.Parameters.AddWithValue(nameof(dto.UOMREF), dto.UOMREF);
				command.Parameters.AddWithValue(nameof(dto.USREF), dto.USREF);
				command.Parameters.AddWithValue(nameof(dto.UINFO1), dto.UINFO1);
				command.Parameters.AddWithValue(nameof(dto.UINFO2), dto.UINFO2);
				command.Parameters.AddWithValue(nameof(dto.UINFO3), dto.UINFO3);
				command.Parameters.AddWithValue(nameof(dto.UINFO4), dto.UINFO4);
				command.Parameters.AddWithValue(nameof(dto.UINFO5), dto.UINFO5);
				command.Parameters.AddWithValue(nameof(dto.UINFO6), dto.UINFO6);
				command.Parameters.AddWithValue(nameof(dto.UINFO7), dto.UINFO7);
				command.Parameters.AddWithValue(nameof(dto.UINFO8), dto.UINFO8);
				command.Parameters.AddWithValue(nameof(dto.PLNAMOUNT), dto.PLNAMOUNT);
				command.Parameters.AddWithValue(nameof(dto.VATINC), dto.VATINC);
				command.Parameters.AddWithValue(nameof(dto.VAT), dto.VAT);
				command.Parameters.AddWithValue(nameof(dto.VATAMNT), dto.VATAMNT);
				command.Parameters.AddWithValue(nameof(dto.VATMATRAH), dto.VATMATRAH);
				command.Parameters.AddWithValue(nameof(dto.BILLEDITEM), dto.BILLEDITEM);
				command.Parameters.AddWithValue(nameof(dto.BILLED), dto.BILLED);
				command.Parameters.AddWithValue(nameof(dto.CPSTFLAG), dto.CPSTFLAG);
				command.Parameters.AddWithValue(nameof(dto.RETCOSTTYPE), dto.RETCOSTTYPE);
				command.Parameters.AddWithValue(nameof(dto.SOURCELINK), dto.SOURCELINK);
				command.Parameters.AddWithValue(nameof(dto.RETCOST), dto.RETCOST);
				command.Parameters.AddWithValue(nameof(dto.RETCOSTCURR), dto.RETCOSTCURR);
				command.Parameters.AddWithValue(nameof(dto.OUTCOST), dto.OUTCOST);
				command.Parameters.AddWithValue(nameof(dto.OUTCOSTCURR), dto.OUTCOSTCURR);
				command.Parameters.AddWithValue(nameof(dto.RETAMOUNT), dto.RETAMOUNT);
				command.Parameters.AddWithValue(nameof(dto.FAREGREF), dto.FAREGREF);
				command.Parameters.AddWithValue(nameof(dto.FAATTRIB), dto.FAATTRIB);
				command.Parameters.AddWithValue(nameof(dto.CANCELLED), dto.CANCELLED);
				command.Parameters.AddWithValue(nameof(dto.LINENET), dto.LINENET);
				command.Parameters.AddWithValue(nameof(dto.DISTADDEXP), dto.DISTADDEXP);
				command.Parameters.AddWithValue(nameof(dto.FADACCREF), dto.FADACCREF);
				command.Parameters.AddWithValue(nameof(dto.FADCENTERREF), dto.FADCENTERREF);
				command.Parameters.AddWithValue(nameof(dto.FARACCREF), dto.FARACCREF);
				command.Parameters.AddWithValue(nameof(dto.FARCENTERREF), dto.FARCENTERREF);
				command.Parameters.AddWithValue(nameof(dto.DIFFPRICE), dto.DIFFPRICE);
				command.Parameters.AddWithValue(nameof(dto.DIFFPRCOST), dto.DIFFPRCOST);
				command.Parameters.AddWithValue(nameof(dto.DECPRDIFF), dto.DECPRDIFF);
				command.Parameters.AddWithValue(nameof(dto.LPRODSTAT), dto.LPRODSTAT);
				command.Parameters.AddWithValue(nameof(dto.PRDEXPTOTAL), dto.PRDEXPTOTAL);
				command.Parameters.AddWithValue(nameof(dto.DIFFREPPRICE), dto.DIFFREPPRICE);
				command.Parameters.AddWithValue(nameof(dto.DIFFPRCRCOST), dto.DIFFPRCRCOST);
				command.Parameters.AddWithValue(nameof(dto.SALESMANREF), dto.SALESMANREF);
				command.Parameters.AddWithValue(nameof(dto.FAPLACCREF), dto.FAPLACCREF);
				command.Parameters.AddWithValue(nameof(dto.FAPLCENTERREF), dto.FAPLCENTERREF);
				command.Parameters.AddWithValue(nameof(dto.OUTPUTIDCODE), dto.OUTPUTIDCODE);

				#endregion Set Line

				var id = await command.ExecuteScalarAsync();
				referenceId = Convert.ToInt32(id);
			}
			lineQuery = $@"UPDATE [dbo].[LG_{_defaultFirmNumber.ToString().PadLeft(3, '0')}_{_defaultPeriodNumber.ToString().PadLeft(2, '0')}_STLINE]
   SET [DREF] = @DREF
      ,[COSTRATE] = @COSTRATE
      ,[XPRICEUPD] = @XPRICEUPD
      ,[XPRICE] = @XPRICE
      ,[XREPRATE] = @XREPRATE
      ,[DISTCOEF] = @DISTCOEF
      ,[TRANSQCOK] = @TRANSQCOK
      ,[SITEID] = @SITEID
      ,[RECSTATUS] = @RECSTATUS
      ,[ORGLOGICREF] = @ORGLOGICREF
      ,[WFSTATUS] = @WFSTATUS
      ,[POLINEREF] = @POLINEREF
      ,[PLNSTTRANSREF] = @PLNSTTRANSREF
      ,[NETDISCFLAG] = @NETDISCFLAG
      ,[NETDISCPERC] = @NETDISCPERC
      ,[NETDISCAMNT] = @NETDISCAMNT
      ,[VATCALCDIFF] = @VATCALCDIFF
      ,[CONDITIONREF] = @CONDITIONREF
      ,[DISTORDERREF] = @DISTORDERREF
      ,[DISTORDLINEREF] = @DISTORDLINEREF
      ,[CAMPAIGNREFS1] = @CAMPAIGNREFS1
      ,[CAMPAIGNREFS2] = @CAMPAIGNREFS2
      ,[CAMPAIGNREFS3] = @CAMPAIGNREFS3
      ,[CAMPAIGNREFS4] = @CAMPAIGNREFS4
      ,[CAMPAIGNREFS5] = @CAMPAIGNREFS5
      ,[POINTCAMPREF] = @POINTCAMPREF
      ,[CAMPPOINT] = @CAMPPOINT
      ,[PROMCLASITEMREF] = @PROMCLASITEMREF
      ,[CMPGLINEREF] = @CMPGLINEREF
      ,[PLNSTTRANSPERNR] = @PLNSTTRANSPERNR
      ,[PORDCLSPLNAMNT] = @PORDCLSPLNAMNT
      ,[VENDCOMM] = @VENDCOMM
      ,[PREVIOUSOUTCOST] = @PREVIOUSOUTCOST
      ,[COSTOFSALEACCREF] = @COSTOFSALEACCREF
      ,[PURCHACCREF] = @PURCHACCREF
      ,[COSTOFSALECNTREF] = @COSTOFSALECNTREF
      ,[PURCHCENTREF] = @PURCHCENTREF
      ,[PREVOUTCOSTCURR] = @PREVOUTCOSTCURR
      ,[ABVATAMOUNT] = @ABVATAMOUNT
      ,[ABVATSTATUS] = @ABVATSTATUS
      ,[PRRATE] = @PRRATE
      ,[ADDTAXRATE] = @ADDTAXRATE
      ,[ADDTAXCONVFACT] = @ADDTAXCONVFACT
      ,[ADDTAXAMOUNT] = @ADDTAXAMOUNT
      ,[ADDTAXPRCOST] = @ADDTAXPRCOST
      ,[ADDTAXRETCOST] = @ADDTAXRETCOST
      ,[ADDTAXRETCOSTCURR] = @ADDTAXRETCOSTCURR
      ,[GROSSUINFO1] = @GROSSUINFO1
      ,[GROSSUINFO2] = @GROSSUINFO2
      ,[ADDTAXPRCOSTCURR] = @ADDTAXPRCOSTCURR
      ,[ADDTAXACCREF] = @ADDTAXACCREF
      ,[ADDTAXCENTERREF] = @ADDTAXCENTERREF
      ,[ADDTAXAMNTISUPD] = @ADDTAXAMNTISUPD
      ,[INFIDX] = @INFIDX
      ,[ADDTAXCOSACCREF] = @ADDTAXCOSACCREF
      ,[ADDTAXCOSCNTREF] = @ADDTAXCOSCNTREF
      ,[PREVIOUSATAXPRCOST] = @PREVIOUSATAXPRCOST
      ,[PREVATAXPRCOSTCURR] = @PREVATAXPRCOSTCURR
      ,[PRDORDTOTCOEF] = @PRDORDTOTCOEF
      ,[DEMPEGGEDAMNT] = @DEMPEGGEDAMNT
      ,[STDUNITCOST] = @STDUNITCOST
      ,[STDRPUNITCOST] = @STDRPUNITCOST
      ,[COSTDIFFACCREF] = @COSTDIFFACCREF
      ,[COSTDIFFCENREF] = @COSTDIFFCENREF
      ,[TEXTINC] = @TEXTINC
      ,[ADDTAXDISCAMOUNT] = @ADDTAXDISCAMOUNT
      ,[ORGLOGOID] = @ORGLOGOID
      ,[EXIMFICHENO] = @EXIMFICHENO
      ,[EXIMFCTYPE] = @EXIMFCTYPE
      ,[TRANSEXPLINE] = @TRANSEXPLINE
      ,[INSEXPLINE] = @INSEXPLINE
      ,[EXIMWHFCREF] = @EXIMWHFCREF
      ,[EXIMWHLNREF] = @EXIMWHLNREF
      ,[EXIMFILEREF] = @EXIMFILEREF
      ,[EXIMPROCNR] = @EXIMPROCNR
      ,[EISRVDSTTYP] = @EISRVDSTTYP
      ,[MAINSTLNREF] = @MAINSTLNREF
      ,[MADEOFSHRED] = @MADEOFSHRED
      ,[FROMORDWITHPAY] = @FROMORDWITHPAY
      ,[PROJECTREF] = @PROJECTREF
      ,[STATUS] = @STATUS
      ,[DORESERVE] = @DORESERVE
      ,[POINTCAMPREFS1] = @POINTCAMPREFS1
      ,[POINTCAMPREFS2] = @POINTCAMPREFS2
      ,[POINTCAMPREFS3] = @POINTCAMPREFS3
      ,[POINTCAMPREFS4] = @POINTCAMPREFS4
      ,[CAMPPOINTS1] = @CAMPPOINTS1
      ,[CAMPPOINTS2] = @CAMPPOINTS2
      ,[CAMPPOINTS3] = @CAMPPOINTS3
      ,[CAMPPOINTS4] = @CAMPPOINTS4
      ,[CMPGLINEREFS1] = @CMPGLINEREFS1
      ,[CMPGLINEREFS2] = @CMPGLINEREFS2
      ,[CMPGLINEREFS3] = @CMPGLINEREFS3
      ,[CMPGLINEREFS4] = @CMPGLINEREFS4
      ,[PRCLISTREF] = @PRCLISTREF
      ,[PORDSYMOUTLN] = @PORDSYMOUTLN
      ,[MONTH_] = @MONTH_
      ,[YEAR_] = @YEAR_
      ,[EXADDTAXRATE] = @EXADDTAXRATE
      ,[EXADDTAXCONVF] = @EXADDTAXCONVF
      ,[EXADDTAXAREF] = @EXADDTAXAREF
      ,[EXADDTAXCREF] = @EXADDTAXCREF
      ,[OTHRADDTAXAREF] = @OTHRADDTAXAREF
      ,[OTHRADDTAXCREF] = @OTHRADDTAXCREF
      ,[EXADDTAXAMNT] = @EXADDTAXAMNT
      ,[AFFECTCOLLATRL] = @AFFECTCOLLATRL
      ,[ALTPROMFLAG] = @ALTPROMFLAG
      ,[EIDISTFLNNR] = @EIDISTFLNNR
      ,[EXIMTYPE] = @EXIMTYPE
      ,[VARIANTREF] = @VARIANTREF
      ,[CANDEDUCT] = @CANDEDUCT
      ,[OUTREMAMNT] = @OUTREMAMNT
      ,[OUTREMCOST] = @OUTREMCOST
      ,[OUTREMCOSTCURR] = @OUTREMCOSTCURR
      ,[REFLVATACCREF] = @REFLVATACCREF
      ,[REFLVATOTHACCREF] = @REFLVATOTHACCREF
      ,[PARENTLNREF] = @PARENTLNREF
      ,[AFFECTRISK] = @AFFECTRISK
      ,[INEFFECTIVECOST] = @INEFFECTIVECOST
      ,[ADDTAXVATMATRAH] = @ADDTAXVATMATRAH
      ,[REFLACCREF] = @REFLACCREF
      ,[REFLOTHACCREF] = @REFLOTHACCREF
      ,[CAMPPAYDEFREF] = @CAMPPAYDEFREF
      ,[FAREGBINDDATE] = @FAREGBINDDATE
      ,[RELTRANSLNREF] = @RELTRANSLNREF
      ,[FROMTRANSFER] = @FROMTRANSFER
      ,[COSTDISTPRICE] = @COSTDISTPRICE
      ,[COSTDISTREPPRICE] = @COSTDISTREPPRICE
      ,[DIFFPRICEUFRS] = @DIFFPRICEUFRS
      ,[DIFFREPPRICEUFRS] = @DIFFREPPRICEUFRS
      ,[OUTCOSTUFRS] = @OUTCOSTUFRS
      ,[OUTCOSTCURRUFRS] = @OUTCOSTCURRUFRS
      ,[DIFFPRCOSTUFRS] = @DIFFPRCOSTUFRS
      ,[DIFFPRCRCOSTUFRS] = @DIFFPRCRCOSTUFRS
      ,[RETCOSTUFRS] = @RETCOSTUFRS
      ,[RETCOSTCURRUFRS] = @RETCOSTCURRUFRS
      ,[OUTREMCOSTUFRS] = @OUTREMCOSTUFRS
      ,[OUTREMCOSTCURRUFRS] = @OUTREMCOSTCURRUFRS
      ,[INFIDXUFRS] = @INFIDXUFRS
      ,[ADJPRICEUFRS] = @ADJPRICEUFRS
      ,[ADJREPPRICEUFRS] = @ADJREPPRICEUFRS
      ,[ADJPRCOSTUFRS] = @ADJPRCOSTUFRS
      ,[ADJPRCRCOSTUFRS] = @ADJPRCRCOSTUFRS
      ,[COSTDISTPRICEUFRS] = @COSTDISTPRICEUFRS
      ,[COSTDISTREPPRICEUFRS] = @COSTDISTREPPRICEUFRS
      ,[PURCHACCREFUFRS] = @PURCHACCREFUFRS
      ,[PURCHCENTREFUFRS] = @PURCHCENTREFUFRS
      ,[COSACCREFUFRS] = @COSACCREFUFRS
      ,[COSCNTREFUFRS] = @COSCNTREFUFRS
      ,[PROUTCOSTUFRSDIFF] = @PROUTCOSTUFRSDIFF
      ,[PROUTCOSTCRUFRSDIFF] = @PROUTCOSTCRUFRSDIFF
      ,[UNDERDEDUCTLIMIT] = @UNDERDEDUCTLIMIT
      ,[GLOBALID] = @GLOBALID
      ,[DEDUCTIONPART1] = @DEDUCTIONPART1
      ,[DEDUCTIONPART2] = @DEDUCTIONPART2
      ,[GUID] = @GUID
      ,[SPECODE2] = @SPECODE2
      ,[OFFERREF] = @OFFERREF
      ,[OFFTRANSREF] = @OFFTRANSREF
      ,[VATEXCEPTREASON] = @VATEXCEPTREASON
      ,[PLNDEFSERILOTNO] = @PLNDEFSERILOTNO
      ,[PLNUNRSRVAMOUNT] = @PLNUNRSRVAMOUNT
      ,[PORDCLSPLNUNRSRVAMNT] = @PORDCLSPLNUNRSRVAMNT
      ,[LPRODRSRVSTAT] = @LPRODRSRVSTAT
      ,[FALINKTYPE] = @FALINKTYPE
      ,[DEDUCTCODE] = @DEDUCTCODE
      ,[UPDTHISLINE] = @UPDTHISLINE
      ,[VATEXCEPTCODE] = @VATEXCEPTCODE
      ,[PORDERFICHENO] = @PORDERFICHENO
      ,[QPRODFCREF] = @QPRODFCREF
      ,[RELTRANSFCREF] = @RELTRANSFCREF
      ,[ATAXEXCEPTREASON] = @ATAXEXCEPTREASON
      ,[ATAXEXCEPTCODE] = @ATAXEXCEPTCODE
      ,[PRODORDERTYP] = @PRODORDERTYP
      ,[SUBCONTORDERREF] = @SUBCONTORDERREF
      ,[QPRODFCTYP] = @QPRODFCTYP
      ,[PRDORDSLPLNRESERVE] = @PRDORDSLPLNRESERVE
      ,[INFDATE] = @INFDATE
      ,[DESTSTATUS] = @DESTSTATUS
      ,[REGTYPREF] = @REGTYPREF
      ,[FAPROFITACCREF] = @FAPROFITACCREF
      ,[FAPROFITCENTREF] = @FAPROFITCENTREF
      ,[FALOSSACCREF] = @FALOSSACCREF
      ,[FALOSSCENTREF] = @FALOSSCENTREF
      ,[CPACODE] = @CPACODE
      ,[GTIPCODE] = @GTIPCODE
      ,[PUBLICCOUNTRYREF] = @PUBLICCOUNTRYREF
      ,[QPRODITEMTYPE] = @QPRODITEMTYPE
      ,[FUTMONTHCNT] = @FUTMONTHCNT
      ,[FUTMONTHBEGDATE] = @FUTMONTHBEGDATE
      ,[QCTRANSFERREF] = @QCTRANSFERREF
      ,[QCTRANSFERAMNT] = @QCTRANSFERAMNT
      ,[FUTMONTHENDDATE] = @FUTMONTHENDDATE
      ,[KKEGACCREF] = @KKEGACCREF
      ,[KKEGCENTREF] = @KKEGCENTREF
      ,[MNTORDERFREF] = @MNTORDERFREF
      ,[FAKKEGAMOUNT] = @FAKKEGAMOUNT
      ,[MIDDLEMANEXPTYP] = @MIDDLEMANEXPTYP
      ,[EXPRACCREF] = @EXPRACCREF
      ,[EXPRCNTRREF] = @EXPRCNTRREF
      ,[KKEGVATACCREF] = @KKEGVATACCREF
      ,[KKEGVATCENTREF] = @KKEGVATCENTREF
      ,[MARKINGTAGNO] = @MARKINGTAGNO
      ,[OWNER] = @OWNER
      ,[TCKTAXNR] = @TCKTAXNR
      ,[FUTMONTHBEGDATE_] = @FUTMONTHBEGDATE_
      ,[ADDTAXVATACCREF] = @ADDTAXVATACCREF
      ,[ADDTAXVATCENREF] = @ADDTAXVATCENREF
      ,[EXPDAYS] = @EXPDAYS
      ,[CANCELLEDINVREF1] = @CANCELLEDINVREF1
      ,[CANCELLEDINVREF2] = @CANCELLEDINVREF2
      ,[CANCELLEDINVREF3] = @CANCELLEDINVREF3
      ,[CANCELLEDINVREF4] = @CANCELLEDINVREF4
      ,[FROMINTEGTYPE] = @FROMINTEGTYPE
      ,[FROMINTEGREF] = @FROMINTEGREF
      ,[TAXFREEACCREF] = @TAXFREEACCREF
      ,[TAXFREECNTRREF] = @TAXFREECNTRREF
      ,[EISRVDSTADDTAXINC] = @EISRVDSTADDTAXINC
      ,[QCTRANSFERREF2] = @QCTRANSFERREF2
      ,[QCTRANSFERAMNT2] = @QCTRANSFERAMNT2
      ,[ADDTAXINLINENET] = @ADDTAXINLINENET
      ,[ORDFICHECMREF] = @ORDFICHECMREF
      ,[ADDTAXEFFECTKDV] = @ADDTAXEFFECTKDV
      ,[ITMDISC] = @ITMDISC
      ,[ADDTAXREF] = @ADDTAXREF
 WHERE LOGICALREF = {referenceId}";
			await using (SqlCommand command = new SqlCommand(lineQuery, connection))
			{
				command.Parameters.AddWithValue(nameof(dto.DREF), dto.DREF);
				command.Parameters.AddWithValue(nameof(dto.COSTRATE), dto.COSTRATE);
				command.Parameters.AddWithValue(nameof(dto.XPRICEUPD), dto.XPRICEUPD);
				command.Parameters.AddWithValue(nameof(dto.XPRICE), dto.XPRICE);
				command.Parameters.AddWithValue(nameof(dto.XREPRATE), dto.XREPRATE);
				command.Parameters.AddWithValue(nameof(dto.DISTCOEF), dto.DISTCOEF);
				command.Parameters.AddWithValue(nameof(dto.TRANSQCOK), dto.TRANSQCOK);
				command.Parameters.AddWithValue(nameof(dto.SITEID), dto.SITEID);
				command.Parameters.AddWithValue(nameof(dto.RECSTATUS), dto.RECSTATUS);
				command.Parameters.AddWithValue(nameof(dto.ORGLOGICREF), dto.ORGLOGICREF);
				command.Parameters.AddWithValue(nameof(dto.WFSTATUS), dto.WFSTATUS);
				command.Parameters.AddWithValue(nameof(dto.POLINEREF), dto.POLINEREF);
				command.Parameters.AddWithValue(nameof(dto.PLNSTTRANSREF), dto.PLNSTTRANSREF);
				command.Parameters.AddWithValue(nameof(dto.NETDISCFLAG), dto.NETDISCFLAG);
				command.Parameters.AddWithValue(nameof(dto.NETDISCPERC), dto.NETDISCPERC);
				command.Parameters.AddWithValue(nameof(dto.NETDISCAMNT), dto.NETDISCAMNT);
				command.Parameters.AddWithValue(nameof(dto.VATCALCDIFF), dto.VATCALCDIFF);
				command.Parameters.AddWithValue(nameof(dto.CONDITIONREF), dto.CONDITIONREF);
				command.Parameters.AddWithValue(nameof(dto.DISTORDERREF), dto.DISTORDERREF);
				command.Parameters.AddWithValue(nameof(dto.DISTORDLINEREF), dto.DISTORDLINEREF);
				command.Parameters.AddWithValue(nameof(dto.CAMPAIGNREFS1), dto.CAMPAIGNREFS1);
				command.Parameters.AddWithValue(nameof(dto.CAMPAIGNREFS2), dto.CAMPAIGNREFS2);
				command.Parameters.AddWithValue(nameof(dto.CAMPAIGNREFS3), dto.CAMPAIGNREFS3);
				command.Parameters.AddWithValue(nameof(dto.CAMPAIGNREFS4), dto.CAMPAIGNREFS4);
				command.Parameters.AddWithValue(nameof(dto.CAMPAIGNREFS5), dto.CAMPAIGNREFS5);
				command.Parameters.AddWithValue(nameof(dto.POINTCAMPREF), dto.POINTCAMPREF);
				command.Parameters.AddWithValue(nameof(dto.CAMPPOINT), dto.CAMPPOINT);
				command.Parameters.AddWithValue(nameof(dto.PROMCLASITEMREF), dto.PROMCLASITEMREF);
				command.Parameters.AddWithValue(nameof(dto.CMPGLINEREF), dto.CMPGLINEREF);
				command.Parameters.AddWithValue(nameof(dto.PLNSTTRANSPERNR), dto.PLNSTTRANSPERNR);
				command.Parameters.AddWithValue(nameof(dto.PORDCLSPLNAMNT), dto.PORDCLSPLNAMNT);
				command.Parameters.AddWithValue(nameof(dto.VENDCOMM), dto.VENDCOMM);
				command.Parameters.AddWithValue(nameof(dto.PREVIOUSOUTCOST), dto.PREVIOUSOUTCOST);
				command.Parameters.AddWithValue(nameof(dto.COSTOFSALEACCREF), dto.COSTOFSALEACCREF);
				command.Parameters.AddWithValue(nameof(dto.PURCHACCREF), dto.PURCHACCREF);
				command.Parameters.AddWithValue(nameof(dto.COSTOFSALECNTREF), dto.COSTOFSALECNTREF);
				command.Parameters.AddWithValue(nameof(dto.PURCHCENTREF), dto.PURCHCENTREF);
				command.Parameters.AddWithValue(nameof(dto.PREVOUTCOSTCURR), dto.PREVOUTCOSTCURR);
				command.Parameters.AddWithValue(nameof(dto.ABVATAMOUNT), dto.ABVATAMOUNT);
				command.Parameters.AddWithValue(nameof(dto.ABVATSTATUS), dto.ABVATSTATUS);
				command.Parameters.AddWithValue(nameof(dto.PRRATE), dto.PRRATE);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXRATE), dto.ADDTAXRATE);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXCONVFACT), dto.ADDTAXCONVFACT);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXAMOUNT), dto.ADDTAXAMOUNT);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXPRCOST), dto.ADDTAXPRCOST);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXRETCOST), dto.ADDTAXRETCOST);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXRETCOSTCURR), dto.ADDTAXRETCOSTCURR);
				command.Parameters.AddWithValue(nameof(dto.GROSSUINFO1), dto.GROSSUINFO1);
				command.Parameters.AddWithValue(nameof(dto.GROSSUINFO2), dto.GROSSUINFO2);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXPRCOSTCURR), dto.ADDTAXPRCOSTCURR);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXACCREF), dto.ADDTAXACCREF);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXCENTERREF), dto.ADDTAXCENTERREF);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXAMNTISUPD), dto.ADDTAXAMNTISUPD);
				command.Parameters.AddWithValue(nameof(dto.INFIDX), dto.INFIDX);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXCOSACCREF), dto.ADDTAXCOSACCREF);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXCOSCNTREF), dto.ADDTAXCOSCNTREF);
				command.Parameters.AddWithValue(nameof(dto.PREVIOUSATAXPRCOST), dto.PREVIOUSATAXPRCOST);
				command.Parameters.AddWithValue(nameof(dto.PREVATAXPRCOSTCURR), dto.PREVATAXPRCOSTCURR);
				command.Parameters.AddWithValue(nameof(dto.PRDORDTOTCOEF), dto.PRDORDTOTCOEF);
				command.Parameters.AddWithValue(nameof(dto.DEMPEGGEDAMNT), dto.DEMPEGGEDAMNT);
				command.Parameters.AddWithValue(nameof(dto.STDUNITCOST), dto.STDUNITCOST);
				command.Parameters.AddWithValue(nameof(dto.STDRPUNITCOST), dto.STDRPUNITCOST);
				command.Parameters.AddWithValue(nameof(dto.COSTDIFFACCREF), dto.COSTDIFFACCREF);
				command.Parameters.AddWithValue(nameof(dto.COSTDIFFCENREF), dto.COSTDIFFCENREF);
				command.Parameters.AddWithValue(nameof(dto.TEXTINC), dto.TEXTINC);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXDISCAMOUNT), dto.ADDTAXDISCAMOUNT);
				command.Parameters.AddWithValue(nameof(dto.ORGLOGOID), dto.ORGLOGOID);
				command.Parameters.AddWithValue(nameof(dto.EXIMFICHENO), dto.EXIMFICHENO);
				command.Parameters.AddWithValue(nameof(dto.EXIMFCTYPE), dto.EXIMFCTYPE);
				command.Parameters.AddWithValue(nameof(dto.TRANSEXPLINE), dto.TRANSEXPLINE);
				command.Parameters.AddWithValue(nameof(dto.INSEXPLINE), dto.INSEXPLINE);
				command.Parameters.AddWithValue(nameof(dto.EXIMWHFCREF), dto.EXIMWHFCREF);
				command.Parameters.AddWithValue(nameof(dto.EXIMWHLNREF), dto.EXIMWHLNREF);
				command.Parameters.AddWithValue(nameof(dto.EXIMFILEREF), dto.EXIMFILEREF);
				command.Parameters.AddWithValue(nameof(dto.EXIMPROCNR), dto.EXIMPROCNR);
				command.Parameters.AddWithValue(nameof(dto.EISRVDSTTYP), dto.EISRVDSTTYP);
				command.Parameters.AddWithValue(nameof(dto.MAINSTLNREF), dto.MAINSTLNREF);
				command.Parameters.AddWithValue(nameof(dto.MADEOFSHRED), dto.MADEOFSHRED);
				command.Parameters.AddWithValue(nameof(dto.FROMORDWITHPAY), dto.FROMORDWITHPAY);
				command.Parameters.AddWithValue(nameof(dto.PROJECTREF), dto.PROJECTREF);
				command.Parameters.AddWithValue(nameof(dto.STATUS), dto.STATUS);
				command.Parameters.AddWithValue(nameof(dto.DORESERVE), dto.DORESERVE);
				command.Parameters.AddWithValue(nameof(dto.POINTCAMPREFS1), dto.POINTCAMPREFS1);
				command.Parameters.AddWithValue(nameof(dto.POINTCAMPREFS2), dto.POINTCAMPREFS2);
				command.Parameters.AddWithValue(nameof(dto.POINTCAMPREFS3), dto.POINTCAMPREFS3);
				command.Parameters.AddWithValue(nameof(dto.POINTCAMPREFS4), dto.POINTCAMPREFS4);
				command.Parameters.AddWithValue(nameof(dto.CAMPPOINTS1), dto.CAMPPOINTS1);
				command.Parameters.AddWithValue(nameof(dto.CAMPPOINTS2), dto.CAMPPOINTS2);
				command.Parameters.AddWithValue(nameof(dto.CAMPPOINTS3), dto.CAMPPOINTS3);
				command.Parameters.AddWithValue(nameof(dto.CAMPPOINTS4), dto.CAMPPOINTS4);
				command.Parameters.AddWithValue(nameof(dto.CMPGLINEREFS1), dto.CMPGLINEREFS1);
				command.Parameters.AddWithValue(nameof(dto.CMPGLINEREFS2), dto.CMPGLINEREFS2);
				command.Parameters.AddWithValue(nameof(dto.CMPGLINEREFS3), dto.CMPGLINEREFS3);
				command.Parameters.AddWithValue(nameof(dto.CMPGLINEREFS4), dto.CMPGLINEREFS4);
				command.Parameters.AddWithValue(nameof(dto.PRCLISTREF), dto.PRCLISTREF);
				command.Parameters.AddWithValue(nameof(dto.PORDSYMOUTLN), dto.PORDSYMOUTLN);
				command.Parameters.AddWithValue(nameof(dto.MONTH_), dto.MONTH_);
				command.Parameters.AddWithValue(nameof(dto.YEAR_), dto.YEAR_);
				command.Parameters.AddWithValue(nameof(dto.EXADDTAXRATE), dto.EXADDTAXRATE);
				command.Parameters.AddWithValue(nameof(dto.EXADDTAXCONVF), dto.EXADDTAXCONVF);
				command.Parameters.AddWithValue(nameof(dto.EXADDTAXAREF), dto.EXADDTAXAREF);
				command.Parameters.AddWithValue(nameof(dto.EXADDTAXCREF), dto.EXADDTAXCREF);
				command.Parameters.AddWithValue(nameof(dto.OTHRADDTAXAREF), dto.OTHRADDTAXAREF);
				command.Parameters.AddWithValue(nameof(dto.OTHRADDTAXCREF), dto.OTHRADDTAXCREF);
				command.Parameters.AddWithValue(nameof(dto.EXADDTAXAMNT), dto.EXADDTAXAMNT);
				command.Parameters.AddWithValue(nameof(dto.AFFECTCOLLATRL), dto.AFFECTCOLLATRL);
				command.Parameters.AddWithValue(nameof(dto.ALTPROMFLAG), dto.ALTPROMFLAG);
				command.Parameters.AddWithValue(nameof(dto.EIDISTFLNNR), dto.EIDISTFLNNR);
				command.Parameters.AddWithValue(nameof(dto.EXIMTYPE), dto.EXIMTYPE);
				command.Parameters.AddWithValue(nameof(dto.VARIANTREF), dto.VARIANTREF);
				command.Parameters.AddWithValue(nameof(dto.CANDEDUCT), dto.CANDEDUCT);
				command.Parameters.AddWithValue(nameof(dto.OUTREMAMNT), dto.OUTREMAMNT);
				command.Parameters.AddWithValue(nameof(dto.OUTREMCOST), dto.OUTREMCOST);
				command.Parameters.AddWithValue(nameof(dto.OUTREMCOSTCURR), dto.OUTREMCOSTCURR);
				command.Parameters.AddWithValue(nameof(dto.REFLVATACCREF), dto.REFLVATACCREF);
				command.Parameters.AddWithValue(nameof(dto.REFLVATOTHACCREF), dto.REFLVATOTHACCREF);
				command.Parameters.AddWithValue(nameof(dto.PARENTLNREF), dto.PARENTLNREF);
				command.Parameters.AddWithValue(nameof(dto.AFFECTRISK), dto.AFFECTRISK);
				command.Parameters.AddWithValue(nameof(dto.INEFFECTIVECOST), dto.INEFFECTIVECOST);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXVATMATRAH), dto.ADDTAXVATMATRAH);
				command.Parameters.AddWithValue(nameof(dto.REFLACCREF), dto.REFLACCREF);
				command.Parameters.AddWithValue(nameof(dto.REFLOTHACCREF), dto.REFLOTHACCREF);
				command.Parameters.AddWithValue(nameof(dto.CAMPPAYDEFREF), dto.CAMPPAYDEFREF);
				command.Parameters.AddWithValue(nameof(dto.FAREGBINDDATE), dto.FAREGBINDDATE);
				command.Parameters.AddWithValue(nameof(dto.RELTRANSLNREF), dto.RELTRANSLNREF);
				command.Parameters.AddWithValue(nameof(dto.FROMTRANSFER), dto.FROMTRANSFER);
				command.Parameters.AddWithValue(nameof(dto.COSTDISTPRICE), dto.COSTDISTPRICE);
				command.Parameters.AddWithValue(nameof(dto.COSTDISTREPPRICE), dto.COSTDISTREPPRICE);
				command.Parameters.AddWithValue(nameof(dto.DIFFPRICEUFRS), dto.DIFFPRICEUFRS);
				command.Parameters.AddWithValue(nameof(dto.DIFFREPPRICEUFRS), dto.DIFFREPPRICEUFRS);
				command.Parameters.AddWithValue(nameof(dto.OUTCOSTUFRS), dto.OUTCOSTUFRS);
				command.Parameters.AddWithValue(nameof(dto.OUTCOSTCURRUFRS), dto.OUTCOSTCURRUFRS);
				command.Parameters.AddWithValue(nameof(dto.DIFFPRCOSTUFRS), dto.DIFFPRCOSTUFRS);
				command.Parameters.AddWithValue(nameof(dto.DIFFPRCRCOSTUFRS), dto.DIFFPRCRCOSTUFRS);
				command.Parameters.AddWithValue(nameof(dto.RETCOSTUFRS), dto.RETCOSTUFRS);
				command.Parameters.AddWithValue(nameof(dto.RETCOSTCURRUFRS), dto.RETCOSTCURRUFRS);
				command.Parameters.AddWithValue(nameof(dto.OUTREMCOSTUFRS), dto.OUTREMCOSTUFRS);
				command.Parameters.AddWithValue(nameof(dto.OUTREMCOSTCURRUFRS), dto.OUTREMCOSTCURRUFRS);
				command.Parameters.AddWithValue(nameof(dto.INFIDXUFRS), dto.INFIDXUFRS);
				command.Parameters.AddWithValue(nameof(dto.ADJPRICEUFRS), dto.ADJPRICEUFRS);
				command.Parameters.AddWithValue(nameof(dto.ADJREPPRICEUFRS), dto.ADJREPPRICEUFRS);
				command.Parameters.AddWithValue(nameof(dto.ADJPRCOSTUFRS), dto.ADJPRCOSTUFRS);
				command.Parameters.AddWithValue(nameof(dto.ADJPRCRCOSTUFRS), dto.ADJPRCRCOSTUFRS);
				command.Parameters.AddWithValue(nameof(dto.COSTDISTPRICEUFRS), dto.COSTDISTPRICEUFRS);
				command.Parameters.AddWithValue(nameof(dto.COSTDISTREPPRICEUFRS), dto.COSTDISTREPPRICEUFRS);
				command.Parameters.AddWithValue(nameof(dto.PURCHACCREFUFRS), dto.PURCHACCREFUFRS);
				command.Parameters.AddWithValue(nameof(dto.PURCHCENTREFUFRS), dto.PURCHCENTREFUFRS);
				command.Parameters.AddWithValue(nameof(dto.COSACCREFUFRS), dto.COSACCREFUFRS);
				command.Parameters.AddWithValue(nameof(dto.COSCNTREFUFRS), dto.COSCNTREFUFRS);
				command.Parameters.AddWithValue(nameof(dto.PROUTCOSTUFRSDIFF), dto.PROUTCOSTUFRSDIFF);
				command.Parameters.AddWithValue(nameof(dto.PROUTCOSTCRUFRSDIFF), dto.PROUTCOSTCRUFRSDIFF);
				command.Parameters.AddWithValue(nameof(dto.UNDERDEDUCTLIMIT), dto.UNDERDEDUCTLIMIT);
				command.Parameters.AddWithValue(nameof(dto.GLOBALID), dto.GLOBALID);
				command.Parameters.AddWithValue(nameof(dto.DEDUCTIONPART1), dto.DEDUCTIONPART1);
				command.Parameters.AddWithValue(nameof(dto.DEDUCTIONPART2), dto.DEDUCTIONPART2);
				command.Parameters.AddWithValue(nameof(dto.GUID), dto.GUID);
				command.Parameters.AddWithValue(nameof(dto.SPECODE2), dto.SPECODE2);
				command.Parameters.AddWithValue(nameof(dto.OFFERREF), dto.OFFERREF);
				command.Parameters.AddWithValue(nameof(dto.OFFTRANSREF), dto.OFFTRANSREF);
				command.Parameters.AddWithValue(nameof(dto.VATEXCEPTREASON), dto.VATEXCEPTREASON);
				command.Parameters.AddWithValue(nameof(dto.PLNDEFSERILOTNO), dto.PLNDEFSERILOTNO);
				command.Parameters.AddWithValue(nameof(dto.PLNUNRSRVAMOUNT), dto.PLNUNRSRVAMOUNT);
				command.Parameters.AddWithValue(nameof(dto.PORDCLSPLNUNRSRVAMNT), dto.PORDCLSPLNUNRSRVAMNT);
				command.Parameters.AddWithValue(nameof(dto.LPRODRSRVSTAT), dto.LPRODRSRVSTAT);
				command.Parameters.AddWithValue(nameof(dto.FALINKTYPE), dto.FALINKTYPE);
				command.Parameters.AddWithValue(nameof(dto.DEDUCTCODE), dto.DEDUCTCODE);
				command.Parameters.AddWithValue(nameof(dto.UPDTHISLINE), dto.UPDTHISLINE);
				command.Parameters.AddWithValue(nameof(dto.VATEXCEPTCODE), dto.VATEXCEPTCODE);
				command.Parameters.AddWithValue(nameof(dto.PORDERFICHENO), dto.PORDERFICHENO);
				command.Parameters.AddWithValue(nameof(dto.QPRODFCREF), dto.QPRODFCREF);
				command.Parameters.AddWithValue(nameof(dto.RELTRANSFCREF), dto.RELTRANSFCREF);
				command.Parameters.AddWithValue(nameof(dto.ATAXEXCEPTREASON), dto.ATAXEXCEPTREASON);
				command.Parameters.AddWithValue(nameof(dto.ATAXEXCEPTCODE), dto.ATAXEXCEPTCODE);
				command.Parameters.AddWithValue(nameof(dto.PRODORDERTYP), dto.PRODORDERTYP);
				command.Parameters.AddWithValue(nameof(dto.SUBCONTORDERREF), dto.SUBCONTORDERREF);
				command.Parameters.AddWithValue(nameof(dto.QPRODFCTYP), dto.QPRODFCTYP);
				command.Parameters.AddWithValue(nameof(dto.PRDORDSLPLNRESERVE), dto.PRDORDSLPLNRESERVE);
				command.Parameters.AddWithValue(nameof(dto.INFDATE), dto.INFDATE);
				command.Parameters.AddWithValue(nameof(dto.DESTSTATUS), dto.DESTSTATUS);
				command.Parameters.AddWithValue(nameof(dto.REGTYPREF), dto.REGTYPREF);
				command.Parameters.AddWithValue(nameof(dto.FAPROFITACCREF), dto.FAPROFITACCREF);
				command.Parameters.AddWithValue(nameof(dto.FAPROFITCENTREF), dto.FAPROFITCENTREF);
				command.Parameters.AddWithValue(nameof(dto.FALOSSACCREF), dto.FALOSSACCREF);
				command.Parameters.AddWithValue(nameof(dto.FALOSSCENTREF), dto.FALOSSCENTREF);
				command.Parameters.AddWithValue(nameof(dto.CPACODE), dto.CPACODE);
				command.Parameters.AddWithValue(nameof(dto.GTIPCODE), dto.GTIPCODE);
				command.Parameters.AddWithValue(nameof(dto.PUBLICCOUNTRYREF), dto.PUBLICCOUNTRYREF);
				command.Parameters.AddWithValue(nameof(dto.QPRODITEMTYPE), dto.QPRODITEMTYPE);
				command.Parameters.AddWithValue(nameof(dto.FUTMONTHCNT), dto.FUTMONTHCNT);
				command.Parameters.AddWithValue(nameof(dto.FUTMONTHBEGDATE), dto.FUTMONTHBEGDATE);
				command.Parameters.AddWithValue(nameof(dto.QCTRANSFERREF), dto.QCTRANSFERREF);
				command.Parameters.AddWithValue(nameof(dto.QCTRANSFERAMNT), dto.QCTRANSFERAMNT);
				command.Parameters.AddWithValue(nameof(dto.FUTMONTHENDDATE), dto.FUTMONTHENDDATE);
				command.Parameters.AddWithValue(nameof(dto.KKEGACCREF), dto.KKEGACCREF);
				command.Parameters.AddWithValue(nameof(dto.KKEGCENTREF), dto.KKEGCENTREF);
				command.Parameters.AddWithValue(nameof(dto.MNTORDERFREF), dto.MNTORDERFREF);
				command.Parameters.AddWithValue(nameof(dto.FAKKEGAMOUNT), dto.FAKKEGAMOUNT);
				command.Parameters.AddWithValue(nameof(dto.MIDDLEMANEXPTYP), dto.MIDDLEMANEXPTYP);
				command.Parameters.AddWithValue(nameof(dto.EXPRACCREF), dto.EXPRACCREF);
				command.Parameters.AddWithValue(nameof(dto.EXPRCNTRREF), dto.EXPRCNTRREF);
				command.Parameters.AddWithValue(nameof(dto.KKEGVATACCREF), dto.KKEGVATACCREF);
				command.Parameters.AddWithValue(nameof(dto.KKEGVATCENTREF), dto.KKEGVATCENTREF);
				command.Parameters.AddWithValue(nameof(dto.MARKINGTAGNO), dto.MARKINGTAGNO);
				command.Parameters.AddWithValue(nameof(dto.OWNER), dto.OWNER);
				command.Parameters.AddWithValue(nameof(dto.TCKTAXNR), dto.TCKTAXNR);
				command.Parameters.AddWithValue(nameof(dto.FUTMONTHBEGDATE_), dto.FUTMONTHBEGDATE_);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXVATACCREF), dto.ADDTAXVATACCREF);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXVATCENREF), dto.ADDTAXVATCENREF);
				command.Parameters.AddWithValue(nameof(dto.EXPDAYS), dto.EXPDAYS);
				command.Parameters.AddWithValue(nameof(dto.CANCELLEDINVREF1), dto.CANCELLEDINVREF1);
				command.Parameters.AddWithValue(nameof(dto.CANCELLEDINVREF2), dto.CANCELLEDINVREF2);
				command.Parameters.AddWithValue(nameof(dto.CANCELLEDINVREF3), dto.CANCELLEDINVREF3);
				command.Parameters.AddWithValue(nameof(dto.CANCELLEDINVREF4), dto.CANCELLEDINVREF4);
				command.Parameters.AddWithValue(nameof(dto.FROMINTEGTYPE), dto.FROMINTEGTYPE);
				command.Parameters.AddWithValue(nameof(dto.FROMINTEGREF), dto.FROMINTEGREF);
				command.Parameters.AddWithValue(nameof(dto.TAXFREEACCREF), dto.TAXFREEACCREF);
				command.Parameters.AddWithValue(nameof(dto.TAXFREECNTRREF), dto.TAXFREECNTRREF);
				command.Parameters.AddWithValue(nameof(dto.EISRVDSTADDTAXINC), dto.EISRVDSTADDTAXINC);
				command.Parameters.AddWithValue(nameof(dto.QCTRANSFERREF2), dto.QCTRANSFERREF2);
				command.Parameters.AddWithValue(nameof(dto.QCTRANSFERAMNT2), dto.QCTRANSFERAMNT2);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXINLINENET), dto.ADDTAXINLINENET);
				command.Parameters.AddWithValue(nameof(dto.ORDFICHECMREF), dto.ORDFICHECMREF);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXEFFECTKDV), dto.ADDTAXEFFECTKDV);
				command.Parameters.AddWithValue(nameof(dto.ITMDISC), dto.ITMDISC);
				command.Parameters.AddWithValue(nameof(dto.ADDTAXREF), dto.ADDTAXREF);

				await command.ExecuteNonQueryAsync();

				result.IsSuccess = true;
				result.Message = "Satır başarıyla eklendi.";
				await connection.CloseAsync();
				return result;
			}
		}
		catch (Exception)
		{
			throw;
		}
	}
}