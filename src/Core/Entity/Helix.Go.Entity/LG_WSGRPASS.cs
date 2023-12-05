namespace Helix.Go.Entity;

//Workstation ve Workstaion gurup ara tabolosu
public class LG_WSGRPASS
{
	public int LOGICALREF { get; set; } = default;
	public int WSGRPREF { get; set; } = default;
	public short PRIORITY { get; set; } = default;
	public int WSREF { get; set; } = default;
	public short DOMINSHFTGRP { get; set; } = default;
}
