using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels
{
    public partial class CustomerListViewModel : BaseViewModel
    {
		IHttpClientService _httpClientService;
		ICustomerService<Customer> _customerService;
        

        public CustomerListViewModel(IHttpClientService httpClientService,ICustomerService<Customer> customerService)
        {
            _httpClientService = httpClientService;
            _customerService = customerService;
            var httpClient = _httpClientService.GetOrCreateHttpClient();
            _customerService.GetObjects(httpClient);

        }

    }
}
