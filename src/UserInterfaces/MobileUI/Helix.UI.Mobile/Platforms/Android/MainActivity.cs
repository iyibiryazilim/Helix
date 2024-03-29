﻿using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace Helix.UI.Mobile
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Android.Views.View decorView = Window.DecorView;
            decorView.SystemUiVisibility = (StatusBarVisibility)(
                SystemUiFlags.HideNavigation |
                SystemUiFlags.Fullscreen |
                SystemUiFlags.ImmersiveSticky);

            const int requestNotification = 0;
            string[] notiPermission =
              {
      Manifest.Permission.PostNotifications
};

            if ((int)Build.VERSION.SdkInt < 33) return;
            if (CheckSelfPermission(Manifest.Permission.PostNotifications) != Permission.Granted)
            {
                RequestPermissions(notiPermission, requestNotification);
            }
        }
    }
}
