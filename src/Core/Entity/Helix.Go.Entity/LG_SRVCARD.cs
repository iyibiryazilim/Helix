namespace Helix.Go.Entity;

public class LG_SRVCARD
{
	#region Properties
	public int LOGICALREF { get; set; }
	public short? CARDTYPE { get; set; }
	public short? ACTIVE { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string DEFINITION_ { get; set; } = string.Empty;
	public string SPECODE { get; set; } = string.Empty;
	public string SPECODE2 { get; set; } = string.Empty;
	public string SPECODE3 { get; set; } = string.Empty;
	public string SPECODE4 { get; set; } = string.Empty;
	public string SPECODE5 { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public double? VAT { get; set; }
	public int? EXTENREF { get; set; }
	public int? PAYMENTREF { get; set; }
	public int? UNITSETREF { get; set; }
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
	public short? SITEID { get; set; }
	public short? RECSTATUS { get; set; }
	public int? ORGLOGICREF { get; set; }
	public int? WFSTATUS { get; set; }
	public double? RETURNVAT { get; set; }
	public short? IMPORTEXPNS { get; set; }
	public short? AFFECTCOST { get; set; }
	public int? ADDTAXREF { get; set; }
	public short? DISTTYPE { get; set; }
	public int? EXTACCESSFLAGS { get; set; }
	public short? USEDINPERIODS { get; set; }
	public short? CANDEDUCT { get; set; }
	public short? DEDUCTIONPART1 { get; set; }
	public short? DEDUCTIONPART2 { get; set; }
	public short? EXEMPTFROMTAXDECL { get; set; }
	public short? CURRDIFF { get; set; }
	public string DEDUCTCODE { get; set; } = string.Empty;
	public int? PROJECTREF { get; set; }
	public string DEFINITION2 { get; set; } = string.Empty;
	public int? PARENTSRVREF { get; set; }
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
	public short? MULTIADDTAX { get; set; }
	public string GTIPCODE { get; set; } = string.Empty;
	public string CPACODE { get; set; } = string.Empty;
	public int? PUBLICCOUNTRYREF { get; set; }

	#endregion
}
