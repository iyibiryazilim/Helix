using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Helper;
using Helix.LBSService.Tiger.Helper.ErrorHelper;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using UnityObjects;

namespace Helix.LBSService.Tiger.DataStores
{
	public class LG_PurchaseOrderDataStore : ILG_PurchaseOrderService
	{
		IUnityApplicationService _unityApplicationService;
		public LG_PurchaseOrderDataStore(IUnityApplicationService unityApplicationService)
		{
			_unityApplicationService = unityApplicationService;
		}
		public async Task<DataResult<LG_PurchaseOrder>> Insert(LG_PurchaseOrder dto)
		{
			UnityApplication unity = Global.UnityApp;
			DataResult<LG_PurchaseOrder> result = new();

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
								Data items = unity.NewDataObject(DataObjectType.doPurchOrderSlip);
								items.New();
								object tm = null;
								unity.PackTime(dto.DATE.TimeOfDay.Hours, dto.DATE.TimeOfDay.Minutes, dto.DATE.TimeOfDay.Seconds, ref tm);

								items.New();
								items.DataFields.FieldByName("NUMBER").Value = dto.NUMBER;
								items.DataFields.FieldByName("DATE").Value = dto.DATE;
								items.DataFields.FieldByName("TIME").Value = tm;
								items.DataFields.FieldByName("SOURCE_WH").Value = dto.SOURCE_WH;
								items.DataFields.FieldByName("SOURCE_COST_GRP").Value = dto.SOURCE_COST_GRP;
								items.DataFields.FieldByName("CREATED_BY").Value = dto.CREATED_BY;
								items.DataFields.FieldByName("DATE_CREATED").Value = dto.DATE_CREATED;
								items.DataFields.FieldByName("ARP_CODE_SHPM").Value = dto.ARP_CODE_SHPM;
								items.DataFields.FieldByName("HOUR_CREATED").Value = dto.HOUR_CREATED;
								items.DataFields.FieldByName("MIN_CREATED").Value = dto.MIN_CREATED;
								items.DataFields.FieldByName("SEC_CREATED").Value = dto.SEC_CREATED;
								items.DataFields.FieldByName("ARP_CODE").Value = dto.ARP_CODE;
								items.DataFields.FieldByName("GUID").Value = dto.GUID.ToString();
								items.DataFields.FieldByName("TOTAL_DISCOUNTED").Value = dto.TOTAL_DISCOUNTED;
								items.DataFields.FieldByName("TOTAL_VAT").Value = dto.TOTAL_VAT;
								items.DataFields.FieldByName("TOTAL_GROSS").Value = dto.TOTAL_GROSS;
								items.DataFields.FieldByName("TOTAL_NET").Value = dto.TOTAL_NET;
								items.DataFields.FieldByName("ORDER_STATUS").Value = dto.ORDER_STATUS;
								items.DataFields.FieldByName("PROJECT_CODE").Value = dto.PROJECT_CODE; 
								items.DataFields.FieldByName("CREATED_BY").Value = dto.CREATED_BY;
								items.DataFields.FieldByName("DATE_CREATED").Value = dto.DATE_CREATED;
								items.DataFields.FieldByName("HOUR_CREATED").Value = dto.HOUR_CREATED;
								items.DataFields.FieldByName("MIN_CREATED").Value = dto.MIN_CREATED;
								items.DataFields.FieldByName("SEC_CREATED").Value = dto.SEC_CREATED;
								items.DataFields.FieldByName("SALESMAN_CODE").Value = dto.SALESMAN_CODE;
								items.DataFields.FieldByName("CURRSEL_TOTAL").Value = dto.CURRSEL_TOTAL;
								items.DataFields.FieldByName("DATA_REFERENCE").Value = dto.DATA_REFERENCE;

								Lines dtos_lines = items.DataFields.FieldByName("TRANSACTIONS").Lines;

								foreach (LG_PurchaseOrderLine line in dto.TRANSACTIONS)
								{
									dtos_lines.AppendLine();
									dtos_lines[dtos_lines.Count - 1].FieldByName("TYPE").Value = line.TYPE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("MASTER_CODE").Value = line.MASTER_CODE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("GL_CODE1").Value = line.GL_CODE1;
									dtos_lines[dtos_lines.Count - 1].FieldByName("GL_CODE2").Value = line.GL_CODE2;
									dtos_lines[dtos_lines.Count - 1].FieldByName("QUANTITY").Value = line.QUANTITY;
									dtos_lines[dtos_lines.Count - 1].FieldByName("PRICE").Value = line.PRICE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("VAT_RATE").Value = line.VAT_RATE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("TRANS_DESCRIPTION").Value = line.TRANS_DESCRIPTION;
									dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CODE").Value = line.UNIT_CODE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("VARIANTCODE").Value = line.VARIANTCODE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV1").Value = line.UNIT_CONV1;
									dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV2").Value = line.UNIT_CONV2;
									dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV3").Value = line.UNIT_CONV3;
									dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV4").Value = line.UNIT_CONV4;
									dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV5").Value = line.UNIT_CONV5;
									dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV6").Value = line.UNIT_CONV6;
									dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV7").Value = line.UNIT_CONV7;
									dtos_lines[dtos_lines.Count - 1].FieldByName("UNIT_CONV8").Value = line.UNIT_CONV8;
									dtos_lines[dtos_lines.Count - 1].FieldByName("DUE_DATE").Value = line.DUE_DATE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("SOURCE_WH").Value = line.SOURCE_WH;
									dtos_lines[dtos_lines.Count - 1].FieldByName("SOURCE_COST_GRP").Value = line.SOURCE_COST_GRP;
									dtos_lines[dtos_lines.Count - 1].FieldByName("DATA_REFERENCE").Value = line.DATA_REFERENCE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("ORG_DUE_DATE").Value = line.ORG_DUE_DATE;
									dtos_lines[dtos_lines.Count - 1].FieldByName("ORG_QUANTITY").Value = line.ORG_QUANTITY;
									dtos_lines[dtos_lines.Count - 1].FieldByName("PRODUCER_CODE").Value = line.PRODUCER_CODE;

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
					catch (Exception)
					{
						throw;
					}
				}
				else
				{

					result = new DataResult<LG_PurchaseOrder>
					{
						Data = null,
						IsSuccess = false,
						Message = unity.GetLastError() + "-" + unity.GetLastErrorString()
					};

				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return await Task.FromResult(result);
		}
	}
}
