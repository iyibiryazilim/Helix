namespace Helix.Go.Entity;

public class LG_INVOICE
{
	public int LOGICALREF { get; set; }
	public short? GRPCODE { get; set; }
	public short TRCODE { get; set; }
	public string FICHENO { get; set; } = string.Empty;
	public DateTime? DATE_ { get; set; }
	public int? TIME_ { get; set; }
	public string DOCODE { get; set; } = string.Empty;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public int CLIENTREF { get; set; }
	public int? RECVREF { get; set; }
	public int? CENTERREF { get; set; }
	public int? ACCOUNTREF { get; set; }
	public short? SOURCEINDEX { get; set; }
	public short? SOURCECOSTGRP { get; set; }
	public short? CANCELLED { get; set; }
	public short? ACCOUNTED { get; set; }
	public short? PAIDINCASH { get; set; }
	public short? FROMKASA { get; set; }
	public short? ENTEGSET { get; set; }
	public double? VAT { get; set; }
	public double? ADDDISCOUNTS { get; set; }
	public double? TOTALDISCOUNTS { get; set; }
	public double? TOTALDISCOUNTED { get; set; }
	public double? ADDEXPENSES { get; set; }
	public double? TOTALEXPENSES { get; set; }
	public double? DISTEXPENSE { get; set; }
	public double? TOTALDEPOZITO { get; set; }
	public double? TOTALPROMOTIONS { get; set; }
	public double? VATINCGROSS { get; set; }
	public double TOTALVAT { get; set; }
	public double GROSSTOTAL { get; set; }
	public double NETTOTAL { get; set; }
	public string GENEXP1 { get; set; } = string.Empty;
	public string GENEXP2 { get; set; } = string.Empty;
	public string GENEXP3 { get; set; } = string.Empty;
	public string GENEXP4 { get; set; } = string.Empty;
	public string GENEXP5 { get; set; } = string.Empty;
	public string GENEXP6 { get; set; } = string.Empty;
	public double? INTERESTAPP { get; set; }
	public short? TRCURR { get; set; }
	public double? TRRATE { get; set; }
	public double? TRNET { get; set; }
	public double? REPORTRATE { get; set; }
	public double? REPORTNET { get; set; }
	public short? ONLYONEPAYLINE { get; set; }
	public int? KASTRANSREF { get; set; }
	public int? PAYDEFREF { get; set; }
	public short? PRINTCNT { get; set; }
	public short? GVATINC { get; set; }
	public short? BRANCH { get; set; }
	public short? DEPARTMENT { get; set; }
	public int? ACCFICHEREF { get; set; }
	public int? ADDEXPACCREF { get; set; }
	public int? ADDEXPCENTREF { get; set; }
	public short? DECPRDIFF { get; set; }
	public short? CAPIBLOCK_CREATEDBY { get; set; }
	public DateTime CAPIBLOCK_CREADEDDATE { get; set; } = DateTime.Now;
	public short CAPIBLOCK_CREATEDHOUR { get; set; } = Convert.ToInt16(DateTime.Now.Hour);
	public short CAPIBLOCK_CREATEDMIN { get; set; } = Convert.ToInt16(DateTime.Now.Minute);
	public short CAPIBLOCK_CREATEDSEC { get; set; } = Convert.ToInt16(DateTime.Now.Second);
	public short? CAPIBLOCK_MODIFIEDBY { get; set; }
	public DateTime CAPIBLOCK_MODIFIEDDATE { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDHOUR { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDMIN { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDSEC { get; set; } = default;
	public int? SALESMANREF { get; set; }
	public short? CANCELLEDACC { get; set; }
	public string SHPTYPCOD { get; set; } = string.Empty;
	public string SHPAGNCOD { get; set; } = string.Empty;
	public string TRACKNR { get; set; } = string.Empty;
	public short? GENEXCTYP { get; set; }
	public short? LINEEXCTYP { get; set; }
	public string TRADINGGRP { get; set; } = string.Empty;
	public short? TEXTINC { get; set; }
	public short? SITEID { get; set; }
	public short? RECSTATUS { get; set; }
	public int? ORGLOGICREF { get; set; }
	public short? FACTORYNR { get; set; }
	public int? WFSTATUS { get; set; }
	public int? SHIPINFOREF { get; set; }
	public int? DISTORDERREF { get; set; }
	public short? SENDCNT { get; set; }
	public short? DLVCLIENT { get; set; }
	public int? COSTOFSALEFCREF { get; set; }
	public short? OPSTAT { get; set; }
	public string DOCTRACKINGNR { get; set; } = string.Empty;
	public double? TOTALADDTAX { get; set; }
	public short? PAYMENTTYPE { get; set; }
	public double? INFIDX { get; set; }
	public short? ACCOUNTEDCNT { get; set; }
	public string ORGLOGOID { get; set; } = string.Empty;
	public short? FROMEXIM { get; set; }
	public string FRGTYPCOD { get; set; } = string.Empty;
	public short? EXIMFCTYPE { get; set; }
	public short? FROMORDWITHPAY { get; set; }
	public int? PROJECTREF { get; set; }
	public int? WFLOWCRDREF { get; set; }
	public short? STATUS { get; set; }
	public short? DEDUCTIONPART1 { get; set; }
	public short? DEDUCTIONPART2 { get; set; }
	public double? TOTALEXADDTAX { get; set; }
	public short? EXACCOUNTED { get; set; }
	public short? FROMBANK { get; set; }
	public int? BNTRANSREF { get; set; }
	public short? AFFECTCOLLATRL { get; set; }
	public short? GRPFIRMTRANS { get; set; }
	public short? AFFECTRISK { get; set; }
	public short? CONTROLINFO { get; set; }
	public short? POSTRANSFERINFO { get; set; }
	public short? TAXFREECHX { get; set; }
	public string PASSPORTNO { get; set; } = string.Empty;
	public string CREDITCARDNO { get; set; } = string.Empty;
	public short? INEFFECTIVECOST { get; set; }
	public short? REFLECTED { get; set; }
	public int? REFLACCFICHEREF { get; set; }
	public short? CANCELLEDREFLACC { get; set; }
	public string CREDITCARDNUM { get; set; } = string.Empty;
	public short? APPROVE { get; set; }
	public DateTime APPROVEDATE { get; set; } = default;
	public short? CANTCREDEDUCT { get; set; }
	public short? ENTRUST { get; set; }
	public DateTime? DOCDATE { get; set; }
	public short? EINVOICE { get; set; }
	public short? PROFILEID { get; set; }
	public string GUID { get; set; } = string.Empty;
	public short? ESTATUS { get; set; }
	public DateTime ESTARTDATE { get; set; } = default;
	public DateTime EENDDATE { get; set; } = default;
	public string EDESCRIPTION { get; set; } = string.Empty;
	public double? EDURATION { get; set; }
	public short? EDURATIONTYPE { get; set; }
	public short? DEVIR { get; set; }
	public double? DISTADJPRICEUFRS { get; set; }
	public int? COSFCREFUFRS { get; set; }
	public string GLOBALID { get; set; } = string.Empty;
	public double? TOTALSERVICES { get; set; }
	public short? FROMLEASING { get; set; }
	public string CANCELEXP { get; set; } = string.Empty;
	public string UNDOEXP { get; set; } = string.Empty;
	public string VATEXCEPTREASON { get; set; } = string.Empty;
	public string CAMPAIGNCODE { get; set; } = string.Empty;
	public short? CANCELDESPSINV { get; set; }
	public short? FROMEXCHDIFF { get; set; }
	public short? EXIMVAT { get; set; }
	public string SERIALCODE { get; set; } = string.Empty;
	public short? APPCLDEDUCTLIM { get; set; }
	public short? EINVOICETYP { get; set; }
	public string VATEXCEPTCODE { get; set; } = string.Empty;
	public int? OFFERREF { get; set; }
	public string ATAXEXCEPTREASON { get; set; } = string.Empty;
	public string ATAXEXCEPTCODE { get; set; } = string.Empty;
	public short? FROMSTAFFOTHEREX { get; set; }
	public short? NOCALCULATE { get; set; }
	public short? INSTEADOFDESP { get; set; }
	public short? OKCFICHE { get; set; }
	public DateTime CANCELDATE { get; set; } = default;
	public string FRGTYPDESC { get; set; } = string.Empty;
	public int? MARKREF { get; set; }
	public DateTime PRINTDATE { get; set; } = default;
	public string DELIVERCODE { get; set; } = string.Empty;
	public string RECHASH { get; set; } = string.Empty;
	public string TYPECODE { get; set; } = string.Empty;
	public short? FUTMNTHYREXPINC { get; set; }
	public short? ACCEPTEINVPUBLIC { get; set; }
	public int? PUBLICBNACCREF { get; set; }
}
