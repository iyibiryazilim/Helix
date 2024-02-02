using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
using System.Diagnostics;
using ZXing;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class BarcodePageView : ContentPage
{
	BarcodePageViewModel _viewModel;
	public BarcodePageView(BarcodePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;

		cameraView.BarCodeOptions = new()
		{
			PossibleFormats = {ZXing.BarcodeFormat.QR_CODE, ZXing.BarcodeFormat.CODE_39, ZXing.BarcodeFormat.CODE_128, ZXing.BarcodeFormat.EAN_8}
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

	public void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
	{
		MainThread.BeginInvokeOnMainThread(() =>
		{
			Debug.WriteLine(args.Result[0].BarcodeFormat);
			Debug.WriteLine(args.Result[0].Text);
		});
	}
}