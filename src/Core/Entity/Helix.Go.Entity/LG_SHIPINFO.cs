namespace Helix.Go.Entity;

public class LG_SHIPINFO
{
	#region Properties
	public int LOGICALREF { get; set; }

	public int? CLIENTREF { get; set; }

	public string CODE { get; set; } = string.Empty;

	public string NAME { get; set; } = string.Empty;

	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;

	public string ADDR1 { get; set; } = string.Empty;

	public string ADDR2 { get; set; } = string.Empty;

	public string CITY { get; set; } = string.Empty;

	public string COUNTRY { get; set; } = string.Empty;

	public string POSTCODE { get; set; } = string.Empty;

	public string TELNRS1 { get; set; } = string.Empty;

	public string TELNRS2 { get; set; } = string.Empty;

	public string FAXNR { get; set; } = string.Empty;
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
	public string TRADINGGRP { get; set; } = string.Empty;
	public string VATNR { get; set; } = string.Empty;

	public string TAXNR { get; set; } = string.Empty;

	public string TAXOFFICE { get; set; } = string.Empty;

	public string TOWNCODE { get; set; } = string.Empty;

	public string TOWN { get; set; } = string.Empty;
	public string DISTRICTCODE { get; set; } = string.Empty;
	public string DISTRICT { get; set; } = string.Empty;

	public string CITYCODE { get; set; } = string.Empty;

	public string COUNTRYCODE { get; set; } = string.Empty;
	public short? ACTIVE { get; set; }
	public short? TEXTINC { get; set; }

	public string EMAILADDR { get; set; } = string.Empty;

	public string INCHANGE { get; set; } = string.Empty;

	public string TELCODES1 { get; set; } = string.Empty;

	public string TELCODES2 { get; set; } = string.Empty;

	public string FAXCODE { get; set; } = string.Empty;
	public string LONGITUDE { get; set; } = string.Empty;
	public string LATITUTE { get; set; } = string.Empty;

	public string CITYID { get; set; } = string.Empty;

	public string TOWNID { get; set; } = string.Empty;
	public int? SHIPBEGTIME1 { get; set; }
	public int? SHIPBEGTIME2 { get; set; }
	public int? SHIPBEGTIME3 { get; set; }
	public int? SHIPENDTIME1 { get; set; }
	public int? SHIPENDTIME2 { get; set; }
	public int? SHIPENDTIME3 { get; set; }
	public string POSTLABELCODE { get; set; } = string.Empty;
	public string SENDERLABELCODE { get; set; } = string.Empty;
	public string TITLE { get; set; } = string.Empty;

	public short? DEFAULTFLG { get; set; }
	#endregion
}
