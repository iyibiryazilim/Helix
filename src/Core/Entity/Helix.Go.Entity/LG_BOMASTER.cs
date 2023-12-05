namespace Helix.Go.Entity;

public class LG_BOMASTER
{
	public int LOGICALREF { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string NAME { get; set; } = string.Empty;
	public int VALIDREVREF { get; set; } = default;
	public int MAINPRODREF { get; set; } = default;
	public short APPROVED { get; set; } = default;
	public short ACTIVE { get; set; } = default;
	public short DEMONTAJ { get; set; } = default;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public short CAPIBLOCK_CREATEDBY { get; set; }
	public DateTime CAPIBLOCK_CREADEDDATE { get; set; }
	public short CAPIBLOCK_CREATEDHOUR { get; set; }
	public short CAPIBLOCK_CREATEDMIN { get; set; }
	public short CAPIBLOCK_CREATEDSEC { get; set; }
	public short CAPIBLOCK_MODIFIEDBY { get; set; }
	public DateTime CAPIBLOCK_MODIFIEDDATE { get; set; }
	public short CAPIBLOCK_MODIFIEDHOUR { get; set; }
	public short CAPIBLOCK_MODIFIEDMIN { get; set; }
	public short CAPIBLOCK_MODIFIEDSEC { get; set; }
	public short TEXTINC { get; set; } = default;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; } = default;
	public int WFSTATUS { get; set; } = default;
	public int ROUTINGREF { get; set; } = default;
	public int PRODUCTLINEREF { get; set; } = default;
	public short PRINTCNT { get; set; } = default;
	public string GUID { get; set; } = string.Empty;
	public string VARIABLEDEFS1 { get; set; } = string.Empty;
	public string VARIABLEDEFS2 { get; set; } = string.Empty;
	public string VARIABLEDEFS3 { get; set; } = string.Empty;
	public string VARIABLEDEFS4 { get; set; } = string.Empty;
	public string VARIABLEDEFS5 { get; set; } = string.Empty;
	public string VARIABLEDEFS6 { get; set; } = string.Empty;
	public string VARIABLEDEFS7 { get; set; } = string.Empty;
	public string VARIABLEDEFS8 { get; set; } = string.Empty;
	public string VARIABLEDEFS9 { get; set; } = string.Empty;
	public string VARIABLEDEFS10 { get; set; } = string.Empty;
	public short BOMTYPE { get; set; } = default;
	public int CLIENTREF { get; set; } = default;
	public DateTime PRINTDATE { get; set; } = default;
	public string SPECODE2 { get; set; } = string.Empty;
	public string NAME2 { get; set; } = string.Empty;
}
