﻿namespace Helix.LBSService.WebAPI.Models
{
	public class LG_STLINE
	{
		#region Properties
		public int LOGICALREF { get; set; } = default;
		public int STOCKREF { get; set; } = default;
		public short LINETYPE { get; set; } = default;
		public int PREVLINEREF { get; set; } = default;
		public short PREVLINENO { get; set; } = default;
		public short DETLINE { get; set; } = default;
		public short TRCODE { get; set; } = default;
		public DateTime DATE_ { get; set; } = DateTime.Now;
		public int FTIME { get; set; } = default;
		public short GLOBTRANS { get; set; } = default;
		public short CALCTYPE { get; set; } = default;
		public int PRODORDERREF { get; set; } = default;
		public short SOURCETYPE { get; set; } = default;
		public short SOURCEINDEX { get; set; } = default;
		public short SOURCECOSTGRP { get; set; } = default;
		public int SOURCEWSREF { get; set; } = default;
		public int SOURCEPOLNREF { get; set; } = default;
		public short DESTTYPE { get; set; } = default;
		public short DESTINDEX { get; set; } = default;
		public short DESTCOSTGRP { get; set; } = default;
		public int DESTWSREF { get; set; } = default;
		public int DESTPOLNREF { get; set; } = default;
		public short FACTORYNR { get; set; } = default;
		public short IOCODE { get; set; } = default;
		public int STFICHEREF { get; set; } = default;
		public short STFICHELNNO { get; set; } = default;
		public int INVOICEREF { get; set; } = default;
		public short INVOICELNNO { get; set; } = default;
		public int CLIENTREF { get; set; } = default;
		public int ORDTRANSREF { get; set; } = default;
		public int ORDFICHEREF { get; set; } = default;
		public int CENTERREF { get; set; } = default;
		public int ACCOUNTREF { get; set; } = default;
		public int VATACCREF { get; set; } = default;
		public int VATCENTERREF { get; set; } = default;
		public int PRACCREF { get; set; } = default;
		public int PRCENTERREF { get; set; } = default;
		public int PRVATACCREF { get; set; } = default;
		public int PRVATCENREF { get; set; } = default;
		public int PROMREF { get; set; } = default;
		public int PAYDEFREF { get; set; } = default;
		public string SPECODE { get; set; } = string.Empty;
		public string DELVRYCODE { get; set; } = string.Empty;
		public double AMOUNT { get; set; } = default;
		public double PRICE { get; set; } = default;
		public double TOTAL { get; set; } = default;
		public short PRCURR { get; set; } = default;
		public double PRPRICE { get; set; } = default;
		public short TRCURR { get; set; } = default;
		public double TRRATE { get; set; } = default;
		public double REPORTRATE { get; set; } = default;
		public double DISTCOST { get; set; } = default;
		public double DISTDISC { get; set; } = default;
		public double DISTEXP { get; set; } = default;
		public double DISTPROM { get; set; } = default;
		public double DISCPER { get; set; } = default;
		public string LINEEXP { get; set; } = string.Empty;
		public int UOMREF { get; set; } = default;
		public int USREF { get; set; } = default;
		public double UINFO1 { get; set; } = default;
		public double UINFO2 { get; set; } = default;
		public double UINFO3 { get; set; } = default;
		public double UINFO4 { get; set; } = default;
		public double UINFO5 { get; set; } = default;
		public double UINFO6 { get; set; } = default;
		public double UINFO7 { get; set; } = default;
		public double UINFO8 { get; set; } = default;
		public double PLNAMOUNT { get; set; } = default;
		public short VATINC { get; set; } = default;
		public double VAT { get; set; } = default;
		public double VATAMNT { get; set; } = default;
		public double VATMATRAH { get; set; } = default;
		public int BILLEDITEM { get; set; } = default;
		public short BILLED { get; set; } = default;
		public short CPSTFLAG { get; set; } = default;
		public short RETCOSTTYPE { get; set; } = default;
		public int SOURCELINK { get; set; } = default;
		public double RETCOST { get; set; } = default;
		public double RETCOSTCURR { get; set; } = default;
		public double OUTCOST { get; set; } = default;
		public double OUTCOSTCURR { get; set; } = default;
		public double RETAMOUNT { get; set; } = default;
		public int FAREGREF { get; set; } = default;
		public short FAATTRIB { get; set; } = default;
		public short CANCELLED { get; set; } = default;
		public double LINENET { get; set; } = default;
		public double DISTADDEXP { get; set; } = default;
		public int FADACCREF { get; set; } = default;
		public int FADCENTERREF { get; set; } = default;
		public int FARACCREF { get; set; } = default;
		public int FARCENTERREF { get; set; } = default;
		public double DIFFPRICE { get; set; } = default;
		public double DIFFPRCOST { get; set; } = default;
		public short DECPRDIFF { get; set; } = default;
		public short LPRODSTAT { get; set; } = default;
		public double PRDEXPTOTAL { get; set; } = default;
		public double DIFFREPPRICE { get; set; } = default;
		public double DIFFPRCRCOST { get; set; } = default;
		public int SALESMANREF { get; set; } = default;
		public int FAPLACCREF { get; set; } = default;
		public int FAPLCENTERREF { get; set; } = default;
		public string OUTPUTIDCODE { get; set; } = string.Empty;
		public int DREF { get; set; } = default;
		public double COSTRATE { get; set; } = default;
		public short XPRICEUPD { get; set; } = default;
		public double XPRICE { get; set; } = default;
		public double XREPRATE { get; set; } = default;
		public double DISTCOEF { get; set; } = default;
		public short TRANSQCOK { get; set; } = default;
		public short SITEID { get; set; } = default;
		public short RECSTATUS { get; set; } = default;
		public int ORGLOGICREF { get; set; } = default;
		public int WFSTATUS { get; set; } = default;
		public int POLINEREF { get; set; } = default;
		public int PLNSTTRANSREF { get; set; } = default;
		public short NETDISCFLAG { get; set; } = default;
		public double NETDISCPERC { get; set; } = default;
		public double NETDISCAMNT { get; set; } = default;
		public double VATCALCDIFF { get; set; } = default;
		public int CONDITIONREF { get; set; } = default;
		public int DISTORDERREF { get; set; } = default;
		public int DISTORDLINEREF { get; set; } = default;
		public int CAMPAIGNREFS1 { get; set; } = default;
		public int CAMPAIGNREFS2 { get; set; } = default;
		public int CAMPAIGNREFS3 { get; set; } = default;
		public int CAMPAIGNREFS4 { get; set; } = default;
		public int CAMPAIGNREFS5 { get; set; } = default;
		public int POINTCAMPREF { get; set; } = default;
		public double CAMPPOINT { get; set; } = default;
		public int PROMCLASITEMREF { get; set; } = default;
		public int CMPGLINEREF { get; set; } = default;
		public int PLNSTTRANSPERNR { get; set; } = default;
		public double PORDCLSPLNAMNT { get; set; } = default;
		public double VENDCOMM { get; set; } = default;
		public double PREVIOUSOUTCOST { get; set; } = default;
		public int COSTOFSALEACCREF { get; set; } = default;
		public int PURCHACCREF { get; set; } = default;
		public int COSTOFSALECNTREF { get; set; } = default;
		public int PURCHCENTREF { get; set; } = default;
		public double PREVOUTCOSTCURR { get; set; } = default;
		public double ABVATAMOUNT { get; set; } = default;
		public int ABVATSTATUS { get; set; } = default;
		public double PRRATE { get; set; } = default;
		public double ADDTAXRATE { get; set; } = default;
		public double ADDTAXCONVFACT { get; set; } = default;
		public double ADDTAXAMOUNT { get; set; } = default;
		public double ADDTAXPRCOST { get; set; } = default;
		public double ADDTAXRETCOST { get; set; } = default;
		public double ADDTAXRETCOSTCURR { get; set; } = default;
		public double GROSSUINFO1 { get; set; } = default;
		public double GROSSUINFO2 { get; set; } = default;
		public double ADDTAXPRCOSTCURR { get; set; } = default;
		public int ADDTAXACCREF { get; set; } = default;
		public int ADDTAXCENTERREF { get; set; } = default;
		public short ADDTAXAMNTISUPD { get; set; } = default;
		public double INFIDX { get; set; } = default;
		public int ADDTAXCOSACCREF { get; set; } = default;
		public int ADDTAXCOSCNTREF { get; set; } = default;
		public double PREVIOUSATAXPRCOST { get; set; } = default;
		public double PREVATAXPRCOSTCURR { get; set; } = default;
		public double PRDORDTOTCOEF { get; set; } = default;
		public double DEMPEGGEDAMNT { get; set; } = default;
		public double STDUNITCOST { get; set; } = default;
		public double STDRPUNITCOST { get; set; } = default;
		public int COSTDIFFACCREF { get; set; } = default;
		public int COSTDIFFCENREF { get; set; } = default;
		public short TEXTINC { get; set; } = default;
		public double ADDTAXDISCAMOUNT { get; set; } = default;
		public string ORGLOGOID { get; set; } = string.Empty;
		public string EXIMFICHENO { get; set; } = string.Empty;
		public short EXIMFCTYPE { get; set; } = default;
		public short TRANSEXPLINE { get; set; } = default;
		public short INSEXPLINE { get; set; } = default;
		public int EXIMWHFCREF { get; set; } = default;
		public int EXIMWHLNREF { get; set; } = default;
		public int EXIMFILEREF { get; set; } = default;
		public short EXIMPROCNR { get; set; } = default;
		public short EISRVDSTTYP { get; set; } = default;
		public int MAINSTLNREF { get; set; } = default;
		public short MADEOFSHRED { get; set; } = default;
		public short FROMORDWITHPAY { get; set; } = default;
		public int PROJECTREF { get; set; } = default;
		public short STATUS { get; set; } = default;
		public short DORESERVE { get; set; } = default;
		public int POINTCAMPREFS1 { get; set; } = default;
		public int POINTCAMPREFS2 { get; set; } = default;
		public int POINTCAMPREFS3 { get; set; } = default;
		public int POINTCAMPREFS4 { get; set; } = default;
		public double CAMPPOINTS1 { get; set; } = default;
		public double CAMPPOINTS2 { get; set; } = default;
		public double CAMPPOINTS3 { get; set; } = default;
		public double CAMPPOINTS4 { get; set; } = default;
		public int CMPGLINEREFS1 { get; set; } = default;
		public int CMPGLINEREFS2 { get; set; } = default;
		public int CMPGLINEREFS3 { get; set; } = default;
		public int CMPGLINEREFS4 { get; set; } = default;
		public int PRCLISTREF { get; set; } = default;
		public short PORDSYMOUTLN { get; set; } = default;
		public short MONTH_ { get; set; } = default;
		public short YEAR_ { get; set; } = default;
		public double EXADDTAXRATE { get; set; } = default;
		public double EXADDTAXCONVF { get; set; } = default;
		public int EXADDTAXAREF { get; set; } = default;
		public int EXADDTAXCREF { get; set; } = default;
		public int OTHRADDTAXAREF { get; set; } = default;
		public int OTHRADDTAXCREF { get; set; } = default;
		public double EXADDTAXAMNT { get; set; } = default;
		public short AFFECTCOLLATRL { get; set; } = default;
		public short ALTPROMFLAG { get; set; } = default;
		public short EIDISTFLNNR { get; set; } = default;
		public short EXIMTYPE { get; set; } = default;
		public int VARIANTREF { get; set; } = default;
		public short CANDEDUCT { get; set; } = default;
		public double OUTREMAMNT { get; set; } = default;
		public double OUTREMCOST { get; set; } = default;
		public double OUTREMCOSTCURR { get; set; } = default;
		public int REFLVATACCREF { get; set; } = default;
		public int REFLVATOTHACCREF { get; set; } = default;
		public int PARENTLNREF { get; set; } = default;
		public short AFFECTRISK { get; set; } = default;
		public short INEFFECTIVECOST { get; set; } = default;
		public double ADDTAXVATMATRAH { get; set; } = default;
		public int REFLACCREF { get; set; } = default;
		public int REFLOTHACCREF { get; set; } = default;
		public int CAMPPAYDEFREF { get; set; } = default;
		public DateTime FAREGBINDDATE { get; set; } = DateTime.Now;
		public int RELTRANSLNREF { get; set; } = default;
		public short FROMTRANSFER { get; set; } = default;
		public double COSTDISTPRICE { get; set; } = default;
		public double COSTDISTREPPRICE { get; set; } = default;
		public double DIFFPRICEUFRS { get; set; } = default;
		public double DIFFREPPRICEUFRS { get; set; } = default;
		public double OUTCOSTUFRS { get; set; } = default;
		public double OUTCOSTCURRUFRS { get; set; } = default;
		public double DIFFPRCOSTUFRS { get; set; } = default;
		public double DIFFPRCRCOSTUFRS { get; set; } = default;
		public double RETCOSTUFRS { get; set; } = default;
		public double RETCOSTCURRUFRS { get; set; } = default;
		public double OUTREMCOSTUFRS { get; set; } = default;
		public double OUTREMCOSTCURRUFRS { get; set; } = default;
		public double INFIDXUFRS { get; set; } = default;
		public double ADJPRICEUFRS { get; set; } = default;
		public double ADJREPPRICEUFRS { get; set; } = default;
		public double ADJPRCOSTUFRS { get; set; } = default;
		public double ADJPRCRCOSTUFRS { get; set; } = default;
		public double COSTDISTPRICEUFRS { get; set; } = default;
		public double COSTDISTREPPRICEUFRS { get; set; } = default;
		public int PURCHACCREFUFRS { get; set; } = default;
		public int PURCHCENTREFUFRS { get; set; } = default;
		public int COSACCREFUFRS { get; set; } = default;
		public int COSCNTREFUFRS { get; set; } = default;
		public double PROUTCOSTUFRSDIFF { get; set; } = default;
		public double PROUTCOSTCRUFRSDIFF { get; set; } = default;
		public short UNDERDEDUCTLIMIT { get; set; } = default;
		public string GLOBALID { get; set; } = string.Empty;
		public short DEDUCTIONPART1 { get; set; } = default;
		public short DEDUCTIONPART2 { get; set; } = default;
		public string GUID { get; set; } = string.Empty;
		public string SPECODE2 { get; set; } = string.Empty;
		public int OFFERREF { get; set; } = default;
		public int OFFTRANSREF { get; set; } = default;
		public string VATEXCEPTREASON { get; set; } = string.Empty;
		public string PLNDEFSERILOTNO { get; set; } = string.Empty;
		public double PLNUNRSRVAMOUNT { get; set; } = default;
		public double PORDCLSPLNUNRSRVAMNT { get; set; } = default;
		public short LPRODRSRVSTAT { get; set; } = default;
		public short FALINKTYPE { get; set; } = default;
		public string DEDUCTCODE { get; set; } = string.Empty;
		public short UPDTHISLINE { get; set; } = default;
		public string VATEXCEPTCODE { get; set; } = string.Empty;
		public string PORDERFICHENO { get; set; } = string.Empty;
		public int QPRODFCREF { get; set; } = default;
		public int RELTRANSFCREF { get; set; } = default;
		public string ATAXEXCEPTREASON { get; set; } = string.Empty;
		public string ATAXEXCEPTCODE { get; set; } = string.Empty;
		public short PRODORDERTYP { get; set; } = default;
		public int SUBCONTORDERREF { get; set; } = default;
		public short QPRODFCTYP { get; set; } = default;
		public short PRDORDSLPLNRESERVE { get; set; } = default;
		public DateTime INFDATE { get; set; } = DateTime.Now;
		public short DESTSTATUS { get; set; } = default;
		public int REGTYPREF { get; set; } = default;
		public int FAPROFITACCREF { get; set; } = default;
		public int FAPROFITCENTREF { get; set; } = default;
		public int FALOSSACCREF { get; set; } = default;
		public int FALOSSCENTREF { get; set; } = default;
		public short FUTMONTHCNT { get; set; } = default;
		public int FUTMONTHBEGDATE { get; set; } = default;
		public string GTIPCODE { get; set; } = string.Empty;
		public string CPACODE { get; set; } = string.Empty;
		public short QPRODITEMTYPE { get; set; } = default;
		public int PUBLICCOUNTRYREF { get; set; } = default;
		public string MARKINGTAGNO { get; set; } = string.Empty;
		#endregion

		public LG_STLINE()
		{
			SERILOTTRANSACTIONS = new List<LG_SLTRANS>();
		}
		public IList<LG_SLTRANS> SERILOTTRANSACTIONS { get; set; }
	}
}