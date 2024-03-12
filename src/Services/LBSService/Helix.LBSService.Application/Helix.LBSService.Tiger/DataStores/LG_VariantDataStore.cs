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
    public class LG_VariantDataStore
    {
        IUnityApplicationService _unityApplicationService;
        IEventBus _eventBus;
        ILogger<LG_VariantDataStore> _logger;
        public LG_VariantDataStore(ILogger<LG_VariantDataStore> logger, IUnityApplicationService unityApplicationService, IEventBus eventBus)
        {
            _unityApplicationService = unityApplicationService;
            _eventBus = eventBus;
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
                        //variant.DataFields.FieldByName("INTERNAL_REFERENCE").Value = 1203451;
                        //variant.DataFields.FieldByName("CARDTYPE").Value = 12;
                        //variant.DataFields.FieldByName("CODE").Value = 00005190;
                        //variant.DataFields.FieldByName("NAME").Value = BEYAZ.BEYAZ.;
                        //variant.DataFields.FieldByName("CYPHCODE").Value = IBR;
                        //variant.DataFields.FieldByName("UNITSETCODE").Value = ADET;
                        //variant.DataFields.FieldByName("DATA_REFERENCE").Value = 1203451;
                        //variant.DataFields.FieldByName("CAPIBLOCK_CREATEDBY").Value = 1;
                        //variant.DataFields.FieldByName("CAPIBLOCK_CREADEDDATE").Value = 06.03.2024;
                        //variant.DataFields.FieldByName("CAPIBLOCK_CREATEDHOUR").Value = 9;
                        //variant.DataFields.FieldByName("CAPIBLOCK_CREATEDMIN").Value = 12;
                        //variant.DataFields.FieldByName("CAPIBLOCK_CREATEDSEC").Value = 43;

                        //if (items.Post())
                        //{
                        //    var referenceId = Convert.ToInt32(items.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());


                        //    result.Data = null;
                        //    result.IsSuccess = true;
                        //    result.Message = "Success";
                        //    _logger.LogInformation($"Variant Inserted :{referenceId}");
                        //    //_eventBus.Publish(new SYSMessageIntegrationEvent(referenceId, result.IsSuccess, result.Message, new Guid(dto.EmployeeOid), dto));
                        //    //_eventBus.Publish(new LOGOSuccessIntegrationEvent(referenceId, result.Message, new Guid(dto.EmployeeOid), dto));
                        //}
                        //else
                        //{
                        //    result.IsSuccess = false;
                        //    result.Message = new ErrorHelper().GetError(items);
                        //    //_eventBus.Publish(new SYSMessageIntegrationEvent(null, result.IsSuccess, result.Message, new Guid(dto.EmployeeOid), dto));
                        //    //_eventBus.Publish(new LOGOFailureIntegrationEvent(null, result.Message, new Guid(dto.EmployeeOid), dto));
                        //}
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
