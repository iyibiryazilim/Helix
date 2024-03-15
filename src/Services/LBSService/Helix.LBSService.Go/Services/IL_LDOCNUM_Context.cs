namespace Helix.LBSService.Go.Services
{
	public interface IL_LDOCNUM_Context
	{
		public Task<string> GetLastAsgn(string effsdate, string effedate, int TRCODE);
		public Task<int> UpdateObject(string lastAsgnd, string effsdate, string effedate, int TRCODE);

	}
}
