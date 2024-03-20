using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Helper;
using Helix.LBSService.Tiger.Helper.ErrorHelper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Microsoft.Extensions.Logging;
using UnityObjects;

namespace Helix.LBSService.Tiger.DataStores
{
	public class LG_VariantDataStore : ILG_VariantService
	{
		private IUnityApplicationService _unityApplicationService;
		private ILogger<LG_VariantDataStore> _logger;

		public LG_VariantDataStore(ILogger<LG_VariantDataStore> logger, IUnityApplicationService unityApplicationService)
		{
			_unityApplicationService = unityApplicationService;
			_logger = logger;
		}

		public async Task<DataResult<LG_Variant>> Insert(LG_Variant dto)
		{
			UnityApplication unity = Global.UnityApp;
			DataResult<LG_Variant> result = new();

			try
			{
				if (!unity.LoggedIn)
					await _unityApplicationService.LogIn();

				if (unity.LoggedIn)
				{
					try
					{
						Data variant = unity.NewDataObject(DataObjectType.doVariant);
						variant.New();
						variant.DataFields.FieldByName("INTERNAL_REFERENCE").Value = dto.INTERNAL_REFERENCE;
						variant.DataFields.FieldByName("CARDTYPE").Value = dto.CARDTYPE;
						variant.DataFields.FieldByName("CODE").Value = dto.CODE;
						variant.DataFields.FieldByName("NAME").Value = dto.NAME;
						variant.DataFields.FieldByName("CYPHCODE").Value = dto.CYPHCODE;
						variant.DataFields.FieldByName("UNITSETCODE").Value = dto.UNITSETCODE;
						variant.DataFields.FieldByName("DATA_REFERENCE").Value = dto.DATA_REFERENCE;
						variant.DataFields.FieldByName("CAPIBLOCK_CREATEDBY").Value = dto.CAPIBLOCK_CREATEDBY;
						variant.DataFields.FieldByName("CAPIBLOCK_CREADEDDATE").Value = dto.CAPIBLOCK_CREADEDDATE;
						variant.DataFields.FieldByName("CAPIBLOCK_CREATEDHOUR").Value = dto.CAPIBLOCK_CREATEDHOUR;
						variant.DataFields.FieldByName("CAPIBLOCK_CREATEDMIN").Value = dto.CAPIBLOCK_CREATEDMIN;
						variant.DataFields.FieldByName("CAPIBLOCK_CREATEDSEC").Value = dto.CAPIBLOCK_CREATEDSEC;
						variant.DataFields.FieldByName("ICODE").Value = dto.ICODE;
						variant.DataFields.FieldByName("IDEF").Value = dto.IDEF;

						Lines vrnt_assigns_lines = variant.DataFields.FieldByName("VRNT_ASSIGNS").Lines;

						foreach (var line in dto.VRNT_ASSIGNS)
						{
							vrnt_assigns_lines.AppendLine();
							vrnt_assigns_lines[vrnt_assigns_lines.Count - 1].FieldByName("INTERNAL_REFERENCE").Value = line.INTERNAL_REFERENCE;
							vrnt_assigns_lines[vrnt_assigns_lines.Count - 1].FieldByName("CHARCODE").Value = line.CHARCODE;
							vrnt_assigns_lines[vrnt_assigns_lines.Count - 1].FieldByName("CHARDEF").Value = line.CHARDEF;
							vrnt_assigns_lines[vrnt_assigns_lines.Count - 1].FieldByName("CHARVAL").Value = line.CHARVAL;
							vrnt_assigns_lines[vrnt_assigns_lines.Count - 1].FieldByName("DATA_REFERENCE").Value = line.DATA_REFERENCE;
						}
						if (variant.Post())
						{
							var referenceId = Convert.ToInt32(variant.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());

							result.Data = null;
							result.IsSuccess = true;
							result.Message = "Success";
							_logger.LogInformation($"Variant Inserted :{referenceId}");
						}
						else
						{
							result.IsSuccess = false;
							result.Message = new ErrorHelper().GetError(variant);
						}
					}
					catch (Exception ex)
					{
						_logger.LogError(ex, ex.Message);
						result = new DataResult<LG_Variant>
						{
							Data = null,
							IsSuccess = false,
							Message = ex.Message == string.Empty ? "Error " : ex.Message
						};
					}
				}
				else
				{
					_logger.LogError(unity.GetLastError() + "-" + unity.GetLastErrorString());

					result = new DataResult<LG_Variant>
					{
						Data = null,
						IsSuccess = false,
						Message = unity.GetLastError() + "-" + unity.GetLastErrorString()
					};
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
			}
			return await Task.FromResult(result);
		}
	}
}