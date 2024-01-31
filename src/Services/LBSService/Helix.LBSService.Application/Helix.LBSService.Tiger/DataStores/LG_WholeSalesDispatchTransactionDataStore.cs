using Helix.LBSService.Tiger.Helper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Models.BaseModel;
using Helix.LBSService.Tiger.Services;
using System.Diagnostics;
using UnityObjects;


namespace Helix.LBSService.Tiger.DataStores
{
	public class LG_WholeSalesDispatchTransactionDataStore : ILG_WholeSalesDispatchTransactionService
	{
		IUnityApplicationService _unityApplicationService;

		public LG_WholeSalesDispatchTransactionDataStore(IUnityApplicationService unityApplicationService)
		{
			_unityApplicationService = unityApplicationService;
		}
		public async Task<DataResult<LG_WholeSalesDispatchTransaction>> Insert(LG_WholeSalesDispatchTransaction dto)
		{
			UnityApplication unity = Global.UnityApp;
			DataResult<LG_WholeSalesDispatchTransaction> result = new();
			 
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
							Data items = unity.NewDataObject(DataObjectType.doSalesDispatch);
							items.New();

							object tm = null;
							unity.PackTime(dto.DATE.TimeOfDay.Hours, dto.DATE.TimeOfDay.Minutes, dto.DATE.TimeOfDay.Seconds, ref tm);

							items.DataFields.FieldByName("TYPE").Value = dto.TYPE;
							items.DataFields.FieldByName("NUMBER").Value = dto.NUMBER;
							items.DataFields.FieldByName("DATE").Value = dto.DATE;
							items.DataFields.FieldByName("TIME").Value = tm;
							items.DataFields.FieldByName("ARP_CODE").Value = dto.ARP_CODE;
							items.DataFields.FieldByName("GL_CODE").Value = dto.GL_CODE;
							items.DataFields.FieldByName("SOURCE_WH").Value = dto.SOURCE_WH;
							items.DataFields.FieldByName("SOURCE_COST_GRP").Value = dto.SOURCE_COST_GRP;
							items.DataFields.FieldByName("TOTAL_DISCOUNTED").Value = dto.TOTAL_DISCOUNTED;
							items.DataFields.FieldByName("TOTAL_VAT").Value = dto.TOTAL_VAT;
							items.DataFields.FieldByName("TOTAL_GROSS").Value = dto.TOTAL_GROSS;
							items.DataFields.FieldByName("TOTAL_NET").Value = dto.TOTAL_NET;
							items.DataFields.FieldByName("RC_RATE").Value = dto.RC_RATE;
							items.DataFields.FieldByName("RC_NET").Value = dto.RC_NET;
							items.DataFields.FieldByName("PAYMENT_CODE").Value = dto.PAYMENT_CODE;
							items.DataFields.FieldByName("CREATED_BY").Value = dto.CREATED_BY;
							items.DataFields.FieldByName("DATE_CREATED").Value = dto.DATE_CREATED;
							items.DataFields.FieldByName("HOUR_CREATED").Value = dto.HOUR_CREATED;
							items.DataFields.FieldByName("MIN_CREATED").Value = dto.MIN_CREATED;
							items.DataFields.FieldByName("SEC_CREATED").Value = dto.SEC_CREATED;
							items.DataFields.FieldByName("CURRSEL_TOTALS").Value = dto.CURRSEL_TOTALS;
							items.DataFields.FieldByName("DATA_REFERENCE").Value = dto.DATA_REFERENCE;
							items.DataFields.FieldByName("GRPFIRMTRANS").Value = dto.GRPFIRMTRANS;
							items.DataFields.FieldByName("DEDUCTIONPART1").Value = dto.DEDUCTIONPART1;
							items.DataFields.FieldByName("DEDUCTIONPART2").Value = dto.DEDUCTIONPART2;
							items.DataFields.FieldByName("AFFECT_RISK").Value = dto.AFFECT_RISK;
							items.DataFields.FieldByName("DISP_STATUS").Value = dto.DISP_STATUS;
							items.DataFields.FieldByName("GUID").Value = dto.GUID.ToString();
							items.DataFields.FieldByName("SHIP_DATE").Value = dto.SHIP_DATE;
							items.DataFields.FieldByName("SHIP_TIME").Value = tm;
							items.DataFields.FieldByName("DOC_DATE").Value = dto.DOC_DATE;
							items.DataFields.FieldByName("DOC_TIME").Value = tm;
							items.DataFields.FieldByName("TOTAL_NET_STR").Value = dto.TOTAL_NET_STR;
							items.DataFields.FieldByName("EDESPATCH").Value = dto.EDESPATCH;
							items.DataFields.FieldByName("EDESPATCH_PROFILEID").Value = dto.EDESPATCH_PROFILEID;
							items.DataFields.FieldByName("EINVOICE").Value = dto.EINVOICE;
							items.DataFields.FieldByName("EINVOICE_PROFILEID").Value = dto.EINVOICE_PROFILEID;
							items.DataFields.FieldByName("EINVOICE_DRIVERNAME1").Value = dto.EINVOICE_DRIVERNAME1;
							items.DataFields.FieldByName("EINVOICE_DRIVERSURNAME1").Value = dto.EINVOICE_DRIVERSURNAME1;
							items.DataFields.FieldByName("EINVOICE_DRIVERTCKNO1").Value = dto.EINVOICE_DRIVERTCKNO1;
							items.DataFields.FieldByName("EINVOICE_PLATENUM1").Value = dto.EINVOICE_PLATENUM1;
							items.DataFields.FieldByName("SHIPPING_AGENT").Value = dto.SHIPPING_AGENT;
							items.DataFields.FieldByName("SHIPLOC_CODE").Value = dto.SHIPLOC_CODE;
							items.DataFields.FieldByName("SHIPLOC_DEF").Value = dto.SHIPLOC_DEF;
							items.DataFields.FieldByName("NOTES1").Value = dto.NOTES1;
							items.DataFields.FieldByName("NOTES2").Value = dto.NOTES2;
							items.DataFields.FieldByName("NOTES3").Value = dto.NOTES3;
							items.DataFields.FieldByName("NOTES4").Value = dto.NOTES4;
							items.DataFields.FieldByName("NOTES5").Value = dto.NOTES5;
							items.DataFields.FieldByName("EDESPATCH").Value = dto.EDESPATCH;
							items.DataFields.FieldByName("EINVOICE").Value = dto.EINVOICE;
							items.DataFields.FieldByName("EINVOICE_PLATENUM2").Value = dto.EINVOICE_PLATENUM2 ?? string.Empty;
							items.DataFields.FieldByName("EINVOICE_DRIVERNAME2").Value = dto.EINVOICE_DRIVERNAME2 ?? string.Empty;
							items.DataFields.FieldByName("EINVOICE_DRIVERSURNAME2").Value = dto.EINVOICE_DRIVERSURNAME2 ?? string.Empty;
							items.DataFields.FieldByName("DOC_TRACKING_NR").Value = dto.DOC_TRACK_NR ?? string.Empty;
							items.DataFields.FieldByName("DOC_NUMBER").Value = dto.DOC_NUMBER ?? string.Empty;
							items.DataFields.FieldByName("EDESPATCH_PROFILEID").Value = dto.EDESPATCH_PROFILEID;
							items.DataFields.FieldByName("EINVOICE_PROFILEID").Value = dto.EINVOICE_PROFILEID;

							Lines dtos_lines = items.DataFields.FieldByName("TRANSACTIONS").Lines;

							foreach (LG_WholeSalesDispatchLine line in dto.TRANSACTIONS)
							{

								dtos_lines.AppendLine();

								dtos_lines[dtos_lines.Count - 1].FieldByName("TYPE").Value = line.TYPE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("MASTER_CODE").Value = line.MASTER_CODE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("SOURCEINDEX").Value = line.SOURCEINDEX;
								dtos_lines[dtos_lines.Count - 1].FieldByName("SOURCECOSTGRP").Value = line.SOURCECOSTGRP;
								dtos_lines[dtos_lines.Count - 1].FieldByName("ORDER_REFERENCE").Value = line.ORDER_REFERENCE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("GL_CODE1").Value = line.GL_CODE1;
								dtos_lines[dtos_lines.Count - 1].FieldByName("GL_CODE2").Value = line.GL_CODE2;
								dtos_lines[dtos_lines.Count - 1].FieldByName("QUANTITY").Value = line.QUANTITY;
								dtos_lines[dtos_lines.Count - 1].FieldByName("PRICE").Value = line.PRICE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("TOTAL").Value = line.TOTAL;
								dtos_lines[dtos_lines.Count - 1].FieldByName("CURR_PRICE").Value = line.CURR_PRICE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("PC_PRICE").Value = line.PC_PRICE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("RC_XRATE").Value = line.RC_XRATE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("DESCRIPTION").Value = line.DESCRIPTION;
								dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CODE").Value = line.UNIT_CODE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV1").Value = line.UNIT_CONV1;
								dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV2").Value = line.UNIT_CONV2;
								dtos_lines[dtos_lines.Count - 1].FieldByName("VAT_RATE").Value = line.VAT_RATE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("VAT_AMOUNT").Value = line.VAT_AMOUNT;
								dtos_lines[dtos_lines.Count - 1].FieldByName("VAT_BASE").Value = line.VAT_BASE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("TOTAL_NET").Value = line.TOTAL_NET;
								dtos_lines[dtos_lines.Count - 1].FieldByName("DATA_REFERENCE").Value = line.DATA_REFERENCE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("DIST_ORD_REFERENCE").Value = line.DIST_ORD_REFERENCE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("PR_RATE").Value = line.PR_RATE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("MULTI_ADD_TAX").Value = line.MULTI_ADD_TAX;
								dtos_lines[dtos_lines.Count - 1].FieldByName("EDT_CURR").Value = line.EDT_CURR;
								dtos_lines[dtos_lines.Count - 1].FieldByName("EDT_PRICE").Value = line.EDT_PRICE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("MONTH").Value = line.MONTH;
								dtos_lines[dtos_lines.Count - 1].FieldByName("YEAR").Value = line.YEAR;
								dtos_lines[dtos_lines.Count - 1].FieldByName("PRCLISTCODE").Value = line.PRCLISTCODE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("PRCLISTTYPE").Value = line.PRCLISTTYPE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("GUID").Value = line.GUID.ToString();
								dtos_lines[dtos_lines.Count - 1].FieldByName("MASTER_DEF").Value = line.MASTER_DEF;
								dtos_lines[dtos_lines.Count - 1].FieldByName("MASTER_DEF3").Value = line.MASTER_DEF3;
								dtos_lines[dtos_lines.Count - 1].FieldByName("FOREIGN_TRADE_TYPE").Value = line.FOREIGN_TRADE_TYPE;
								dtos_lines[dtos_lines.Count - 1].FieldByName("DISTRIBUTION_TYPE_WHS").Value = line.DISTRIBUTION_TYPE_WHS;
								dtos_lines[dtos_lines.Count - 1].FieldByName("DISTRIBUTION_TYPE_FNO").Value = line.DISTRIBUTION_TYPE_FNO;
								dtos_lines[dtos_lines.Count - 1].FieldByName("ORDER_REFERENCE").Value = line.ORDER_REFERENCE;

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
					Debug.WriteLine(ex.Message);
					result = new DataResult<LG_WholeSalesDispatchTransaction>
					{
						Data = null,
						IsSuccess = false,
						Message = ex.Message
					};
				}

			}
			else
			{
				result = new DataResult<LG_WholeSalesDispatchTransaction>
				{
					Data = null,
					IsSuccess = false,
					Message = unity.GetLastError() + "-" + unity.GetLastErrorString()
				};
			}

			await _unityApplicationService.LogOut();
			return await Task.FromResult(result);
		}
	}
}
