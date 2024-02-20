using CommunityToolkit.Maui.Views;
using Helix.UI.Mobile.Helpers.MappingHelper;
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
using ZXing.Net.Maui;

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

		cameraBarcodeReaderView.Options = new BarcodeReaderOptions
		{
			Formats = BarcodeFormats.All,
			TryHarder = false,
			AutoRotate = true,
			Multiple = false
		};
	}

	//public void CameraBarcodeReaderViewMethod()
	//{
	//	cameraBarcodeReaderView.Options = new BarcodeReaderOptions
	//	{
	//		Formats = BarcodeFormats.All,
	//		AutoRotate = true,
	//		Multiple = false
	//	};
	//}

	private void cameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
		
		//e.Results.Value
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			CancellationTokenSource cancellationToken = new();
			var first = e.Results?.FirstOrDefault();

			#region WarehouseTransferOperationView -- not completed
			if (_viewModel.CurrentPage == "WarehouseTransferOperationView")
			{
				WarehouseTransferOperationViewModel viewModel = _serviceProvider.GetService<WarehouseTransferOperationViewModel>();
				var product = viewModel.Items.Where(x => x.ProductCode == first.Value).FirstOrDefault();
				if (product != null)
				{
					product.IsSelected = true;
					viewModel.SelectedItems.Add(product);
					await Task.Delay(500);
					await Shell.Current.GoToAsync("..");
				}
				else
				{
					Debug.WriteLine(first.Value);
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region PurchaseDispatchListView
			else if (_viewModel.CurrentPage == "PurchaseDispatchListView")
			{
				PurchaseDispatchListViewModel viewModel = _serviceProvider.GetService<PurchaseDispatchListViewModel>();
				SharedProductListViewModel sharedViewModel = _serviceProvider.GetService<SharedProductListViewModel>();

				var product = sharedViewModel.Results.Where(x => x.ProductCode == first.Value).FirstOrDefault();
				if (product != null)
				{
					if (viewModel.Items.Any(x => x.Code == product.ProductCode))
					{
						await new MessageHelper().GetToastMessage("Taratýlan ürün listede bulunmaktadýr").Show(cancellationToken.Token);
					}
					else
					{
						var obj = Mapping.Mapper.Map<ProductModel>(product);
						obj.ReferenceId = product.ProductReferenceId;
						obj.Code = product.ProductCode;
						obj.Name = product.ProductName;
						obj.Image = product.Image;
						obj.UnitsetReferenceId = product.UnitsetReferenceId;
						obj.SubUnitsetReferenceId = product.SubUnitsetReferenceId;
						obj.StockQuantity = product.OnHand;
						obj.Quantity = 1;
						viewModel.Items.Add(obj);
						await Task.Delay(500);
						await Shell.Current.GoToAsync("..");
					}
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region SalesDispatchListView
			else if (_viewModel.CurrentPage == "SalesDispatchListView")
			{
				SalesDispatchListViewModel viewModel = _serviceProvider.GetService<SalesDispatchListViewModel>();
				SharedProductListViewModel sharedViewModel = _serviceProvider.GetService<SharedProductListViewModel>();

				var product = sharedViewModel.Results.Where(x => x.ProductCode == first.Value).FirstOrDefault();
				if (product != null)
				{
					if (viewModel.Results.Any(x => x.Code == product.ProductCode))
					{
						await new MessageHelper().GetToastMessage("Taratýlan ürün listede bulunmaktadýr").Show(cancellationToken.Token);
					}
					else
					{
						var obj = Mapping.Mapper.Map<ProductModel>(product);
						obj.ReferenceId = product.ProductReferenceId;
						obj.Code = product.ProductCode;
						obj.Name = product.ProductName;
						obj.Image = product.Image;
						obj.UnitsetReferenceId = product.UnitsetReferenceId;
						obj.SubUnitsetReferenceId = product.SubUnitsetReferenceId;
						obj.StockQuantity = product.OnHand;
						obj.Quantity = 1;
						viewModel.Results.Add(obj);
						await Task.Delay(500);
						await Shell.Current.GoToAsync("..");
					}
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region InCountingTransactionOperationView
			else if (_viewModel.CurrentPage == "InCountingTransactionOperationView")
			{
				InCountingTransactionOperationViewModel viewModel = _serviceProvider.GetService<InCountingTransactionOperationViewModel>();
				SharedProductListViewModel sharedViewModel = _serviceProvider.GetService<SharedProductListViewModel>();

				var product = sharedViewModel.Results.Where(x => x.ProductCode == first.Value).FirstOrDefault();
				if (product != null)
				{
					if (viewModel.Items.Any(x => x.Code == product.ProductCode)){
						await new MessageHelper().GetToastMessage("Taratýlan ürün listede bulunmaktadýr").Show(cancellationToken.Token);
					}
					else
					{
						var obj = Mapping.Mapper.Map<ProductModel>(product);
						obj.ReferenceId = product.ProductReferenceId;
						obj.Code = product.ProductCode;
						obj.Name = product.ProductName;
						obj.Image = product.Image;
						obj.UnitsetReferenceId = product.UnitsetReferenceId;
						obj.SubUnitsetReferenceId = product.SubUnitsetReferenceId;
						obj.StockQuantity = product.OnHand;
						obj.Quantity = 1;
						//obj.LastTransactionDate = product.TransactionDate;
						viewModel.Items.Add(obj);
						await Task.Delay(500);
						await Shell.Current.GoToAsync("..");
					}
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
				SharedProductListViewModel sharedViewModel = _serviceProvider.GetService<SharedProductListViewModel>();

				var product = sharedViewModel.Results.Where(x => x.ProductCode == first.Value).FirstOrDefault();
				if (product != null)
				{
					if (viewModel.Items.Any(x => x.Code == product.ProductCode))
					{
						await new MessageHelper().GetToastMessage("Taratýlan ürün listede bulunmaktadýr").Show(cancellationToken.Token);
					}
					else
					{
						var obj = Mapping.Mapper.Map<ProductModel>(product);
						obj.ReferenceId = product.ProductReferenceId;
						obj.Code = product.ProductCode;
						obj.Name = product.ProductName;
						obj.Image = product.Image;
						obj.UnitsetReferenceId = product.UnitsetReferenceId;
						obj.SubUnitsetReferenceId = product.SubUnitsetReferenceId;
						obj.StockQuantity = product.OnHand;
						obj.Quantity = 1;
						viewModel.Items.Add(obj);
						await Task.Delay(500);
						await Shell.Current.GoToAsync("..");
					}
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
				SharedProductListViewModel sharedViewModel = _serviceProvider.GetService<SharedProductListViewModel>();

				var product = sharedViewModel.Results.Where(x => x.ProductCode == first.Value).FirstOrDefault();
				if (product != null)
				{
					if (viewModel.Items.Any(x => x.Code == product.ProductCode))
					{
						await new MessageHelper().GetToastMessage("Taratýlan ürün listede bulunmaktadýr").Show(cancellationToken.Token);
					}
					else
					{
						var obj = Mapping.Mapper.Map<ProductModel>(product);
						obj.ReferenceId = product.ProductReferenceId;
						obj.Code = product.ProductCode;
						obj.Name = product.ProductName;
						obj.Image = product.Image;
						obj.UnitsetReferenceId = product.UnitsetReferenceId;
						obj.SubUnitsetReferenceId = product.SubUnitsetReferenceId;
						obj.StockQuantity = product.OnHand;
						obj.Quantity = 1;
						viewModel.Items.Add(obj);
						await Task.Delay(500);
						await Shell.Current.GoToAsync("..");
					}
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
				SharedProductListViewModel sharedViewModel = _serviceProvider.GetService<SharedProductListViewModel>();

				var product = sharedViewModel.Results.Where(x => x.ProductCode == first.Value).FirstOrDefault();
				if (product != null)
				{
					if (viewModel.Items.Any(x => x.Code == product.ProductCode))
					{
						await new MessageHelper().GetToastMessage("Taratýlan ürün listede bulunmaktadýr").Show(cancellationToken.Token);
					}
					else
					{
						var obj = Mapping.Mapper.Map<ProductModel>(product);
						obj.ReferenceId = product.ProductReferenceId;
						obj.Code = product.ProductCode;
						obj.Name = product.ProductName;
						obj.Image = product.Image;
						obj.UnitsetReferenceId = product.UnitsetReferenceId;
						obj.SubUnitsetReferenceId = product.SubUnitsetReferenceId;
						obj.StockQuantity = product.OnHand;
						obj.Quantity = 1;
						viewModel.Items.Add(obj);
						await Task.Delay(500);
						await Shell.Current.GoToAsync("..");
					}
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region ProductionTransactionOperationView
			else if (_viewModel.CurrentPage == "ProductionTransactionOperationView")
			{
				ProductionTransactionOperationViewModel viewModel = _serviceProvider.GetService<ProductionTransactionOperationViewModel>();
				SharedProductListViewModel sharedViewModel = _serviceProvider.GetService<SharedProductListViewModel>();

				var product = sharedViewModel.Results.Where(x => x.ProductCode == first.Value).FirstOrDefault();
				if (product != null)
				{
					if(viewModel.Results.Any(x => x.Code == product.ProductCode))
					{
						await new MessageHelper().GetToastMessage("Taratýlan ürün listede bulunmaktadýr").Show(cancellationToken.Token);
					}
					else
					{
						var obj = Mapping.Mapper.Map<ProductModel>(product);
						obj.ReferenceId = product.ProductReferenceId;
						obj.Code = product.ProductCode;
						obj.Name = product.ProductName;
						obj.Image = product.Image;
						obj.UnitsetReferenceId = product.UnitsetReferenceId;
						obj.SubUnitsetReferenceId = product.SubUnitsetReferenceId;
						obj.StockQuantity = product.OnHand;
						obj.Quantity = 1;
						viewModel.Results.Add(obj);
						await Task.Delay(500);
						await Shell.Current.GoToAsync("..");
					}
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region ReturnSalesListView
			else if (_viewModel.CurrentPage == "ReturnSalesListView")
			{
				ReturnSalesListViewModel viewModel = _serviceProvider.GetService<ReturnSalesListViewModel>();
				SharedProductListViewModel sharedViewModel = _serviceProvider.GetService<SharedProductListViewModel>();

				var product = sharedViewModel.Results.Where(x => x.ProductCode == first.Value).FirstOrDefault();
				if (product != null)
				{
					if (viewModel.Items.Any(x => x.Code == product.ProductCode))
					{
						await new MessageHelper().GetToastMessage("Taratýlan ürün listede bulunmaktadýr").Show(cancellationToken.Token);
					}
					else
					{
						var obj = Mapping.Mapper.Map<ProductModel>(product);
						obj.ReferenceId = product.ProductReferenceId;
						obj.Code = product.ProductCode;
						obj.Name = product.ProductName;
						obj.Image = product.Image;
						obj.UnitsetReferenceId = product.UnitsetReferenceId;
						obj.SubUnitsetReferenceId = product.SubUnitsetReferenceId;
						obj.StockQuantity = product.OnHand;
						obj.Quantity = 1;
						viewModel.Items.Add(obj);
						await Task.Delay(500);
						await Shell.Current.GoToAsync("..");
					}
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
				SharedProductListViewModel sharedViewModel = _serviceProvider.GetService<SharedProductListViewModel>();

				var product = sharedViewModel.Results.Where(x => x.ProductCode == first.Value).FirstOrDefault();
				if (product != null)
				{
					if (viewModel.Items.Any(x => x.Code == product.ProductCode))
					{
						await new MessageHelper().GetToastMessage("Taratýlan ürün listede bulunmaktadýr").Show(cancellationToken.Token);
					}
					else
					{
						var obj = Mapping.Mapper.Map<ProductModel>(product);
						obj.ReferenceId = product.ProductReferenceId;
						obj.Code = product.ProductCode;
						obj.Name = product.ProductName;
						obj.Image = product.Image;
						obj.UnitsetReferenceId = product.UnitsetReferenceId;
						obj.SubUnitsetReferenceId = product.SubUnitsetReferenceId;
						obj.StockQuantity = product.OnHand;
						obj.Quantity = 1;
						viewModel.Items.Add(obj);
						await Task.Delay(500);
						await Shell.Current.GoToAsync("..");
					}
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region WarehouseCountingListView
			else if (_viewModel.CurrentPage == "WarehouseCountingListView")
			{
				WarehouseCountingListViewModel viewModel = _serviceProvider.GetService<WarehouseCountingListViewModel>();
				WarehouseCountingSelectProductsViewModel selectProductsViewModel = _serviceProvider.GetService<WarehouseCountingSelectProductsViewModel>();

				var product = selectProductsViewModel.Items.Where(x => x.Code == first.Value).FirstOrDefault();
				if (product != null)
				{
					if (viewModel.Results.Any(x => x.ProductCode == product.Code))
					{
						await new MessageHelper().GetToastMessage("Taratýlan ürün listede bulunmaktadýr").Show(cancellationToken.Token);
					}
					else
					{
						var obj = Mapping.Mapper.Map<WarehouseTotal>(product);
						obj.ProductReferenceId = product.ReferenceId;
						obj.ProductCode = product.Code;
						obj.ProductName = product.Name;
						obj.Image = product.Image;
						obj.UnitsetReferenceId = product.ReferenceId;
						obj.SubUnitsetReferenceId = product.SubUnitsetReferenceId;
						obj.OnHand = product.StockQuantity;
						obj.TempOnhand = product.StockQuantity;
						obj.QuantityCounter = (int)product.StockQuantity;
						viewModel.Items.Add(obj);
						viewModel.Results.Add(obj);
						await Task.Delay(500);
						await Shell.Current.GoToAsync("..");
					}
				}
				else
				{
					await new MessageHelper().GetToastMessage("Ürün Bulunamadý").Show(cancellationToken.Token);
				}
			}
			#endregion
			#region WarehouseTransferOperationSelectedItemsListView -- not completed
			else if (_viewModel.CurrentPage == "WarehouseTransferOperationSelectedItemsListView")
			{
				WarehouseTransferOperationSelectedItemsListViewModel viewModel = _serviceProvider.GetService<WarehouseTransferOperationSelectedItemsListViewModel>();
				var product = viewModel.Result.Where(x => x.ProductCode == first.Value).FirstOrDefault();
				if (product != null && !viewModel.Result.Contains(product))
				{
					if (viewModel.Result.Contains(product))
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