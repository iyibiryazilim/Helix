namespace Helix.Go.Entity;

public class LG_BANKACC
{
	#region Properties
	public int? LOGICALREF { get; set; }
	public short? CARDTYPE { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string DEFINITION_ { get; set; } = string.Empty;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public int? BANKREF { get; set; }
	public double? CHECKMARGIN { get; set; }
	public double? NOTEMARGIN { get; set; }
	public double? CHECKLIMIT { get; set; }
	public double? NOTELIMIT { get; set; }
	public double? CUSTINTEREST { get; set; }
	public double? SKINTEREST { get; set; }
	public double? CKINTEREST { get; set; }
	public double? STOPAJPER { get; set; }
	public double? FONPER { get; set; }
	public short? CURRENCY { get; set; }
	public int? EXTENREF { get; set; }
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
	public short? ACTIVE { get; set; }
	public string ACCOUNTNO { get; set; } = string.Empty;
	public short? TEXTINC { get; set; }
	public short? SITEID { get; set; }
	public short? RECSTATUS { get; set; }
	public int? ORGLOGICREF { get; set; }
	public int? WFSTATUS { get; set; }
	public short? KKUSAGE { get; set; }
	public double? COLLATRLLIMIT { get; set; }
	public short? CURRATETYPE { get; set; }
	public double? WTHCLTRLINTEREST { get; set; }
	public double? WTHCLTRLLIMIT { get; set; }
	public short? USEDINPERIODS { get; set; }
	public string IBAN { get; set; } = string.Empty;
	public short? CUTOFFDAY { get; set; }
	public short? LASTPAYMENTDAY { get; set; }
	public double? CREDITCARDLIMIT { get; set; }
	public string CREDITCARDNO { get; set; } = string.Empty;
	public string GLBBANKBRANCH { get; set; } = string.Empty;
	public int? DEFBNACCREF { get; set; }
	public string GUID { get; set; } = string.Empty;
	public string BATCHNUM { get; set; } = string.Empty;
	public string POSTERMINALNUM { get; set; } = string.Empty;
	public int? DEFKSREF { get; set; }
	#endregion
}
