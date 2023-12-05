using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.Go.Entity;

public class LG_SHIFT
{
	public int LOGICALREF { get; set; }
	public string CODE { get; set; } = string.Empty;
	public string NAME { get; set; } = string.Empty;
	public short ACTIVE { get; set; } = default;
	public string SPECODE { get; set; } = string.Empty;
	public string CYPHCODE { get; set; } = string.Empty;
	public int SITEID { get; set; }
	public int ORGLOGICREF { get; set; }
	public short CAPIBLOCK_CREADEDBY { get; set; } = default;
	public DateTime CAPIBLOCK_CREADEDDATE { get; set; }
	public short CAPIBLOCK_CREATEDHOUR { get; set; } = default;
	public short CAPIBLOCK_CREATEDMIN { get; set; } = default;
	public short CAPIBLOCK_CREATEDSEC { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDBY { get; set; } = default;
	public DateTime CAPIBLOCK_MODIFIEDDATE { get; set; }
	public short CAPIBLOCK_MODIFIEDHOUR { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDMIN { get; set; } = default;
	public short CAPIBLOCK_MODIFIEDSEC { get; set; } = default;
	public short TEXTINC { get; set; } = default;
	public short RECSTATUS { get; set; } = default;
	public double COSTFACTOR { get; set; }
	public short WHOLEDAY { get; set; } = default;
	public short CARDTYPE { get; set; } = default;
	public string GUID { get; set; } = string.Empty;
}
