using CommunityToolkit.Maui.Views;
using Helix.UI.Mobile.Helpers.MessageHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;
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
			PossibleFormats = {BarcodeFormat.QR_CODE, BarcodeFormat.CODE_39, BarcodeFormat.CODE_128, BarcodeFormat.EAN_8, BarcodeFormat.CODE_39},
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
			WarehouseTransferOperationViewModel viewModel = _serviceProvider.GetService<WarehouseTransferOperationViewModel>();
			var product = viewModel.Items.Where(x => x.ProductCode == args.Result[0].Text).FirstOrDefault();
			if(product != null)
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
		});
	}
}