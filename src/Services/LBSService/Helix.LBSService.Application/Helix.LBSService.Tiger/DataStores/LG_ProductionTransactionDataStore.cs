using Helix.LBSService.Tiger.Helper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Models.BaseModel;
using Helix.LBSService.Tiger.Services;
using UnityObjects;

namespace Helix.LBSService.Tiger.DataStores
{
	public class LG_ProductionTransactionDataStore : ILG_ProductionTransactionService
	{
		IUnityApplicationService _unityApplicationService;

		public LG_ProductionTransactionDataStore(IUnityApplicationService unityApplicationService)
		{
			_unityApplicationService = unityApplicationService;
		}
		public async Task<DataResult<LG_ProductionTransaction>> Insert(LG_ProductionTransaction dto)
		{
			UnityApplication unity = Global.UnityApp;
			DataResult<LG_ProductionTransaction> result = new();
			foreach (var line in dto.TRANSACTIONS.ToList())
			{
				foreach (var item in line.SLTRANS)
				{
					line.SLTRANS.Add(item);
				}
				dto.TRANSACTIONS.Add(line);
			}


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
							Data items = unity.NewDataObject(DataObjectType.doMaterialSlip);
							items.New();

							object tm = null;
							unity.PackTime(dto.DATE.TimeOfDay.Hours, dto.DATE.TimeOfDay.Minutes, dto.DATE.TimeOfDay.Seconds, ref tm);

							items.New();
							items.DataFields.FieldByName("GROUP").Value = dto.GROUP;
							items.DataFields.FieldByName("TYPE").Value = dto.TYPE;
							items.DataFields.FieldByName("NUMBER").Value = dto.NUMBER;
							items.DataFields.FieldByName("DOC_TRACK_NR").Value = dto.DOC_TRACK_NR;
							items.DataFields.FieldByName("DATE").Value = dto.DATE;
							items.DataFields.FieldByName("TIME").Value = tm;
							items.DataFields.FieldByName("SOURCE_WH").Value = dto.SOURCE_WH;
							items.DataFields.FieldByName("SOURCE_COST_GRP").Value = dto.SOURCE_COST_GRP;
							items.DataFields.FieldByName("CREATED_BY").Value = dto.CREATED_BY;
							items.DataFields.FieldByName("DATE_CREATED").Value = dto.DATE_CREATED;
							items.DataFields.FieldByName("HOUR_CREATED").Value = dto.HOUR_CREATED;
							items.DataFields.FieldByName("MIN_CREATED").Value = dto.MIN_CREATED;
							items.DataFields.FieldByName("SEC_CREATED").Value = dto.SEC_CREATED;
							items.DataFields.FieldByName("GUID").Value = dto.GUID.ToString();

							Lines dtos_lines = items.DataFields.FieldByName("TRANSACTIONS").Lines;

							foreach (LG_ProductionTransactionLine line in dto.TRANSACTIONS)
							{
								dtos_lines.AppendLine();
								dtos_lines[dtos_lines.Count - 1].FieldByName("ITEM_CODE").Value = line.ITEM_CODE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("LINE_TYPE").Value = line.LINE_TYPE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("SOURCEINDEX").Value = line.SOURCEINDEX;
								dtos_lines[dtos_lines.Count - 1].FieldByName("SOURCECOSTGRP").Value = line.SOURCECOSTGRP;
								dtos_lines[dtos_lines.Count - 1].FieldByName("QUANTITY").Value = line.QUANTITY;
								dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CODE").Value = line.UNIT_CODE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV1").Value = line.UNIT_CONV1;
								dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV2").Value = line.UNIT_CONV2;
								if (line.SLTRANS.Count > 0)

								{
									UnityObjects.Lines sl_details0 = dtos_lines[dtos_lines.Count - 1].FieldByName("SL_DETAILS").Lines;
									foreach (LG_SeriLotTransaction trans in line.SLTRANS)
									{
										sl_details0.AppendLine();

										sl_details0[sl_details0.Count - 1].FieldByName("SOURCE_MT_REFERENCE").Value = trans.SOURCE_MT_REFERENCE;
										sl_details0[sl_details0.Count - 1].FieldByName("SOURCE_SLT_REFERENCE").Value = trans.SOURCE_SLT_REFERENCE;
										sl_details0[sl_details0.Count - 1].FieldByName("IOCODE").Value = trans.IOCODE;
										sl_details0[sl_details0.Count - 1].FieldByName("SOURCE_WH").Value = trans.SOURCE_WH;
										sl_details0[sl_details0.Count - 1].FieldByName("LOCATION_CODE").Value = trans.LOCATION_CODE;
										sl_details0[sl_details0.Count - 1].FieldByName("DEST_LOCATION_CODE").Value = trans.DEST_LOCATION_CODE;
										sl_details0[sl_details0.Count - 1].FieldByName("SL_TYPE").Value = trans.SL_TYPE;
										sl_details0[sl_details0.Count - 1].FieldByName("SL_CODE").Value = trans.SL_CODE;
										sl_details0[sl_details0.Count - 1].FieldByName("SL_NAME").Value = trans.SL_NAME;
										sl_details0[sl_details0.Count - 1].FieldByName("UNIT_CODE").Value = trans.UNIT_CODE;
										sl_details0[sl_details0.Count - 1].FieldByName("UNIT_CONV1").Value = trans.UNIT_CONV1;
										sl_details0[sl_details0.Count - 1].FieldByName("UNIT_CONV2").Value = trans.UNIT_CONV2;
										sl_details0[sl_details0.Count - 1].FieldByName("QUANTITY").Value = trans.QUANTITY;

										if (trans.UNIT_CONV1 == trans.UNIT_CONV2)
										{
											sl_details0[sl_details0.Count - 1].FieldByName("MU_QUANTITY").Value = trans.MU_QUANTITY;
											sl_details0[sl_details0.Count - 1].FieldByName("SOURCE_QUANTITY").Value = trans.SOURCE_QUANTITY;
										}
										else
										{
											sl_details0[sl_details0.Count - 1].FieldByName("MU_QUANTITY").Value = trans.MU_QUANTITY;
											sl_details0[sl_details0.Count - 1].FieldByName("SOURCE_QUANTITY").Value = trans.SOURCE_QUANTITY;
										}

										//sl_details0[sl_details0.Count - 1].FieldByName("DATE_EXPIRED").Value = DateTime.Now.AddDays(90);
									}

								}
							}

							if (items.Post())
							{
								var referenceId = Convert.ToInt32(items.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());
								var code = items.DataFields.FieldByName("NUMBER").Value.ToString();

								result.Data = null;
								result.IsSuccess = true;
								result.Message = "Success";
							}
							else
							{
								result.IsSuccess = false;
								result.Message = unity.GetLastError() + "-" + unity.GetLastErrorString();
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
					result = new DataResult<LG_ProductionTransaction>
					{
						Data = null,
						IsSuccess = false,
						Message = ex.Message
					};
				}

			}
			else
			{
				result = new DataResult<LG_ProductionTransaction>
				{
					Data = null,
					IsSuccess = false,
					Message = unity.GetLastError() + "-" + unity.GetLastErrorString()
				};
			}
			return await Task.FromResult(result);
		}
	}
}
