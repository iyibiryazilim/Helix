﻿namespace Helix.Go.Entity;

public class LG_EINVOICEDET
{
	public int LOGICALREF { get; set; } = default;
	public int INVOICEREF { get; set; } = default;
	public int STFREF { get; set; } = default;
	public short EINVOICETYP { get; set; } = default;
	public short PROFILEID { get; set; } = default;
	public short ESTATUS { get; set; } = default;
	public DateTime ESTARTDATE { get; set; } = default;
	public DateTime EENDDATE { get; set; } = default;
	public string EDESCRIPTION { get; set; } = string.Empty;
	public double EDURATION { get; set; } = default;
	public short EDURATIONTYPE { get; set; } = default;
	public short TAXTYPE { get; set; } = default;
	public string TUNAME { get; set; } = string.Empty;
	public string TUSURNAME { get; set; } = string.Empty;
	public string TUPASSPORTNO { get; set; } = string.Empty;
	public DateTime TUPASSPORTDATE { get; set; } = default;
	public string TUNATIONALITY { get; set; } = string.Empty;
	public string TUNATIONALITYNAME { get; set; } = string.Empty;
	public string TUBANKNAME { get; set; } = string.Empty;
	public string TUBNACCOUNTNO { get; set; } = string.Empty;
	public string TUBNBRANCH { get; set; } = string.Empty;
	public string TUPAYMENTNOTE { get; set; } = string.Empty;
	public string TUBNCURR { get; set; } = string.Empty;
	public string ADDR1 { get; set; } = string.Empty;
	public string ADDR2 { get; set; } = string.Empty;
	public string CITYCODE { get; set; } = string.Empty;
	public string CITY { get; set; } = string.Empty;
	public string COUNTRYCODE { get; set; } = string.Empty;
	public string COUNTRY { get; set; } = string.Empty;
	public string DISTRICTCODE { get; set; } = string.Empty;
	public string DISTRICT { get; set; } = string.Empty;
	public string TOWNCODE { get; set; } = string.Empty;
	public string TOWN { get; set; } = string.Empty;
	public string EXITTOWN { get; set; } = string.Empty;
	public string EXITGATECODE { get; set; } = string.Empty;
	public string EXITGATE { get; set; } = string.Empty;
	public string AGENCYCODE { get; set; } = string.Empty;
	public string AGENCY { get; set; } = string.Empty;
	public string EXITCOUNTRYCODE { get; set; } = string.Empty;
	public string EXITCOUNTRY { get; set; } = string.Empty;
	public short TRANSPORTTYP { get; set; } = default;
	public string TRANSPORTTYPCODE { get; set; } = string.Empty;
	public string TRANSPORTTYPNAME { get; set; } = string.Empty;
	public DateTime EXITDATE { get; set; } = default;
	public int EXITTIME { get; set; } = default;
	public string FLIGHTNUMBER { get; set; } = string.Empty;
	public string GUIDE { get; set; } = string.Empty;
	public double TURETPRICE { get; set; } = default;
	public short SENDEINVCUSTOM { get; set; } = default;
	public short EINVOICETYPSGK { get; set; } = default;
	public string TAXPAYERCODE { get; set; } = string.Empty;
	public string TAXPAYERNAME { get; set; } = string.Empty;
	public string DOCUMENTNOSGK { get; set; } = string.Empty;
	public string DRIVERNAME1 { get; set; } = string.Empty;
	public string DRIVERNAME2 { get; set; } = string.Empty;
	public string DRIVERNAME3 { get; set; } = string.Empty;
	public string DRIVERSURNAME1 { get; set; } = string.Empty;
	public string DRIVERSURNAME2 { get; set; } = string.Empty;
	public string DRIVERSURNAME3 { get; set; } = string.Empty;
	public string DRIVERTCKNO1 { get; set; } = string.Empty;
	public string DRIVERTCKNO2 { get; set; } = string.Empty;
	public string DRIVERTCKNO3 { get; set; } = string.Empty;
	public string PLATENUM1 { get; set; } = string.Empty;
	public string PLATENUM2 { get; set; } = string.Empty;
	public string PLATENUM3 { get; set; } = string.Empty;
	public string CHASSISNUM1 { get; set; } = string.Empty;
	public string CHASSISNUM2 { get; set; } = string.Empty;
	public string CHASSISNUM3 { get; set; } = string.Empty;
	public short RESPONSECODE { get; set; } = default;
	public short RESPONSESTATUS { get; set; } = default;
	public string STATUSDESC { get; set; } = string.Empty;
	public short RESPONSECODEDESP { get; set; } = default;
	public short RESPONSESTATUSDESP { get; set; } = default;
	public string STATUSDESCDESP { get; set; } = string.Empty;
	public int ORDFCREF { get; set; } = default;
	public short CHAINDELIVERY { get; set; } = default;
	public int SELLERCLIENTREF { get; set; } = default;
	public string TAXNRTOPAY { get; set; } = string.Empty;
}
