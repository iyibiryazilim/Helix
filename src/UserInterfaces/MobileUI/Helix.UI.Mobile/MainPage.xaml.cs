using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;

namespace Helix.UI.Mobile
{
	public partial class MainPage : ContentPage
    {
        int count = 0;
        HttpClientService _service = new();

        public MainPage()
        {
            InitializeComponent();

		}

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";
			PurchaseDispatchTransactionDataStore dto = new();
            
            var result = await dto.GetObjects(_service.GetOrCreateHttpClient());
            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
