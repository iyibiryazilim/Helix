﻿namespace Helix.Go.Entity;

public class LG_DISPLINE
{
	public int LOGICALREF { get; set; } = default;
	public int PRODORDREF { get; set; } = default;
	public short BOMLEVEL { get; set; } = default;
	public int REVREF { get; set; } = default;
	public string LINENO_ { get; set; } = string.Empty;
	public int ROUTLINEREF { get; set; } = default;
	public int OPERATIONREF { get; set; } = default;
	public short QCOPOK { get; set; } = default;
	public int OPREQREF { get; set; } = default;
	public int WSREF { get; set; } = default;
	public double WSDAILYOPTIME { get; set; } = default;
	public short WSWORKINGDAYS { get; set; } = default;
	public short SCHEDULED { get; set; } = default;
	public short RELEASED { get; set; } = default;
	public int SETUPTIME { get; set; } = default;
	public int QUEUETIME { get; set; } = default;
	public double RUNBATCH { get; set; } = default;
	public int RUNTIME { get; set; } = default;
	public double MOVEBATCH { get; set; } = default;
	public int MOVETIME { get; set; } = default;
	public int INSPTIME { get; set; } = default;
	public int HEADTIME { get; set; } = default;
	public int TAILTIME { get; set; } = default;
	public DateTime OPBEGDATE { get; set; } = default;
	public int OPBEGTIME { get; set; } = default;
	public DateTime OPDUEDATE { get; set; } = default;
	public int OPDUETIME { get; set; } = default;
	public double PLNDURATION { get; set; } = default;
	public DateTime ACTBEGDATE { get; set; } = default;
	public int ACTBEGTIME { get; set; } = default;
	public DateTime ACTDUEDATE { get; set; } = default;
	public int ACTDUETIME { get; set; } = default;
	public double ACTDURATION { get; set; } = default;
	public short LINESTATUS { get; set; } = default;
	public double STDMATERIALCOST { get; set; } = default;
	public double STDEQUIPTCOST { get; set; } = default;
	public double STDWSCOST { get; set; } = default;
	public double STDLABORCOST { get; set; } = default;
	public double STDOVERHCOST { get; set; } = default;
	public double STDTOTALCOST { get; set; } = default;
	public double STDMATERIALRPCOST { get; set; } = default;
	public double STDEQUIPTRPCOST { get; set; } = default;
	public double STDWSRPCOST { get; set; } = default;
	public double STDLABORRPCOST { get; set; } = default;
	public double STDOVERHRPCOST { get; set; } = default;
	public double STDTOTALRPCOST { get; set; } = default;
	public double ACTMATERIALCOST { get; set; } = default;
	public double ACTEQUIPTCOST { get; set; } = default;
	public double ACTWSCOST { get; set; } = default;
	public double ACTLABORCOST { get; set; } = default;
	public double ACTOVERHCOST { get; set; } = default;
	public double ACTTOTALCOST { get; set; } = default;
	public double ACTMATERIALRPCOST { get; set; } = default;
	public double ACTEQUIPTRPCOST { get; set; } = default;
	public double ACTWSRPCOST { get; set; } = default;
	public double ACTLABORRPCOST { get; set; } = default;
	public double ACTOVERHRPCOST { get; set; } = default;
	public double ACTTOTALRPCOST { get; set; } = default;
	public string STDOVHDFORMULA { get; set; } = string.Empty;
	public string STDOVHDRPFORMULA { get; set; } = string.Empty;
	public string ACTOVHDFORMULA { get; set; } = string.Empty;
	public string ACTOVHDRPFORMULA { get; set; } = string.Empty;
	public int ITEMREF { get; set; } = default;
	public DateTime OPWSBEGDATE { get; set; } = default;
	public int BOMMASTERREF { get; set; } = default;
	public double STPDURATION { get; set; } = default;
	public double STPCOSTDURATION { get; set; } = default;
	public string DOCODE { get; set; } = string.Empty;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public short SITEID { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public int ORGLOGICREF { get; set; } = default;
	public int WFSTATUS { get; set; } = default;
	public short PRINTCNT { get; set; } = default;
	public int PROJECTREF { get; set; } = default;
	public short DOCOUNTING { get; set; } = default;
	public int VARIANTREF { get; set; } = default;
	public double UFRSMATERIALCOST { get; set; } = default;
	public double UFRSEQUIPTCOST { get; set; } = default;
	public double UFRSWSCOST { get; set; } = default;
	public double UFRSLABORCOST { get; set; } = default;
	public double UFRSOVERHCOST { get; set; } = default;
	public double UFRSTOTALCOST { get; set; } = default;
	public double UFRSMATERIALRPCOST { get; set; } = default;
	public double UFRSEQUIPTRPCOST { get; set; } = default;
	public double UFRSWSRPCOST { get; set; } = default;
	public double UFRSLABORRPCOST { get; set; } = default;
	public double UFRSOVERHRPCOST { get; set; } = default;
	public double UFRSTOTALRPCOST { get; set; } = default;
	public double STDOVERHCOSTG1 { get; set; } = default;
	public double STDOVERHCOSTG2 { get; set; } = default;
	public double STDOVERHCOSTG3 { get; set; } = default;
	public double STDOVERHCOSTG4 { get; set; } = default;
	public double STDOVERHCOSTG5 { get; set; } = default;
	public double STDOVERHCOSTG6 { get; set; } = default;
	public double STDOVERHCOSTG7 { get; set; } = default;
	public double STDOVERHCOSTG8 { get; set; } = default;
	public double STDOVERHCOSTG9 { get; set; } = default;
	public double STDOVERHCOSTG10 { get; set; } = default;
	public double STDOVERHRPCOSTG1 { get; set; } = default;
	public double STDOVERHRPCOSTG2 { get; set; } = default;
	public double STDOVERHRPCOSTG3 { get; set; } = default;
	public double STDOVERHRPCOSTG4 { get; set; } = default;
	public double STDOVERHRPCOSTG5 { get; set; } = default;
	public double STDOVERHRPCOSTG6 { get; set; } = default;
	public double STDOVERHRPCOSTG7 { get; set; } = default;
	public double STDOVERHRPCOSTG8 { get; set; } = default;
	public double STDOVERHRPCOSTG9 { get; set; } = default;
	public double STDOVERHRPCOSTG10 { get; set; } = default;
	public double ACTOVERHCOSTG1 { get; set; } = default;
	public double ACTOVERHCOSTG2 { get; set; } = default;
	public double ACTOVERHCOSTG3 { get; set; } = default;
	public double ACTOVERHCOSTG4 { get; set; } = default;
	public double ACTOVERHCOSTG5 { get; set; } = default;
	public double ACTOVERHCOSTG6 { get; set; } = default;
	public double ACTOVERHCOSTG7 { get; set; } = default;
	public double ACTOVERHCOSTG8 { get; set; } = default;
	public double ACTOVERHCOSTG9 { get; set; } = default;
	public double ACTOVERHCOSTG10 { get; set; } = default;
	public double ACTOVERHRPCOSTG1 { get; set; } = default;
	public double ACTOVERHRPCOSTG2 { get; set; } = default;
	public double ACTOVERHRPCOSTG3 { get; set; } = default;
	public double ACTOVERHRPCOSTG4 { get; set; } = default;
	public double ACTOVERHRPCOSTG5 { get; set; } = default;
	public double ACTOVERHRPCOSTG6 { get; set; } = default;
	public double ACTOVERHRPCOSTG7 { get; set; } = default;
	public double ACTOVERHRPCOSTG8 { get; set; } = default;
	public double ACTOVERHRPCOSTG9 { get; set; } = default;
	public double ACTOVERHRPCOSTG10 { get; set; } = default;
	public double UFRSOVERHCOSTG1 { get; set; } = default;
	public double UFRSOVERHCOSTG2 { get; set; } = default;
	public double UFRSOVERHCOSTG3 { get; set; } = default;
	public double UFRSOVERHCOSTG4 { get; set; } = default;
	public double UFRSOVERHCOSTG5 { get; set; } = default;
	public double UFRSOVERHCOSTG6 { get; set; } = default;
	public double UFRSOVERHCOSTG7 { get; set; } = default;
	public double UFRSOVERHCOSTG8 { get; set; } = default;
	public double UFRSOVERHCOSTG9 { get; set; } = default;
	public double UFRSOVERHCOSTG10 { get; set; } = default;
	public double UFRSOVERHRPCOSTG1 { get; set; } = default;
	public double UFRSOVERHRPCOSTG2 { get; set; } = default;
	public double UFRSOVERHRPCOSTG3 { get; set; } = default;
	public double UFRSOVERHRPCOSTG4 { get; set; } = default;
	public double UFRSOVERHRPCOSTG5 { get; set; } = default;
	public double UFRSOVERHRPCOSTG6 { get; set; } = default;
	public double UFRSOVERHRPCOSTG7 { get; set; } = default;
	public double UFRSOVERHRPCOSTG8 { get; set; } = default;
	public double UFRSOVERHRPCOSTG9 { get; set; } = default;
	public double UFRSOVERHRPCOSTG10 { get; set; } = default;
	public double ROLLUPMATERIALCOST { get; set; } = default;
	public double ROLLUPEQUIPTCOST { get; set; } = default;
	public double ROLLUPWSCOST { get; set; } = default;
	public double ROLLUPLABORCOST { get; set; } = default;
	public double ROLLUPOVERHCOST { get; set; } = default;
	public double ROLLUPTOTALCOST { get; set; } = default;
	public double ROLLUPMATERIALRPCOST { get; set; } = default;
	public double ROLLUPEQUIPTRPCOST { get; set; } = default;
	public double ROLLUPWSRPCOST { get; set; } = default;
	public double ROLLUPLABORRPCOST { get; set; } = default;
	public double ROLLUPOVERHRPCOST { get; set; } = default;
	public double ROLLUPTOTALRPCOST { get; set; } = default;
	public double ROLLUPOVERHCOSTG1 { get; set; } = default;
	public double ROLLUPOVERHCOSTG2 { get; set; } = default;
	public double ROLLUPOVERHCOSTG3 { get; set; } = default;
	public double ROLLUPOVERHCOSTG4 { get; set; } = default;
	public double ROLLUPOVERHCOSTG5 { get; set; } = default;
	public double ROLLUPOVERHCOSTG6 { get; set; } = default;
	public double ROLLUPOVERHCOSTG7 { get; set; } = default;
	public double ROLLUPOVERHCOSTG8 { get; set; } = default;
	public double ROLLUPOVERHCOSTG9 { get; set; } = default;
	public double ROLLUPOVERHCOSTG10 { get; set; } = default;
	public double ROLLUPOVERHRPCOSTG1 { get; set; } = default;
	public double ROLLUPOVERHRPCOSTG2 { get; set; } = default;
	public double ROLLUPOVERHRPCOSTG3 { get; set; } = default;
	public double ROLLUPOVERHRPCOSTG4 { get; set; } = default;
	public double ROLLUPOVERHRPCOSTG5 { get; set; } = default;
	public double ROLLUPOVERHRPCOSTG6 { get; set; } = default;
	public double ROLLUPOVERHRPCOSTG7 { get; set; } = default;
	public double ROLLUPOVERHRPCOSTG8 { get; set; } = default;
	public double ROLLUPOVERHRPCOSTG9 { get; set; } = default;
	public double ROLLUPOVERHRPCOSTG10 { get; set; } = default;
	public string GUID { get; set; } = string.Empty;
	public double WAITBATCH { get; set; } = default;
	public int WAITTIME { get; set; } = default;
	public short PRODORDTYP { get; set; } = default;
	public int CLIENTREF { get; set; } = default;
	public short MANUELEDIT { get; set; } = default;
	public short REWORK { get; set; } = default;
	public short PARTING { get; set; } = default;
	public DateTime PRINTDATE { get; set; } = default;
	public short ENTRYTYPE { get; set; } = default;
}
