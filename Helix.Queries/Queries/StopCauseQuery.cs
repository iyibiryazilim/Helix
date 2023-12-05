using Microsoft.Extensions.Configuration;

namespace Helix.Queries
{
	public class StopCauseQuery : BaseQuery
	{
		public StopCauseQuery(IConfiguration configuration) : base(configuration)
		{
		}

		public string GetStopCauseList() =>
			$@"SELECT
		[ReferenceId] = STOPCAUSE.LOGICALREF,
		[Code] = STOPCAUSE.CODE,
		[Name] = STOPCAUSE.NAME,
		[AffectsCost] = STOPCAUSE.AFFECTSCOST,
		[AffectsPlan] = STOPCAUSE.AFFECTSPLAN
		FROM LG_00{FirmNumber}_STOPCAUSE AS STOPCAUSE";
	}
}
