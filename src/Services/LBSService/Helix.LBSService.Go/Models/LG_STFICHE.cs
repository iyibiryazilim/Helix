﻿namespace Helix.LBSService.Go.Models
{
	public class LG_STFICHE
	{
		public string EmployeeOid { get; set; } = string.Empty;

		#region Properties

		public int LOGICALREF { get; set; }
		public short GRPCODE { get; set; } = default;
		public short TRCODE { get; set; } = default;
		public short IOCODE { get; set; } = default;
		public string FICHENO { get; set; } = string.Empty;
		public DateTime DATE_ { get; set; } = DateTime.Now;
		public int FTIME { get; set; } = default;
		public string DOCODE { get; set; } = string.Empty;
		public string INVNO { get; set; } = string.Empty;
		public string SPECODE { get; set; } = string.Empty;
		public string CYPHCODE { get; set; } = string.Empty;
		public int INVOICEREF { get; set; } = default;
		public int CLIENTREF { get; set; } = default;
		public int RECVREF { get; set; } = default;
		public int ACCOUNTREF { get; set; } = default;
		public int CENTERREF { get; set; } = default;
		public int PRODORDERREF { get; set; } = default;
		public string PORDERFICHENO { get; set; } = string.Empty;
		public short SOURCETYPE { get; set; } = default;
		public short SOURCEINDEX { get; set; } = default;
		public int SOURCEWSREF { get; set; } = default;
		public int SOURCEPOLNREF { get; set; } = default;
		public short SOURCECOSTGRP { get; set; } = default;
		public short DESTTYPE { get; set; } = default;
		public short DESTINDEX { get; set; } = default;
		public int DESTWSREF { get; set; } = default;
		public int DESTPOLNREF { get; set; } = default;
		public short DESTCOSTGRP { get; set; } = default;
		public short FACTORYNR { get; set; } = default;
		public short BRANCH { get; set; } = default;
		public short DEPARTMENT { get; set; } = default;
		public short COMPBRANCH { get; set; } = default;
		public short COMPDEPARTMENT { get; set; } = default;
		public short COMPFACTORY { get; set; } = default;
		public short PRODSTAT { get; set; } = default;
		public short DEVIR { get; set; } = default;
		public short CANCELLED { get; set; } = default;
		public short BILLED { get; set; } = default;
		public short ACCOUNTED { get; set; } = default;
		public short UPDCURR { get; set; } = default;
		public short INUSE { get; set; } = default;
		public short INVKIND { get; set; } = default;
		public double ADDDISCOUNTS { get; set; } = default;
		public double TOTALDISCOUNTS { get; set; } = default;
		public double TOTALDISCOUNTED { get; set; } = default;
		public double ADDEXPENSES { get; set; } = default;
		public double TOTALEXPENSES { get; set; } = default;
		public double TOTALDEPOZITO { get; set; } = default;
		public double TOTALPROMOTIONS { get; set; } = default;
		public double TOTALVAT { get; set; } = default;
		public double GROSSTOTAL { get; set; } = default;
		public double NETTOTAL { get; set; } = default;
		public string GENEXP1 { get; set; } = string.Empty;
		public string GENEXP2 { get; set; } = string.Empty;
		public string GENEXP3 { get; set; } = string.Empty;
		public string GENEXP4 { get; set; } = string.Empty;
		public string GENEXP5 { get; set; } = string.Empty;
		public string GENEXP6 { get; set; } = string.Empty;
		public double REPORTRATE { get; set; } = default;
		public double REPORTNET { get; set; } = default;
		public int EXTENREF { get; set; } = default;
		public int PAYDEFREF { get; set; } = default;
		public short PRINTCNT { get; set; } = default;
		public short FICHECNT { get; set; } = default;
		public int ACCFICHEREF { get; set; } = default;
		public short CAPIBLOCK_CREATEDBY { get; set; } = default;
		public DateTime CAPIBLOCK_CREADEDDATE { get; set; } = DateTime.Now;
		public short CAPIBLOCK_CREATEDHOUR { get; set; } = (short)DateTime.Now.Hour;
		public short CAPIBLOCK_CREATEDMIN { get; set; } = (short)DateTime.Now.Minute;
		public short CAPIBLOCK_CREATEDSEC { get; set; } = (short)DateTime.Now.Second;
		public short CAPIBLOCK_MODIFIEDBY { get; set; } = default;
		public DateTime CAPIBLOCK_MODIFIEDDATE { get; set; } = DateTime.Now;
		public short CAPIBLOCK_MODIFIEDHOUR { get; set; } = default;
		public short CAPIBLOCK_MODIFIEDMIN { get; set; } = default;
		public short CAPIBLOCK_MODIFIEDSEC { get; set; } = default;
		public int SALESMANREF { get; set; } = default;
		public short CANCELLEDACC { get; set; } = default;
		public string SHPTYPCOD { get; set; } = string.Empty;
		public string SHPAGNCOD { get; set; } = string.Empty;
		public string TRACKNR { get; set; } = string.Empty;
		public short GENEXCTYP { get; set; } = default;
		public short LINEEXCTYP { get; set; } = default;
		public string TRADINGGRP { get; set; } = string.Empty;
		public short TEXTINC { get; set; } = default;
		public short SITEID { get; set; } = default;
		public short RECSTATUS { get; set; } = default;
		public int ORGLOGICREF { get; set; } = default;
		public int WFSTATUS { get; set; } = default;
		public int SHIPINFOREF { get; set; } = default;
		public int DISTORDERREF { get; set; } = default;
		public short SENDCNT { get; set; } = default;
		public short DLVCLIENT { get; set; } = default;
		public string DOCTRACKINGNR { get; set; } = string.Empty;
		public short ADDTAXCALC { get; set; } = default;
		public double TOTALADDTAX { get; set; } = default;
		public string UGIRTRACKINGNO { get; set; } = string.Empty;
		public int QPRODFCREF { get; set; } = default;
		public int VAACCREF { get; set; } = default;
		public int VACENTERREF { get; set; } = default;
		public string ORGLOGOID { get; set; } = string.Empty;
		public short FROMEXIM { get; set; } = default;
		public string FRGTYPCOD { get; set; } = string.Empty;
		public short TRCURR { get; set; } = default;
		public double TRRATE { get; set; } = default;
		public double TRNET { get; set; } = default;
		public int EXIMWHFCREF { get; set; } = default;
		public short EXIMFCTYPE { get; set; } = default;
		public int MAINSTFCREF { get; set; } = default;
		public short FROMORDWITHPAY { get; set; } = default;
		public int PROJECTREF { get; set; } = default;
		public int WFLOWCRDREF { get; set; } = default;
		public short STATUS { get; set; } = default;
		public short UPDTRCURR { get; set; } = default;
		public double TOTALEXADDTAX { get; set; } = default;
		public short AFFECTCOLLATRL { get; set; } = default;
		public short DEDUCTIONPART1 { get; set; } = default;
		public short DEDUCTIONPART2 { get; set; } = default;
		public short GRPFIRMTRANS { get; set; } = default;
		public short AFFECTRISK { get; set; } = default;
		public short DISPSTATUS { get; set; } = default;
		public short APPROVE { get; set; } = default;
		public DateTime APPROVEDATE { get; set; } = DateTime.Now;
		public short CANTCREDEDUCT { get; set; } = default;
		public DateTime SHIPDATE { get; set; } = DateTime.Now;
		public int SHIPTIME { get; set; } = default;
		public short ENTRUSTDEVIR { get; set; } = default;
		public int RELTRANSFCREF { get; set; } = default;
		public short FROMTRANSFER { get; set; } = default;
		public string GUID { get; set; } = string.Empty;
		public string GLOBALID { get; set; } = string.Empty;
		public int COMPSTFCREF { get; set; } = default;
		public int COMPINVREF { get; set; } = default;
		public double TOTALSERVICES { get; set; } = default;
		public string CAMPAIGNCODE { get; set; } = string.Empty;
		public int OFFERREF { get; set; } = default;
		public short EINVOICETYP { get; set; } = default;
		public short EINVOICE { get; set; } = default;
		public short NOCALCULATE { get; set; } = default;
		public short PRODORDERTYP { get; set; } = default;
		public short QPRODFCTYP { get; set; } = default;
		public DateTime PRINTDATE { get; set; } = DateTime.Now;
		public short PRDORDSLPLNRESERVE { get; set; } = default;
		public short CONTROLINFO { get; set; } = default;
		public short EDESPATCH { get; set; } = default;
		public DateTime DOCDATE { get; set; } = DateTime.Now;
		public int DOCTIME { get; set; } = default;
		public short EDESPSTATUS { get; set; } = default;
		public short PROFILEID { get; set; } = default;
		public string DELIVERYCODE { get; set; } = string.Empty;
		public short DESTSTATUS { get; set; } = default;
		public string CANCELEXP { get; set; } = string.Empty;
		public string UNDOEXP { get; set; } = string.Empty;
		public DateTime CANCELDATE { get; set; } = DateTime.Now;
		public string RECHASH { get; set; } = string.Empty;

		#endregion Properties

		public LG_STFICHE()
		{
			TRANSACTIONS = new List<LG_STLINE>();
		}

		public IList<LG_STLINE> TRANSACTIONS { get; set; }

		public LG_EINVOICEDET? EINVOICEDET { get; set; }
	}
}