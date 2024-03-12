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
	public class LG_CurrentDataStore : ILG_CurrentService
	{
		IUnityApplicationService _unityApplicationService;
		IEventBus _eventBus;
		ILogger<LG_CurrentDataStore> _logger;
		public LG_CurrentDataStore(ILogger<LG_CurrentDataStore> logger, IUnityApplicationService unityApplicationService, IEventBus eventBus)
		{
			_unityApplicationService = unityApplicationService;
			_eventBus = eventBus;
			_logger = logger;
		}
		public async Task<DataResult<LG_Current>> Insert(LG_Current dto)
		{
			UnityApplication unity = Global.UnityApp;
			DataResult<LG_Current> result = new();

			try
			{

				if (!unity.LoggedIn)
					await _unityApplicationService.LogIn();

				if (unity.LoggedIn)
				{

					try
					{
						Data items = unity.NewDataObject(DataObjectType.doAccountsRP);
						items.New(); 

						items.DataFields.FieldByName("ACCOUNT_TYPE").Value = dto.ACCOUNT_TYPE;
						items.DataFields.FieldByName("CODE").Value = dto.CODE;
						items.DataFields.FieldByName("TITLE").Value = dto.TITLE;
						items.DataFields.FieldByName("AUXIL_CODE").Value = dto.AUXIL_CODE;
						items.DataFields.FieldByName("ADDRESS1").Value = dto.ADDRESS1;
						items.DataFields.FieldByName("ADDRESS2").Value = dto.ADDRESS2;
						items.DataFields.FieldByName("DISTRICT_CODE").Value = dto.DISTRICT_CODE;
						items.DataFields.FieldByName("DISTRICT").Value = dto.DISTRICT;
						items.DataFields.FieldByName("TOWN_CODE").Value = dto.TOWN_CODE;
						items.DataFields.FieldByName("TOWN").Value = dto.TOWN;
						items.DataFields.FieldByName("CITY_CODE").Value = dto.CITY_CODE;
						items.DataFields.FieldByName("CITY").Value = dto.CITY;
						items.DataFields.FieldByName("COUNTRY_CODE").Value = dto.COUNTRY_CODE;
						items.DataFields.FieldByName("COUNTRY").Value = dto.COUNTRY;
						items.DataFields.FieldByName("TELEPHONE1").Value = dto.TELEPHONE1;
						items.DataFields.FieldByName("TAX_ID").Value = dto.TAX_ID;
						items.DataFields.FieldByName("TAX_OFFICE").Value = dto.TAX_OFFICE;
						items.DataFields.FieldByName("PAYMENT_CODE").Value = dto.PAYMENT_CODE;
						items.DataFields.FieldByName("E_MAIL").Value = dto.E_MAIL;
 						items.DataFields.FieldByName("CREATED_BY").Value = dto.CREATED_BY;
						items.DataFields.FieldByName("DATE_CREATED").Value = dto.DATE_CREATED;
						items.DataFields.FieldByName("HOUR_CREATED").Value = dto.HOUR_CREATED;
						items.DataFields.FieldByName("MIN_CREATED").Value = dto.MIN_CREATED;
						items.DataFields.FieldByName("SEC_CREATED").Value = dto.SEC_CREATED;
						items.DataFields.FieldByName("MODIFIED_BY").Value = dto.MODIFIED_BY;
						items.DataFields.FieldByName("DATE_MODIFIED").Value = dto.DATE_MODIFIED;
						items.DataFields.FieldByName("HOUR_MODIFIED").Value = dto.HOUR_MODIFIED;
						items.DataFields.FieldByName("MIN_MODIFIED").Value = dto.MIN_MODIFIED;
						items.DataFields.FieldByName("SEC_MODIFIED").Value = dto.SEC_MODIFIED;
						items.DataFields.FieldByName("NOTES").Value = dto.NOTES;
						items.DataFields.FieldByName("CREDIT_TYPE").Value = dto.CREDIT_TYPE;
						items.DataFields.FieldByName("RISKFACT_CHQ").Value = dto.RISKFACT_CHQ;
						items.DataFields.FieldByName("RISKFACT_PROMNT").Value = dto.RISKFACT_PROMNT;
						items.DataFields.FieldByName("GL_CODE").Value = dto.GL_CODE;
						items.DataFields.FieldByName("LOGOID").Value = dto.LOGOID;
						items.DataFields.FieldByName("IMG2INC").Value = dto.IMG2INC;
						items.DataFields.FieldByName("INVOICE_PRNT_CNT").Value = dto.INVOICE_PRNT_CNT;
						items.DataFields.FieldByName("PARENTCLCODE").Value = "120.01";
						items.DataFields.FieldByName("PURCHBRWS").Value = dto.PURCHBRWS;
						items.DataFields.FieldByName("SALESBRWS").Value = dto.SALESBRWS;
						items.DataFields.FieldByName("IMPBRWS").Value = dto.IMPBRWS;
						items.DataFields.FieldByName("EXPBRWS").Value = dto.EXPBRWS;
						items.DataFields.FieldByName("FINBRWS").Value = dto.FINBRWS;
						items.DataFields.FieldByName("COLLATRLRISK_TYPE").Value = dto.COLLATRLRISK_TYPE;
						items.DataFields.FieldByName("ACCEPT_EINV").Value = dto.ACCEPT_EINV;
						items.DataFields.FieldByName("PROFILE_ID").Value = dto.PROFILE_ID;
						items.DataFields.FieldByName("EARCHIVE_SEND_MODE").Value = dto.EARCHIVE_SEND_MODE;
						items.DataFields.FieldByName("TITLE2").Value = dto.TITLE2;
						items.DataFields.FieldByName("POST_LABEL").Value = dto.POST_LABEL;
						items.DataFields.FieldByName("SENDER_LABEL").Value = dto.SENDER_LABEL;
						items.DataFields.FieldByName("ACCEPT_DESP").Value = dto.ACCEPT_DESP;
						items.DataFields.FieldByName("PROFILEID_DESP").Value = dto.PROFILEID_DESP;
						items.DataFields.FieldByName("POST_LABEL_CODE_DESP").Value = dto.POST_LABEL_CODE_DESP;
						items.DataFields.FieldByName("SENDER_LABEL_CODE_DESP").Value = dto.SENDER_LABEL_CODE_DESP;
						items.DataFields.FieldByName("DISP_PRINT_CNT").Value = dto.DISP_PRINT_CNT;
						items.DataFields.FieldByName("ORD_PRINT_CNT").Value = dto.ORD_PRINT_CNT;
						items.DataFields.FieldByName("GUID").Value = dto.GUID.ToString();
						if (items.Post())
						{
							var referenceId = Convert.ToInt32(items.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());
 

							result.Data = null;
							result.IsSuccess = true;
							result.Message = "Success";
							_logger.LogInformation($"Current Inserted :{referenceId}");
							//_eventBus.Publish(new SYSMessageIntegrationEvent(referenceId, result.IsSuccess, result.Message, new Guid(dto.EmployeeOid), dto));
							//_eventBus.Publish(new LOGOSuccessIntegrationEvent(referenceId, result.Message, new Guid(dto.EmployeeOid), dto));
						}
						else
						{
							result.IsSuccess = false;
							result.Message = new ErrorHelper().GetError(items);
							//_eventBus.Publish(new SYSMessageIntegrationEvent(null, result.IsSuccess, result.Message, new Guid(dto.EmployeeOid), dto));
							//_eventBus.Publish(new LOGOFailureIntegrationEvent(null, result.Message, new Guid(dto.EmployeeOid), dto));
						}
					}
					catch (Exception ex)
					{
						_logger.LogError(ex, ex.Message);
						result = new DataResult<LG_Current>
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

					result = new DataResult<LG_Current>
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
