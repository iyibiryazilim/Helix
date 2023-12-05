namespace Helix.Go.Entity;

public class LG_PRCLIST
{
	public int LOGICALREF { get; set; }
	public int? CARDREF { get; set; }
	public string CLIENTCODE { get; set; } = string.Empty;
	public string CLSPECODE { get; set; } = string.Empty;
	public int? PAYPLANREF { get; set; }
	public double? PRICE { get; set; }
	public int? UOMREF { get; set; }
	public short? INCVAT { get; set; }
	public short? CURRENCY { get; set; }
	public short? PRIORITY { get; set; }
	public short? PTYPE { get; set; }
	public short? MTRLTYPE { get; set; }
	public int? LEADTIME { get; set; }
	public DateTime? BEGDATE { get; set; }
	public DateTime? ENDDATE { get; set; }
	public string CONDITION { get; set; } = string.Empty;
	public string SHIPTYP { get; set; } = string.Empty;
	public short? SPECIALIZED { get; set; }
	public int? CAPIBLOCK_CREATEDBY { get; set; }
	public DateTime? CAPIBLOCK_CREADEDDATE { get; set; }
	public int? CAPIBLOCK_CREATEDHOUR { get; set; }
	public int? CAPIBLOCK_CREATEDMIN { get; set; }
	public int? CAPIBLOCK_CREATEDSEC { get; set; }
	public int? CAPIBLOCK_MODIFIEDBY { get; set; }
	public DateTime? CAPIBLOCK_MODIFIEDDATE { get; set; }
	public int? CAPIBLOCK_MODIFIEDHOUR { get; set; }
	public int? CAPIBLOCK_MODIFIEDMIN { get; set; }
	public int? CAPIBLOCK_MODIFIEDSEC { get; set; }
	public short? SITEID { get; set; }
	public short? RECSTATUS { get; set; }
	public int? ORGLOGICREF { get; set; }
	public int? WFSTATUS { get; set; }
	public short? UNITCONVERT { get; set; }
	public int? EXTACCESSFLAGS { get; set; }
	public string CYPHCODE { get; set; } = string.Empty;
	public string ORGLOGOID { get; set; } = string.Empty;
	public string TRADINGGRP { get; set; } = string.Empty;
	public int? BEGTIME { get; set; }
	public int? ENDTIME { get; set; }
	public string DEFINITION_ { get; set; } = string.Empty;
	public string CODE { get; set; } = string.Empty;
	public string GRPCODE { get; set; } = string.Empty;
	public short? ORDERNR { get; set; }
	public string GENIUSPAYTYPE { get; set; } = string.Empty;
	public int? GENIUSSHPNR { get; set; }
	public short? PRCALTERTYP1 { get; set; }
	public double? PRCALTERLMT1 { get; set; }
	public short? PRCALTERTYP2 { get; set; }
	public double? PRCALTERLMT2 { get; set; }
	public short? PRCALTERTYP3 { get; set; }
	public double? PRCALTERLMT3 { get; set; }
	public short? ACTIVE { get; set; }
	public int? PURCHCONTREF { get; set; }
	public short? BRANCH { get; set; }
	public double? COSTVAL { get; set; }
	public string CLTRADINGGRP { get; set; } = string.Empty;
	public string CLCYPHCODE { get; set; } = string.Empty;
	public string CLSPECODE2 { get; set; } = string.Empty;
	public string CLSPECODE3 { get; set; } = string.Empty;
	public string CLSPECODE4 { get; set; } = string.Empty;
	public string CLSPECODE5 { get; set; } = string.Empty;
	public string GLOBALID { get; set; } = string.Empty;
	public string VARIANTCODE { get; set; } = string.Empty;
	public int? WFLOWCRDREF { get; set; }
	public string GUID { get; set; } = string.Empty;
	public int? PROJECTREF { get; set; }
	public int? MARKREF { get; set; }
	public string TRSPECODE { get; set; } = string.Empty;
}
