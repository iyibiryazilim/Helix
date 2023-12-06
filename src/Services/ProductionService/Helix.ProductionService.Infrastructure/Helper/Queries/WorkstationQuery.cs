﻿using Microsoft.Extensions.Configuration;

namespace Helix.ProductionService.Infrastructure.Helper.Queries;

public class WorkstationQuery : BaseQuery
{
	public WorkstationQuery(IConfiguration configuration) : base(configuration)
	{
	}
	public string GetWorkstationList() =>
		@$"SELECT
			[ReferenceId] = Workstation.LOGICALREF,
			[Code]=Workstation.CODE,
			[Name]=Workstation.NAME,
			[SpeCode] = Workstation.SPECODE,
			[PermissionCode] = Workstation.CYPHCODE
			FROM LG_00{FirmNumber}_WORKSTAT AS Workstation";

	public string GetWorkstationByCode(string code) =>
		@$"SELECT
			[ReferenceId] = Workstation.LOGICALREF,
			[Code]=Workstation.CODE,
			[Name]=Workstation.NAME,
			[SpeCode] = Workstation.SPECODE,
			[PermissionCode] = Workstation.CYPHCODE
			FROM LG_00{FirmNumber}_WORKSTAT AS Workstation
			WHERE Workstation.CODE = '{code}'";
	public string GetWorkstationById(int id) =>
		@$"SELECT
			[ReferenceId] = Workstation.LOGICALREF,
			[Code]=Workstation.CODE,
			[Name]=Workstation.NAME,
			[SpeCode] = Workstation.SPECODE,
			[PermissionCode] = Workstation.CYPHCODE
			FROM LG_00{FirmNumber}_WORKSTAT AS Workstation
			WHERE Workstation.LOGICALREF = {id}";
}
}
