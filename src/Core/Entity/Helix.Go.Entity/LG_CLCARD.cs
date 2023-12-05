using System.Runtime.Serialization;

namespace Helix.Go.Entity;

public class LG_CLCARD
{
	#region Properties

	
	public int LOGICALREF { get; set; }
	public short? ACTIVE { get; set; }
	public short? CARDTYPE { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string DEFINITION_ { get; set; } = string.Empty;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public string ADDR1 { get; set; } = string.Empty;
	public string ADDR2 { get; set; } = string.Empty;
	public string CITY { get; set; } = string.Empty;
	public string COUNTRY { get; set; } = string.Empty;
	public string POSTCODE { get; set; } = string.Empty;
	public string TELNRS1 { get; set; } = string.Empty;
	public string TELNRS2 { get; set; } = string.Empty;
	public string FAXNR { get; set; } = string.Empty;
	public string TAXNR { get; set; } = string.Empty;
	public string TAXOFFICE { get; set; } = string.Empty;
	public string INCHARGE { get; set; } = string.Empty;
	public double? DISCRATE { get; set; }
	public int? EXTENREF { get; set; }
	public int? PAYMENTREF { get; set; }
	public string EMAILADDR { get; set; } = string.Empty;
	public string WEBADDR { get; set; } = string.Empty;
	public short? WARNMETHOD { get; set; }
	public string WARNEMAILADDR { get; set; } = string.Empty;
	public string WARNFAXNR { get; set; } = string.Empty;
	public short? CLANGUAGE { get; set; }
	public string VATNR { get; set; } = string.Empty;
	public short? BLOCKED { get; set; }
	public string BANKBRANCHS1 { get; set; } = string.Empty;
	public string BANKBRANCHS2 { get; set; } = string.Empty;
	public string BANKBRANCHS3 { get; set; } = string.Empty;
	public string BANKBRANCHS4 { get; set; } = string.Empty;
	public string BANKBRANCHS5 { get; set; } = string.Empty;
	public string BANKBRANCHS6 { get; set; } = string.Empty;
	public string BANKBRANCHS7 { get; set; } = string.Empty;
	public string BANKACCOUNTS1 { get; set; } = string.Empty;
	public string BANKACCOUNTS2 { get; set; } = string.Empty;
	public string BANKACCOUNTS3 { get; set; } = string.Empty;
	public string BANKACCOUNTS4 { get; set; } = string.Empty;
	public string BANKACCOUNTS5 { get; set; } = string.Empty;
	public string BANKACCOUNTS6 { get; set; } = string.Empty;
	public string BANKACCOUNTS7 { get; set; } = string.Empty;
	public string DELIVERYMETHOD { get; set; } = string.Empty;
	public string DELIVERYFIRM { get; set; } = string.Empty;
	public short? CCURRENCY { get; set; }
	public short? TEXTINC { get; set; }
	public short? SITEID { get; set; }
	public short? RECSTATUS { get; set; }
	public int? ORGLOGICREF { get; set; }
	public string EDINO { get; set; } = string.Empty;
	public string TRADINGGRP { get; set; } = string.Empty;
	public short? CAPIBLOCK_CREATEDBY { get; set; }
	public DateTime? CAPIBLOCK_CREADEDDATE { get; set; }
	public short? CAPIBLOCK_CREATEDHOUR { get; set; }
	public short? CAPIBLOCK_CREATEDMIN { get; set; }
	public short? CAPIBLOCK_CREATEDSEC { get; set; }
	public short? CAPIBLOCK_MODIFIEDBY { get; set; }
	public DateTime? CAPIBLOCK_MODIFIEDDATE { get; set; }
	public short? CAPIBLOCK_MODIFIEDHOUR { get; set; }
	public short? CAPIBLOCK_MODIFIEDMIN { get; set; }
	public short? CAPIBLOCK_MODIFIEDSEC { get; set; }
	public short? PAYMENTPROC { get; set; }
	public short? CRATEDIFFPROC { get; set; }
	public int? WFSTATUS { get; set; }
	public string PPGROUPCODE { get; set; } = string.Empty;
	public int? PPGROUPREF { get; set; }
	public string TAXOFFCODE { get; set; } = string.Empty;
	public string TOWNCODE { get; set; } = string.Empty;
	public string TOWN { get; set; } = string.Empty;
	public string DISTRICTCODE { get; set; } = string.Empty;
	public string DISTRICT { get; set; } = string.Empty;
	public string CITYCODE { get; set; } = string.Empty;
	public string COUNTRYCODE { get; set; } = string.Empty;
	public short? ORDSENDMETHOD { get; set; }
	public string ORDSENDEMAILADDR { get; set; } = string.Empty;
	public string ORDSENDFAXNR { get; set; } = string.Empty;
	public short? DSPSENDMETHOD { get; set; }
	public string DSPSENDEMAILADDR { get; set; } = string.Empty;
	public string DSPSENDFAXNR { get; set; } = string.Empty;
	public short? INVSENDMETHOD { get; set; }
	public string INVSENDEMAILADDR { get; set; } = string.Empty;
	public string INVSENDFAXNR { get; set; } = string.Empty;
	public short? SUBSCRIBERSTAT { get; set; }
	public string SUBSCRIBEREXT { get; set; } = string.Empty;
	public string AUTOPAIDBANK { get; set; } = string.Empty;
	public short? PAYMENTTYPE { get; set; }
	public int? LASTSENDREMLEV { get; set; }
	public int? EXTACCESSFLAGS { get; set; }
	public short? ORDSENDFORMAT { get; set; }
	public short? DSPSENDFORMAT { get; set; }
	public short? INVSENDFORMAT { get; set; }
	public short? REMSENDFORMAT { get; set; }
	public string STORECREDITCARDNO { get; set; } = string.Empty;
	public short? CLORDFREQ { get; set; }
	public short? ORDDAY { get; set; }
	public string LOGOID { get; set; } = string.Empty;
	public short? LIDCONFIRMED { get; set; }
	public string EXPREGNO { get; set; } = string.Empty;
	public string EXPDOCNO { get; set; } = string.Empty;
	public int? EXPBUSTYPREF { get; set; }
	public short? INVPRINTCNT { get; set; }
	public short? PIECEORDINFLICT { get; set; }
	public short? COLLECTINVOICING { get; set; }
	public short? EBUSDATASENDTYPE { get; set; }
	public int? INISTATUSFLAGS { get; set; }
	public short? SLSORDERSTATUS { get; set; }
	public short? SLSORDERPRICE { get; set; }
	public short? LTRSENDMETHOD { get; set; }
	public string LTRSENDEMAILADDR { get; set; } = string.Empty;
	public string LTRSENDFAXNR { get; set; } = string.Empty;
	public short? LTRSENDFORMAT { get; set; }
	public short? IMAGEINC { get; set; }
	public string CELLPHONE { get; set; } = string.Empty;
	public short? SAMEITEMCODEUSE { get; set; }
	public string STATECODE { get; set; } = string.Empty;
	public string STATENAME { get; set; } = string.Empty;
	public int? WFLOWCRDREF { get; set; }
	public int? PARENTCLREF { get; set; }
	public int? LOWLEVELCODES1 { get; set; }
	public int? LOWLEVELCODES2 { get; set; }
	public int? LOWLEVELCODES3 { get; set; }
	public int? LOWLEVELCODES4 { get; set; }
	public int? LOWLEVELCODES5 { get; set; }
	public int? LOWLEVELCODES6 { get; set; }
	public int? LOWLEVELCODES7 { get; set; }
	public int? LOWLEVELCODES8 { get; set; }
	public int? LOWLEVELCODES9 { get; set; }
	public int? LOWLEVELCODES10 { get; set; }
	public string TELCODES1 { get; set; } = string.Empty;
	public string TELCODES2 { get; set; } = string.Empty;
	public string FAXCODE { get; set; } = string.Empty;
	public short? PURCHBRWS { get; set; }
	public short? SALESBRWS { get; set; }
	public short? IMPBRWS { get; set; }
	public short? EXPBRWS { get; set; }
	public short? FINBRWS { get; set; }
	public string ORGLOGOID { get; set; } = string.Empty;
	public short? ADDTOREFLIST { get; set; }
	public short? TEXTREFTR { get; set; }
	public short? TEXTREFEN { get; set; }
	public short? ARPQUOTEINC { get; set; }
	public short? CLCRM { get; set; }
	public short? GRPFIRMNR { get; set; }
	public int? CONSCODEREF { get; set; }
	public string SPECODE2 { get; set; } = string.Empty;
	public string SPECODE3 { get; set; } = string.Empty;
	public string SPECODE4 { get; set; } = string.Empty;
	public string SPECODE5 { get; set; } = string.Empty;
	public short? OFFSENDMETHOD { get; set; }
	public string OFFSENDEMAILADDR { get; set; } = string.Empty;
	public string OFFSENDFAXNR { get; set; } = string.Empty;
	public short? OFFSENDFORMAT { get; set; }
	public short? EBANKNO { get; set; }
	public short? LOANGRPCTRL { get; set; }
	public string BANKNAMES1 { get; set; } = string.Empty;
	public string BANKNAMES2 { get; set; } = string.Empty;
	public string BANKNAMES3 { get; set; } = string.Empty;
	public string BANKNAMES4 { get; set; } = string.Empty;
	public string BANKNAMES5 { get; set; } = string.Empty;
	public string BANKNAMES6 { get; set; } = string.Empty;
	public string BANKNAMES7 { get; set; } = string.Empty;
	public short? LDXFIRMNR { get; set; }
	public string MAPID { get; set; } = string.Empty;
	public string LONGITUDE { get; set; } = string.Empty;
	public string LATITUTE { get; set; } = string.Empty;
	public string CITYID { get; set; } = string.Empty;
	public string TOWNID { get; set; } = string.Empty;
	public string BANKIBANS1 { get; set; } = string.Empty;
	public string BANKIBANS2 { get; set; } = string.Empty;
	public string BANKIBANS3 { get; set; } = string.Empty;
	public string BANKIBANS4 { get; set; } = string.Empty;
	public string BANKIBANS5 { get; set; } = string.Empty;
	public string BANKIBANS6 { get; set; } = string.Empty;
	public string BANKIBANS7 { get; set; } = string.Empty;
	public string TCKNO { get; set; } = string.Empty;
	public short? ISPERSCOMP { get; set; }
	public short? EXTSENDMETHOD { get; set; }
	public string EXTSENDEMAILADDR { get; set; } = string.Empty;
	public string EXTSENDFAXNR { get; set; } = string.Empty;
	public short? EXTSENDFORMAT { get; set; }
	public string BANKBICS1 { get; set; } = string.Empty;
	public string BANKBICS2 { get; set; } = string.Empty;
	public string BANKBICS3 { get; set; } = string.Empty;
	public string BANKBICS4 { get; set; } = string.Empty;
	public string BANKBICS5 { get; set; } = string.Empty;
	public string BANKBICS6 { get; set; } = string.Empty;
	public string BANKBICS7 { get; set; } = string.Empty;
	public int? CASHREF { get; set; }
	public short? USEDINPERIODS { get; set; }
	public string INCHARGE2 { get; set; } = string.Empty;
	public string INCHARGE3 { get; set; } = string.Empty;
	public string EMAILADDR2 { get; set; } = string.Empty;
	public string EMAILADDR3 { get; set; } = string.Empty;
	public short? RSKLIMCR { get; set; }
	public short? RSKDUEDATECR { get; set; }
	public short? RSKAGINGCR { get; set; }
	public short? RSKAGINGDAY { get; set; }
	public short? ACCEPTEINV { get; set; }
	public string EINVOICEID { get; set; } = string.Empty;
	public short? PROFILEID { get; set; }
	public string BANKBCURRENCY1 { get; set; } = string.Empty;
	public string BANKBCURRENCY2 { get; set; } = string.Empty;
	public string BANKBCURRENCY3 { get; set; } = string.Empty;
	public string BANKBCURRENCY4 { get; set; } = string.Empty;
	public string BANKBCURRENCY5 { get; set; } = string.Empty;
	public string BANKBCURRENCY6 { get; set; } = string.Empty;
	public string BANKBCURRENCY7 { get; set; } = string.Empty;
	public short? PURCORDERSTATUS { get; set; }
	public short? PURCORDERPRICE { get; set; }
	public short? ISFOREIGN { get; set; }
	public int? SHIPBEGTIME1 { get; set; }
	public int? SHIPBEGTIME2 { get; set; }
	public int? SHIPBEGTIME3 { get; set; }
	public int? SHIPENDTIME1 { get; set; }
	public int? SHIPENDTIME2 { get; set; }
	public int? SHIPENDTIME3 { get; set; }
	public double? DBSLIMIT1 { get; set; }
	public double? DBSLIMIT2 { get; set; }
	public double? DBSLIMIT3 { get; set; }
	public double? DBSLIMIT4 { get; set; }
	public double? DBSLIMIT5 { get; set; }
	public double? DBSLIMIT6 { get; set; }
	public double? DBSLIMIT7 { get; set; }
	public double? DBSTOTAL1 { get; set; }
	public double? DBSTOTAL2 { get; set; }
	public double? DBSTOTAL3 { get; set; }
	public double? DBSTOTAL4 { get; set; }
	public double? DBSTOTAL5 { get; set; }
	public double? DBSTOTAL6 { get; set; }
	public double? DBSTOTAL7 { get; set; }
	public short? DBSBANKNO1 { get; set; }
	public short? DBSBANKNO2 { get; set; }
	public short? DBSBANKNO3 { get; set; }
	public short? DBSBANKNO4 { get; set; }
	public short? DBSBANKNO5 { get; set; }
	public short? DBSBANKNO6 { get; set; }
	public short? DBSBANKNO7 { get; set; }
	public short? DBSRISKCNTRL1 { get; set; }
	public short? DBSRISKCNTRL2 { get; set; }
	public short? DBSRISKCNTRL3 { get; set; }
	public short? DBSRISKCNTRL4 { get; set; }
	public short? DBSRISKCNTRL5 { get; set; }
	public short? DBSRISKCNTRL6 { get; set; }
	public short? DBSRISKCNTRL7 { get; set; }
	public short? DBSBANKCURRENCY1 { get; set; }
	public short? DBSBANKCURRENCY2 { get; set; }
	public short? DBSBANKCURRENCY3 { get; set; }
	public short? DBSBANKCURRENCY4 { get; set; }
	public short? DBSBANKCURRENCY5 { get; set; }
	public short? DBSBANKCURRENCY6 { get; set; }
	public short? DBSBANKCURRENCY7 { get; set; }
	public string BANKCORRPACC1 { get; set; } = string.Empty;
	public string BANKCORRPACC2 { get; set; } = string.Empty;
	public string BANKCORRPACC3 { get; set; } = string.Empty;
	public string BANKCORRPACC4 { get; set; } = string.Empty;
	public string BANKCORRPACC5 { get; set; } = string.Empty;
	public string BANKCORRPACC6 { get; set; } = string.Empty;
	public string BANKCORRPACC7 { get; set; } = string.Empty;
	public string BANKVOEN1 { get; set; } = string.Empty;
	public string BANKVOEN2 { get; set; } = string.Empty;
	public string BANKVOEN3 { get; set; } = string.Empty;
	public string BANKVOEN4 { get; set; } = string.Empty;
	public string BANKVOEN5 { get; set; } = string.Empty;
	public string BANKVOEN6 { get; set; } = string.Empty;
	public string BANKVOEN7 { get; set; } = string.Empty;
	public short? EINVOICETYPE { get; set; }
	public string DEFINITION2 { get; set; } = string.Empty;
	public string TELEXTNUMS1 { get; set; } = string.Empty;
	public string TELEXTNUMS2 { get; set; } = string.Empty;
	public string FAXEXTNUM { get; set; } = string.Empty;
	public string FACEBOOKURL { get; set; } = string.Empty;
	public string TWITTERURL { get; set; } = string.Empty;
	public string APPLEID { get; set; } = string.Empty;
	public string SKYPEID { get; set; } = string.Empty;
	public string GLOBALID { get; set; } = string.Empty;
	public string GUID { get; set; } = string.Empty;
	public short? DUEDATECOUNT { get; set; }
	public double? DUEDATELIMIT { get; set; }
	public short? DUEDATETRACK { get; set; }
	public short? DUEDATECONTROL1 { get; set; }
	public short? DUEDATECONTROL2 { get; set; }
	public short? DUEDATECONTROL3 { get; set; }
	public short? DUEDATECONTROL4 { get; set; }
	public short? DUEDATECONTROL5 { get; set; }
	public short? DUEDATECONTROL6 { get; set; }
	public short? DUEDATECONTROL7 { get; set; }
	public short? DUEDATECONTROL8 { get; set; }
	public short? DUEDATECONTROL9 { get; set; }
	public short? DUEDATECONTROL10 { get; set; }
	public short? DUEDATECONTROL11 { get; set; }
	public short? DUEDATECONTROL12 { get; set; }
	public short? DUEDATECONTROL13 { get; set; }
	public short? DUEDATECONTROL14 { get; set; }
	public short? DUEDATECONTROL15 { get; set; }
	public short? CLOSEDATECOUNT { get; set; }
	public short? CLOSEDATETRACK { get; set; }
	public string SENDERLABELCODE { get; set; } = string.Empty;
	public string ADRESSNO { get; set; } = string.Empty;
	public string POSTLABELCODE { get; set; } = string.Empty;
	public short? DEGACTIVE { get; set; }
	public short? DEGCURR { get; set; }
	public string NAME { get; set; } = string.Empty;
	public string SURNAME { get; set; } = string.Empty;
	public short? LABELINFO { get; set; }
	public int? DEFBNACCREF { get; set; }
	public int? PROJECTREF { get; set; }
	public short? DISCTYPE { get; set; }
	public short? SENDMOD { get; set; }
	public short? ISPERCURR { get; set; }
	public short? CURRATETYPE { get; set; }
	public short? INSTEADOFDESP { get; set; }
	public short? EINVOICETYP { get; set; }
	public short? FBSSENDMETHOD { get; set; }
	public string FBSSENDEMAILADDR { get; set; } = string.Empty;
	public short? FBSSENDFORMAT { get; set; }
	public string FBSSENDFAXNR { get; set; } = string.Empty;
	public short? FBASENDMETHOD { get; set; }
	public string FBASENDEMAILADDR { get; set; } = string.Empty;
	public short? FBASENDFORMAT { get; set; }
	public string FBASENDFAXNR { get; set; } = string.Empty;
	public int? SECTORMAINREF { get; set; }
	public int? SECTORSUBREF { get; set; }
	public short? PERSONELCOSTS { get; set; }
	public string EARCEMAILADDR1 { get; set; } = string.Empty;
	public string EARCEMAILADDR2 { get; set; } = string.Empty;
	public string EARCEMAILADDR3 { get; set; } = string.Empty;
	public short? FACTORYDIVNR { get; set; }
	public short? FACTORYNR { get; set; }
	public short? ININVENNR { get; set; }
	public short? OUTINVENNR { get; set; }
	public double? QTYDEPDURATION { get; set; }
	public double? QTYINDEPDURATION { get; set; }
	public short? OVERLAPTYPE { get; set; }
	public double? OVERLAPAMNT { get; set; }
	public double? OVERLAPPERC { get; set; }
	public short? BROKERCOMP { get; set; }
	public short? CREATEWHFICHE { get; set; }
	public short? EINVCUSTOM { get; set; }
	public short? SUBCONT { get; set; }
	public short? ORDPRIORITY { get; set; }
	public short? ACCEPTEDESP { get; set; }
	public short? PROFILEIDDESP { get; set; }
	public short? LABELINFODESP { get; set; }
	public string POSTLABELCODEDESP { get; set; } = string.Empty;
	public string SENDERLABELCODEDESP { get; set; } = string.Empty;
	public short? PAYMENTPROCBRANCH { get; set; }
	public int? PUBLICBNACCREF { get; set; }
	public short? ACCEPTEINVPUBLIC { get; set; }


	#endregion
}
