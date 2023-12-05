namespace Helix.Go.Entity;

public class L_CAPIWHOUSE
{
	#region Properties
	public int? LOGICALREF { get; set; }
	public short? FIRMNR { get; set; }
	public short? NR { get; set; }
	public string NAME { get; set; } = string.Empty;
	public short? DIVISNR { get; set; }
	public short? FACTNR { get; set; }
	public short? COSTGRP { get; set; }
	public short? SITEID { get; set; }
	public int? USEREXT { get; set; }
	public DateTime MODDATE { get; set; }
	public int? MODTIME { get; set; }
	public short? VIRTUALINVEN { get; set; }
	public string LONGITUDE { get; set; } = string.Empty;
	public string LATITUTE { get; set; } = string.Empty;
	public string ADDR1 { get; set; } = string.Empty;
	public string ADDR2 { get; set; } = string.Empty;
	public string TOWNCODE { get; set; } = string.Empty;
	public string TOWN { get; set; } = string.Empty;
	public string DISTRICTCODE { get; set; } = string.Empty;
	public string DISTRICT { get; set; } = string.Empty;
	public string CITYCODE { get; set; } = string.Empty;
	public string CITY { get; set; } = string.Empty;
	public string COUNTRYCODE { get; set; } = string.Empty;
	public string COUNTRY { get; set; } = string.Empty;
	public string TELCODES1 { get; set; } = string.Empty;
	public string TELCODES2 { get; set; } = string.Empty;
	public string TELNRS1 { get; set; } = string.Empty;
	public string TELNRS2 { get; set; } = string.Empty;
	public string TELEXTNUMS1 { get; set; } = string.Empty;
	public string TELEXTNUMS2 { get; set; } = string.Empty;
	public string EMAILADDR { get; set; } = string.Empty;
	public string SHPAGNCOD { get; set; } = string.Empty;
	public short? AREACODE { get; set; }
	#endregion
}
