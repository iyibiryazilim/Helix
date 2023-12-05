namespace Helix.Go.Entity;

public class LG_ITEMS
{
	#region Properties

	public int LOGICALREF { get; set; }
	public short? ACTIVE { get; set; }
	public short? CARDTYPE { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string NAME { get; set; } = string.Empty;
	public string STGRPCODE { get; set; } = string.Empty;
	public string PRODUCERCODE { get; set; } = string.Empty;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public short? CLASSTYPE { get; set; }
	public short? PURCHBRWS { get; set; }
	public short? SALESBRWS { get; set; }
	public short? MTRLBRWS { get; set; }
	public double VAT { get; set; } = default;
	public int? PAYMENTREF { get; set; }
	public short TRACKTYPE { get; set; }
	public short LOCTRACKING { get; set; }
	public short? TOOL { get; set; }
	public short? AUTOINCSL { get; set; }
	public short? DIVLOTSIZE { get; set; }
	public short? MOLD { get; set; }
	public double? SHELFLIFE { get; set; }
	public short? SHELFDATE { get; set; }
	public int? DOMINANTREFS1 { get; set; }
	public int? DOMINANTREFS2 { get; set; }
	public int? DOMINANTREFS3 { get; set; }
	public int? DOMINANTREFS4 { get; set; }
	public int? DOMINANTREFS5 { get; set; }
	public int? DOMINANTREFS6 { get; set; }
	public int? DOMINANTREFS7 { get; set; }
	public int? DOMINANTREFS8 { get; set; }
	public int? DOMINANTREFS9 { get; set; }
	public int? DOMINANTREFS10 { get; set; }
	public int? DOMINANTREFS11 { get; set; }
	public int? DOMINANTREFS12 { get; set; }
	public short? IMAGEINC { get; set; }
	public short? TEXTINC { get; set; }
	public short? DEPRTYPE { get; set; }
	public double? DEPRRATE { get; set; }
	public short? DEPRDUR { get; set; }
	public double? SALVAGEVAL { get; set; }
	public short? REVALFLAG { get; set; }
	public short? REVDEPRFLAG { get; set; }
	public short? PARTDEP { get; set; }
	public short? DEPRTYPE2 { get; set; }
	public double? DEPRRATE2 { get; set; }
	public short? DEPRDUR2 { get; set; }
	public short? REVALFLAG2 { get; set; }
	public short? REVDEPRFLAG2 { get; set; }
	public short? PARTDEP2 { get; set; }
	public short? APPROVED { get; set; }
	public int UNITSETREF { get; set; }
	public int? QCCSETREF { get; set; }
	public double? DISTAMOUNT { get; set; }
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
	public string UNIVID { get; set; } = string.Empty;
	public short? DISTLOTUNITS { get; set; }
	public short? COMBLOTUNITS { get; set; }
	public int? WFSTATUS { get; set; }
	public double? DISTPOINT { get; set; }
	public double? CAMPPOINT { get; set; }
	public short? CANUSEINTRNS { get; set; }
	public string ISONR { get; set; } = string.Empty;
	public string GROUPNR { get; set; } = string.Empty;
	public string PRODCOUNTRY { get; set; } = string.Empty;
	public int? ADDTAXREF { get; set; }
	public double? QPRODAMNT { get; set; }
	public int? QPRODUOM { get; set; }
	public short? QPRODSRCINDEX { get; set; }
	public int? EXTACCESSFLAGS { get; set; }
	public short? PACKET { get; set; }
	public double? SALVAGEVAL2 { get; set; }
	public double? SELLVAT { get; set; }
	public double? RETURNVAT { get; set; }
	public string LOGOID { get; set; } = string.Empty;
	public short? LIDCONFIRMED { get; set; }
	public string GTIPCODE { get; set; } = string.Empty;
	public string EXPCTGNO { get; set; } = string.Empty;
	public string B2CCODE { get; set; } = string.Empty;
	public int MARKREF { get; set; }
	public short? IMAGE2INC { get; set; }
	public double? AVRWHDURATION { get; set; }
	public int? EXTCARDFLAGS { get; set; }
	public double? MINORDAMOUNT { get; set; }
	public string FREIGHTPLACE { get; set; } = string.Empty;
	public string FREIGHTTYPCODE1 { get; set; } = string.Empty;
	public string FREIGHTTYPCODE2 { get; set; } = string.Empty;
	public string FREIGHTTYPCODE3 { get; set; } = string.Empty;
	public string FREIGHTTYPCODE4 { get; set; } = string.Empty;
	public string FREIGHTTYPCODE5 { get; set; } = string.Empty;
	public string FREIGHTTYPCODE6 { get; set; } = string.Empty;
	public string FREIGHTTYPCODE7 { get; set; } = string.Empty;
	public string FREIGHTTYPCODE8 { get; set; } = string.Empty;
	public string FREIGHTTYPCODE9 { get; set; } = string.Empty;
	public string FREIGHTTYPCODE10 { get; set; } = string.Empty;
	public string STATECODE { get; set; } = string.Empty;
	public string STATENAME { get; set; } = string.Empty;
	public string EXPCATEGORY { get; set; } = string.Empty;
	public double? LOSTFACTOR { get; set; }
	public short? TEXTINCENG { get; set; }
	public string EANBARCODE { get; set; } = string.Empty;
	public string DEPRCLASSTYPE { get; set; } = string.Empty;
	public int? WFLOWCRDREF { get; set; }
	public double? SELLPRVAT { get; set; }
	public double? RETURNPRVAT { get; set; }
	public int? LOWLEVELCODES1 { get; set; }
	public int? LOWLEVELCODES2 { get; set; }
	public int? LOWLEVELCODES3 { get; set; }
	public int? LOWLEVELCODES4 { get; set; }
	public int? LOWLEVELCODES5 { get; set; }
	public int? LOWLEVELCODES6 { get; set; }
	public int? LOWLEVELCODES7 { get; set; }
	public int? LOWLEVELCODES8 { get; set; }
	public int? LOWLEVELCODES9 { get; set; }
	public int? LOWLEVELCODES10 { get; set; }
	public string ORGLOGOID { get; set; } = string.Empty;
	public short? QPRODDEPART { get; set; }
	public short? CANCONFIGURE { get; set; }
	public int? CHARSETREF { get; set; }
	public short? CANDEDUCT { get; set; }
	public int? CONSCODEREF { get; set; }


	public string SPECODE2 { get; set; } = string.Empty;


	public string SPECODE3 { get; set; } = string.Empty;


	public string SPECODE4 { get; set; } = string.Empty;


	public string SPECODE5 { get; set; } = string.Empty;
	public short? EXPENSE { get; set; }
	public string ORIGIN { get; set; } = string.Empty;


	public string NAME2 { get; set; } = string.Empty;
	public short? COMPKDVUSE { get; set; }
	public short? USEDINPERIODS { get; set; }
	public double? EXIMTAX1 { get; set; }
	public double? EXIMTAX2 { get; set; }
	public double? EXIMTAX3 { get; set; }
	public double? EXIMTAX4 { get; set; }
	public double? EXIMTAX5 { get; set; }
	public short? PRODUCTLEVEL { get; set; }
	public short? APPSPEVATMATRAH { get; set; }


	public string NAME3 { get; set; } = string.Empty;
	public short? FACOSTKEYS { get; set; }
	public short? KKLINESDISABLE { get; set; }
	public short? APPROVE { get; set; }
	public DateTime? APPROVEDATE { get; set; }
	public string GLOBALID { get; set; } = string.Empty;
	public short? SALEDEDUCTPART1 { get; set; }
	public short? SALEDEDUCTPART2 { get; set; }
	public short? PURCDEDUCTPART1 { get; set; }
	public short? PURCDEDUCTPART2 { get; set; }
	public string CATEGORYID { get; set; } = string.Empty;
	public string CATEGORYNAME { get; set; } = string.Empty;
	public string KEYWORD1 { get; set; } = string.Empty;
	public string KEYWORD2 { get; set; } = string.Empty;
	public string KEYWORD3 { get; set; } = string.Empty;
	public string KEYWORD4 { get; set; } = string.Empty;
	public string KEYWORD5 { get; set; } = string.Empty;
	public string GUID { get; set; } = string.Empty;
	public string DEMANDMEETSORTFLD4 { get; set; } = string.Empty;
	public string DEMANDMEETSORTFLD5 { get; set; } = string.Empty;
	public string DEMANDMEETSORTFLD3 { get; set; } = string.Empty;
	public string DEMANDMEETSORTFLD1 { get; set; } = string.Empty;
	public string DEMANDMEETSORTFLD2 { get; set; } = string.Empty;

	public string DEDUCTCODE { get; set; } = string.Empty;
	public int? PROJECTREF { get; set; }

	public int? QPRODSUBUOM { get; set; }


	public double? QPRODSUBAMNT { get; set; }
	public double? PORDAMNTTOLERANCE { get; set; }
	public double? SORDAMNTTOLERANCE { get; set; }

	public short? QPRODSUBSRCINDEX { get; set; }
	public short? QPRODSUBDEPART { get; set; }
	public short? MULTIADDTAX { get; set; }




	public int? PUBLICCOUNTRYREF { get; set; }
	public string NAME4 { get; set; } = string.Empty;
	public string CPACODE { get; set; } = string.Empty;

	#endregion
}
