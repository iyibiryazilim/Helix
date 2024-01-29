using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Helix.LBSService.WebAPI.Models;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Helix.LBSService.WebAPI.Services;
using System.Diagnostics;
using UnityObjects;
namespace Helix.LBSService.WebAPI.DataStores
{
	public class LG_PurchaseDispatchTransactionDataStore : ILG_PurchaseDispatchTransactionService
	{
		IUnityApplicationService _unityApplicationService;

		public LG_PurchaseDispatchTransactionDataStore(IUnityApplicationService unityApplicationService) 
		{
			_unityApplicationService = unityApplicationService;

		}
		public async Task<DataResult<PurchaseDispatchTransactionDto>> Insert(PurchaseDispatchTransactionDto dto)
		{
			UnityApplication unity = Global.UnityApp;
			DataResult<PurchaseDispatchTransactionDto> result = new();
			var transaction = Mapping.Mapper.Map<LG_PurchaseDispatchTransaction>(dto);

			foreach (var line in dto.Lines.ToList())
			{
				var transactionLine = Mapping.Mapper.Map<LG_PurchaseDispatchTransactionLine>(line);
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
							Data items = unity.NewDataObject(DataObjectType.doPurchDispatch);
							items.New();

							object tm = null;
							unity.PackTime(transaction.DATE.TimeOfDay.Hours, transaction.DATE.TimeOfDay.Minutes, transaction.DATE.TimeOfDay.Seconds, ref tm);

							items.New();
							items.DataFields.FieldByName("TYPE").Value = transaction.TYPE;
							items.DataFields.FieldByName("NUMBER").Value = transaction.NUMBER;
							items.DataFields.FieldByName("DATE").Value = transaction.DATE;
							items.DataFields.FieldByName("TIME").Value = tm;
							items.DataFields.FieldByName("ARP_CODE").Value = transaction.ARP_CODE;
							items.DataFields.FieldByName("GL_CODE").Value = transaction.GL_CODE;
							items.DataFields.FieldByName("SOURCE_WH").Value = transaction.SOURCE_WH;
							items.DataFields.FieldByName("SOURCE_COST_GRP").Value = transaction.SOURCE_COST_GRP;
							items.DataFields.FieldByName("TOTAL_NET").Value = transaction.TOTAL_NET;
							items.DataFields.FieldByName("PAYMENT_CODE").Value = transaction.PAYMENT_CODE;
							items.DataFields.FieldByName("CREATED_BY").Value = transaction.CREATED_BY;
							items.DataFields.FieldByName("DATE_CREATED").Value = transaction.DATE_CREATED;
							items.DataFields.FieldByName("HOUR_CREATED").Value = transaction.HOUR_CREATED;
							items.DataFields.FieldByName("MIN_CREATED").Value = transaction.MIN_CREATED;
							items.DataFields.FieldByName("SEC_CREATED").Value = transaction.SEC_CREATED;
							items.DataFields.FieldByName("CURRSEL_TOTALS").Value = transaction.CURRSEL_TOTALS;
							items.DataFields.FieldByName("DATA_REFERENCE").Value = transaction.DATA_REFERENCE;
							items.DataFields.FieldByName("GRPFIRMTRANS").Value = transaction.GRPFIRMTRANS;
							items.DataFields.FieldByName("DISP_STATUS").Value = transaction.DISP_STATUS;
							items.DataFields.FieldByName("DEDUCTIONPART1").Value = transaction.DEDUCTIONPART1;
							items.DataFields.FieldByName("DEDUCTIONPART2").Value = transaction.DEDUCTIONPART2;
							items.DataFields.FieldByName("AFFECT_RISK").Value = transaction.AFFECT_RISK;
							items.DataFields.FieldByName("GUID").Value = transaction.GUID.ToString();
							items.DataFields.FieldByName("SHIP_DATE").Value = transaction.SHIP_DATE;
							items.DataFields.FieldByName("SHIP_TIME").Value = tm;
							items.DataFields.FieldByName("DOC_DATE").Value = transaction.DOC_DATE;
							items.DataFields.FieldByName("DOC_TIME").Value = tm;
							items.DataFields.FieldByName("EINVOICE_DRIVERNAME1").Value = transaction.EINVOICE_DRIVERNAME1;
							items.DataFields.FieldByName("EINVOICE_DRIVERSURNAME1").Value = transaction.EINVOICE_DRIVERSURNAME1;
							items.DataFields.FieldByName("EINVOICE_DRIVERTCKNO1").Value = transaction.EINVOICE_DRIVERTCKNO1;
							items.DataFields.FieldByName("EINVOICE_PLATENUM1").Value = transaction.EINVOICE_PLATENUM1;
							items.DataFields.FieldByName("SHIPPING_AGENT").Value = transaction.SHIPPING_AGENT;
							items.DataFields.FieldByName("SHIPLOC_CODE").Value = transaction.SHIPLOC_CODE;
							items.DataFields.FieldByName("SHIPLOC_DEF").Value = transaction.SHIPLOC_DEF;
							items.DataFields.FieldByName("NOTES1").Value = transaction.NOTES1;
							items.DataFields.FieldByName("NOTES2").Value = transaction.NOTES2;
							items.DataFields.FieldByName("NOTES3").Value = transaction.NOTES3;
							items.DataFields.FieldByName("NOTES4").Value = transaction.NOTES4;
							items.DataFields.FieldByName("NOTES5").Value = transaction.NOTES5;
							items.DataFields.FieldByName("EDESPATCH_PROFILEID").Value = transaction.EDESPATCH_PROFILEID;
							items.DataFields.FieldByName("EINVOICE_PROFILEID").Value = transaction.EINVOICE_PROFILEID;



							Lines transactions_lines = items.DataFields.FieldByName("TRANSACTIONS").Lines;


							foreach (var line in transaction.TRANSACTIONS)
							{

								transactions_lines.AppendLine();

								transactions_lines[transactions_lines.Count - 1].FieldByName("TYPE").Value = line.TYPE;
								transactions_lines[transactions_lines.Count - 1].FieldByName("MASTER_CODE").Value = line.MASTER_CODE;
								transactions_lines[transactions_lines.Count - 1].FieldByName("SOURCEINDEX").Value = line.SOURCEINDEX;
								transactions_lines[transactions_lines.Count - 1].FieldByName("SOURCECOSTGRP").Value = line.SOURCECOSTGRP;
								transactions_lines[transactions_lines.Count - 1].FieldByName("GL_CODE1").Value = line.GL_CODE1;
								transactions_lines[transactions_lines.Count - 1].FieldByName("GL_CODE2").Value = line.GL_CODE2;
								transactions_lines[transactions_lines.Count - 1].FieldByName("QUANTITY").Value = line.QUANTITY;
								transactions_lines[transactions_lines.Count - 1].FieldByName("UNIT_CODE").Value = line.UNIT_CODE;
								transactions_lines[transactions_lines.Count - 1].FieldByName("UNIT_CONV1").Value = line.UNIT_CONV1;
								transactions_lines[transactions_lines.Count - 1].FieldByName("UNIT_CONV2").Value = line.UNIT_CONV2;
								transactions_lines[transactions_lines.Count - 1].FieldByName("VAT_RATE").Value = line.VAT_RATE;
								transactions_lines[transactions_lines.Count - 1].FieldByName("DATA_REFERENCE").Value = line.DATA_REFERENCE;
								transactions_lines[transactions_lines.Count - 1].FieldByName("DIST_ORD_REFERENCE").Value = line.DIST_ORD_REFERENCE;
								transactions_lines[transactions_lines.Count - 1].FieldByName("MULTI_ADD_TAX").Value = line.MULTI_ADD_TAX;
								transactions_lines[transactions_lines.Count - 1].FieldByName("EDT_CURR").Value = line.EDT_CURR;
								transactions_lines[transactions_lines.Count - 1].FieldByName("MONTH").Value = line.MONTH;
								transactions_lines[transactions_lines.Count - 1].FieldByName("YEAR").Value = line.YEAR;
								transactions_lines[transactions_lines.Count - 1].FieldByName("GUID").Value = line.GUID.ToString();
								transactions_lines[transactions_lines.Count - 1].FieldByName("MASTER_DEF").Value = line.MASTER_DEF;
								transactions_lines[transactions_lines.Count - 1].FieldByName("FOREIGN_TRADE_TYPE").Value = line.FOREIGN_TRADE_TYPE;
								transactions_lines[transactions_lines.Count - 1].FieldByName("DISTRIBUTION_TYPE_WHS").Value = line.DISTRIBUTION_TYPE_WHS;
								transactions_lines[transactions_lines.Count - 1].FieldByName("DISTRIBUTION_TYPE_FNO").Value = line.DISTRIBUTION_TYPE_FNO;
								transactions_lines[transactions_lines.Count - 1].FieldByName("RET_COST_TYPE").Value = 1;
								transactions_lines[transactions_lines.Count - 1].FieldByName("SOURCE_REFERENCE").Value = line.SOURCE_REFERENCE;

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
					Debug.WriteLine(ex.Message);
					result = new DataResult<PurchaseDispatchTransactionDto>
					{
						Data = null,
						IsSuccess = false,
						Message = ex.Message
					};
				}

			}
			else
			{
				result = new DataResult<PurchaseDispatchTransactionDto>
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
