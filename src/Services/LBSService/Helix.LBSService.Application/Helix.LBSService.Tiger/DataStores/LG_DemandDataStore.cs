using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Helper;
using Helix.LBSService.Tiger.Helper.ErrorHelper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using UnityObjects;

namespace Helix.LBSService.Tiger.DataStores
{
	public class LG_DemandDataStore : ILG_DemandService
	{
		private IUnityApplicationService _unityApplicationService;

		public LG_DemandDataStore(IUnityApplicationService unityApplicationService)
		{
			_unityApplicationService = unityApplicationService;
		}

		public async Task<DataResult<LG_Demand>> Insert(LG_Demand dto)
		{
			UnityApplication unity = Global.UnityApp;
			DataResult<LG_Demand> result = new();
			try
			{
				if (!unity.LoggedIn)
					await _unityApplicationService.LogIn();

				if (unity.LoggedIn)
				{
					try
					{
						if (unity != null)
						{
							if (unity.LoggedIn)
							{
								Data items = unity.NewDataObject(DataObjectType.doDemand);
								items.New();

								object tm = null;
								unity.PackTime(dto.DATE.TimeOfDay.Hours, dto.DATE.TimeOfDay.Minutes, dto.DATE.TimeOfDay.Seconds, ref tm);

								items.New();
								items.DataFields.FieldByName("DATE").Value = dto.DATE;
								items.DataFields.FieldByName("TIME").Value = tm;
								items.DataFields.FieldByName("DO_CODE").Value = dto.DO_CODE;
								items.DataFields.FieldByName("AUXIL_CODE").Value = dto.AUXIL_CODE;
								items.DataFields.FieldByName("DATE_CREATED").Value = dto.DATE_CREATED;
								items.DataFields.FieldByName("HOUR_CREATED").Value = dto.DATE_CREATED.Hour;
								items.DataFields.FieldByName("MIN_CREATED").Value = dto.DATE_CREATED.Minute;
								items.DataFields.FieldByName("SEC_CREATED").Value = dto.DATE_CREATED.Second;
								items.DataFields.FieldByName("PROJECT_CODE").Value = dto.PROJECT_CODE;

								Lines dtos_lines = items.DataFields.FieldByName("TRANSACTIONS").Lines;

								foreach (var line in dto.TRANSACTION)
								{
									dtos_lines.AppendLine();
									dtos_lines[dtos_lines.Count - 1].FieldByName("AMOUNT").Value = line.AMOUNT;
									dtos_lines[dtos_lines.Count - 1].FieldByName("PROCURE_DATE").Value = line.PROCURE_DATE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("FICHE_DATE").Value = dto.DATE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("ARP_CODE").Value = line.ARP_CODE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("ITEM_CODE").Value = line.ITEM_CODE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CODE").Value = line.UNIT_CODE;
									//dtos_lines[dtos_lines.Count - 1].FieldByName("ORD_PEG_USE").Value = 0; // SİPARİŞ BAĞLANTISI
									dtos_lines[dtos_lines.Count - 1].FieldByName("PRICE").Value = line.PRICE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("VARIANTCODE").Value = line.VARIANTCODE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("PROJECT_CODE").Value = dto.PROJECT_CODE;
								}

								if (items.Post())
								{
									var referenceId = Convert.ToInt32(items.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());

									result.Data = null;
									result.IsSuccess = true;
									result.Message = "Success";
								}
								else
								{
									result.IsSuccess = false;
									result.Message = new ErrorHelper().GetError(items);
								}
							}
							else
							{
								result.IsSuccess = false;
								result.Message = "Unity Login Olamadı";
							}
						}
						else
						{
							result.IsSuccess = false;
							result.Message = "Unity is null";
						}
					}
					catch (Exception ex)
					{
						throw;
					}
				}
				else
				{
					result = new DataResult<LG_Demand>
					{
						Data = null,
						IsSuccess = false,
						Message = unity.GetLastError() + "-" + unity.GetLastErrorString()
					};
				}
			}
			catch (Exception ex)
			{
				throw;
			}
			return await Task.FromResult(result);
		}
	}
}