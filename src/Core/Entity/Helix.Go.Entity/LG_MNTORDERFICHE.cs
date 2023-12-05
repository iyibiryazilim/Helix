﻿namespace Helix.Go.Entity;

public class LG_MNTORDERFICHE
{
	public int LOGICALREF { get; set; } = default;
	public string FICHENO { get; set; } = string.Empty;
	public DateTime DATE_ { get; set; } = default;
	public int TIME_ { get; set; } = default;
	public string DOCODE { get; set; } = string.Empty;
	public short STATUS { get; set; } = default;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public short BRANCH { get; set; } = default;
	public short DEPARTMENT { get; set; } = default;
	public short FACTORYNR { get; set; } = default;
	public short SOURCEINDEX { get; set; } = default;
	public string GENEXP1 { get; set; } = string.Empty;
	public int DEMANDLREF { get; set; } = default;
	public int MAINTITEMREF { get; set; } = default;
	public int MAINTFAREGREF { get; set; } = default;
	public int MAINTWSREF { get; set; } = default;
	public short MAINTTYPE { get; set; } = default;
	public short MAINTITEMTYPE { get; set; } = default;
	public int MAINTTMPLREF { get; set; } = default;
	public double MAINTDURATION { get; set; } = default;
	public short MAINTDURATIONTYPE { get; set; } = default;
	public DateTime PLNBEGDATE { get; set; } = default;
	public int PLNBEGTIME { get; set; } = default;
	public DateTime PLNENDDATE { get; set; } = default;
	public int PLNENDTIME { get; set; } = default;
	public DateTime ACTBEGDATE { get; set; } = default;
	public int ACTBEGTIME { get; set; } = default;
	public DateTime ACTENDDATE { get; set; } = default;
	public int ACTENDTIME { get; set; } = default;
	public short ISEXPENSE { get; set; } = default;
	public double ACTMTRLCOST { get; set; } = default;
	public double ACTSRVCOST { get; set; } = default;
	public double ACTEMPCOST { get; set; } = default;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; } = default;
	public int WFSTATUS { get; set; } = default;
	public short CAPIBLOCK_CREATEDBY { get; set; } = default;
	public DateTime CAPIBLOCK_CREADEDDATE { get; set; } = default;
	public short CAPIBLOCK_CREATEDHOUR { get; set; } = default;
	public short CAPIBLOCK_CREATEDMIN { get; set; } = default;
	public short CAPIBLOCK_CREATEDSEC { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDBY { get; set; } = default;
	public DateTime CAPIBLOCK_MODIFIEDDATE { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDHOUR { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDMIN { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDSEC { get; set; } = default;
	public short PRINTCNT { get; set; } = default;
	public short TEXTINC { get; set; } = default;
	public int WFLOWCRDREF { get; set; } = default;
	public int PROJECTREF { get; set; } = default;
	public int PERREF { get; set; } = default;
	public string GUID { get; set; } = string.Empty;
	public DateTime PRINTDATE { get; set; } = default;
	public short APPROVE { get; set; } = default;
	public DateTime APPROVEDATE { get; set; } = default;
	public short CANCELLED { get; set; } = default;
	public double ACTMTRLRPCOST { get; set; } = default;
	public double ACTSRVRPCOST { get; set; } = default;
	public double ACTEMPRPCOST { get; set; } = default;
}
