namespace Helix.Go.Entity;

public class LG_DEMANDLINE
{
	#region Properties
	public int LOGICALREF { get; set; }
	public int DEMANDFICHEREF { get; set; } = default;
	public int ITEMREF { get; set; } = default;
	public int CLIENTREF { get; set; } = default;

	public double AMOUNT { get; set; } = default;

	public double MEETAMNT { get; set; } = default;

	public double CANCAMOUNT { get; set; } = default;
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

	public short MEETTYPE { get; set; } = default;

	public DateTime PROCUREDATE { get; set; } = default;

	public short SOURCEINDEX { get; set; } = default;

	public short BRANCH { get; set; } = default;
	public short DEPARTMENT { get; set; } = default;
	public short FACTORYNR { get; set; } = default;
	public int BOMMASTERREF { get; set; } = default;
	public int BOMREVREF { get; set; } = default;

	public string SPECODE { get; set; } = string.Empty;

	public string LINEEXP { get; set; } = string.Empty;

	public short STATUS { get; set; } = default;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; } = default;
	public int WFSTATUS { get; set; } = default;
	public int PAYDEFREF { get; set; } = default;

	public short LINETYPE { get; set; } = default;
	public string CYPHCODE { get; set; } = string.Empty;
	public short CPSTFLAG { get; set; } = default;
	public short DETLINE { get; set; } = default;
	public int PREVLINEREF { get; set; } = default;
	public short PREVLINENO { get; set; } = default;
	public short LINENO_ { get; set; } = default;

	public string USERNAME { get; set; } = string.Empty;

	public DateTime FICHEDATE { get; set; } = default;
	public int MRPLINEREF { get; set; } = default;
	public int MRPHEADREF { get; set; } = default;
	public short ALTITEMUSE { get; set; } = default;
	public short MRPHEADTYPE { get; set; } = default;
	public short ORDPEGUSE { get; set; } = default;
	public double ORDPEGAMOUNT { get; set; } = default;

	public double PRICE { get; set; } = default;
	public int PROCURETIME { get; set; } = default;
	public short INVUSEPARAM { get; set; } = default;
	public int PRODORDREF { get; set; } = default;
	public int POLINEREF { get; set; } = default;
	public int DISPLINEREF { get; set; } = default;
	public int PLNSTFCREF { get; set; } = default;
	public int PLNSTLREF { get; set; } = default;
	public short PLNFICHEPER { get; set; } = default;

	public short REALSRCINDEX { get; set; } = default;
	public int ACCOUNTREF { get; set; } = default;
	public int CENTERREF { get; set; } = default;
	public int PROJECTREF { get; set; } = default;
	public int CRSACCOUNTREF { get; set; } = default;
	public int CRSCENTERREF { get; set; } = default;
	public int CRSPROJECTREF { get; set; } = default;
	public short PRCURR { get; set; } = default;
	public double PRPRICE { get; set; } = default;
	public int VARIANTREF { get; set; } = default;
	public short MEETWITHSTOCK { get; set; } = default;
	public short FICHETYPE { get; set; } = default;
	#endregion
}
