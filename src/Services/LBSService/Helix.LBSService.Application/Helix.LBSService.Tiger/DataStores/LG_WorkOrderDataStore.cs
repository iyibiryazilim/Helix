﻿using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Helper;
using Helix.LBSService.Tiger.Models.BaseModel;
using Helix.LBSService.Tiger.Services;
using UnityObjects;

namespace Helix.LBSService.Tiger.DataStores
{
	public class LG_WorkOrderDataStore : ILG_WorkOrderService
	{
		IUnityApplicationService _unityApplicationService;
		public LG_WorkOrderDataStore(IUnityApplicationService unityApplicationService)
		{
			_unityApplicationService = unityApplicationService;

		}
		public async Task<DataResult<WorkOrderDto>> Insert(WorkOrdersDto dtos)
		{
			var unity = Global.UnityApp;
			DataResult<WorkOrderDto> result;
			if (!unity.LoggedIn)
				await _unityApplicationService.LogIn();

			if (unity.LoggedIn)
			{
				foreach (var dto in dtos.WorkOrders)
				{
					IProductionApplication prodApp = unity.NewProductionApplication();
					FastRealizeSlipRefLists lines = prodApp.NewSlipRefLists();

					bool isSuccess = prodApp.FastRealizeFicheGenerateForWOrder(dto.WorkOrderReferenceId, dto.ProductReferenceId, dto.ActualQuantity, dto.SubUnitsetReferenceId, dto.CalculatedMethod, dto.IsIncludeSideProduct, lines);
					if (!isSuccess)
					{
						result = new DataResult<WorkOrderDto>
						{
							Data = null,
							IsSuccess = false,
							Message = prodApp.GetLastError() + "-" + prodApp.GetLastErrorString()
						};

						return result;
					}
				}
				result = new DataResult<WorkOrderDto>
				{
					Data = null,
					IsSuccess = true,
					Message = "Success"
				};
			}
			else
			{
				result = new DataResult<WorkOrderDto>
				{
					Data = null,
					IsSuccess = false,
					Message = unity.GetLastError() + "-" + unity.GetLastErrorString()
				};
			}
			return await Task.FromResult(result);
		}

		public async Task<DataResult<WorkOrderDto>> InsertStopTransaction(StopTransactionForWorkOrderDto dtos)
		{
			var unity = Global.UnityApp;
			DataResult<WorkOrderDto> result;
			ProductionApplication ProdApp = unity.NewProductionApplication();
			if (!unity.LoggedIn)
				await _unityApplicationService.LogIn();
			if (unity.LoggedIn)
			{

				object StpDate = 0;
				object StpTime = 0;
				unity.PackDate(dtos.StopDate.Day, dtos.StopDate.Month, dtos.StopDate.Year, ref StpDate);
				unity.PackTime(dtos.StopTime.Hours, dtos.StopTime.Minutes, dtos.StopTime.Seconds, ref StpTime);
				if (!(ProdApp.AddStopTransForAWOrd(dtos.WorkOrderReferenceId, dtos.StopCauseReferenceId, Convert.ToInt32(StpDate), Convert.ToInt32(StpTime), 0, 0)))
				{
					result = new DataResult<WorkOrderDto>
					{
						Data = null,
						IsSuccess = false,
						Message = ProdApp.GetLastError() + "-" + ProdApp.GetLastErrorString()
					};
				}
				else
				{
					result = new DataResult<WorkOrderDto>
					{
						Data = null,
						IsSuccess = true,
						Message = "Success"
					};
				}

			}
			else
			{
				result = new DataResult<WorkOrderDto>
				{
					Data = null,
					IsSuccess = false,
					Message = unity.GetLastError() + "-" + unity.GetLastErrorString()
				};
			}
			return await Task.FromResult(result);
		}

		public async Task<DataResult<WorkOrderDto>> InsertWorkOrderStatus(WorkOrderChangeStatusDto dtos)
		{
			var unity = Global.UnityApp;
			DataResult<WorkOrderDto> result;
			ProductionApplication ProdApp = unity.NewProductionApplication();
			if (!unity.LoggedIn)
				await _unityApplicationService.LogIn();
			if(unity.LoggedIn)
			{
				if (!ProdApp.ChangePOAndWOStatus(dtos.FicheNo, dtos.Status, 2, true, dtos.DeleteFiche))
				{
					result = new DataResult<WorkOrderDto>
					{
						Data = null,
						IsSuccess = false,
						Message = ProdApp.GetLastError() + "-" + ProdApp.GetLastErrorString()
					};

				}
				else
				{
					result = new DataResult<WorkOrderDto>
					{
						Data = null,
						IsSuccess = true,
						Message = "Success"
					};
				}
			}
			else
			{
				result = new DataResult<WorkOrderDto>
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
