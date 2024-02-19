using CommunityToolkit.Maui.Views;
using Helix.UI.Mobile.Helpers.MessageHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.OutCountingTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ProductionTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WastageTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.PurchaseDispatchViewModels;
using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnPurchaseViewModels;
using Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnSalesViewModels;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Purchases.ReturnPurchaseViews;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;
using System.Diagnostics;
using ZXing;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class BarcodePageView : ContentPage
{
	BarcodePageViewModel _viewModel;
	IServiceProvider _serviceProvider;
	public BarcodePageView(BarcodePageViewModel viewModel, IServiceProvider serviceProvider)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
		_serviceProvider = serviceProvider;

		cameraView.BarCodeOptions = new()
		{
			PossibleFormats = {BarcodeFormat.QR_CODE, BarcodeFormat.CODE_39, BarcodeFormat.CODE_128, BarcodeFormat.EAN_8},
			AutoRotate = true,
		};
	}

	public void CameraView_CamerasLoaded(object sender, EventArgs e)
	{
		if(cameraView.Cameras.Count > 0)
		{
			cameraView.Camera = cameraView.Cameras.First();
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				//Task.Delay(500);
				await cameraView.StopCameraAsync();
				await cameraView.StartCameraAsync();

			});
		}
	}

	public void CameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
	{
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			CancellationTokenSource cancellationToken = new();

			#region WarehouseTransferOperationView
			if (_viewModel.CurrentPage == "WarehouseTransferOperationView")
			{
				WarehouseTransferOperationViewModel viewModel = _serviceProvider.GetService<WarehouseTransferOperationViewModel>();
				var product = viewModel.Items.Where(x => x.ProductCode == args.Result[0].Text).FirstOrDefault();
				if (product != null)
				{
					product.IsSelected = true;
					viewModel.SelectedItems.Add(product);
					//Debug.WriteLine(args.Result[0].BarcodeFormat);
					Debug.WriteLine(args.Result[0].Text);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					Debug.WriteLine(args.Result[0].Text);
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region PurchaseDispatchListView
			else if (_viewModel.CurrentPage == "PurchaseDispatchListView")
			{
				PurchaseDispatchListViewModel viewModel = _serviceProvider.GetService<PurchaseDispatchListViewModel>();
				var product = viewModel.Items.Where(x => x.Code == args.Result[0].Text).FirstOrDefault();
				if (product != null)
				{
					//product.IsSelected = true;
					viewModel.Items.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					Debug.WriteLine(args.Result[0].Text);
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region SalesDispatchListView
			else if (_viewModel.CurrentPage == "SalesDispatchListView")
			{
				SalesDispatchListViewModel viewModel = _serviceProvider.GetService<SalesDispatchListViewModel>();
				var product = viewModel.Items.Where(x => x.Code == args.Result[0].Text).FirstOrDefault();
				if (product != null)
				{
					//product.IsSelected = true;
					viewModel.Items.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					Debug.WriteLine(args.Result[0].Text);
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region InCountingTransactionOperationView
			else if (_viewModel.CurrentPage == "InCountingTransactionOperationView")
			{
				InCountingTransactionOperationViewModel viewModel = _serviceProvider.GetService<InCountingTransactionOperationViewModel>();
				var product = viewModel.Items.Where(x => x.Code == args.Result[0].Text).FirstOrDefault();
				if (product != null)
				{
					//product.IsSelected = true;
					viewModel.Items.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region ConsumableTransactionOperationView
			else if (_viewModel.CurrentPage == "ConsumableTransactionOperationView")
			{
				ConsumableTransactionOperationViewModel viewModel = _serviceProvider.GetService<ConsumableTransactionOperationViewModel>();
				var product = viewModel.Items.Where(x => x.Code == args.Result[0].Text).FirstOrDefault();
				if (product != null)
				{
					//product.IsSelected = true;
					viewModel.Items.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region WastageTransactionOperationView
			else if (_viewModel.CurrentPage == "WastageTransactionOperationView")
			{
				WastageTransactionOperationViewModel viewModel = _serviceProvider.GetService<WastageTransactionOperationViewModel>();
				var product = viewModel.Items.Where(x => x.Code == args.Result[0].Text).FirstOrDefault();
				if (product != null)
				{
					//product.IsSelected = true;
					viewModel.Items.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region OutCountingTransactionOperationView
			else if (_viewModel.CurrentPage == "OutCountingTransactionOperationView")
			{
				OutCountingTransactionOperationViewModel viewModel = _serviceProvider.GetService<OutCountingTransactionOperationViewModel>();
				var product = viewModel.Items.Where(x => x.Code == args.Result[0].Text).FirstOrDefault();
				if (product != null)
				{
					//product.IsSelected = true;
					viewModel.Items.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region ProductionTransactionOperationView
			else if(_viewModel.CurrentPage == "ProductionTransactionOperationView")
			{
				ProductionTransactionOperationViewModel viewModel = _serviceProvider.GetService<ProductionTransactionOperationViewModel>();
				var product = viewModel.Results.Where( x => x.Code == args.Result[0].Text).FirstOrDefault();
				if(product != null)
				{
					//product.IsSelected = true;
					viewModel.Results.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region ReturnSalesListView
			else if(_viewModel.CurrentPage == "ReturnSalesListView")
			{
				ReturnSalesListViewModel viewModel = _serviceProvider.GetService<ReturnSalesListViewModel>();
				var product = viewModel.Items.Where(x => x.Code == args.Result[0].Text).FirstOrDefault();
				if(product != null)
				{
					//product.IsSelected = true;
					viewModel.Items.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region ReturnPurchaseListView
			else if (_viewModel.CurrentPage == "ReturnPurchaseListView")
			{
				ReturnPurchaseListViewModel viewModel = _serviceProvider.GetService<ReturnPurchaseListViewModel>();
				var product = viewModel.Items.Where(x => x.Code == args.Result[0].Text).FirstOrDefault();
				if (product != null)
				{
					//product.IsSelected = true;
					viewModel.Items.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region WarehouseCountingListView
			else if(_viewModel.CurrentPage == "WarehouseCountingListView")
			{
				WarehouseCountingListViewModel viewModel = _serviceProvider.GetService<WarehouseCountingListViewModel>();
				var product = viewModel.Results.Where(x => x.ProductCode == args.Result[0].Text).FirstOrDefault();
				if(product != null)
				{
					//product.IsSelected = true;
					viewModel.Results.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region WarehouseTransferOperationSelectedItemsListView
			else if(_viewModel.CurrentPage == "WarehouseTransferOperationSelectedItemsListView")
			{
				WarehouseTransferOperationSelectedItemsListViewModel viewModel = _serviceProvider.GetService<WarehouseTransferOperationSelectedItemsListViewModel>();
				var product = viewModel.Result.Where(x => x.ProductCode == args.Result[0].Text).FirstOrDefault();
				if(product != null && !viewModel.Result.Contains(product))
				{
					if(viewModel.Result.Contains(product))
						await new MessageHelper().GetToastMessage("Ürün malzeme listesinde yer almaktadýr").Show(cancellationToken.Token);

					viewModel.Result.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion

		});
	}
}