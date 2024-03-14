using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Models;
using Helix.LBSService.Go.Services;
using Microsoft.Data.SqlClient;

namespace Helix.LBSService.Go.DataStores;

public class LG_STLINE_Context : ILG_STLINE_Context
{
	readonly IEventBus _eventBus;
	readonly int _defaultFirmNumber = LBSParameter.FirmNumber;
	readonly int _defaultPeriodNumber = LBSParameter.Period;
	readonly string _connectionString = LBSParameter.Connection;

	public LG_STLINE_Context(IEventBus eventBus)
	{
		_eventBus = eventBus;
	}
	public async Task<DataResult<LG_STLINE>> InsertAsync(LG_STLINE line)
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
           ,BILLEDline
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
           ,PROMCLASlineREF
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
           ,QPRODlineTYPE
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
           ,@BILLEDline
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
           ,@PROMCLASlineREF
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
           ,@QPRODlineTYPE
           ,@FUTMONTHCNT
           ,@FUTMONTHBEGDATE
           
           
           ); SELECT SCOPE_IDENTITY();";

		try
		{
			await using SqlConnection connection = new SqlConnection(_connectionString);
			await using (SqlCommand command = new SqlCommand(lineQuery, connection))
			{
				#region Set Line
				command.Parameters.AddWithValue("STOCKREF", line.STOCKREF);
				command.Parameters.AddWithValue("LINETYPE", line.LINETYPE);
				command.Parameters.AddWithValue("PREVLINEREF", line.PREVLINEREF);
				command.Parameters.AddWithValue("PREVLINENO", line.PREVLINENO);
				command.Parameters.AddWithValue("DETLINE", line.DETLINE);
				command.Parameters.AddWithValue("TRCODE", line.TRCODE);
				command.Parameters.AddWithValue("DATE_", line.DATE_);
				command.Parameters.AddWithValue("FHOUR", line.DATE_.Hour);
				command.Parameters.AddWithValue("FMINUTE", line.DATE_.Minute);
				command.Parameters.AddWithValue("FSECOND", line.DATE_.Second);
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
				command.Parameters.AddWithValue("STFICHEREF", line.LOGICALREF);
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
				#endregion
				var id = await command.ExecuteScalarAsync();
				result.Data = null;
				result.IsSuccess = true;
				result.Message = "Satır başarıyla eklendi.";

                return result;
			}
		}
		catch (Exception ex)
		{

			result.Message = ex.Message;
			result.IsSuccess = false;

			return result;
		}
	}
}
