using DevExpress.ExpressApp;
using DevExpress.ExpressApp.AspNetCore;
using DevExpress.ExpressApp.AspNetCore.WebApi;
using DevExpress.Persistent.BaseImpl;

namespace Helix.IdentityServer.WebApi.Services;

public class WebApiApplicationSetup : IWebApiApplicationSetup
{
	public void SetupApplication(AspNetCoreApplication application)
	{
		application.Modules.Add(new UI.Sys.Module.SysModule());

#if DEBUG
		if (System.Diagnostics.Debugger.IsAttached)
		{
			application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
		}
#endif
		//application.DatabaseVersionMismatch += (s, e) => {
		//    e.Updater.Update();
		//    e.Handled = true;
		//};
	}
}
