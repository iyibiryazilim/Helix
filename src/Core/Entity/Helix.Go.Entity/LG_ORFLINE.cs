namespace Helix.Go.Entity;

public class LG_ORFLINE
{
	#region Properties		
	public int LOGICALREF { get; set; }
	public int? STOCKREF { get; set; }
	public int? ORDFICHEREF { get; set; }
	public int? CLIENTREF { get; set; }
	public short? LINETYPE { get; set; }
	public int? PREVLINEREF { get; set; }
	public short? PREVLINENO { get; set; }
	public short? DETLINE { get; set; }
	public short? LINENO_ { get; set; }
	public short TRCODE { get; set; }
	public DateTime? DATE_ { get; set; }
	public int? TIME_ { get; set; }
	public short? GLOBTRANS { get; set; }
	public short? CALCTYPE { get; set; }
	public int? CENTERREF { get; set; }
	public int? ACCOUNTREF { get; set; }
	public int? VATACCREF { get; set; }
	public int? VATCENTERREF { get; set; }
	public int? PRACCREF { get; set; }
	public int? PRCENTERREF { get; set; }
	public int? PRVATACCREF { get; set; }
	public int? PRVATCENREF { get; set; }
	public int? PROMREF { get; set; }
	public string SPECODE { get; set; } = string.Empty;
	public string DELVRYCODE { get; set; } = string.Empty;
	public double AMOUNT { get; set; }
	public double? PRICE { get; set; }
	public double TOTAL { get; set; }
	public double? SHIPPEDAMOUNT { get; set; }
	public double? DISCPER { get; set; }
	public double? DISTCOST { get; set; }
	public double? DISTDISC { get; set; }
	public double? DISTEXP { get; set; }
	public double? DISTPROM { get; set; }
	public double VAT { get; set; }
	public double? VATAMNT { get; set; }
	public double? VATMATRAH { get; set; }
	public string LINEEXP { get; set; } = string.Empty;
	public int? UOMREF { get; set; }
	public int? USREF { get; set; }
	public double? UINFO1 { get; set; }
	public double? UINFO2 { get; set; }
	public double? UINFO3 { get; set; }
	public double? UINFO4 { get; set; }
	public double? UINFO5 { get; set; }
	public double? UINFO6 { get; set; }
	public double? UINFO7 { get; set; }
	public double? UINFO8 { get; set; }
	public short? VATINC { get; set; }
	public short? CLOSED { get; set; }
	public short? DORESERVE { get; set; }
	public short? INUSE { get; set; }
	public DateTime? DUEDATE { get; set; }
	public short? PRCURR { get; set; }
	public double? PRPRICE { get; set; }
	public double? REPORTRATE { get; set; }
	public int? BILLEDITEM { get; set; }
	public int? PAYDEFREF { get; set; }
	public int? EXTENREF { get; set; }
	public short? CPSTFLAG { get; set; }
	public short? SOURCEINDEX { get; set; }
	public short? SOURCECOSTGRP { get; set; }
	public short? BRANCH { get; set; }
	public short? DEPARTMENT { get; set; }
	public double? LINENET { get; set; }
	public int? SALESMANREF { get; set; }
	public short? STATUS { get; set; }
	public int? DREF { get; set; }
	public short? TRGFLAG { get; set; }
	public short? SITEID { get; set; }
	public short? RECSTATUS { get; set; }
	public int? ORGLOGICREF { get; set; }
	public short? FACTORYNR { get; set; }
	public int? WFSTATUS { get; set; }
	public short? NETDISCFLAG { get; set; }
	public double? NETDISCPERC { get; set; }
	public double? NETDISCAMNT { get; set; }
	public int? CONDITIONREF { get; set; }
	public double? DISTRESERVED { get; set; }
	public double? ONVEHICLE { get; set; }
	public int? CAMPAIGNREFS1 { get; set; }
	public int? CAMPAIGNREFS2 { get; set; }
	public int? CAMPAIGNREFS3 { get; set; }
	public int? CAMPAIGNREFS4 { get; set; }
	public int? CAMPAIGNREFS5 { get; set; }
	public int? POINTCAMPREF { get; set; }
	public double? CAMPPOINT { get; set; }
	public int? PROMCLASITEMREF { get; set; }
	public short? REASONFORNOTSHP { get; set; }
	public int? CMPGLINEREF { get; set; }
	public double? PRRATE { get; set; }
	public double? GROSSUINFO1 { get; set; }
	public double? GROSSUINFO2 { get; set; }
	public short? CANCELLED { get; set; }
	public double? DEMPEGGEDAMNT { get; set; }
	public short? TEXTINC { get; set; }
	public int? OFFERREF { get; set; }
	public short? ORDERPARAM { get; set; }
	public int? ITEMASGREF { get; set; }
	public double? EXIMAMOUNT { get; set; }
	public int? OFFTRANSREF { get; set; }
	public double? ORDEREDAMOUNT { get; set; }
	public string ORGLOGOID { get; set; } = string.Empty;
	public short? TRCURR { get; set; }
	public double? TRRATE { get; set; }
	public short? WITHPAYTRANS { get; set; }
	public int? PROJECTREF { get; set; }
	public int? POINTCAMPREFS1 { get; set; }
	public int? POINTCAMPREFS2 { get; set; }
	public int? POINTCAMPREFS3 { get; set; }
	public int? POINTCAMPREFS4 { get; set; }
	public double? CAMPPOINTS1 { get; set; }
	public double? CAMPPOINTS2 { get; set; }
	public double? CAMPPOINTS3 { get; set; }
	public double? CAMPPOINTS4 { get; set; }
	public int? CMPGLINEREFS1 { get; set; }
	public int? CMPGLINEREFS2 { get; set; }
	public int? CMPGLINEREFS3 { get; set; }
	public int? CMPGLINEREFS4 { get; set; }
	public int? PRCLISTREF { get; set; }
	public short? AFFECTCOLLATRL { get; set; }
	public short? FCTYP { get; set; }
	public short? PURCHOFFNR { get; set; }
	public int? DEMFICHEREF { get; set; }
	public int? DEMTRANSREF { get; set; }
	public short? ALTPROMFLAG { get; set; }
	public int VARIANTREF { get; set; }
	public int? REFLVATACCREF { get; set; }
	public int? REFLVATOTHACCREF { get; set; }
	public short? PRIORITY { get; set; }
	public short? AFFECTRISK { get; set; }
	public int? BOMREF { get; set; }
	public int? BOMREVREF { get; set; }
	public int? ROUTINGREF { get; set; }
	public int? OPERATIONREF { get; set; }
	public int? WSREF { get; set; }
	public double? ADDTAXRATE { get; set; }
	public double? ADDTAXCONVFACT { get; set; }
	public double? ADDTAXAMOUNT { get; set; }
	public int? ADDTAXACCREF { get; set; }
	public int? ADDTAXCENTERREF { get; set; }
	public short? ADDTAXAMNTISUPD { get; set; }
	public double? ADDTAXDISCAMOUNT { get; set; }
	public double? EXADDTAXRATE { get; set; }
	public double? EXADDTAXCONVF { get; set; }
	public double? EXADDTAXAMNT { get; set; }
	public int? EUVATSTATUS { get; set; }
	public double? ADDTAXVATMATRAH { get; set; }
	public int? CAMPPAYDEFREF { get; set; }
	public double? RPRICE { get; set; }
	public DateTime? ORGDUEDATE { get; set; }
	public double? ORGAMOUNT { get; set; }
	public double? ORGPRICE { get; set; }
	public string SPECODE2 { get; set; } = string.Empty;
	public DateTime? RESERVEDATE { get; set; }
	public short? CANDEDUCT { get; set; }
	public short? UNDERDEDUCTLIMIT { get; set; }
	public string GLOBALID { get; set; } = string.Empty;
	public short? DEDUCTIONPART1 { get; set; }
	public short? DEDUCTIONPART2 { get; set; }
	public int? PARENTLNREF { get; set; }
	public string GUID { get; set; } = string.Empty;
	public double? DISTEXPVAT { get; set; }
	public double? SHIPPEDAMNTSUGG { get; set; }
	public double? RESERVEAMOUNT { get; set; }
	public string DEDUCTCODE { get; set; } = string.Empty;
	public short? BOMTYPE { get; set; }
	public short? DEVIR { get; set; }
	public int? FAREGREF { get; set; }
	public string VATEXCEPTCODE { get; set; } = string.Empty;
	public string VATEXCEPTREASON { get; set; } = string.Empty;
	public string ATAXEXCEPTCODE { get; set; } = string.Empty;
	public string ATAXEXCEPTREASON { get; set; } = string.Empty;
	public string CPACODE { get; set; } = string.Empty;
	public string GTIPCODE { get; set; } = string.Empty;
	public int? PUBLICCOUNTRYREF { get; set; }
	public string UNITSETCODE { get; set; } = string.Empty;

	#endregion
}
