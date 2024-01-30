using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Helix.LBSService.WebAPI.Models;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Helix.LBSService.WebAPI.Services;
using UnityObjects;

namespace Helix.LBSService.WebAPI.DataStores
{
	public class LG_OutCountingTransactionDataStore : ILG_OutCountingTransactionService
	{
		IUnityApplicationService _unityApplicationService;

		public LG_OutCountingTransactionDataStore(IUnityApplicationService unityApplicationService)
		{
			_unityApplicationService = unityApplicationService;
		}
		public async Task<DataResult<OutCountingTransactionDto>> Insert(OutCountingTransactionDto dto)
		{
			UnityApplication unity = Global.UnityApp;
			DataResult<OutCountingTransactionDto> result = new();
			var transaction = Mapping.Mapper.Map<LG_OutCountingTransaction>(dto);

			foreach (var line in dto.Lines.ToList())
			{
				var transactionLine = Mapping.Mapper.Map<LG_OutCountingTransactionLine>(line);
				foreach (var item in transactionLine.SLTRANS)
				{
					var serilot = Mapping.Mapper.Map<LG_SeriLotTransaction>(item);
					transactionLine.SLTRANS.Add(serilot);
				}
				transaction.TRANSACTIONS.Add(transactionLine);
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
							unity.PackTime(transaction.DATE.TimeOfDay.Hours, transaction.DATE.TimeOfDay.Minutes, transaction.DATE.TimeOfDay.Seconds, ref tm);

							items.New();
							items.DataFields.FieldByName("GROUP").Value = transaction.GROUP;
							items.DataFields.FieldByName("TYPE").Value = transaction.TYPE;
							items.DataFields.FieldByName("NUMBER").Value = transaction.NUMBER;
							items.DataFields.FieldByName("DOC_TRACK_NR").Value = transaction.DOC_TRACK_NR;
							items.DataFields.FieldByName("DATE").Value = transaction.DATE;
							items.DataFields.FieldByName("TIME").Value = tm;
							items.DataFields.FieldByName("SOURCE_WH").Value = transaction.SOURCE_WH;
							items.DataFields.FieldByName("SOURCE_COST_GRP").Value = transaction.SOURCE_COST_GRP;
							items.DataFields.FieldByName("CREATED_BY").Value = transaction.CREATED_BY;
							items.DataFields.FieldByName("DATE_CREATED").Value = transaction.DATE_CREATED;
							items.DataFields.FieldByName("HOUR_CREATED").Value = transaction.HOUR_CREATED;
							items.DataFields.FieldByName("MIN_CREATED").Value = transaction.MIN_CREATED;
							items.DataFields.FieldByName("SEC_CREATED").Value = transaction.SEC_CREATED;
							items.DataFields.FieldByName("GUID").Value = transaction.GUID.ToString();

							Lines transactions_lines = items.DataFields.FieldByName("TRANSACTIONS").Lines;

							foreach (LG_OutCountingTransactionLine line in transaction.TRANSACTIONS)
							{
								transactions_lines.AppendLine();
								transactions_lines[transactions_lines.Count - 1].FieldByName("ITEM_CODE").Value = line.ITEM_CODE;
								transactions_lines[transactions_lines.Count - 1].FieldByName("LINE_TYPE").Value = line.LINE_TYPE;
								transactions_lines[transactions_lines.Count - 1].FieldByName("SOURCEINDEX").Value = line.SOURCEINDEX;
								transactions_lines[transactions_lines.Count - 1].FieldByName("SOURCECOSTGRP").Value = line.SOURCECOSTGRP;
								transactions_lines[transactions_lines.Count - 1].FieldByName("QUANTITY").Value = line.QUANTITY;
								transactions_lines[transactions_lines.Count - 1].FieldByName("UNIT_CODE").Value = line.UNIT_CODE;
								transactions_lines[transactions_lines.Count - 1].FieldByName("UNIT_CONV1").Value = line.UNIT_CONV1;
								transactions_lines[transactions_lines.Count - 1].FieldByName("UNIT_CONV2").Value = line.UNIT_CONV2;
								if (line.SLTRANS.Count > 0)

								{
									UnityObjects.Lines sl_details0 = transactions_lines[transactions_lines.Count - 1].FieldByName("SL_DETAILS").Lines;
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

								result.Data = new() { ReferenceId = referenceId, Code = code };
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
					result = new DataResult<OutCountingTransactionDto>
					{
						Data = null,
						IsSuccess = false,
						Message = ex.Message
					};
				}

			}
			else
			{
				result = new DataResult<OutCountingTransactionDto>
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
