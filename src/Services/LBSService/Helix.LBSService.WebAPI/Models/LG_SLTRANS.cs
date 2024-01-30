﻿namespace Helix.LBSService.WebAPI.Models
{
	public class LG_SLTRANS
	{
		public int LOGICALREF { get; set; }
		public int STFICHEREF { get; set; } = default;
		public int STTRANSREF { get; set; } = default;
		public int INTRANSREF { get; set; } = default;
		public int INSLTRANSREF { get; set; } = default;
		public double? INSLAMOUNT { get; set; } = default;
		public short? LINENR { get; set; } = default;
		public int ITEMREF { get; set; } = default;
		public DateTime DATE_ { get; set; } = default;
		public short IOCODE { get; set; } = default;
		public short INVENNO { get; set; } = default;
		public short? FICHETYPE { get; set; } = default;
		public short SLTYPE { get; set; } = default;
		public int SLREF { get; set; } = default;
		public int LOCREF { get; set; } = default;
		public double? MAINAMOUNT { get; set; } = default;
		public int UOMREF { get; set; } = default;
		public double? AMOUNT { get; set; } = default;
		public double? REMAMOUNT { get; set; } = default;
		public double? REMLNUNITAMNT { get; set; } = default;
		public double UINFO1 { get; set; } = default;
		public double UINFO2 { get; set; } = default;
		public double? UINFO3 { get; set; } = default;
		public double? UINFO4 { get; set; } = default;
		public double? UINFO5 { get; set; } = default;
		public double? UINFO6 { get; set; } = default;
		public double? UINFO7 { get; set; } = default;
		public double? UINFO8 { get; set; } = default;
		public DateTime EXPDATE { get; set; } = default;
		public short? RATESCORE { get; set; } = default;
		public short? CANCELLED { get; set; } = default;
		public double? OUTCOST { get; set; } = default;
		public double? OUTCOSTCURR { get; set; } = default;
		public double? DIFFPRCOST { get; set; } = default;
		public double? DIFFPRCOSTCURR { get; set; } = default;
		public short? SERIQCOK { get; set; } = default;
		public short? LPRODSTAT { get; set; } = default;
		public short? SOURCETYPE { get; set; } = default;
		public int SOURCEWSREF { get; set; } = default;
		public short? SITEID { get; set; } = default;
		public short? RECSTATUS { get; set; } = default;
		public int? ORGLOGICREF { get; set; } = default;
		public int? WFSTATUS { get; set; } = default;
		public int? DISTORDREF { get; set; } = default;
		public int? DISTORDLNREF { get; set; } = default;
		public int? INDORDSLTRNREF { get; set; } = default;
		public double? GROSSUINFO1 { get; set; } = default;
		public double? GROSSUINFO2 { get; set; } = default;
		public double? ATAXPRCOST { get; set; } = default;
		public double? ATAXPRCOSTCURR { get; set; } = default;
		public double? INFIDX { get; set; } = default;
		public string ORGLOGOID { get; set; } = string.Empty;
		public string LINEEXP { get; set; } = string.Empty;
		public short? EXIMFCTYPE { get; set; } = default;
		public int? EXIMFILEREF { get; set; } = default;
		public short? EXIMPROCNR { get; set; } = default;
		public int? MAINSLLNREF { get; set; } = default;
		public short? MADEOFSHRED { get; set; } = default;
		public short? STATUS { get; set; } = default;
		public int? VARIANTREF { get; set; } = default;
		public string GRPBEGCODE { get; set; } = string.Empty;
		public string GRPENDCODE { get; set; } = string.Empty;
		public double? OUTCOSTUFRS { get; set; } = default;
		public double? OUTCOSTCURRUFRS { get; set; } = default;
		public double? DIFFPRCOSTUFRS { get; set; } = default;
		public double? DIFFPRCOSTCURRUFRS { get; set; } = default;
		public double? INFIDXUFRS { get; set; } = default;
		public double? ADJPRCOSTUFRS { get; set; } = default;
		public double? ADJPRCOSTCURRUFRS { get; set; } = default;
		public string GUID { get; set; } = string.Empty;
		public int? PRDORDREF { get; set; } = default;
		public short? PRDORDSLPLNRESERVE { get; set; } = default;
		public int? INPLNSLTRANSREF { get; set; } = default;
		public short? NOTSHIPPED { get; set; } = default;
	}
}
