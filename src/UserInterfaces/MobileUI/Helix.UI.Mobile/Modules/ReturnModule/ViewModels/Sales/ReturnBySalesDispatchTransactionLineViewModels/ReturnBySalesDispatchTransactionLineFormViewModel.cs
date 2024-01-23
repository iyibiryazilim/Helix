using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionLineViewModels
{
    public partial class ReturnBySalesDispatchTransactionLineFormViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        ISpeCodeService _speCodeService;

        [ObservableProperty]
        string searchText = string.Empty;

        [ObservableProperty]
        int currentPage = 0;
        [ObservableProperty]
        int pageSize = 20;

        [ObservableProperty]
        string speCode = string.Empty;

        public ObservableCollection<SpeCodeModel> SpeCodeModelItems { get; } = new();

        public ReturnBySalesDispatchTransactionLineFormViewModel(IHttpClientService httpClientService, ISpeCodeService speCodeService)
        {
            Title = "Satın Alma Form";
            _httpClientService = httpClientService;

            _speCodeService = speCodeService;

        }

        [RelayCommand]
        public async Task GetSpeCodeAsync()
        {
            string action;

            try
            {
                var httpClient = _httpClientService.GetOrCreateHttpClient();
                CurrentPage = 0;
                var result = await _speCodeService.GetObjects(httpClient);

                if (result.Data.Any())
                {
                    SpeCodeModelItems.Clear();

                    foreach (var item in result.Data)
                    {
                        SpeCodeModelItems.Add(item);
                    }

                    List<string> speCodeStrings = SpeCodeModelItems.Select(code => code.SpeCode).ToList();

                    action = await Shell.Current.DisplayActionSheet("Özel Kod:", "Vazgeç", null, speCodeStrings.ToArray());

                    SpeCode = action;


                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;

            }
        }
    }
}
